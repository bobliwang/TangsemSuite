using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;



namespace Tangsem.Identity.Domain.Entities.DTOs
{
  public partial class AspNetRoleClaimDTO
  {	
    /// <summary>
    /// The default constructor for AspNetRoleClaimDTO class.
    /// </summary>
    public AspNetRoleClaimDTO()
    {
    }

        /// <summary>
    /// Property Id mapping to AspNetRoleClaim.Id
    /// </summary>
    public virtual int Id { get; set; }
    
        /// <summary>
    /// Property ClaimType mapping to AspNetRoleClaim.ClaimType
    /// </summary>
    public virtual string ClaimType { get; set; }
    
        /// <summary>
    /// Property ClaimValue mapping to AspNetRoleClaim.ClaimValue
    /// </summary>
    public virtual string ClaimValue { get; set; }
    
        /// <summary>
    /// Property CreatedTime mapping to AspNetRoleClaim.CreatedTime
    /// </summary>
    public virtual System.DateTime? CreatedTime { get; set; }
    
        /// <summary>
    /// Property ModifiedTime mapping to AspNetRoleClaim.ModifiedTime
    /// </summary>
    public virtual System.DateTime? ModifiedTime { get; set; }
    
        /// <summary>
    /// Property CreatedById mapping to AspNetRoleClaim.CreatedById
    /// </summary>
    public virtual int? CreatedById { get; set; }
    
        /// <summary>
    /// Property ModifiedById mapping to AspNetRoleClaim.ModifiedById
    /// </summary>
    public virtual int? ModifiedById { get; set; }
    
        /// <summary>
    /// Property Active mapping to AspNetRoleClaim.Active
    /// </summary>
    public virtual bool Active { get; set; }
    
        /// <summary>
    /// Property AspNetRoleId mapping to AspNetRoleClaim.AspNetRoleId
    /// </summary>
    public virtual int AspNetRoleId { get; set; }
    
    
    
  }
}