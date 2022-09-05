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
  /// This entity maps to 'FormSigner'.
  /// </summary>
    public partial class FormSigner : AuditableEntity
  {
    /// <summary>
    /// The default constructor for FormSigner class.
    /// </summary>
    public FormSigner()
    {
    }
  
    
    #region "Basic Columns"

        /// <summary>
    /// Property Id mapping to FormSigner.Id.
    /// </summary>
    public virtual int Id { get; set; }

    
    #endregion
    
    #region "Outgoing References"
        /// <summary>
    /// Gets or sets reference to Form. ReferenceName: FK_FormSigner_Form.
    /// </summary>
    public virtual Form Form { get; set; }

        /// <summary>
    /// Gets or sets reference to Signer. ReferenceName: FK_FormSigner_Signer.
    /// </summary>
    public virtual Signer Signer { get; set; }

    
    #endregion
    
    #region "Incoming References"

    #endregion
    
        
    public static readonly int Id_MaxLenth = 0;
    
        
    public static readonly int FormId_MaxLenth = 0;
    
        
    public static readonly int SignerId_MaxLenth = 0;
    
        
    public static readonly int CreatedTime_MaxLenth = 0;
    
        
    public static readonly int ModifiedTime_MaxLenth = 0;
    
        
    public static readonly int CreatedById_MaxLenth = 0;
    
        
    public static readonly int ModifiedById_MaxLenth = 0;
    
        
    public static readonly int Active_MaxLenth = 0;
    
    
  }
}