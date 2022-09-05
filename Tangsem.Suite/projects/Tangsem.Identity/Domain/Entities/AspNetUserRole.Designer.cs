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
  /// This entity maps to 'AspNetUserRole'.
  /// </summary>
  public partial class AspNetUserRole : AuditableEntity
  {
    /// <summary>
    /// The default constructor for AspNetUserRole class.
    /// </summary>
    public AspNetUserRole()
    {
    }
  
    
#region "Basic Columns"

        
    /// <summary>
    /// Property Id mapping to AspNetUserRole.Id.
    /// </summary>
    public virtual int Id { get; set; }
    
#endregion
    
    
#region "Outgoing References"
        /// <summary>
    /// Gets or sets reference to AspNetUser. ReferenceName: FK_5B92CFCB.
    /// </summary>
    public virtual AspNetUser AspNetUser { get; set; }

        /// <summary>
    /// Gets or sets reference to AspNetRole. ReferenceName: FK_A0CA6CD2.
    /// </summary>
    public virtual AspNetRole AspNetRole { get; set; }

    
#endregion
    

    
    public const int Id_MaxLenth = 0;    
    
    public const int CreatedTime_MaxLenth = 0;    
    
    public const int ModifiedTime_MaxLenth = 0;    
    
    public const int CreatedById_MaxLenth = 0;    
    
    public const int ModifiedById_MaxLenth = 0;    
    
    public const int Active_MaxLenth = 0;    
    
    public const int AspNetRoleId_MaxLenth = 0;    
    
    public const int AspNetUserId_MaxLenth = 0;    

  }
}