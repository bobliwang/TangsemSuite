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
  /// This entity maps to 'AspNetRole'.
  /// </summary>
  public partial class AspNetRole : AuditableEntity
  {
    /// <summary>
    /// The default constructor for AspNetRole class.
    /// </summary>
    public AspNetRole()
    {
      this.AspNetUserRoles = new List<AspNetUserRole>();
      this.AspNetRoleClaims = new List<AspNetRoleClaim>();
    }
  
    
#region "Basic Columns"

        
    /// <summary>
    /// Property Id mapping to AspNetRole.Id.
    /// </summary>
    public virtual int Id { get; set; }
        
    /// <summary>
    /// Property Name mapping to AspNetRole.Name.
    /// </summary>
    public virtual string Name { get; set; }
        
    /// <summary>
    /// Property DisplayName mapping to AspNetRole.DisplayName.
    /// </summary>
    public virtual string DisplayName { get; set; }
    
#endregion
    
    
#region "Incoming References"
 
    /// <summary>
    /// Field for the child list of Ref: FK_A0CA6CD2.
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
      aspNetUserRole.AspNetRole = this;
      this.AspNetUserRoles.Add(aspNetUserRole);
    }
  
    /// <summary>
    /// Field for the child list of Ref: FK_F1EFDCE1.
    /// </summary>
    public virtual IList<AspNetRoleClaim> AspNetRoleClaims { get; set; }
    
    /// <summary>
    /// Add AspNetRoleClaim entity to AspNetRoleClaims.
    /// </summary>
    /// <param name="aspNetRoleClaim">
    ///	The AspNetRoleClaim entity.
    /// </param>
    public virtual void AddToAspNetRoleClaims(AspNetRoleClaim aspNetRoleClaim)
    {
      aspNetRoleClaim.AspNetRole = this;
      this.AspNetRoleClaims.Add(aspNetRoleClaim);
    }
  
#endregion

    
    public const int Id_MaxLenth = 0;    
    
    public const int Name_MaxLenth = 200;    
    
    public const int DisplayName_MaxLenth = 500;    
    
    public const int CreatedTime_MaxLenth = 0;    
    
    public const int ModifiedTime_MaxLenth = 0;    
    
    public const int CreatedById_MaxLenth = 0;    
    
    public const int ModifiedById_MaxLenth = 0;    
    
    public const int Active_MaxLenth = 0;    

  }
}