using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;



namespace Tangsem.NHibernate.Tests.PostgreTest1.Domain.Entities.DTOs
{
  public partial class ProductPhotoDTO
  {	
    /// <summary>
    /// The default constructor for ProductPhotoDTO class.
    /// </summary>
    public ProductPhotoDTO()
    {
    }

        /// <summary>
    /// Property Id mapping to ProductPhoto.Id
    /// </summary>
    public virtual long Id { get; set; }
    
        /// <summary>
    /// Property CreatedDate mapping to ProductPhoto.CreatedDate
    /// </summary>
    public virtual System.DateTime CreatedDate { get; set; }
    
        /// <summary>
    /// Property ExtdProps mapping to ProductPhoto.ExtdProps
    /// </summary>
    public virtual string ExtdProps { get; set; }
    
        /// <summary>
    /// Property ProductId mapping to ProductPhoto.ProductId
    /// </summary>
    public virtual long ProductId { get; set; }
    
        /// <summary>
    /// Property ImageData mapping to ProductPhoto.ImageData
    /// </summary>
    public virtual byte[] ImageData { get; set; }
    
    
    
  }
}