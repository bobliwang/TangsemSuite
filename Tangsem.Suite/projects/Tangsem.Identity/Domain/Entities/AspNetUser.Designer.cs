using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Common.Entities;
using Newtonsoft.Json;


namespace Tangsem.Identity.Domain.Entities
{
  /// <summary>
  /// This entity maps to 'AspNetUser'.
  /// </summary>
  public partial class AspNetUser : AuditableEntity
  {
    /// <summary>
    /// The default constructor for AspNetUser class.
    /// </summary>
    public AspNetUser()
    {
      this.AspNetUserRoles = new List<AspNetUserRole>();
      this.AspNetUserClaims = new List<AspNetUserClaim>();
      this.AspNetUserLogins = new List<AspNetUserLogin>();
      this.AspNetUserTokens = new List<AspNetUserToken>();
      this.ApplicationUsers = new List<ApplicationUser>();
    }
  
    
#region "Basic Columns"

        
    /// <summary>
    /// Property Id mapping to AspNetUser.Id.
    /// </summary>
    public virtual int Id { get; set; }
        
    /// <summary>
    /// Property UserName mapping to AspNetUser.UserName.
    /// </summary>
    public virtual string UserName { get; set; }
        
    /// <summary>
    /// Property Email mapping to AspNetUser.Email.
    /// </summary>
    public virtual string Email { get; set; }
        
    /// <summary>
    /// Property EmailConfirmed mapping to AspNetUser.EmailConfirmed.
    /// </summary>
    public virtual bool EmailConfirmed { get; set; }
        
    /// <summary>
    /// Property PasswordHash mapping to AspNetUser.PasswordHash.
    /// </summary>
    public virtual string PasswordHash { get; set; }
        
    /// <summary>
    /// Property PhoneNumber mapping to AspNetUser.PhoneNumber.
    /// </summary>
    public virtual string PhoneNumber { get; set; }
        
    /// <summary>
    /// Property PhoneNumberConfirmed mapping to AspNetUser.PhoneNumberConfirmed.
    /// </summary>
    public virtual bool PhoneNumberConfirmed { get; set; }
        
    /// <summary>
    /// Property TwoFactorEnabled mapping to AspNetUser.TwoFactorEnabled.
    /// </summary>
    public virtual bool TwoFactorEnabled { get; set; }
        
    /// <summary>
    /// Property LockoutEnd mapping to AspNetUser.LockoutEnd.
    /// </summary>
    public virtual System.DateTime? LockoutEnd { get; set; }
        
    /// <summary>
    /// Property LockoutEnabled mapping to AspNetUser.LockoutEnabled.
    /// </summary>
    public virtual bool LockoutEnabled { get; set; }
        
    /// <summary>
    /// Property AccessFailedCount mapping to AspNetUser.AccessFailedCount.
    /// </summary>
    public virtual int AccessFailedCount { get; set; }
        
    /// <summary>
    /// Property SecurityStamp mapping to AspNetUser.SecurityStamp.
    /// </summary>
    public virtual string SecurityStamp { get; set; }
        
    /// <summary>
    /// Property ConcurrencyStamp mapping to AspNetUser.ConcurrencyStamp.
    /// </summary>
    public virtual string ConcurrencyStamp { get; set; }
        
    /// <summary>
    /// Property AuthenticatorKey mapping to AspNetUser.AuthenticatorKey.
    /// </summary>
    public virtual string AuthenticatorKey { get; set; }
        
    /// <summary>
    /// Property NormalizedUserName mapping to AspNetUser.NormalizedUserName.
    /// </summary>
    public virtual string NormalizedUserName { get; set; }
        
    /// <summary>
    /// Property NormalizedEmail mapping to AspNetUser.NormalizedEmail.
    /// </summary>
    public virtual string NormalizedEmail { get; set; }
    
#endregion
    
    
#region "Incoming References"
 
    /// <summary>
    /// Field for the child list of Ref: FK_5B92CFCB.
    /// </summary>
    public virtual IList<AspNetUserRole> AspNetUserRoles { get; set; }
    
    /// <summary>
    /// Add AspNetUserRole entity to AspNetUserRoles.
    /// </summary>
    /// <param name="aspNetUserRole">
    ///	The AspNetUserRole entity.
    /// </param>
    public virtual void AddToAspNetUserRoles(AspNetUserRole aspNetUserRole)
    {
      aspNetUserRole.AspNetUser = this;
      this.AspNetUserRoles.Add(aspNetUserRole);
    }
  
    /// <summary>
    /// Field for the child list of Ref: FK_5F0AD757.
    /// </summary>
    public virtual IList<AspNetUserClaim> AspNetUserClaims { get; set; }
    
    /// <summary>
    /// Add AspNetUserClaim entity to AspNetUserClaims.
    /// </summary>
    /// <param name="aspNetUserClaim">
    ///	The AspNetUserClaim entity.
    /// </param>
    public virtual void AddToAspNetUserClaims(AspNetUserClaim aspNetUserClaim)
    {
      aspNetUserClaim.AspNetUser = this;
      this.AspNetUserClaims.Add(aspNetUserClaim);
    }
  
    /// <summary>
    /// Field for the child list of Ref: FK_5FB27165.
    /// </summary>
    public virtual IList<AspNetUserLogin> AspNetUserLogins { get; set; }
    
    /// <summary>
    /// Add AspNetUserLogin entity to AspNetUserLogins.
    /// </summary>
    /// <param name="aspNetUserLogin">
    ///	The AspNetUserLogin entity.
    /// </param>
    public virtual void AddToAspNetUserLogins(AspNetUserLogin aspNetUserLogin)
    {
      aspNetUserLogin.AspNetUser = this;
      this.AspNetUserLogins.Add(aspNetUserLogin);
    }
  
    /// <summary>
    /// Field for the child list of Ref: FK_81DF1BFC.
    /// </summary>
    public virtual IList<AspNetUserToken> AspNetUserTokens { get; set; }
    
    /// <summary>
    /// Add AspNetUserToken entity to AspNetUserTokens.
    /// </summary>
    /// <param name="aspNetUserToken">
    ///	The AspNetUserToken entity.
    /// </param>
    public virtual void AddToAspNetUserTokens(AspNetUserToken aspNetUserToken)
    {
      aspNetUserToken.AspNetUser = this;
      this.AspNetUserTokens.Add(aspNetUserToken);
    }
  
    /// <summary>
    /// Field for the child list of Ref: FK_FAE92318.
    /// </summary>
    public virtual IList<ApplicationUser> ApplicationUsers { get; set; }
    
    /// <summary>
    /// Add ApplicationUser entity to ApplicationUsers.
    /// </summary>
    /// <param name="applicationUser">
    ///	The ApplicationUser entity.
    /// </param>
    public virtual void AddToApplicationUsers(ApplicationUser applicationUser)
    {
      applicationUser.AspNetUser = this;
      this.ApplicationUsers.Add(applicationUser);
    }
  
#endregion

    
    public const int Id_MaxLenth = 0;    
    
    public const int UserName_MaxLenth = 250;    
    
    public const int Email_MaxLenth = 250;    
    
    public const int EmailConfirmed_MaxLenth = 0;    
    
    public const int PasswordHash_MaxLenth = 2000;    
    
    public const int PhoneNumber_MaxLenth = 50;    
    
    public const int PhoneNumberConfirmed_MaxLenth = 0;    
    
    public const int TwoFactorEnabled_MaxLenth = 0;    
    
    public const int LockoutEnd_MaxLenth = 0;    
    
    public const int LockoutEnabled_MaxLenth = 0;    
    
    public const int AccessFailedCount_MaxLenth = 0;    
    
    public const int SecurityStamp_MaxLenth = 1024;    
    
    public const int ConcurrencyStamp_MaxLenth = 1024;    
    
    public const int CreatedTime_MaxLenth = 0;    
    
    public const int ModifiedTime_MaxLenth = 0;    
    
    public const int CreatedById_MaxLenth = 0;    
    
    public const int ModifiedById_MaxLenth = 0;    
    
    public const int Active_MaxLenth = 0;    
    
    public const int AuthenticatorKey_MaxLenth = 300;    
    
    public const int NormalizedUserName_MaxLenth = 300;    
    
    public const int NormalizedEmail_MaxLenth = 300;    

  }
}