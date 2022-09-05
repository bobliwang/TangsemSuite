using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Identity.Domain.Entities;

namespace Sample.Core.Domain.Entities.DTOs
{
  public partial class FormDTO
  {	
    /// <summary>
    /// The default constructor for FormDTO class.
    /// </summary>
    public FormDTO()
    {
    }

        /// <summary>
    /// Property Id mapping to Form.Id
    /// </summary>
    public virtual int Id { get; set; }
    
        /// <summary>
    /// Property Title mapping to Form.Title
    /// </summary>
    public virtual string Title { get; set; }
    
        /// <summary>
    /// Property FormJson mapping to Form.FormJson
    /// </summary>
    public virtual byte[] FormJson { get; set; }
    
        /// <summary>
    /// Property CreatedTime mapping to Form.CreatedTime
    /// </summary>
    public virtual System.DateTime? CreatedTime { get; set; }
    
        /// <summary>
    /// Property ModifiedTime mapping to Form.ModifiedTime
    /// </summary>
    public virtual System.DateTime? ModifiedTime { get; set; }
    
        /// <summary>
    /// Property CreatedById mapping to Form.CreatedById
    /// </summary>
    public virtual int? CreatedById { get; set; }
    
        /// <summary>
    /// Property ModifiedById mapping to Form.ModifiedById
    /// </summary>
    public virtual int? ModifiedById { get; set; }
    
        /// <summary>
    /// Property Active mapping to Form.Active
    /// </summary>
    public virtual bool Active { get; set; }
    
        /// <summary>
    /// Property AspNetUserId mapping to Form.AspNetUserId
    /// </summary>
    public virtual int AspNetUserId { get; set; }
    
        /// <summary>
    /// Property RowVersion mapping to Form.RowVersion
    /// </summary>
    public virtual byte[] RowVersion { get; set; }
    
    
    
  }
}