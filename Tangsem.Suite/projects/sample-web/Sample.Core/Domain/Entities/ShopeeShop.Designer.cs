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
  /// This entity maps to 'ShopeeShop'.
  /// </summary>
    public partial class ShopeeShop : AuditableEntity
  {
    /// <summary>
    /// The default constructor for ShopeeShop class.
    /// </summary>
    public ShopeeShop()
    {
      this.ShopeeShopUsers = new List<ShopeeShopUser>();
    }
  
    
    #region "Basic Columns"

        /// <summary>
    /// Property Id mapping to ShopeeShop.Id.
    /// </summary>
    public virtual int Id { get; set; }

        /// <summary>
    /// Property ShopId mapping to ShopeeShop.ShopId.
    /// </summary>
    public virtual string ShopId { get; set; }

        /// <summary>
    /// Property ShopName mapping to ShopeeShop.ShopName.
    /// </summary>
    public virtual string ShopName { get; set; }

        /// <summary>
    /// Property Status mapping to ShopeeShop.Status.
    /// </summary>
    public virtual string Status { get; set; }

    
    #endregion
    
    #region "Outgoing References"
    
    #endregion
    
    #region "Incoming References"
    /// <summary>
    /// Field for the child list of Ref: FK_19FE0267.
    /// </summary>
    public virtual IList<ShopeeShopUser> ShopeeShopUsers { get; set; }
    
    /// <summary>
    /// Add ShopeeShopUser entity to ShopeeShopUsers.
    /// </summary>
    /// <param name="shopeeShopUser">
    ///	The ShopeeShopUser entity.
    /// </param>
    public virtual void AddToShopeeShopUsers(ShopeeShopUser shopeeShopUser)
    {
      shopeeShopUser.ShopeeShop = this;
      this.ShopeeShopUsers.Add(shopeeShopUser);
    }

    #endregion
    
        
    public static readonly int Id_MaxLenth = 0;
    
        
    public static readonly int ShopId_MaxLenth = 50;
    
        
    public static readonly int ShopName_MaxLenth = 500;
    
        
    public static readonly int Status_MaxLenth = 200;
    
        
    public static readonly int CreatedTime_MaxLenth = 0;
    
        
    public static readonly int ModifiedTime_MaxLenth = 0;
    
        
    public static readonly int CreatedById_MaxLenth = 0;
    
        
    public static readonly int ModifiedById_MaxLenth = 0;
    
        
    public static readonly int Active_MaxLenth = 0;
    
    
  }
}