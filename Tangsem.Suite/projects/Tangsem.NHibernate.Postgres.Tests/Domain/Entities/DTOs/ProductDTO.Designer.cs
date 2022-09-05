using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;



namespace Tangsem.NHibernate.Tests.PostgreTest1.Domain.Entities.DTOs
{
  public partial class ProductDTO
  {	
    /// <summary>
    /// The default constructor for ProductDTO class.
    /// </summary>
    public ProductDTO()
    {
    }

        /// <summary>
    /// Property Id mapping to Product.Id
    /// </summary>
    public virtual long Id { get; set; }
    
        /// <summary>
    /// Property ProductName mapping to Product.ProductName
    /// </summary>
    public virtual string ProductName { get; set; }
    
        /// <summary>
    /// Property CreatedDate mapping to Product.CreatedDate
    /// </summary>
    public virtual System.DateTime CreatedDate { get; set; }
    
    
        /// <summary>
    /// Property ExtdProps mapping to Product.ExtdProps.
    /// JSON Object!
    /// </summary>
    public virtual Tangsem.NHibernate.Tests.PostgreTest1.Models.PictureModel[] ExtdProps { get; set; }
    
    
  }
}