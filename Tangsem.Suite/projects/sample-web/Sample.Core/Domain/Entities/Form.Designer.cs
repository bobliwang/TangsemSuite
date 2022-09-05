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
  /// This entity maps to 'Form'.
  /// </summary>
    public partial class Form : AuditableEntity, IVersioned
  {
    /// <summary>
    /// The default constructor for Form class.
    /// </summary>
    public Form()
    {
      this.FormSigners = new List<FormSigner>();
    }
  
    
    #region "Basic Columns"

        /// <summary>
    /// Property Id mapping to Form.Id.
    /// </summary>
    public virtual int Id { get; set; }

        /// <summary>
    /// Property Title mapping to Form.Title.
    /// </summary>
    public virtual string Title { get; set; }

        /// <summary>
    /// Property FormJson mapping to Form.FormJson.
    /// </summary>
    public virtual byte[] FormJson { get; set; }

        /// <summary>
    /// Property RowVersion mapping to Form.RowVersion.
    /// </summary>
    public virtual byte[] RowVersion { get; set; }

    
    #endregion
    
    #region "Outgoing References"
        /// <summary>
    /// Gets or sets reference to AspNetUser. ReferenceName: FK_Form_AspNetUser.
    /// </summary>
    public virtual AspNetUser AspNetUser { get; set; }

    
    #endregion
    
    #region "Incoming References"
    /// <summary>
    /// Field for the child list of Ref: FK_FormSigner_Form.
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
      formSigner.Form = this;
      this.FormSigners.Add(formSigner);
    }

    #endregion
    
        
    public static readonly int Id_MaxLenth = 0;
    
        
    public static readonly int Title_MaxLenth = 250;
    
        
    public static readonly int FormJson_MaxLenth = -1;
    
        
    public static readonly int CreatedTime_MaxLenth = 0;
    
        
    public static readonly int ModifiedTime_MaxLenth = 0;
    
        
    public static readonly int CreatedById_MaxLenth = 0;
    
        
    public static readonly int ModifiedById_MaxLenth = 0;
    
        
    public static readonly int Active_MaxLenth = 0;
    
        
    public static readonly int AspNetUserId_MaxLenth = 0;
    
        
    public static readonly int RowVersion_MaxLenth = 0;
    
    
  }
}