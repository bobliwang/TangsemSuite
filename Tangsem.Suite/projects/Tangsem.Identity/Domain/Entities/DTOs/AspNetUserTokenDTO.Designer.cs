using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;



namespace Tangsem.Identity.Domain.Entities.DTOs
{
  public partial class AspNetUserTokenDTO
  {	
    /// <summary>
    /// The default constructor for AspNetUserTokenDTO class.
    /// </summary>
    public AspNetUserTokenDTO()
    {
    }

        /// <summary>
    /// Property Id mapping to AspNetUserToken.Id
    /// </summary>
    public virtual int Id { get; set; }
    
        /// <summary>
    /// Property LoginProvider mapping to AspNetUserToken.LoginProvider
    /// </summary>
    public virtual string LoginProvider { get; set; }
    
        /// <summary>
    /// Property Name mapping to AspNetUserToken.Name
    /// </summary>
    public virtual string Name { get; set; }
    
        /// <summary>
    /// Property Value mapping to AspNetUserToken.Value
    /// </summary>
    public virtual string Value { get; set; }
    
        /// <summary>
    /// Property CreatedTime mapping to AspNetUserToken.CreatedTime
    /// </summary>
    public virtual System.DateTime? CreatedTime { get; set; }
    
        /// <summary>
    /// Property ModifiedTime mapping to AspNetUserToken.ModifiedTime
    /// </summary>
    public virtual System.DateTime? ModifiedTime { get; set; }
    
        /// <summary>
    /// Property CreatedById mapping to AspNetUserToken.CreatedById
    /// </summary>
    public virtual int? CreatedById { get; set; }
    
        /// <summary>
    /// Property ModifiedById mapping to AspNetUserToken.ModifiedById
    /// </summary>
    public virtual int? ModifiedById { get; set; }
    
        /// <summary>
    /// Property Active mapping to AspNetUserToken.Active
    /// </summary>
    public virtual bool Active { get; set; }
    
        /// <summary>
    /// Property AspNetUserId mapping to AspNetUserToken.AspNetUserId
    /// </summary>
    public virtual int AspNetUserId { get; set; }
    
    
    
  }
}