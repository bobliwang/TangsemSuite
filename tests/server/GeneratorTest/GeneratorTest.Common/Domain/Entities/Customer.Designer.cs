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
  public partial class Customer : IAuditableEntity
  {

    /// <summary>
    /// The property name 'CustomerId'. It matches the property to column 'CustomerId'.
    /// </summary>
    public static readonly string Prop_CustomerId = "CustomerId";
    
    /// <summary>
    /// The lamda expression for CustomerId.
    /// </summary>
    public static readonly Expression<Func<Customer, object>> Expr_CustomerId = x => x.CustomerId;
    
    /// <summary>
    /// The property name 'CustomerName'. It matches the property to column 'CustomerName'.
    /// </summary>
    public static readonly string Prop_CustomerName = "CustomerName";
    
    /// <summary>
    /// The lamda expression for CustomerName.
    /// </summary>
    public static readonly Expression<Func<Customer, object>> Expr_CustomerName = x => x.CustomerName;
    
    /// <summary>
    /// The property name 'CreatedById'. It matches the property to column 'CreatedById'.
    /// </summary>
    public static readonly string Prop_CreatedById = "CreatedById";
    
    /// <summary>
    /// The lamda expression for CreatedById.
    /// </summary>
    public static readonly Expression<Func<Customer, object>> Expr_CreatedById = x => x.CreatedById;
    
    /// <summary>
    /// The property name 'ModifiedById'. It matches the property to column 'ModifiedById'.
    /// </summary>
    public static readonly string Prop_ModifiedById = "ModifiedById";
    
    /// <summary>
    /// The lamda expression for ModifiedById.
    /// </summary>
    public static readonly Expression<Func<Customer, object>> Expr_ModifiedById = x => x.ModifiedById;
    
    /// <summary>
    /// The property name 'CreatedTime'. It matches the property to column 'CreatedTime'.
    /// </summary>
    public static readonly string Prop_CreatedTime = "CreatedTime";
    
    /// <summary>
    /// The lamda expression for CreatedTime.
    /// </summary>
    public static readonly Expression<Func<Customer, object>> Expr_CreatedTime = x => x.CreatedTime;
    
    /// <summary>
    /// The property name 'ModifiedTime'. It matches the property to column 'ModifiedTime'.
    /// </summary>
    public static readonly string Prop_ModifiedTime = "ModifiedTime";
    
    /// <summary>
    /// The lamda expression for ModifiedTime.
    /// </summary>
    public static readonly Expression<Func<Customer, object>> Expr_ModifiedTime = x => x.ModifiedTime;
    
    /// <summary>
    /// The property name 'Active'. It matches the property to column 'Active'.
    /// </summary>
    public static readonly string Prop_Active = "Active";
    
    /// <summary>
    /// The lamda expression for Active.
    /// </summary>
    public static readonly Expression<Func<Customer, object>> Expr_Active = x => x.Active;
        

    /// <summary>
    /// The property name 'Store'. It is for the reference 'FK_Customer_Store'.
    /// </summary>
    public static readonly string Prop_Store  = "Store";

    /// <summary>
    /// The lamda expression for Store.
    /// </summary>
    public static readonly Expression<Func<Customer, object>> Expr_Store = x => x.Store;
        
    
    
    /// <summary>
    /// The default constructor for Customer class.
    /// </summary>
    public Customer()
    {

        this.Orders = new List<Order>();
            }
  

    #region "Basic Columns"


    /// <summary>
    /// Property CustomerId mapping to Customer.CustomerId
    /// </summary>
    [JsonProperty("customerId")]   
    public virtual System.Guid CustomerId { get; set; } = System.Guid.NewGuid(); 
    
    /// <summary>
    /// Property CustomerName mapping to Customer.CustomerName
    /// </summary>
    [JsonProperty("customerName")]   
    public virtual string CustomerName { get; set; }
    
    /// <summary>
    /// Property CreatedById mapping to Customer.CreatedById
    /// </summary>
    [JsonProperty("createdById")]   
    public virtual int? CreatedById { get; set; }
    
    /// <summary>
    /// Property ModifiedById mapping to Customer.ModifiedById
    /// </summary>
    [JsonProperty("modifiedById")]   
    public virtual int? ModifiedById { get; set; }
    
    /// <summary>
    /// Property CreatedTime mapping to Customer.CreatedTime
    /// </summary>
    [JsonProperty("createdTime")]   
    public virtual System.DateTime? CreatedTime { get; set; }
    
    /// <summary>
    /// Property ModifiedTime mapping to Customer.ModifiedTime
    /// </summary>
    [JsonProperty("modifiedTime")]   
    public virtual System.DateTime? ModifiedTime { get; set; }
    
    /// <summary>
    /// Property Active mapping to Customer.Active
    /// </summary>
    [JsonProperty("active")]   
    public virtual bool? Active { get; set; }
    
    #endregion
    
    #region "Outgoing References"

    /// <summary>
    /// Gets or sets reference to Store. ReferenceName: FK_Customer_Store.
    /// </summary>
    public virtual Store Store { get; set; }
        #endregion
    
    #region "Incoming References"

    /// <summary>
    /// Field for the child list of Ref: FK_Order_Customer.
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
    
      public static readonly int StoreId_MaxLenth = 0;
    
      public static readonly int CreatedById_MaxLenth = 0;
    
      public static readonly int ModifiedById_MaxLenth = 0;
    
      public static readonly int CreatedTime_MaxLenth = 0;
    
      public static readonly int ModifiedTime_MaxLenth = 0;
    
      public static readonly int Active_MaxLenth = 0;
      }
}