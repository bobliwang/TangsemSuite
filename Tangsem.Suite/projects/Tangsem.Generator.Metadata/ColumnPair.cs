// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColumnPair.cs" company="TangsemTechAu">
//   LiWang@TangsemTechAu
// </copyright>
// <summary>
//   The column pair.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tangsem.Generator.Metadata
{
  /// <summary>
  /// The column pair.
  /// </summary>
  public class ColumnPair
  {
    /// <summary>
    /// Gets or sets SourceColumnMetadata.
    /// </summary>
    public ColumnMetadata ChildColumnMetadata { get; set; }

    /// <summary>
    /// Gets or sets TargetColumnMetadata.
    /// </summary>
    public ColumnMetadata ParentColumnMetadata { get; set; }

    public string ChildPropertyName
    {
      get
      {
        return this.ChildColumnMetadata.PropertyName;
      }
    }

    public string ParentPropertyName
    {
      get
      {
        return this.ParentColumnMetadata.PropertyName;
      }
    }
  }
}