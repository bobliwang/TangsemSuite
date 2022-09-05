using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Common.Entities;
using Newtonsoft.Json;

using Tangsem.Identity.Domain.Entities;
namespace Sample.Core.Domain.Entities
{
  /// <summary>
  /// This entity maps to 'Signer'.
  /// </summary>
    public partial class Signer : AuditableEntity, IVersioned
  {
    /// <summary>
    /// The default constructor for Signer class.
    /// </summary>
    public Signer()
    {
      this.FormSigners = new List<FormSigner>();
    }
  
    
    #region "Basic Columns"

        /// <summary>
    /// Property Id mapping to Signer.Id.
    /// </summary>
    public virtual int Id { get; set; }

        /// <summary>
    /// Property FirstName mapping to Signer.FirstName.
    /// </summary>
    public virtual string FirstName { get; set; }

        /// <summary>
    /// Property LastName mapping to Signer.LastName.
    /// </summary>
    public virtual string LastName { get; set; }

        /// <summary>
    /// Property Email mapping to Signer.Email.
    /// </summary>
    public virtual string Email { get; set; }

        /// <summary>
    /// Property RowVersion mapping to Signer.RowVersion.
    /// </summary>
    public virtual byte[] RowVersion { get; set; }

    
    #endregion
    
    #region "Outgoing References"
    
    #endregion
    
    #region "Incoming References"
    /// <summary>
    /// Field for the child list of Ref: FK_FormSigner_Signer.
    /// </summary>
    public virtual IList<FormSigner> FormSigners { get; set; }
    
    /// <summary>
    /// Add FormSigner entity to FormSigners.
    /// </summary>
    /// <param name="formSigner">
    ///	The FormSigner entity.
    /// </param>
    public virtual void AddToFormSigners(FormSigner formSigner)
    {
      formSigner.Signer = this;
      this.FormSigners.Add(formSigner);
    }

    #endregion
    
        
    public static readonly int Id_MaxLenth = 0;
    
        
    public static readonly int FirstName_MaxLenth = 50;
    
        
    public static readonly int LastName_MaxLenth = 50;
    
        
    public static readonly int Email_MaxLenth = 50;
    
        
    public static readonly int CreatedTime_MaxLenth = 0;
    
        
    public static readonly int ModifiedTime_MaxLenth = 0;
    
        
    public static readonly int CreatedById_MaxLenth = 0;
    
        
    public static readonly int ModifiedById_MaxLenth = 0;
    
        
    public static readonly int Active_MaxLenth = 0;
    
        
    public static readonly int RowVersion_MaxLenth = 0;
    
    
  }
}