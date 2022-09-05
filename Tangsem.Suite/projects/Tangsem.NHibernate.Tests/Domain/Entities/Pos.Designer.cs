using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Common.Entities;
using Newtonsoft.Json;

namespace Tangsem.NHibernate.Tests.Domain.Entities
{
  /// <summary>
  /// This entity maps to 'Pos'.
  /// </summary>
  public partial class Pos : AuditableEntity
  {
    /// <summary>
    /// The default constructor for Pos class.
    /// </summary>
    public Pos()
    {
    }
  
    
    #region "Basic Columns"

        /// <summary>
    /// Property Id mapping to Pos.Id.
    /// </summary>
    public virtual int Id { get; set; }

        /// <summary>
    /// Property Name mapping to Pos.Name.
    /// </summary>
    public virtual string Name { get; set; }

        /// <summary>
    /// Property StoreId mapping to Pos.StoreId.
    /// </summary>
    public virtual int? StoreId { get; set; }

    
    #endregion
    
    #region "Outgoing References"
    
    #endregion
    
    #region "Incoming References"

    #endregion
    
        
    public static readonly int Id_MaxLenth = 0;
    
        
    public static readonly int Name_MaxLenth = 50;
    
        
    public static readonly int StoreId_MaxLenth = 0;
    
        
    public static readonly int CreatedById_MaxLenth = 0;
    
        
    public static readonly int ModifiedById_MaxLenth = 0;
    
        
    public static readonly int CreatedTime_MaxLenth = 0;
    
        
    public static readonly int ModifiedTime_MaxLenth = 0;
    
        
    public static readonly int Active_MaxLenth = 0;
    
    
  }
}