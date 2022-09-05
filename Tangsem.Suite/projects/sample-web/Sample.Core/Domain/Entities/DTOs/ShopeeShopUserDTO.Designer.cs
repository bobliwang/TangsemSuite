using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Identity.Domain.Entities;

namespace Sample.Core.Domain.Entities.DTOs
{
  public partial class ShopeeShopUserDTO
  {	
    /// <summary>
    /// The default constructor for ShopeeShopUserDTO class.
    /// </summary>
    public ShopeeShopUserDTO()
    {
    }

        /// <summary>
    /// Property Id mapping to ShopeeShopUser.Id
    /// </summary>
    public virtual int Id { get; set; }
    
        /// <summary>
    /// Property AspNetUserId mapping to ShopeeShopUser.AspNetUserId
    /// </summary>
    public virtual int AspNetUserId { get; set; }
    
        /// <summary>
    /// Property LastLoginTime mapping to ShopeeShopUser.LastLoginTime
    /// </summary>
    public virtual System.DateTime? LastLoginTime { get; set; }
    
        /// <summary>
    /// Property CreatedTime mapping to ShopeeShopUser.CreatedTime
    /// </summary>
    public virtual System.DateTime? CreatedTime { get; set; }
    
        /// <summary>
    /// Property ModifiedTime mapping to ShopeeShopUser.ModifiedTime
    /// </summary>
    public virtual System.DateTime? ModifiedTime { get; set; }
    
        /// <summary>
    /// Property CreatedById mapping to ShopeeShopUser.CreatedById
    /// </summary>
    public virtual int? CreatedById { get; set; }
    
        /// <summary>
    /// Property ModifiedById mapping to ShopeeShopUser.ModifiedById
    /// </summary>
    public virtual int? ModifiedById { get; set; }
    
        /// <summary>
    /// Property Active mapping to ShopeeShopUser.Active
    /// </summary>
    public virtual bool Active { get; set; }
    
        /// <summary>
    /// Property ShopeeShopId mapping to ShopeeShopUser.ShopeeShopId
    /// </summary>
    public virtual int ShopeeShopId { get; set; }
    
    
    
  }
}