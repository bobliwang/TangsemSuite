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
  /// This entity maps to 'AspNetUserToken'.
  /// </summary>
  public partial class AspNetUserToken : AuditableEntity
  {
    /// <summary>
    /// The default constructor for AspNetUserToken class.
    /// </summary>
    public AspNetUserToken()
    {
    }
  
    
#region "Basic Columns"

        
    /// <summary>
    /// Property Id mapping to AspNetUserToken.Id.
    /// </summary>
    public virtual int Id { get; set; }
        
    /// <summary>
    /// Property LoginProvider mapping to AspNetUserToken.LoginProvider.
    /// </summary>
    public virtual string LoginProvider { get; set; }
        
    /// <summary>
    /// Property Name mapping to AspNetUserToken.Name.
    /// </summary>
    public virtual string Name { get; set; }
        
    /// <summary>
    /// Property Value mapping to AspNetUserToken.Value.
    /// </summary>
    public virtual string Value { get; set; }
    
#endregion
    
    
#region "Outgoing References"
        /// <summary>
    /// Gets or sets reference to AspNetUser. ReferenceName: FK_81DF1BFC.
    /// </summary>
    public virtual AspNetUser AspNetUser { get; set; }

    
#endregion
    

    
    public const int Id_MaxLenth = 0;    
    
    public const int LoginProvider_MaxLenth = 200;    
    
    public const int Name_MaxLenth = 200;    
    
    public const int Value_MaxLenth = 2000;    
    
    public const int CreatedTime_MaxLenth = 0;    
    
    public const int ModifiedTime_MaxLenth = 0;    
    
    public const int CreatedById_MaxLenth = 0;    
    
    public const int ModifiedById_MaxLenth = 0;    
    
    public const int Active_MaxLenth = 0;    
    
    public const int AspNetUserId_MaxLenth = 0;    

  }
}