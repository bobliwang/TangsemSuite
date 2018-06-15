using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Common.Entities;
using Newtonsoft.Json;

namespace NHTest.Common.Domain.Entities
{
  /// <summary>
  /// This entity maps to 'Product'.
  /// </summary>
  public partial class Product
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
    /// The default constructor for Product class.
    /// </summary>
    public Product()
    {
    }
  

    /// <summary>
    /// Property SpecsJson mapping to Product.SpecsJson. JSON COLUMN!
    /// </summary>
    [JsonProperty("specsJson")]   
    public virtual NHTest.Common.Domain.ViewModels.ProductSpec[] SpecsJson { get; set; }
    
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
    
    #endregion
    
    #region "Outgoing References"
    #endregion
    
    #region "Incoming References"
    #endregion
    

      public static readonly int Id_MaxLenth = 0;
    
      public static readonly int Name_MaxLenth = 500;
    
      public static readonly int UnitPrice_MaxLenth = 0;
    
      public static readonly int SpecsJson_MaxLenth = -1;
      }
}