using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;



namespace Tangsem.Identity.Domain.Entities.DTOs
{
  public partial class AspNetRoleDTO
  {	
    /// <summary>
    /// The default constructor for AspNetRoleDTO class.
    /// </summary>
    public AspNetRoleDTO()
    {
    }

        /// <summary>
    /// Property Id mapping to AspNetRole.Id
    /// </summary>
    public virtual int Id { get; set; }
    
        /// <summary>
    /// Property Name mapping to AspNetRole.Name
    /// </summary>
    public virtual string Name { get; set; }
    
        /// <summary>
    /// Property DisplayName mapping to AspNetRole.DisplayName
    /// </summary>
    public virtual string DisplayName { get; set; }
    
        /// <summary>
    /// Property CreatedTime mapping to AspNetRole.CreatedTime
    /// </summary>
    public virtual System.DateTime? CreatedTime { get; set; }
    
        /// <summary>
    /// Property ModifiedTime mapping to AspNetRole.ModifiedTime
    /// </summary>
    public virtual System.DateTime? ModifiedTime { get; set; }
    
        /// <summary>
    /// Property CreatedById mapping to AspNetRole.CreatedById
    /// </summary>
    public virtual int? CreatedById { get; set; }
    
        /// <summary>
    /// Property ModifiedById mapping to AspNetRole.ModifiedById
    /// </summary>
    public virtual int? ModifiedById { get; set; }
    
        /// <summary>
    /// Property Active mapping to AspNetRole.Active
    /// </summary>
    public virtual bool Active { get; set; }
    
    
    
  }
}