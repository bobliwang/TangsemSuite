using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Identity.Domain.Entities;

namespace Sample.Core.Domain.Entities.DTOs
{
  public partial class SignerDTO
  {	
    /// <summary>
    /// The default constructor for SignerDTO class.
    /// </summary>
    public SignerDTO()
    {
    }

        /// <summary>
    /// Property Id mapping to Signer.Id
    /// </summary>
    public virtual int Id { get; set; }
    
        /// <summary>
    /// Property FirstName mapping to Signer.FirstName
    /// </summary>
    public virtual string FirstName { get; set; }
    
        /// <summary>
    /// Property LastName mapping to Signer.LastName
    /// </summary>
    public virtual string LastName { get; set; }
    
        /// <summary>
    /// Property Email mapping to Signer.Email
    /// </summary>
    public virtual string Email { get; set; }
    
        /// <summary>
    /// Property CreatedTime mapping to Signer.CreatedTime
    /// </summary>
    public virtual System.DateTime? CreatedTime { get; set; }
    
        /// <summary>
    /// Property ModifiedTime mapping to Signer.ModifiedTime
    /// </summary>
    public virtual System.DateTime? ModifiedTime { get; set; }
    
        /// <summary>
    /// Property CreatedById mapping to Signer.CreatedById
    /// </summary>
    public virtual int? CreatedById { get; set; }
    
        /// <summary>
    /// Property ModifiedById mapping to Signer.ModifiedById
    /// </summary>
    public virtual int? ModifiedById { get; set; }
    
        /// <summary>
    /// Property Active mapping to Signer.Active
    /// </summary>
    public virtual bool Active { get; set; }
    
        /// <summary>
    /// Property RowVersion mapping to Signer.RowVersion
    /// </summary>
    public virtual byte[] RowVersion { get; set; }
    
    
    
  }
}