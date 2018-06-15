using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Common.Entities;
using Newtonsoft.Json;

namespace NHTest.Common.Domain.Entities
{
  /// <summary>
  /// This entity maps to 'Order'.
  /// </summary>
  public partial class Order
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
    
    #endregion
    
    #region "Outgoing References"
    #endregion
    
    #region "Incoming References"
    #endregion
    

      public static readonly int Id_MaxLenth = 0;
    
      public static readonly int CustomerName_MaxLenth = 200;
    
      public static readonly int OrderTotal_MaxLenth = 0;
      }
}