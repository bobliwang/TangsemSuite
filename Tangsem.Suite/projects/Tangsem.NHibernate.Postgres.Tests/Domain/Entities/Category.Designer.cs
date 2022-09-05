using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Common.Entities;
using Newtonsoft.Json;


namespace Tangsem.NHibernate.Tests.PostgreTest1.Domain.Entities
{
  /// <summary>
  /// This entity maps to 'Category'.
  /// </summary>
  public partial class Category
  {
    /// <summary>
    /// The default constructor for Category class.
    /// </summary>
    public Category()
    {
      this.ProductCategoryMaps = new List<ProductCategoryMap>();
    }
  
    
#region "Basic Columns"

        
    /// <summary>
    /// Property Id mapping to Category.Id.
    /// </summary>
    public virtual long Id { get; set; }
        
    /// <summary>
    /// Property CategoryName mapping to Category.CategoryName.
    /// </summary>
    public virtual string CategoryName { get; set; }
        
    /// <summary>
    /// Property CreatedDate mapping to Category.CreatedDate.
    /// </summary>
    public virtual System.DateTime CreatedDate { get; set; }
        
    /// <summary>
    /// Property ExtdProps mapping to Category.ExtdProps.
    /// </summary>
    public virtual string ExtdProps { get; set; }
    
#endregion
    
    
#region "Incoming References"
 
    /// <summary>
    /// Field for the child list of Ref: FK_ProductCategoryMap_Category.
    /// </summary>
    public virtual IList<ProductCategoryMap> ProductCategoryMaps { get; set; }
    
    /// <summary>
    /// Add ProductCategoryMap entity to ProductCategoryMaps.
    /// </summary>
    /// <param name="productCategoryMap">
    ///	The ProductCategoryMap entity.
    /// </param>
    public virtual void AddToProductCategoryMaps(ProductCategoryMap productCategoryMap)
    {
      productCategoryMap.Category = this;
      this.ProductCategoryMaps.Add(productCategoryMap);
    }
  
#endregion

    
    public const int Id_MaxLenth = 0;    
    
    public const int CategoryName_MaxLenth = 200;    
    
    public const int CreatedDate_MaxLenth = 0;    
    
    public const int ExtdProps_MaxLenth = 0;    

  }
}