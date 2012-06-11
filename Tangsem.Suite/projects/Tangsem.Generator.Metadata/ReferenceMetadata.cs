// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenceMetadata.cs" company="TangsemTechAu">
//   LiWang@TangsemTechAu
// </copyright>
// <summary>
//   The reference metadata.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

using Tangsem.Common.Extensions;

namespace Tangsem.Generator.Metadata
{
  /// <summary>
  /// The reference metadata.
  /// </summary>
  public class ReferenceMetadata
  {
    /// <summary>
    /// Gets or sets Name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets ColumnPairs.
    /// </summary>
    public IList<ColumnPair> ColumnPairs { get; set; }

    /// <summary>
    /// Gets the child table metadata.
    /// </summary>
    public TableMetadata ChildTableMetadata
    {
      get
      {
        return this.ColumnPairs.Any() ? this.ColumnPairs.FirstOrDefault().ChildColumnMetadata.TableMetadata : null;
      }
    }

    /// <summary>
    /// Gets the parent table metadata.
    /// </summary>
    public TableMetadata ParentTableMetadata
    {
      get
      {
        return this.ColumnPairs.Any() ? this.ColumnPairs.FirstOrDefault().ParentColumnMetadata.TableMetadata : null;
      }
    }

    /// <summary>
    /// Gets the child list field name.
    /// </summary>
    public string ChildListFieldName
    {
      get
      {
        return "_" + this.ChildListPropertyName.LowerFirst();
      }
    }

    /// <summary>
    /// Gets the child list property name.
    /// </summary>
    public string ChildListPropertyName
    {
      get
      {
        var nameSuffix = this.NameSuffix;
        var pkPropertyName = this.ParentTableMetadata.PrimaryKeyPropertyName;

        if (this.ColumnPairs.Count == 1)
        {
          if (nameSuffix == "By" + this.ParentTableMetadata.EntityName + pkPropertyName)
          {
            return this.ChildTableMetadata.EntityName.Pluralize();
          }

          if (nameSuffix == "By" + pkPropertyName)
          {
            return this.ChildTableMetadata.EntityName.Pluralize();
          }
        }

        return this.ChildTableMetadata.EntityName.Pluralize() + nameSuffix;
      }
    }

    /// <summary>
    /// Gets the parent property name.
    /// </summary>
    public string ParentPropertyName
    {
      get
      {
        var nameSuffix = this.NameSuffix;
        var pkPropertyName = this.ParentTableMetadata.PrimaryKeyPropertyName;

        if (this.ColumnPairs.Count == 1)
        {
          if (nameSuffix == "By" + this.ParentTableMetadata.EntityName + pkPropertyName)
          {
            return this.ParentTableMetadata.EntityName;
          }

          if (nameSuffix == "By" + pkPropertyName)
          {
            return this.ParentTableMetadata.EntityName;
          }

          if (nameSuffix.EndsWith(pkPropertyName))
          {
            return nameSuffix.Between("By".Length, this.NameSuffix.LastIndexOf(pkPropertyName));
          }
        }

        return this.ParentTableMetadata.EntityName + nameSuffix;
      }
    }

    /// <summary>
    /// Gets the name suffix. Sth like "ByUserId" or "ByXxxIdAndYyyId".
    /// </summary>
    public string NameSuffix
    {
      get
      {
        // sth like "UserId" or "XxxIdAndYyyId" 
        var suffix = string.Join("And", this.ColumnPairs.Select(cp => cp.ChildColumnMetadata.PropertyName));

        // sth like "ByUserId" or "ByXxxIdAndYyyId".
        return "By" + suffix;
      }
    }

    public string ChildPropertyNames
    {
      get
      {
        return string.Join("And", this.ColumnPairs.Select(cp => cp.ChildColumnMetadata.PropertyName));
      }
    }

    public string ParentPropertyNames
    {
      get
      {
        return string.Join("And", this.ColumnPairs.Select(cp => cp.ParentColumnMetadata.PropertyName));
      }
    }

    public bool IsUniqueForeignKey
    {
      get
      {
        return this.ColumnPairs.First().ChildColumnMetadata.IsUnique;
      }
    }

    public bool IsOneToOne
    {
      get
      {
        return this.IsUniqueForeignKey;
      }
    }
  }
}