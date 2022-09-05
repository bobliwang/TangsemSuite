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
  /// This entity maps to 'AspNetUserLogin'.
  /// </summary>
  public partial class AspNetUserLogin : AuditableEntity
  {
    /// <summary>
    /// The default constructor for AspNetUserLogin class.
    /// </summary>
    public AspNetUserLogin()
    {
    }
  
    
#region "Basic Columns"

        
    /// <summary>
    /// Property Id mapping to AspNetUserLogin.Id.
    /// </summary>
    public virtual int Id { get; set; }
        
    /// <summary>
    /// Property LoginProvider mapping to AspNetUserLogin.LoginProvider.
    /// </summary>
    public virtual string LoginProvider { get; set; }
        
    /// <summary>
    /// Property ProviderKey mapping to AspNetUserLogin.ProviderKey.
    /// </summary>
    public virtual string ProviderKey { get; set; }
        
    /// <summary>
    /// Property ProviderDisplayName mapping to AspNetUserLogin.ProviderDisplayName.
    /// </summary>
    public virtual string ProviderDisplayName { get; set; }
    
#endregion
    
    
#region "Outgoing References"
        /// <summary>
    /// Gets or sets reference to AspNetUser. ReferenceName: FK_5FB27165.
    /// </summary>
    public virtual AspNetUser AspNetUser { get; set; }

    
#endregion
    

    
    public const int Id_MaxLenth = 0;    
    
    public const int LoginProvider_MaxLenth = 200;    
    
    public const int ProviderKey_MaxLenth = 200;    
    
    public const int ProviderDisplayName_MaxLenth = 1024;    
    
    public const int CreatedTime_MaxLenth = 0;    
    
    public const int ModifiedTime_MaxLenth = 0;    
    
    public const int CreatedById_MaxLenth = 0;    
    
    public const int ModifiedById_MaxLenth = 0;    
    
    public const int Active_MaxLenth = 0;    
    
    public const int AspNetUserId_MaxLenth = 0;    

  }
}