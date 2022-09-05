using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Identity.Domain.Entities;

namespace Sample.Core.Domain.Entities.DTOs
{
  public partial class FormSignerDTO
  {	
    /// <summary>
    /// The default constructor for FormSignerDTO class.
    /// </summary>
    public FormSignerDTO()
    {
    }

        /// <summary>
    /// Property Id mapping to FormSigner.Id
    /// </summary>
    public virtual int Id { get; set; }
    
        /// <summary>
    /// Property FormId mapping to FormSigner.FormId
    /// </summary>
    public virtual int FormId { get; set; }
    
        /// <summary>
    /// Property SignerId mapping to FormSigner.SignerId
    /// </summary>
    public virtual int SignerId { get; set; }
    
        /// <summary>
    /// Property CreatedTime mapping to FormSigner.CreatedTime
    /// </summary>
    public virtual System.DateTime? CreatedTime { get; set; }
    
        /// <summary>
    /// Property ModifiedTime mapping to FormSigner.ModifiedTime
    /// </summary>
    public virtual System.DateTime? ModifiedTime { get; set; }
    
        /// <summary>
    /// Property CreatedById mapping to FormSigner.CreatedById
    /// </summary>
    public virtual int? CreatedById { get; set; }
    
        /// <summary>
    /// Property ModifiedById mapping to FormSigner.ModifiedById
    /// </summary>
    public virtual int? ModifiedById { get; set; }
    
        /// <summary>
    /// Property Active mapping to FormSigner.Active
    /// </summary>
    public virtual bool Active { get; set; }
    
    
    
  }
}