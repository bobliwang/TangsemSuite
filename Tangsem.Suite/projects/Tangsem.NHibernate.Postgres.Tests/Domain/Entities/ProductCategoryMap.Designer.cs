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
  /// This entity maps to 'ProductCategoryMap'.
  /// </summary>
  public partial class ProductCategoryMap
  {
    /// <summary>
    /// The default constructor for ProductCategoryMap class.
    /// </summary>
    public ProductCategoryMap()
    {
    }
  
    
#region "Basic Columns"

        
    /// <summary>
    /// Property Id mapping to ProductCategoryMap.Id.
    /// </summary>
    public virtual long Id { get; set; }
        
    /// <summary>
    /// Property CreatedDate mapping to ProductCategoryMap.CreatedDate.
    /// </summary>
    public virtual System.DateTime CreatedDate { get; set; }
        
    /// <summary>
    /// Property ExtdProps mapping to ProductCategoryMap.ExtdProps.
    /// </summary>
    public virtual string ExtdProps { get; set; }
    
#endregion
    
    
#region "Outgoing References"
        /// <summary>
    /// Gets or sets reference to Category. ReferenceName: FK_ProductCategoryMap_Category.
    /// </summary>
    public virtual Category Category { get; set; }

        /// <summary>
    /// Gets or sets reference to Product. ReferenceName: FK_ProductCategoryMap_Product.
    /// </summary>
    public virtual Product Product { get; set; }

    
#endregion
    

    
    public const int Id_MaxLenth = 0;    
    
    public const int CreatedDate_MaxLenth = 0;    
    
    public const int ExtdProps_MaxLenth = 0;    
    
    public const int ProductId_MaxLenth = 0;    
    
    public const int CategoryId_MaxLenth = 0;    

  }
}