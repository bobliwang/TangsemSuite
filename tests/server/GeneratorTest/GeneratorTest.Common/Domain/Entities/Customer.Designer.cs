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
  /// This entity maps to 'Customer'.
  /// </summary>
  public partial class Customer : AuditableEntity
  {
    /// <summary>
    /// The default constructor for Customer class.
    /// </summary>
    public Customer()
    {
      this.Orders = new List<Order>();
    }
  
    
    #region "Basic Columns"

        /// <summary>
    /// Property CustomerId mapping to Customer.CustomerId.
    /// </summary>
    public virtual System.Guid CustomerId { get; set; } = System.Guid.NewGuid();

        /// <summary>
    /// Property CustomerName mapping to Customer.CustomerName.
    /// </summary>
    public virtual string CustomerName { get; set; }

        /// <summary>
    /// Property RowVersion mapping to Customer.RowVersion.
    /// </summary>
    public virtual byte[] RowVersion { get; set; }

    
    #endregion
    
    #region "Outgoing References"
        /// <summary>
    /// Gets or sets reference to Store. ReferenceName: FK156F447FBED2C858.
    /// </summary>
    public virtual Store Store { get; set; }

    
    #endregion
    
    #region "Incoming References"
    /// <summary>
    /// Field for the child list of Ref: FKDB190C6555361DC8.
    /// </summary>
    public virtual IList<Order> Orders { get; set; }
    
    /// <summary>
    /// Add Order entity to Orders.
    /// </summary>
    /// <param name="order">
    ///	The Order entity.
    /// </param>
    public virtual void AddToOrders(Order order)
    {
      order.Customer = this;
      this.Orders.Add(order);
    }

    #endregion
    
        
    public static readonly int CustomerId_MaxLenth = 0;
    
        
    public static readonly int CustomerName_MaxLenth = 50;
    
        
    public static readonly int CreatedById_MaxLenth = 0;
    
        
    public static readonly int ModifiedById_MaxLenth = 0;
    
        
    public static readonly int CreatedTime_MaxLenth = 0;
    
        
    public static readonly int ModifiedTime_MaxLenth = 0;
    
        
    public static readonly int Active_MaxLenth = 0;
    
        
    public static readonly int StoreId_MaxLenth = 0;
    
        
    public static readonly int RowVersion_MaxLenth = 0;
    
    
  }
}