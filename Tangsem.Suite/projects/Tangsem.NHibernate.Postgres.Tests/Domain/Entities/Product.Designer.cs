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
  /// This entity maps to 'Product'.
  /// </summary>
  public partial class Product
  {
    /// <summary>
    /// The default constructor for Product class.
    /// </summary>
    public Product()
    {
      this.ProductCategoryMaps = new List<ProductCategoryMap>();
      this.ProductPhotos = new List<ProductPhoto>();
    }
  
        
    /// <summary>
    /// Property ExtdProps mapping to Product.ExtdProps.
    /// JSON COLUMN!
    /// </summary>
    public virtual Tangsem.NHibernate.Tests.PostgreTest1.Models.PictureModel[] ExtdProps { get; set; }
   
    
#region "Basic Columns"

        
    /// <summary>
    /// Property Id mapping to Product.Id.
    /// </summary>
    public virtual long Id { get; set; }
        
    /// <summary>
    /// Property ProductName mapping to Product.ProductName.
    /// </summary>
    public virtual string ProductName { get; set; }
        
    /// <summary>
    /// Property CreatedDate mapping to Product.CreatedDate.
    /// </summary>
    public virtual System.DateTime CreatedDate { get; set; }
    
#endregion
    
    
#region "Incoming References"
 
    /// <summary>
    /// Field for the child list of Ref: FK_ProductCategoryMap_Product.
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
      productCategoryMap.Product = this;
      this.ProductCategoryMaps.Add(productCategoryMap);
    }
  
    /// <summary>
    /// Field for the child list of Ref: FK_ProductPhoto_Product.
    /// </summary>
    public virtual IList<ProductPhoto> ProductPhotos { get; set; }
    
    /// <summary>
    /// Add ProductPhoto entity to ProductPhotos.
    /// </summary>
    /// <param name="productPhoto">
    ///	The ProductPhoto entity.
    /// </param>
    public virtual void AddToProductPhotos(ProductPhoto productPhoto)
    {
      productPhoto.Product = this;
      this.ProductPhotos.Add(productPhoto);
    }
  
#endregion

    
    public const int Id_MaxLenth = 0;    
    
    public const int ProductName_MaxLenth = 200;    
    
    public const int CreatedDate_MaxLenth = 0;    
    
    public const int ExtdProps_MaxLenth = 0;    

  }
}