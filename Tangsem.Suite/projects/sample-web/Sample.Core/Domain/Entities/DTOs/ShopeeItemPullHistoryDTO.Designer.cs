using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Identity.Domain.Entities;

namespace Sample.Core.Domain.Entities.DTOs
{
  public partial class ShopeeItemPullHistoryDTO
  {	
    /// <summary>
    /// The default constructor for ShopeeItemPullHistoryDTO class.
    /// </summary>
    public ShopeeItemPullHistoryDTO()
    {
    }

        /// <summary>
    /// Property Id mapping to ShopeeItemPullHistory.Id
    /// </summary>
    public virtual int Id { get; set; }
    
        /// <summary>
    /// Property RowVersion mapping to ShopeeItemPullHistory.RowVersion
    /// </summary>
    public virtual byte[] RowVersion { get; set; }
    
        /// <summary>
    /// Property RawResponse mapping to ShopeeItemPullHistory.RawResponse
    /// </summary>
    public virtual string RawResponse { get; set; }
    
        /// <summary>
    /// Property CreatedTime mapping to ShopeeItemPullHistory.CreatedTime
    /// </summary>
    public virtual System.DateTime? CreatedTime { get; set; }
    
        /// <summary>
    /// Property ModifiedTime mapping to ShopeeItemPullHistory.ModifiedTime
    /// </summary>
    public virtual System.DateTime? ModifiedTime { get; set; }
    
        /// <summary>
    /// Property CreatedById mapping to ShopeeItemPullHistory.CreatedById
    /// </summary>
    public virtual int? CreatedById { get; set; }
    
        /// <summary>
    /// Property ModifiedById mapping to ShopeeItemPullHistory.ModifiedById
    /// </summary>
    public virtual int? ModifiedById { get; set; }
    
        /// <summary>
    /// Property Active mapping to ShopeeItemPullHistory.Active
    /// </summary>
    public virtual bool Active { get; set; }
    
        /// <summary>
    /// Property ShopeeShopUserId mapping to ShopeeItemPullHistory.ShopeeShopUserId
    /// </summary>
    public virtual int ShopeeShopUserId { get; set; }
    
    
    
  }
}