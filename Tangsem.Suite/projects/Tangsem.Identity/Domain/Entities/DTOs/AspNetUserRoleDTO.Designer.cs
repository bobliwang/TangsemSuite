using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;



namespace Tangsem.Identity.Domain.Entities.DTOs
{
  public partial class AspNetUserRoleDTO
  {	
    /// <summary>
    /// The default constructor for AspNetUserRoleDTO class.
    /// </summary>
    public AspNetUserRoleDTO()
    {
    }

        /// <summary>
    /// Property Id mapping to AspNetUserRole.Id
    /// </summary>
    public virtual int Id { get; set; }
    
        /// <summary>
    /// Property CreatedTime mapping to AspNetUserRole.CreatedTime
    /// </summary>
    public virtual System.DateTime? CreatedTime { get; set; }
    
        /// <summary>
    /// Property ModifiedTime mapping to AspNetUserRole.ModifiedTime
    /// </summary>
    public virtual System.DateTime? ModifiedTime { get; set; }
    
        /// <summary>
    /// Property CreatedById mapping to AspNetUserRole.CreatedById
    /// </summary>
    public virtual int? CreatedById { get; set; }
    
        /// <summary>
    /// Property ModifiedById mapping to AspNetUserRole.ModifiedById
    /// </summary>
    public virtual int? ModifiedById { get; set; }
    
        /// <summary>
    /// Property Active mapping to AspNetUserRole.Active
    /// </summary>
    public virtual bool Active { get; set; }
    
        /// <summary>
    /// Property AspNetRoleId mapping to AspNetUserRole.AspNetRoleId
    /// </summary>
    public virtual int AspNetRoleId { get; set; }
    
        /// <summary>
    /// Property AspNetUserId mapping to AspNetUserRole.AspNetUserId
    /// </summary>
    public virtual int AspNetUserId { get; set; }
    
    
    
  }
}