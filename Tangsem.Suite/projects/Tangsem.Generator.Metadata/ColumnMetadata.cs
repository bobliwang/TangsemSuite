// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColumnMetadata.cs" company="TangsemTechAu">
//   LiWang@TangsemTechAu
// </copyright>
// <summary>
//   The column metadata.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Data;
using System.Linq;

using Tangsem.Common.DataAccess;
using Tangsem.Common.Extensions;
using Tangsem.Generator.Metadata.RawInfos;

namespace Tangsem.Generator.Metadata
{
  /// <summary>
  /// The column metadata.
  /// </summary>
  public class ColumnMetadata
  {
    /// <summary>
    /// Gets or sets PropertyName.
    /// </summary>
    public string PropertyName { get; set; }

    /// <summary>
    /// Gets or sets ColumnName.
    /// </summary>
    public string ColumnName { get; set; }

    /// <summary>
    /// Gets the table name.
    /// </summary>
    public string TableName
    {
      get
      {
        return this.TableMetadata.Name;
      }
    }

    
    /// <summary>
    /// Gets or sets a value indicating whether ReadOnly.
    /// </summary>
    public bool ReadOnly
    {
      get
      {
        return this.ColumnName == "RowVersion" || this.IsComputed;
      }
    }

    /// <summary>
    /// Gets or sets the table metadata.
    /// </summary>
    public TableMetadata TableMetadata { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether IsPrimaryKey.
    /// </summary>
    public bool IsPrimaryKey { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether IsAutoIncrement.
    /// </summary>
    public bool IsAutoIncrement { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether Nullable.
    /// </summary>
    public bool Nullable { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether IsAutoIncrement.
    /// </summary>
    public bool IsComputed { get; set; }

    /// <summary>
    /// Gets or sets ColumnSize.
    /// </summary>
    public int ColumnSize { get; set; }

    /// <summary>
    /// Gets or sets DataType.
    /// </summary>
    public string DataType { get; set; }

    public Type ClrType { get; set; }

    public string DefaultValueExpr { get; set; }

    public string DefaultValue
    {
      get
      {
        if (this.TableMetadata.IsReosReplicatedEntity)
        {
          if ("Replicated".Equals(this.PropertyName))
          {
            return (this.DefaultValueExpr != null && this.DefaultValueExpr.Contains("1")).ToString().ToLower();
          }
        }

        return null;
      }
    }

    public string CSharpTypeAsString
    {
      get
      {
        var provider = CodeDomProvider.CreateProvider("CSharp");
        var typeOutput = provider.GetTypeOutput(new CodeTypeReference(this.ClrType));
        
        if (this.Nullable && this.ClrType.IsValueType)
        {
          return typeOutput + "?";
        }

        return typeOutput;
      }
    }

    public string TsTypeAsString
    {
      get
      {
        if (this.IsJsonType)
        {
          return this.JsonType.EndsWith("[]") ? "any[]" : "any";
        }

        var numberTypes = new[] { typeof(int), typeof(double), typeof(decimal), typeof(float) };

        if (numberTypes.Contains(this.ClrType))
        {
          return "number";
        }

        if (typeof(string) == this.ClrType || typeof(DateTime) == this.ClrType)
        {
          return "string";
        }

        return this.ClrType.Name.Lf();
      }
    }

    /// <summary>
    /// Gets or sets DataProviderDbType.
    /// </summary>
    public Enum DataProviderDbType { get; set; }

    /// <summary>
    /// Gets or sets DbType.
    /// </summary>
    public DbType DbType
    {
      get
      {
        var mapper = new DbTypeMapper();

        if (this.DataProviderDbType is SqlDbType)
        {
          var dbType = mapper.FromSqlDbType((SqlDbType)this.DataProviderDbType);

          return dbType;
        }
        else
        {
          throw new Exception(string.Format("DataProviderDbType {0} is not supported.", this.DataProviderDbType.GetType()));
        }
      }
    }

    public ColumnMetadata FromRawColumn(RawColumn rc)
    {
      this.ColumnName = rc.ColumnName;
      this.ColumnSize = rc.ColumnSize;
      this.IsPrimaryKey = rc.IsPrimaryKey;
      this.IsAutoIncrement = rc.IsAutoIncrement;
      this.Nullable = rc.Nullable;
      this.DataType = rc.DataType;
      this.IsComputed = rc.IsComputed;
      this.DefaultValueExpr = rc.DefaultValueExpr;

      this.PropertyName = rc.ColumnName.ToPropertyName();

      return this;
    }

    public bool IsOutgoingRefKey
    {
      get
      {
        return
         this.TableMetadata.OutgoingReferences.Any(
           r => r.ColumnPairs.Any(cp => cp.ChildColumnMetadata.ColumnName == this.ColumnName)
         );
      }
    }

    public ReferenceMetadata OutgoingReference
    {
      get
      {
        return this.TableMetadata.OutgoingReferences.FirstOrDefault(
          r => r.ColumnPairs.Any(cp => cp.ChildColumnMetadata.ColumnName == this.ColumnName));
      }
    }

    public bool IsIncomingRefKey
    {
      get
      {
        return
          this.TableMetadata.IncomingReferences.Any(
            r => r.ColumnPairs.Any(cp => cp.ChildColumnMetadata.ColumnName == this.ColumnName)
          );
      }
    }

    public bool IsUnique
    {
      get
      {
        return this.TableMetadata.UniqueKeys.Any(uk => uk.Columns.Any(c => c.ColumnName == this.ColumnName));
      }
    }

    public bool IsAuditingingColumn
    {
      get
      {
        return TableMetadata.AuditingPropertyInfos.ToList().Any(x => x.Name == this.PropertyName);
      }
    }

    public ExtraColumnMeta ExtraColumnMeta { get; set; }

    public bool IsJsonType => this.ExtraColumnMeta != null && !string.IsNullOrWhiteSpace(this.ExtraColumnMeta.JsonType);


    public string JsonType => this.ExtraColumnMeta?.JsonType;
  }
}