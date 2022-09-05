using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;



namespace Tangsem.Identity.Domain.Entities.DTOs
{
  public partial class AspNetUserClaimDTO
  {	
    /// <summary>
    /// The default constructor for AspNetUserClaimDTO class.
    /// </summary>
    public AspNetUserClaimDTO()
    {
    }

        /// <summary>
    /// Property Id mapping to AspNetUserClaim.Id
    /// </summary>
    public virtual int Id { get; set; }
    
        /// <summary>
    /// Property ClaimType mapping to AspNetUserClaim.ClaimType
    /// </summary>
    public virtual string ClaimType { get; set; }
    
        /// <summary>
    /// Property ClaimValue mapping to AspNetUserClaim.ClaimValue
    /// </summary>
    public virtual string ClaimValue { get; set; }
    
        /// <summary>
    /// Property CreatedTime mapping to AspNetUserClaim.CreatedTime
    /// </summary>
    public virtual System.DateTime? CreatedTime { get; set; }
    
        /// <summary>
    /// Property ModifiedTime mapping to AspNetUserClaim.ModifiedTime
    /// </summary>
    public virtual System.DateTime? ModifiedTime { get; set; }
    
        /// <summary>
    /// Property CreatedById mapping to AspNetUserClaim.CreatedById
    /// </summary>
    public virtual int? CreatedById { get; set; }
    
        /// <summary>
    /// Property ModifiedById mapping to AspNetUserClaim.ModifiedById
    /// </summary>
    public virtual int? ModifiedById { get; set; }
    
        /// <summary>
    /// Property Active mapping to AspNetUserClaim.Active
    /// </summary>
    public virtual bool Active { get; set; }
    
        /// <summary>
    /// Property AspNetUserId mapping to AspNetUserClaim.AspNetUserId
    /// </summary>
    public virtual int AspNetUserId { get; set; }
    
    
    
  }
}