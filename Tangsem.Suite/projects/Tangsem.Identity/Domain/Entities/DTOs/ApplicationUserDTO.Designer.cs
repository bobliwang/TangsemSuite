using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;



namespace Tangsem.Identity.Domain.Entities.DTOs
{
  public partial class ApplicationUserDTO
  {	
    /// <summary>
    /// The default constructor for ApplicationUserDTO class.
    /// </summary>
    public ApplicationUserDTO()
    {
    }

        /// <summary>
    /// Property Id mapping to ApplicationUser.Id
    /// </summary>
    public virtual int Id { get; set; }
    
        /// <summary>
    /// Property CreatedTime mapping to ApplicationUser.CreatedTime
    /// </summary>
    public virtual System.DateTime? CreatedTime { get; set; }
    
        /// <summary>
    /// Property ModifiedTime mapping to ApplicationUser.ModifiedTime
    /// </summary>
    public virtual System.DateTime? ModifiedTime { get; set; }
    
        /// <summary>
    /// Property CreatedById mapping to ApplicationUser.CreatedById
    /// </summary>
    public virtual int? CreatedById { get; set; }
    
        /// <summary>
    /// Property ModifiedById mapping to ApplicationUser.ModifiedById
    /// </summary>
    public virtual int? ModifiedById { get; set; }
    
        /// <summary>
    /// Property Active mapping to ApplicationUser.Active
    /// </summary>
    public virtual bool Active { get; set; }
    
        /// <summary>
    /// Property AspNetUserId mapping to ApplicationUser.AspNetUserId
    /// </summary>
    public virtual int AspNetUserId { get; set; }
    
    
    
  }
}