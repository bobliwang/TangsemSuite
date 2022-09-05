using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;



namespace Tangsem.Identity.Domain.Entities.DTOs
{
  public partial class AspNetUserDTO
  {	
    /// <summary>
    /// The default constructor for AspNetUserDTO class.
    /// </summary>
    public AspNetUserDTO()
    {
    }

        /// <summary>
    /// Property Id mapping to AspNetUser.Id
    /// </summary>
    public virtual int Id { get; set; }
    
        /// <summary>
    /// Property UserName mapping to AspNetUser.UserName
    /// </summary>
    public virtual string UserName { get; set; }
    
        /// <summary>
    /// Property Email mapping to AspNetUser.Email
    /// </summary>
    public virtual string Email { get; set; }
    
        /// <summary>
    /// Property EmailConfirmed mapping to AspNetUser.EmailConfirmed
    /// </summary>
    public virtual bool EmailConfirmed { get; set; }
    
        /// <summary>
    /// Property PasswordHash mapping to AspNetUser.PasswordHash
    /// </summary>
    public virtual string PasswordHash { get; set; }
    
        /// <summary>
    /// Property PhoneNumber mapping to AspNetUser.PhoneNumber
    /// </summary>
    public virtual string PhoneNumber { get; set; }
    
        /// <summary>
    /// Property PhoneNumberConfirmed mapping to AspNetUser.PhoneNumberConfirmed
    /// </summary>
    public virtual bool PhoneNumberConfirmed { get; set; }
    
        /// <summary>
    /// Property TwoFactorEnabled mapping to AspNetUser.TwoFactorEnabled
    /// </summary>
    public virtual bool TwoFactorEnabled { get; set; }
    
        /// <summary>
    /// Property LockoutEnd mapping to AspNetUser.LockoutEnd
    /// </summary>
    public virtual System.DateTime? LockoutEnd { get; set; }
    
        /// <summary>
    /// Property LockoutEnabled mapping to AspNetUser.LockoutEnabled
    /// </summary>
    public virtual bool LockoutEnabled { get; set; }
    
        /// <summary>
    /// Property AccessFailedCount mapping to AspNetUser.AccessFailedCount
    /// </summary>
    public virtual int AccessFailedCount { get; set; }
    
        /// <summary>
    /// Property SecurityStamp mapping to AspNetUser.SecurityStamp
    /// </summary>
    public virtual string SecurityStamp { get; set; }
    
        /// <summary>
    /// Property ConcurrencyStamp mapping to AspNetUser.ConcurrencyStamp
    /// </summary>
    public virtual string ConcurrencyStamp { get; set; }
    
        /// <summary>
    /// Property CreatedTime mapping to AspNetUser.CreatedTime
    /// </summary>
    public virtual System.DateTime? CreatedTime { get; set; }
    
        /// <summary>
    /// Property ModifiedTime mapping to AspNetUser.ModifiedTime
    /// </summary>
    public virtual System.DateTime? ModifiedTime { get; set; }
    
        /// <summary>
    /// Property CreatedById mapping to AspNetUser.CreatedById
    /// </summary>
    public virtual int? CreatedById { get; set; }
    
        /// <summary>
    /// Property ModifiedById mapping to AspNetUser.ModifiedById
    /// </summary>
    public virtual int? ModifiedById { get; set; }
    
        /// <summary>
    /// Property Active mapping to AspNetUser.Active
    /// </summary>
    public virtual bool Active { get; set; }
    
        /// <summary>
    /// Property AuthenticatorKey mapping to AspNetUser.AuthenticatorKey
    /// </summary>
    public virtual string AuthenticatorKey { get; set; }
    
        /// <summary>
    /// Property NormalizedUserName mapping to AspNetUser.NormalizedUserName
    /// </summary>
    public virtual string NormalizedUserName { get; set; }
    
        /// <summary>
    /// Property NormalizedEmail mapping to AspNetUser.NormalizedEmail
    /// </summary>
    public virtual string NormalizedEmail { get; set; }
    
    
    
  }
}