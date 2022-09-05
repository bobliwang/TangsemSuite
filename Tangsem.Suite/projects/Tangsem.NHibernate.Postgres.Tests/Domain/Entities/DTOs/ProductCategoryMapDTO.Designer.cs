using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;



namespace Tangsem.NHibernate.Tests.PostgreTest1.Domain.Entities.DTOs
{
  public partial class ProductCategoryMapDTO
  {	
    /// <summary>
    /// The default constructor for ProductCategoryMapDTO class.
    /// </summary>
    public ProductCategoryMapDTO()
    {
    }

        /// <summary>
    /// Property Id mapping to ProductCategoryMap.Id
    /// </summary>
    public virtual long Id { get; set; }
    
        /// <summary>
    /// Property CreatedDate mapping to ProductCategoryMap.CreatedDate
    /// </summary>
    public virtual System.DateTime CreatedDate { get; set; }
    
        /// <summary>
    /// Property ExtdProps mapping to ProductCategoryMap.ExtdProps
    /// </summary>
    public virtual string ExtdProps { get; set; }
    
        /// <summary>
    /// Property ProductId mapping to ProductCategoryMap.ProductId
    /// </summary>
    public virtual long ProductId { get; set; }
    
        /// <summary>
    /// Property CategoryId mapping to ProductCategoryMap.CategoryId
    /// </summary>
    public virtual long CategoryId { get; set; }
    
    
    
  }
}