using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;



namespace Tangsem.Identity.Domain.Entities.DTOs
{
  public partial class AspNetUserLoginDTO
  {	
    /// <summary>
    /// The default constructor for AspNetUserLoginDTO class.
    /// </summary>
    public AspNetUserLoginDTO()
    {
    }

        /// <summary>
    /// Property Id mapping to AspNetUserLogin.Id
    /// </summary>
    public virtual int Id { get; set; }
    
        /// <summary>
    /// Property LoginProvider mapping to AspNetUserLogin.LoginProvider
    /// </summary>
    public virtual string LoginProvider { get; set; }
    
        /// <summary>
    /// Property ProviderKey mapping to AspNetUserLogin.ProviderKey
    /// </summary>
    public virtual string ProviderKey { get; set; }
    
        /// <summary>
    /// Property ProviderDisplayName mapping to AspNetUserLogin.ProviderDisplayName
    /// </summary>
    public virtual string ProviderDisplayName { get; set; }
    
        /// <summary>
    /// Property CreatedTime mapping to AspNetUserLogin.CreatedTime
    /// </summary>
    public virtual System.DateTime? CreatedTime { get; set; }
    
        /// <summary>
    /// Property ModifiedTime mapping to AspNetUserLogin.ModifiedTime
    /// </summary>
    public virtual System.DateTime? ModifiedTime { get; set; }
    
        /// <summary>
    /// Property CreatedById mapping to AspNetUserLogin.CreatedById
    /// </summary>
    public virtual int? CreatedById { get; set; }
    
        /// <summary>
    /// Property ModifiedById mapping to AspNetUserLogin.ModifiedById
    /// </summary>
    public virtual int? ModifiedById { get; set; }
    
        /// <summary>
    /// Property Active mapping to AspNetUserLogin.Active
    /// </summary>
    public virtual bool Active { get; set; }
    
        /// <summary>
    /// Property AspNetUserId mapping to AspNetUserLogin.AspNetUserId
    /// </summary>
    public virtual int AspNetUserId { get; set; }
    
    
    
  }
}