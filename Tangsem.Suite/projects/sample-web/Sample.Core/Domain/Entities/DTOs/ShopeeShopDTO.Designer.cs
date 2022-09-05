using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Identity.Domain.Entities;

namespace Sample.Core.Domain.Entities.DTOs
{
  public partial class ShopeeShopDTO
  {	
    /// <summary>
    /// The default constructor for ShopeeShopDTO class.
    /// </summary>
    public ShopeeShopDTO()
    {
    }

        /// <summary>
    /// Property Id mapping to ShopeeShop.Id
    /// </summary>
    public virtual int Id { get; set; }
    
        /// <summary>
    /// Property ShopId mapping to ShopeeShop.ShopId
    /// </summary>
    public virtual string ShopId { get; set; }
    
        /// <summary>
    /// Property ShopName mapping to ShopeeShop.ShopName
    /// </summary>
    public virtual string ShopName { get; set; }
    
        /// <summary>
    /// Property Status mapping to ShopeeShop.Status
    /// </summary>
    public virtual string Status { get; set; }
    
        /// <summary>
    /// Property CreatedTime mapping to ShopeeShop.CreatedTime
    /// </summary>
    public virtual System.DateTime? CreatedTime { get; set; }
    
        /// <summary>
    /// Property ModifiedTime mapping to ShopeeShop.ModifiedTime
    /// </summary>
    public virtual System.DateTime? ModifiedTime { get; set; }
    
        /// <summary>
    /// Property CreatedById mapping to ShopeeShop.CreatedById
    /// </summary>
    public virtual int? CreatedById { get; set; }
    
        /// <summary>
    /// Property ModifiedById mapping to ShopeeShop.ModifiedById
    /// </summary>
    public virtual int? ModifiedById { get; set; }
    
        /// <summary>
    /// Property Active mapping to ShopeeShop.Active
    /// </summary>
    public virtual bool Active { get; set; }
    
    
    
  }
}