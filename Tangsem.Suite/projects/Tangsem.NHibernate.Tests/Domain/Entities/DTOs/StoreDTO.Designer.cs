using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Tangsem.NHibernate.Tests.Domain.Entities.DTOs
{
  public partial class StoreDTO
  {	
    /// <summary>
    /// The default constructor for StoreDTO class.
    /// </summary>
    public StoreDTO()
    {
    }

        /// <summary>
    /// Property Id mapping to Store.Id
    /// </summary>
    public virtual int Id { get; set; }
    
        /// <summary>
    /// Property StoreName mapping to Store.StoreName
    /// </summary>
    public virtual string StoreName { get; set; }
    
        /// <summary>
    /// Property StorePhoto mapping to Store.StorePhoto
    /// </summary>
    public virtual string StorePhoto { get; set; }
    
        /// <summary>
    /// Property CreatedById mapping to Store.CreatedById
    /// </summary>
    public virtual int? CreatedById { get; set; }
    
        /// <summary>
    /// Property CreatedTime mapping to Store.CreatedTime
    /// </summary>
    public virtual System.DateTime? CreatedTime { get; set; }
    
        /// <summary>
    /// Property ModifiedById mapping to Store.ModifiedById
    /// </summary>
    public virtual int? ModifiedById { get; set; }
    
        /// <summary>
    /// Property ModifiedTime mapping to Store.ModifiedTime
    /// </summary>
    public virtual System.DateTime? ModifiedTime { get; set; }
    
        /// <summary>
    /// Property Active mapping to Store.Active
    /// </summary>
    public virtual bool Active { get; set; }
    
    
    
  }
}