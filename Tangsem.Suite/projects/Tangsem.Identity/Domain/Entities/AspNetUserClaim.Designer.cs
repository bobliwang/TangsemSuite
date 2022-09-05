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
  /// This entity maps to 'AspNetUserClaim'.
  /// </summary>
  public partial class AspNetUserClaim : AuditableEntity
  {
    /// <summary>
    /// The default constructor for AspNetUserClaim class.
    /// </summary>
    public AspNetUserClaim()
    {
    }
  
    
#region "Basic Columns"

        
    /// <summary>
    /// Property Id mapping to AspNetUserClaim.Id.
    /// </summary>
    public virtual int Id { get; set; }
        
    /// <summary>
    /// Property ClaimType mapping to AspNetUserClaim.ClaimType.
    /// </summary>
    public virtual string ClaimType { get; set; }
        
    /// <summary>
    /// Property ClaimValue mapping to AspNetUserClaim.ClaimValue.
    /// </summary>
    public virtual string ClaimValue { get; set; }
    
#endregion
    
    
#region "Outgoing References"
        /// <summary>
    /// Gets or sets reference to AspNetUser. ReferenceName: FK_5F0AD757.
    /// </summary>
    public virtual AspNetUser AspNetUser { get; set; }

    
#endregion
    

    
    public const int Id_MaxLenth = 0;    
    
    public const int ClaimType_MaxLenth = 1024;    
    
    public const int ClaimValue_MaxLenth = 1024;    
    
    public const int CreatedTime_MaxLenth = 0;    
    
    public const int ModifiedTime_MaxLenth = 0;    
    
    public const int CreatedById_MaxLenth = 0;    
    
    public const int ModifiedById_MaxLenth = 0;    
    
    public const int Active_MaxLenth = 0;    
    
    public const int AspNetUserId_MaxLenth = 0;    

  }
}