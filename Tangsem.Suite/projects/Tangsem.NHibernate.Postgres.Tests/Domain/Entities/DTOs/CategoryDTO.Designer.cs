using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;



namespace Tangsem.NHibernate.Tests.PostgreTest1.Domain.Entities.DTOs
{
  public partial class CategoryDTO
  {	
    /// <summary>
    /// The default constructor for CategoryDTO class.
    /// </summary>
    public CategoryDTO()
    {
    }

        /// <summary>
    /// Property Id mapping to Category.Id
    /// </summary>
    public virtual long Id { get; set; }
    
        /// <summary>
    /// Property CategoryName mapping to Category.CategoryName
    /// </summary>
    public virtual string CategoryName { get; set; }
    
        /// <summary>
    /// Property CreatedDate mapping to Category.CreatedDate
    /// </summary>
    public virtual System.DateTime CreatedDate { get; set; }
    
        /// <summary>
    /// Property ExtdProps mapping to Category.ExtdProps
    /// </summary>
    public virtual string ExtdProps { get; set; }
    
    
    
  }
}