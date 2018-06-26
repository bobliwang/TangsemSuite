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
  /// This entity maps to 'Product'.
  /// </summary>
  public partial class Product : IAuditableEntity
  {

    /// <summary>
    /// The property name 'Id'. It matches the property to column 'Id'.
    /// </summary>
    public static readonly string Prop_Id = "Id";
    
    /// <summary>
    /// The lamda expression for Id.
    /// </summary>
    public static readonly Expression<Func<Product, object>> Expr_Id = x => x.Id;
    
    /// <summary>
    /// The property name 'Name'. It matches the property to column 'Name'.
    /// </summary>
    public static readonly string Prop_Name = "Name";
    
    /// <summary>
    /// The lamda expression for Name.
    /// </summary>
    public static readonly Expression<Func<Product, object>> Expr_Name = x => x.Name;
    
    /// <summary>
    /// The property name 'UnitPrice'. It matches the property to column 'UnitPrice'.
    /// </summary>
    public static readonly string Prop_UnitPrice = "UnitPrice";
    
    /// <summary>
    /// The lamda expression for UnitPrice.
    /// </summary>
    public static readonly Expression<Func<Product, object>> Expr_UnitPrice = x => x.UnitPrice;
    
    /// <summary>
    /// The property name 'SpecsJson'. It matches the property to column 'SpecsJson'.
    /// </summary>
    public static readonly string Prop_SpecsJson = "SpecsJson";
    
    /// <summary>
    /// The lamda expression for SpecsJson.
    /// </summary>
    public static readonly Expression<Func<Product, object>> Expr_SpecsJson = x => x.SpecsJson;
    
    /// <summary>
    /// The property name 'CreatedById'. It matches the property to column 'CreatedById'.
    /// </summary>
    public static readonly string Prop_CreatedById = "CreatedById";
    
    /// <summary>
    /// The lamda expression for CreatedById.
    /// </summary>
    public static readonly Expression<Func<Product, object>> Expr_CreatedById = x => x.CreatedById;
    
    /// <summary>
    /// The property name 'CreatedTime'. It matches the property to column 'CreatedTime'.
    /// </summary>
    public static readonly string Prop_CreatedTime = "CreatedTime";
    
    /// <summary>
    /// The lamda expression for CreatedTime.
    /// </summary>
    public static readonly Expression<Func<Product, object>> Expr_CreatedTime = x => x.CreatedTime;
    
    /// <summary>
    /// The property name 'ModifiedById'. It matches the property to column 'ModifiedById'.
    /// </summary>
    public static readonly string Prop_ModifiedById = "ModifiedById";
    
    /// <summary>
    /// The lamda expression for ModifiedById.
    /// </summary>
    public static readonly Expression<Func<Product, object>> Expr_ModifiedById = x => x.ModifiedById;
    
    /// <summary>
    /// The property name 'ModifiedTime'. It matches the property to column 'ModifiedTime'.
    /// </summary>
    public static readonly string Prop_ModifiedTime = "ModifiedTime";
    
    /// <summary>
    /// The lamda expression for ModifiedTime.
    /// </summary>
    public static readonly Expression<Func<Product, object>> Expr_ModifiedTime = x => x.ModifiedTime;
    
    /// <summary>
    /// The property name 'Active'. It matches the property to column 'Active'.
    /// </summary>
    public static readonly string Prop_Active = "Active";
    
    /// <summary>
    /// The lamda expression for Active.
    /// </summary>
    public static readonly Expression<Func<Product, object>> Expr_Active = x => x.Active;
        
    
    
    
    /// <summary>
    /// The default constructor for Product class.
    /// </summary>
    public Product()
    {

        this.Orders = new List<Order>();
            }
  

    /// <summary>
    /// Property SpecsJson mapping to Product.SpecsJson. JSON COLUMN!
    /// </summary>
    [JsonProperty("specsJson")]   
    public virtual GeneratorTest.Common.Domain.ViewModels.ProductSpec[] SpecsJson { get; set; }
    
    #region "Basic Columns"


    /// <summary>
    /// Property Id mapping to Product.Id
    /// </summary>
    [JsonProperty("id")]   
    public virtual int Id { get; set; }
    
    /// <summary>
    /// Property Name mapping to Product.Name
    /// </summary>
    [JsonProperty("name")]   
    public virtual string Name { get; set; }
    
    /// <summary>
    /// Property UnitPrice mapping to Product.UnitPrice
    /// </summary>
    [JsonProperty("unitPrice")]   
    public virtual decimal UnitPrice { get; set; }
    
    /// <summary>
    /// Property CreatedById mapping to Product.CreatedById
    /// </summary>
    [JsonProperty("createdById")]   
    public virtual int? CreatedById { get; set; }
    
    /// <summary>
    /// Property CreatedTime mapping to Product.CreatedTime
    /// </summary>
    [JsonProperty("createdTime")]   
    public virtual System.DateTime? CreatedTime { get; set; }
    
    /// <summary>
    /// Property ModifiedById mapping to Product.ModifiedById
    /// </summary>
    [JsonProperty("modifiedById")]   
    public virtual int? ModifiedById { get; set; }
    
    /// <summary>
    /// Property ModifiedTime mapping to Product.ModifiedTime
    /// </summary>
    [JsonProperty("modifiedTime")]   
    public virtual System.DateTime? ModifiedTime { get; set; }
    
    /// <summary>
    /// Property Active mapping to Product.Active
    /// </summary>
    [JsonProperty("active")]   
    public virtual bool? Active { get; set; }
    
    #endregion
    
    #region "Outgoing References"
    #endregion
    
    #region "Incoming References"

    /// <summary>
    /// Field for the child list of Ref: FK_Order_Product.
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
      order.Product = this;
      this.Orders.Add(order);
    }
        #endregion
    

      public static readonly int Id_MaxLenth = 0;
    
      public static readonly int Name_MaxLenth = 500;
    
      public static readonly int UnitPrice_MaxLenth = 0;
    
      public static readonly int SpecsJson_MaxLenth = -1;
    
      public static readonly int CreatedById_MaxLenth = 0;
    
      public static readonly int CreatedTime_MaxLenth = 0;
    
      public static readonly int ModifiedById_MaxLenth = 0;
    
      public static readonly int ModifiedTime_MaxLenth = 0;
    
      public static readonly int Active_MaxLenth = 0;
      }
}