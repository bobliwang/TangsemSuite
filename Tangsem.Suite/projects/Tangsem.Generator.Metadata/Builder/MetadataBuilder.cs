using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.Common;

using Tangsem.Common.DataAccess;
using Tangsem.Common.Extensions;
using Tangsem.Generator.Metadata.RawInfos;
using Tangsem.Generator.Metadata.TypeMapping;

namespace Tangsem.Generator.Metadata.Builder
{
  public abstract class MetadataBuilder
  {
    private ITypeMapper _typeMapper;

    protected MetadataBuilder(string connectionString)
    {
      this.CachedTableMetadata = new Dictionary<string, TableMetadata>();
      this.ConnectionString = connectionString;
      this.Cache = new RawInfoCache();
    }

    public string ConnectionString { get; set; }

    public abstract DbConnection GetDbConnection();

    public abstract string ColumnsSql { get; }

    public abstract string KeysSql { get; }

    public abstract string ReferencesSql { get; }

    public abstract string TablesSql { get; }

    public RawInfoCache Cache { get; set; }

    public IDictionary<string, TableMetadata> CachedTableMetadata { get; set; }

    public List<string> AllTableNames
    {
      get
      {
        return this.Cache.RawTables.Select(t => t.Table).ToList();
      }
    }

    public virtual ITypeMapper TypeMapper
    {
      get
      {
        return _typeMapper ?? (_typeMapper = this.CreateTypeMapper());
      }
    }

    public abstract ITypeMapper CreateTypeMapper();

    public virtual void Build()
    {
		using (var conn = this.GetDbConnection())
		{
			conn.Open();
			var db = new Database(conn);
			var tableNameParam = new Parameter("TableName", DBNull.Value, DbType.String);

			this.Cache.Clear();

			// get column metadata
			this.Cache.RawColumns.AddRange(db.ExecuteList<RawColumn>(this.ColumnsSql, tableNameParam.AsList()));
			this.Cache.RawReferences.AddRange(db.ExecuteList<RawReference>(this.ReferencesSql, tableNameParam.AsList()));
			this.Cache.RawKeys.AddRange(db.ExecuteList<RawKey>(this.KeysSql, tableNameParam.AsList()));
			this.Cache.RawTables.AddRange(db.ExecuteList<RawTable>(this.TablesSql));
		}

		foreach(var tn in this.AllTableNames)
		{
			this.GetTableMetadata(tn);
		}
    }

    public TableMetadata this[string tableName]
    {
      get
      {
        return this.GetTableMetadata(tableName);
      }
    }

    public TableMetadata GetTableMetadata(string tableName)
    {
      if (this.CachedTableMetadata.ContainsKey(tableName))
      {
        return this.CachedTableMetadata[tableName];
      }

      var tableMetadata = new TableMetadata
      {
        Name = tableName,
        EntityName = tableName.ToEntityName(),
        IsView = this.Cache.RawTables.Single(rt => rt.Table == tableName).IsView,
        Schema = this.Cache.RawTables.Single(rt => rt.Table == tableName).Schema
      };

      // put newly created table metadata into cache.
      this.CachedTableMetadata[tableName] = tableMetadata;

      // get column metadata
      var columnMetadatas = this.GetColumnMetadatas(tableName);

      // link table and column here.
      foreach (var col in columnMetadatas)
      {
        col.TableMetadata = tableMetadata;
      }
      tableMetadata.Columns = columnMetadatas;

      // References.
      tableMetadata.OutgoingReferences = this.GetOutgoingRefMetadatas(tableName, columnMetadatas);
      tableMetadata.IncomingReferences = this.GetIncomingRefMetadatas(tableName, columnMetadatas);

      // Unique Keys
      tableMetadata.Keys = this.GetUniqkKeyMetadatas(tableName, columnMetadatas);

      return tableMetadata;
    }

    private List<ColumnMetadata> GetColumnMetadatas(string tableName)
    {
      return this.Cache.RawColumns.Where(c => c.TableName == tableName).Select(
        rc =>
        {
          var colMeta = new ColumnMetadata().FromRawColumn(rc);
          colMeta.ClrType = this.TypeMapper[rc.DataType];

          return colMeta;
        }
        ).ToList();
    }

    private List<ReferenceMetadata> GetOutgoingRefMetadatas(string tableName, IEnumerable<ColumnMetadata> columnMetadatas)
    {
      var rawReferences = this.Cache.RawReferences
                              .Where(r => r.ChildTable == tableName)
                              .OrderBy(r => r.ReferenceName).ToList();

      var refGrps = rawReferences.GroupBy(r => r.ReferenceName);

      return refGrps.Select(
        grp =>
        {
          var refMetadata = this.FindReferenceMetadataInCachedTableMetadata(grp.Key);
          if (refMetadata != null)
          {
            return refMetadata;
          }

          // get parent table metadata.
          var pkTableMetadata = this.GetTableMetadata(grp.First().ParentTable);

          // create a reference metadata
          refMetadata = new ReferenceMetadata { Name = grp.Key };

          // assign column pairs.
          refMetadata.ColumnPairs =
            grp.Select(
              r =>
              new ColumnPair
                {
                  ParentColumnMetadata = pkTableMetadata[r.ParentColumn],
                  ChildColumnMetadata = columnMetadatas.Single(c => c.ColumnName == r.ChildColumn)
                }).ToList();

          return refMetadata;
        }
      ).ToList();
    }

    private List<ReferenceMetadata> GetIncomingRefMetadatas(string tableName, IEnumerable<ColumnMetadata> columnMetadatas)
    {
      var rawReferences = this.Cache.RawReferences
                              .Where(r => r.ParentTable == tableName)
                              .OrderBy(r => r.ReferenceName).ToList();

      var refGrps = rawReferences.GroupBy(r => r.ReferenceName);

      return refGrps.Select(
        grp =>
        {
          var refMetadata = this.FindReferenceMetadataInCachedTableMetadata(grp.Key);
          if (refMetadata != null)
          {
            return refMetadata;
          }

          // get child table metadata.
          var childTableMetadata = this.GetTableMetadata(grp.First().ChildTable);

          // create a reference metadata
          refMetadata = new ReferenceMetadata { Name = grp.Key };

          // assign column pairs.
          refMetadata.ColumnPairs =
            grp.Select(
              r =>
              new ColumnPair
              {
                ParentColumnMetadata = columnMetadatas.Single(c => c.ColumnName == r.ParentColumn),
                ChildColumnMetadata = childTableMetadata[r.ChildColumn]
              }).ToList();

          return refMetadata;
        }
      ).ToList();
    }

    private List<UniqueKeyMetadata> GetUniqkKeyMetadatas(string tableName, IEnumerable<ColumnMetadata> columnMetadatas)
    {
      var rawUniqueKeys = this.Cache.RawKeys.Where(uk => uk.Table == tableName)
                                    .OrderBy(uk => uk.KeyName)
                                    .ToList();

      var ukGrps = rawUniqueKeys.GroupBy(uk => uk.KeyName);

      return ukGrps.Select(
        grp =>
        new UniqueKeyMetadata
          {
            Name = grp.Key,
            Columns = columnMetadatas.Where(c => grp.Any(rk => rk.Column == c.ColumnName)).ToList()
          }
        ).ToList();
    }

    private ReferenceMetadata FindReferenceMetadataInCachedTableMetadata(string referenceName)
    {
      foreach (var tblMetadata in this.CachedTableMetadata.Values)
      {
        var found = tblMetadata.IncomingReferences
                              .Union(tblMetadata.OutgoingReferences)
                              .SingleOrDefault(r => r.Name == referenceName);
        if (found != null)
        {
          return found;
        }
      }

      return null;
    }
  }
}
