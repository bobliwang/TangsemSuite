using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Common.Entities;
using Newtonsoft.Json;

namespace GeneratorTest.Common.Domain.Entities
{
  /// <summary>
  /// This entity maps to 'Order'.
  /// </summary>
  public partial class Order : AuditableEntity
  {
    /// <summary>
    /// The default constructor for Order class.
    /// </summary>
    public Order()
    {
    }
  
    
    #region "Basic Columns"

        /// <summary>
    /// Property Id mapping to Order.Id.
    /// </summary>
    public virtual int Id { get; set; }

        /// <summary>
    /// Property CustomerName mapping to Order.CustomerName.
    /// </summary>
    public virtual string CustomerName { get; set; }

        /// <summary>
    /// Property OrderTotal mapping to Order.OrderTotal.
    /// </summary>
    public virtual decimal OrderTotal { get; set; }

    
    #endregion
    
    #region "Outgoing References"
        /// <summary>
    /// Gets or sets reference to Customer. ReferenceName: FKDB190C6555361DC8.
    /// </summary>
    public virtual Customer Customer { get; set; }

        /// <summary>
    /// Gets or sets reference to Product. ReferenceName: FKDB190C6593CBF3E5.
    /// </summary>
    public virtual Product Product { get; set; }

    
    #endregion
    
    #region "Incoming References"

    #endregion
    
        
    public static readonly int Id_MaxLenth = 0;
    
        
    public static readonly int CustomerName_MaxLenth = 200;
    
        
    public static readonly int OrderTotal_MaxLenth = 0;
    
        
    public static readonly int CreatedById_MaxLenth = 0;
    
        
    public static readonly int ModifiedById_MaxLenth = 0;
    
        
    public static readonly int CreatedTime_MaxLenth = 0;
    
        
    public static readonly int ModifiedTime_MaxLenth = 0;
    
        
    public static readonly int Active_MaxLenth = 0;
    
        
    public static readonly int CustomerId_MaxLenth = 0;
    
        
    public static readonly int ProductId_MaxLenth = 0;
    
    
  }
}