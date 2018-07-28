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
  public partial class Order : IAuditableEntity
  {

    /// <summary>
    /// The property name 'Id'. It matches the property to column 'Id'.
    /// </summary>
    public static readonly string Prop_Id = "Id";
    
    /// <summary>
    /// The lamda expression for Id.
    /// </summary>
    public static readonly Expression<Func<Order, object>> Expr_Id = x => x.Id;
    
    /// <summary>
    /// The property name 'CustomerName'. It matches the property to column 'CustomerName'.
    /// </summary>
    public static readonly string Prop_CustomerName = "CustomerName";
    
    /// <summary>
    /// The lamda expression for CustomerName.
    /// </summary>
    public static readonly Expression<Func<Order, object>> Expr_CustomerName = x => x.CustomerName;
    
    /// <summary>
    /// The property name 'OrderTotal'. It matches the property to column 'OrderTotal'.
    /// </summary>
    public static readonly string Prop_OrderTotal = "OrderTotal";
    
    /// <summary>
    /// The lamda expression for OrderTotal.
    /// </summary>
    public static readonly Expression<Func<Order, object>> Expr_OrderTotal = x => x.OrderTotal;
    
    /// <summary>
    /// The property name 'CreatedById'. It matches the property to column 'CreatedById'.
    /// </summary>
    public static readonly string Prop_CreatedById = "CreatedById";
    
    /// <summary>
    /// The lamda expression for CreatedById.
    /// </summary>
    public static readonly Expression<Func<Order, object>> Expr_CreatedById = x => x.CreatedById;
    
    /// <summary>
    /// The property name 'ModifiedById'. It matches the property to column 'ModifiedById'.
    /// </summary>
    public static readonly string Prop_ModifiedById = "ModifiedById";
    
    /// <summary>
    /// The lamda expression for ModifiedById.
    /// </summary>
    public static readonly Expression<Func<Order, object>> Expr_ModifiedById = x => x.ModifiedById;
    
    /// <summary>
    /// The property name 'CreatedTime'. It matches the property to column 'CreatedTime'.
    /// </summary>
    public static readonly string Prop_CreatedTime = "CreatedTime";
    
    /// <summary>
    /// The lamda expression for CreatedTime.
    /// </summary>
    public static readonly Expression<Func<Order, object>> Expr_CreatedTime = x => x.CreatedTime;
    
    /// <summary>
    /// The property name 'ModifiedTime'. It matches the property to column 'ModifiedTime'.
    /// </summary>
    public static readonly string Prop_ModifiedTime = "ModifiedTime";
    
    /// <summary>
    /// The lamda expression for ModifiedTime.
    /// </summary>
    public static readonly Expression<Func<Order, object>> Expr_ModifiedTime = x => x.ModifiedTime;
    
    /// <summary>
    /// The property name 'Active'. It matches the property to column 'Active'.
    /// </summary>
    public static readonly string Prop_Active = "Active";
    
    /// <summary>
    /// The lamda expression for Active.
    /// </summary>
    public static readonly Expression<Func<Order, object>> Expr_Active = x => x.Active;
        

    /// <summary>
    /// The property name 'Customer'. It is for the reference 'FK_Order_Customer'.
    /// </summary>
    public static readonly string Prop_Customer  = "Customer";

    /// <summary>
    /// The lamda expression for Customer.
    /// </summary>
    public static readonly Expression<Func<Order, object>> Expr_Customer = x => x.Customer;
    
    /// <summary>
    /// The property name 'Product'. It is for the reference 'FK_Order_Product'.
    /// </summary>
    public static readonly string Prop_Product  = "Product";

    /// <summary>
    /// The lamda expression for Product.
    /// </summary>
    public static readonly Expression<Func<Order, object>> Expr_Product = x => x.Product;
        
    
    
    /// <summary>
    /// The default constructor for Order class.
    /// </summary>
    public Order()
    {
    }
  

    #region "Basic Columns"


    /// <summary>
    /// Property Id mapping to Order.Id
    /// </summary>
    [JsonProperty("id")]   
    public virtual int Id { get; set; }
    
    /// <summary>
    /// Property CustomerName mapping to Order.CustomerName
    /// </summary>
    [JsonProperty("customerName")]   
    public virtual string CustomerName { get; set; }
    
    /// <summary>
    /// Property OrderTotal mapping to Order.OrderTotal
    /// </summary>
    [JsonProperty("orderTotal")]   
    public virtual decimal OrderTotal { get; set; }
    
    /// <summary>
    /// Property CreatedById mapping to Order.CreatedById
    /// </summary>
    [JsonProperty("createdById")]   
    public virtual int? CreatedById { get; set; }
    
    /// <summary>
    /// Property ModifiedById mapping to Order.ModifiedById
    /// </summary>
    [JsonProperty("modifiedById")]   
    public virtual int? ModifiedById { get; set; }
    
    /// <summary>
    /// Property CreatedTime mapping to Order.CreatedTime
    /// </summary>
    [JsonProperty("createdTime")]   
    public virtual System.DateTime? CreatedTime { get; set; }
    
    /// <summary>
    /// Property ModifiedTime mapping to Order.ModifiedTime
    /// </summary>
    [JsonProperty("modifiedTime")]   
    public virtual System.DateTime? ModifiedTime { get; set; }
    
    /// <summary>
    /// Property Active mapping to Order.Active
    /// </summary>
    [JsonProperty("active")]   
    public virtual bool? Active { get; set; }
    
    #endregion
    
    #region "Outgoing References"

    /// <summary>
    /// Gets or sets reference to Customer. ReferenceName: FK_Order_Customer.
    /// </summary>
    public virtual Customer Customer { get; set; }
    
    /// <summary>
    /// Gets or sets reference to Product. ReferenceName: FK_Order_Product.
    /// </summary>
    public virtual Product Product { get; set; }
        #endregion
    
    #region "Incoming References"
    #endregion
    

      public static readonly int Id_MaxLenth = 0;
    
      public static readonly int CustomerName_MaxLenth = 200;
    
      public static readonly int ProductId_MaxLenth = 0;
    
      public static readonly int CustomerId_MaxLenth = 0;
    
      public static readonly int OrderTotal_MaxLenth = 0;
    
      public static readonly int CreatedById_MaxLenth = 0;
    
      public static readonly int ModifiedById_MaxLenth = 0;
    
      public static readonly int CreatedTime_MaxLenth = 0;
    
      public static readonly int ModifiedTime_MaxLenth = 0;
    
      public static readonly int Active_MaxLenth = 0;
      }
}