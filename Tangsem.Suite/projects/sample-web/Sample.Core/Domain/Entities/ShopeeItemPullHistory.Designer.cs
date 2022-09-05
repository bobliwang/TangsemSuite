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
  /// This entity maps to 'ShopeeItemPullHistory'.
  /// </summary>
    public partial class ShopeeItemPullHistory : AuditableEntity, IVersioned
  {
    /// <summary>
    /// The default constructor for ShopeeItemPullHistory class.
    /// </summary>
    public ShopeeItemPullHistory()
    {
    }
  
    
    #region "Basic Columns"

        /// <summary>
    /// Property Id mapping to ShopeeItemPullHistory.Id.
    /// </summary>
    public virtual int Id { get; set; }

        /// <summary>
    /// Property RowVersion mapping to ShopeeItemPullHistory.RowVersion.
    /// </summary>
    public virtual byte[] RowVersion { get; set; }

        /// <summary>
    /// Property RawResponse mapping to ShopeeItemPullHistory.RawResponse.
    /// </summary>
    public virtual string RawResponse { get; set; }

    
    #endregion
    
    #region "Outgoing References"
        /// <summary>
    /// Gets or sets reference to ShopeeShopUser. ReferenceName: FK_35DE9215.
    /// </summary>
    public virtual ShopeeShopUser ShopeeShopUser { get; set; }

    
    #endregion
    
    #region "Incoming References"

    #endregion
    
        
    public static readonly int Id_MaxLenth = 0;
    
        
    public static readonly int RowVersion_MaxLenth = -1;
    
        
    public static readonly int RawResponse_MaxLenth = 255;
    
        
    public static readonly int CreatedTime_MaxLenth = 0;
    
        
    public static readonly int ModifiedTime_MaxLenth = 0;
    
        
    public static readonly int CreatedById_MaxLenth = 0;
    
        
    public static readonly int ModifiedById_MaxLenth = 0;
    
        
    public static readonly int Active_MaxLenth = 0;
    
        
    public static readonly int ShopeeShopUserId_MaxLenth = 0;
    
    
  }
}