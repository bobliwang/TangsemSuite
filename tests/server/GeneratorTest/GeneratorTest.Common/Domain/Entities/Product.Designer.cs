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
  public partial class Product : AuditableEntity
  {
    /// <summary>
    /// The default constructor for Product class.
    /// </summary>
    public Product()
    {
      this.Orders = new List<Order>();
    }
  
        
    /// <summary>
    /// Property SpecsJson mapping to Product.SpecsJson.
    /// JSON COLUMN!
    /// </summary>
    public virtual GeneratorTest.Common.Domain.ViewModels.ProductSpec[] SpecsJson { get; set; }
   
    
    #region "Basic Columns"

        /// <summary>
    /// Property Id mapping to Product.Id.
    /// </summary>
    public virtual int Id { get; set; }

        /// <summary>
    /// Property Name mapping to Product.Name.
    /// </summary>
    public virtual string Name { get; set; }

        /// <summary>
    /// Property UnitPrice mapping to Product.UnitPrice.
    /// </summary>
    public virtual decimal UnitPrice { get; set; }

    
    #endregion
    
    #region "Outgoing References"
    
    #endregion
    
    #region "Incoming References"
    /// <summary>
    /// Field for the child list of Ref: FKDB190C6593CBF3E5.
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