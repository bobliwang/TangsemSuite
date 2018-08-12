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
  /// This entity maps to 'Pos'.
  /// </summary>
  public partial class Pos : IAuditableEntity
  {

    /// <summary>
    /// The property name 'Id'. It matches the property to column 'Id'.
    /// </summary>
    public static readonly string Prop_Id = "Id";
    
    /// <summary>
    /// The lamda expression for Id.
    /// </summary>
    public static readonly Expression<Func<Pos, object>> Expr_Id = x => x.Id;
    
    /// <summary>
    /// The property name 'Name'. It matches the property to column 'Name'.
    /// </summary>
    public static readonly string Prop_Name = "Name";
    
    /// <summary>
    /// The lamda expression for Name.
    /// </summary>
    public static readonly Expression<Func<Pos, object>> Expr_Name = x => x.Name;
    
    /// <summary>
    /// The property name 'StoreId'. It matches the property to column 'StoreId'.
    /// </summary>
    public static readonly string Prop_StoreId = "StoreId";
    
    /// <summary>
    /// The lamda expression for StoreId.
    /// </summary>
    public static readonly Expression<Func<Pos, object>> Expr_StoreId = x => x.StoreId;
    
    /// <summary>
    /// The property name 'CreatedById'. It matches the property to column 'CreatedById'.
    /// </summary>
    public static readonly string Prop_CreatedById = "CreatedById";
    
    /// <summary>
    /// The lamda expression for CreatedById.
    /// </summary>
    public static readonly Expression<Func<Pos, object>> Expr_CreatedById = x => x.CreatedById;
    
    /// <summary>
    /// The property name 'ModifiedById'. It matches the property to column 'ModifiedById'.
    /// </summary>
    public static readonly string Prop_ModifiedById = "ModifiedById";
    
    /// <summary>
    /// The lamda expression for ModifiedById.
    /// </summary>
    public static readonly Expression<Func<Pos, object>> Expr_ModifiedById = x => x.ModifiedById;
    
    /// <summary>
    /// The property name 'CreatedTime'. It matches the property to column 'CreatedTime'.
    /// </summary>
    public static readonly string Prop_CreatedTime = "CreatedTime";
    
    /// <summary>
    /// The lamda expression for CreatedTime.
    /// </summary>
    public static readonly Expression<Func<Pos, object>> Expr_CreatedTime = x => x.CreatedTime;
    
    /// <summary>
    /// The property name 'ModifiedTime'. It matches the property to column 'ModifiedTime'.
    /// </summary>
    public static readonly string Prop_ModifiedTime = "ModifiedTime";
    
    /// <summary>
    /// The lamda expression for ModifiedTime.
    /// </summary>
    public static readonly Expression<Func<Pos, object>> Expr_ModifiedTime = x => x.ModifiedTime;
    
    /// <summary>
    /// The property name 'Active'. It matches the property to column 'Active'.
    /// </summary>
    public static readonly string Prop_Active = "Active";
    
    /// <summary>
    /// The lamda expression for Active.
    /// </summary>
    public static readonly Expression<Func<Pos, object>> Expr_Active = x => x.Active;
        
    
    
    
    /// <summary>
    /// The default constructor for Pos class.
    /// </summary>
    public Pos()
    {
    }
  

    #region "Basic Columns"


    /// <summary>
    /// Property Id mapping to Pos.Id
    /// </summary>
    [JsonProperty("id")]   
    public virtual int Id { get; set; }
    
    /// <summary>
    /// Property Name mapping to Pos.Name
    /// </summary>
    [JsonProperty("name")]   
    public virtual string Name { get; set; }
    
    /// <summary>
    /// Property StoreId mapping to Pos.StoreId
    /// </summary>
    [JsonProperty("storeId")]   
    public virtual int? StoreId { get; set; }
    
    /// <summary>
    /// Property CreatedById mapping to Pos.CreatedById
    /// </summary>
    [JsonProperty("createdById")]   
    public virtual int? CreatedById { get; set; }
    
    /// <summary>
    /// Property ModifiedById mapping to Pos.ModifiedById
    /// </summary>
    [JsonProperty("modifiedById")]   
    public virtual int? ModifiedById { get; set; }
    
    /// <summary>
    /// Property CreatedTime mapping to Pos.CreatedTime
    /// </summary>
    [JsonProperty("createdTime")]   
    public virtual System.DateTime? CreatedTime { get; set; }
    
    /// <summary>
    /// Property ModifiedTime mapping to Pos.ModifiedTime
    /// </summary>
    [JsonProperty("modifiedTime")]   
    public virtual System.DateTime? ModifiedTime { get; set; }
    
    /// <summary>
    /// Property Active mapping to Pos.Active
    /// </summary>
    [JsonProperty("active")]   
    public virtual bool? Active { get; set; }
    
    #endregion
    
    #region "Outgoing References"
    #endregion
    
    #region "Incoming References"
    #endregion
    

      public static readonly int Id_MaxLenth = 0;
    
      public static readonly int Name_MaxLenth = 50;
    
      public static readonly int StoreId_MaxLenth = 0;
    
      public static readonly int CreatedById_MaxLenth = 0;
    
      public static readonly int ModifiedById_MaxLenth = 0;
    
      public static readonly int CreatedTime_MaxLenth = 0;
    
      public static readonly int ModifiedTime_MaxLenth = 0;
    
      public static readonly int Active_MaxLenth = 0;
      }
}