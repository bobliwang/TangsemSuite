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
  /// This entity maps to 'ProductPhoto'.
  /// </summary>
  public partial class ProductPhoto
  {
    /// <summary>
    /// The default constructor for ProductPhoto class.
    /// </summary>
    public ProductPhoto()
    {
    }
  
    
#region "Basic Columns"

        
    /// <summary>
    /// Property Id mapping to ProductPhoto.Id.
    /// </summary>
    public virtual long Id { get; set; }
        
    /// <summary>
    /// Property CreatedDate mapping to ProductPhoto.CreatedDate.
    /// </summary>
    public virtual System.DateTime CreatedDate { get; set; }
        
    /// <summary>
    /// Property ExtdProps mapping to ProductPhoto.ExtdProps.
    /// </summary>
    public virtual string ExtdProps { get; set; }
        
    /// <summary>
    /// Property ImageData mapping to ProductPhoto.ImageData.
    /// </summary>
    public virtual byte[] ImageData { get; set; }
    
#endregion
    
    
#region "Outgoing References"
        /// <summary>
    /// Gets or sets reference to Product. ReferenceName: FK_ProductPhoto_Product.
    /// </summary>
    public virtual Product Product { get; set; }

    
#endregion
    

    
    public const int Id_MaxLenth = 0;    
    
    public const int CreatedDate_MaxLenth = 0;    
    
    public const int ExtdProps_MaxLenth = 0;    
    
    public const int ProductId_MaxLenth = 0;    
    
    public const int ImageData_MaxLenth = 0;    

  }
}