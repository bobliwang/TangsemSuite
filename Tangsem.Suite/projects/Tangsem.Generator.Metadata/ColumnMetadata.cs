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
    public string TableName => this.TableMetadata.Name;


    /// <summary>
    /// Gets or sets a value indicating whether ReadOnly.
    /// </summary>
    public bool ReadOnly => this.IsRowVersion || this.IsComputed;

    /// <summary>
    /// TODO: add data type check.
    /// </summary>
    public bool IsRowVersion => this.ColumnName == "RowVersion" && this.ClrType == typeof(byte[]);

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
        CSharpTypeNameProvider.PrimitiveTypeNameMap.TryGetValue(this.ClrType, out var typeOutput);

        if (this.Nullable && this.ClrType.IsValueType)
        {
          return typeOutput + "?";
        }

        return typeOutput;
      }
    }

    public string NullableCSharpTypeAsString
    {
      get
      {
        CSharpTypeNameProvider.PrimitiveTypeNameMap.TryGetValue(this.ClrType, out var typeOutput);

        if (this.ClrType.IsValueType)
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

        var stringTypes = new[] { typeof(string), typeof(DateTime), typeof(Guid) };
        if (stringTypes.Contains(this.ClrType))
        {
          return "string";
        }

        return this.ClrType.Name.Lf();
      }
    }

    public bool IsJsonDataType => this.ExtraColumnMeta != null && !string.IsNullOrWhiteSpace(this.ExtraColumnMeta.JsonType);
    
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
        if (this.TableMetadata != null && this.TableMetadata.IsAuditableEntity)
        {
          return TableMetadata.AuditingPropertyInfos.ToList().Any(x => x.Name == this.PropertyName);
        }

        return false;
      }
    }

    public ExtraColumnMeta ExtraColumnMeta { get; set; }

    public string Description { get; set; }

    public bool IsJsonType => this.ExtraColumnMeta != null && !string.IsNullOrWhiteSpace(this.ExtraColumnMeta.JsonType);

    public bool IsGuidPrimaryKey => this.IsPrimaryKey && this.ClrType == typeof(Guid);

    public string JsonType => this.ExtraColumnMeta?.JsonType;
  }
}