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
  /// This entity maps to 'Store'.
  /// </summary>
  public partial class Store : IAuditableEntity
  {

    /// <summary>
    /// The property name 'Id'. It matches the property to column 'Id'.
    /// </summary>
    public static readonly string Prop_Id = "Id";
    
    /// <summary>
    /// The lamda expression for Id.
    /// </summary>
    public static readonly Expression<Func<Store, object>> Expr_Id = x => x.Id;
    
    /// <summary>
    /// The property name 'StoreName'. It matches the property to column 'StoreName'.
    /// </summary>
    public static readonly string Prop_StoreName = "StoreName";
    
    /// <summary>
    /// The lamda expression for StoreName.
    /// </summary>
    public static readonly Expression<Func<Store, object>> Expr_StoreName = x => x.StoreName;
    
    /// <summary>
    /// The property name 'CreatedById'. It matches the property to column 'CreatedById'.
    /// </summary>
    public static readonly string Prop_CreatedById = "CreatedById";
    
    /// <summary>
    /// The lamda expression for CreatedById.
    /// </summary>
    public static readonly Expression<Func<Store, object>> Expr_CreatedById = x => x.CreatedById;
    
    /// <summary>
    /// The property name 'CreatedTime'. It matches the property to column 'CreatedTime'.
    /// </summary>
    public static readonly string Prop_CreatedTime = "CreatedTime";
    
    /// <summary>
    /// The lamda expression for CreatedTime.
    /// </summary>
    public static readonly Expression<Func<Store, object>> Expr_CreatedTime = x => x.CreatedTime;
    
    /// <summary>
    /// The property name 'ModifiedById'. It matches the property to column 'ModifiedById'.
    /// </summary>
    public static readonly string Prop_ModifiedById = "ModifiedById";
    
    /// <summary>
    /// The lamda expression for ModifiedById.
    /// </summary>
    public static readonly Expression<Func<Store, object>> Expr_ModifiedById = x => x.ModifiedById;
    
    /// <summary>
    /// The property name 'ModifiedTime'. It matches the property to column 'ModifiedTime'.
    /// </summary>
    public static readonly string Prop_ModifiedTime = "ModifiedTime";
    
    /// <summary>
    /// The lamda expression for ModifiedTime.
    /// </summary>
    public static readonly Expression<Func<Store, object>> Expr_ModifiedTime = x => x.ModifiedTime;
    
    /// <summary>
    /// The property name 'Active'. It matches the property to column 'Active'.
    /// </summary>
    public static readonly string Prop_Active = "Active";
    
    /// <summary>
    /// The lamda expression for Active.
    /// </summary>
    public static readonly Expression<Func<Store, object>> Expr_Active = x => x.Active;
        
    
    
    
    /// <summary>
    /// The default constructor for Store class.
    /// </summary>
    public Store()
    {
    }
  

    #region "Basic Columns"


    /// <summary>
    /// Property Id mapping to Store.Id
    /// </summary>
    [JsonProperty("id")]   
    public virtual int Id { get; set; }
    
    /// <summary>
    /// Property StoreName mapping to Store.StoreName
    /// </summary>
    [JsonProperty("storeName")]   
    public virtual string StoreName { get; set; }
    
    /// <summary>
    /// Property CreatedById mapping to Store.CreatedById
    /// </summary>
    [JsonProperty("createdById")]   
    public virtual int? CreatedById { get; set; }
    
    /// <summary>
    /// Property CreatedTime mapping to Store.CreatedTime
    /// </summary>
    [JsonProperty("createdTime")]   
    public virtual System.DateTime? CreatedTime { get; set; }
    
    /// <summary>
    /// Property ModifiedById mapping to Store.ModifiedById
    /// </summary>
    [JsonProperty("modifiedById")]   
    public virtual int? ModifiedById { get; set; }
    
    /// <summary>
    /// Property ModifiedTime mapping to Store.ModifiedTime
    /// </summary>
    [JsonProperty("modifiedTime")]   
    public virtual System.DateTime? ModifiedTime { get; set; }
    
    /// <summary>
    /// Property Active mapping to Store.Active
    /// </summary>
    [JsonProperty("active")]   
    public virtual bool? Active { get; set; }
    
    #endregion
    
    #region "Outgoing References"
    #endregion
    
    #region "Incoming References"
    #endregion
    

      public static readonly int Id_MaxLenth = 0;
    
      public static readonly int StoreName_MaxLenth = 200;
    
      public static readonly int CreatedById_MaxLenth = 0;
    
      public static readonly int CreatedTime_MaxLenth = 0;
    
      public static readonly int ModifiedById_MaxLenth = 0;
    
      public static readonly int ModifiedTime_MaxLenth = 0;
    
      public static readonly int Active_MaxLenth = 0;
      }
}