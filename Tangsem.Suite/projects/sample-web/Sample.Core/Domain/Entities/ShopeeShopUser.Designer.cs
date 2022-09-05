using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Common.Entities;
using Newtonsoft.Json;

using Tangsem.Identity.Domain.Entities;
namespace Sample.Core.Domain.Entities
{
  /// <summary>
  /// This entity maps to 'ShopeeShopUser'.
  /// </summary>
    public partial class ShopeeShopUser : AuditableEntity
  {
    /// <summary>
    /// The default constructor for ShopeeShopUser class.
    /// </summary>
    public ShopeeShopUser()
    {
      this.ShopeeItemPullHistories = new List<ShopeeItemPullHistory>();
    }
  
    
    #region "Basic Columns"

        /// <summary>
    /// Property Id mapping to ShopeeShopUser.Id.
    /// </summary>
    public virtual int Id { get; set; }

        /// <summary>
    /// Property AspNetUserId mapping to ShopeeShopUser.AspNetUserId.
    /// </summary>
    public virtual int AspNetUserId { get; set; }

        /// <summary>
    /// Property LastLoginTime mapping to ShopeeShopUser.LastLoginTime.
    /// </summary>
    public virtual System.DateTime? LastLoginTime { get; set; }

    
    #endregion
    
    #region "Outgoing References"
        /// <summary>
    /// Gets or sets reference to ShopeeShop. ReferenceName: FK_19FE0267.
    /// </summary>
    public virtual ShopeeShop ShopeeShop { get; set; }

    
    #endregion
    
    #region "Incoming References"
    /// <summary>
    /// Field for the child list of Ref: FK_35DE9215.
    /// </summary>
    public virtual IList<ShopeeItemPullHistory> ShopeeItemPullHistories { get; set; }
    
    /// <summary>
    /// Add ShopeeItemPullHistory entity to ShopeeItemPullHistories.
    /// </summary>
    /// <param name="shopeeItemPullHistory">
    ///	The ShopeeItemPullHistory entity.
    /// </param>
    public virtual void AddToShopeeItemPullHistories(ShopeeItemPullHistory shopeeItemPullHistory)
    {
      shopeeItemPullHistory.ShopeeShopUser = this;
      this.ShopeeItemPullHistories.Add(shopeeItemPullHistory);
    }

    #endregion
    
        
    public static readonly int Id_MaxLenth = 0;
    
        
    public static readonly int AspNetUserId_MaxLenth = 0;
    
        
    public static readonly int LastLoginTime_MaxLenth = 0;
    
        
    public static readonly int CreatedTime_MaxLenth = 0;
    
        
    public static readonly int ModifiedTime_MaxLenth = 0;
    
        
    public static readonly int CreatedById_MaxLenth = 0;
    
        
    public static readonly int ModifiedById_MaxLenth = 0;
    
        
    public static readonly int Active_MaxLenth = 0;
    
        
    public static readonly int ShopeeShopId_MaxLenth = 0;
    
    
  }
}