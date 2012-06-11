using System;
using System.Linq;
using System.Collections.Generic;
using Tangsem.Common.DataAccess;

namespace Tangsem.Generator.Metadata.RawInfos
{
  public class RawColumn
  {
    /// <summary>
    /// Gets or sets ColumnName.
    /// </summary>
    [PropertyColumn("Column")]
    public string ColumnName { get; set; }

    [PropertyColumn("Table")]
    public string TableName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether IsPrimaryKey.
    /// </summary>
    [PropertyColumn("IsPrimaryKey")]
    public bool IsPrimaryKey { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether IsAutoIncrement.
    /// </summary>
    [PropertyColumn("IsAutoIncrement")]
    public bool IsAutoIncrement { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether Nullable.
    /// </summary>
    [PropertyColumn("Nullable")]
    public bool Nullable { get; set; }

    /// <summary>
    /// Gets or sets ColumnSize.
    /// </summary>
    [PropertyColumn("ColumnSize")]
    public int ColumnSize { get; set; }

    /// <summary>
    /// Gets or sets DataType.
    /// </summary>
    [PropertyColumn("DataType")]
    public string DataType { get; set; }
  }
}
