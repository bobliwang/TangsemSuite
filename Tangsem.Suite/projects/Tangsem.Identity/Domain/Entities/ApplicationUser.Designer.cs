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
  /// This entity maps to 'ApplicationUser'.
  /// </summary>
  public partial class ApplicationUser : AuditableEntity
  {
    /// <summary>
    /// The default constructor for ApplicationUser class.
    /// </summary>
    public ApplicationUser()
    {
    }
  
    
#region "Basic Columns"

        
    /// <summary>
    /// Property Id mapping to ApplicationUser.Id.
    /// </summary>
    public virtual int Id { get; set; }
    
#endregion
    
    
#region "Outgoing References"
        /// <summary>
    /// Gets or sets reference to AspNetUser. ReferenceName: FK_FAE92318.
    /// </summary>
    public virtual AspNetUser AspNetUser { get; set; }

    
#endregion
    

    
    public const int Id_MaxLenth = 0;    
    
    public const int CreatedTime_MaxLenth = 0;    
    
    public const int ModifiedTime_MaxLenth = 0;    
    
    public const int CreatedById_MaxLenth = 0;    
    
    public const int ModifiedById_MaxLenth = 0;    
    
    public const int Active_MaxLenth = 0;    
    
    public const int AspNetUserId_MaxLenth = 0;    

  }
}