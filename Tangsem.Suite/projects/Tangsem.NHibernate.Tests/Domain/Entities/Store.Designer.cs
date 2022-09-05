using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Common.Entities;
using Newtonsoft.Json;

namespace Tangsem.NHibernate.Tests.Domain.Entities
{
  /// <summary>
  /// This entity maps to 'Store'.
  /// </summary>
  public partial class Store : AuditableEntity
  {
    /// <summary>
    /// The default constructor for Store class.
    /// </summary>
    public Store()
    {
      this.Customers = new List<Customer>();
    }
  
    
    #region "Basic Columns"

        /// <summary>
    /// Property Id mapping to Store.Id.
    /// </summary>
    public virtual int Id { get; set; }

        /// <summary>
    /// Property StoreName mapping to Store.StoreName.
    /// </summary>
    public virtual string StoreName { get; set; }

        /// <summary>
    /// Property StorePhoto mapping to Store.StorePhoto.
    /// </summary>
    public virtual string StorePhoto { get; set; }

    
    #endregion
    
    #region "Outgoing References"
    
    #endregion
    
    #region "Incoming References"
    /// <summary>
    /// Field for the child list of Ref: FK156F447FBED2C858.
    /// </summary>
    public virtual IList<Customer> Customers { get; set; }
    
    /// <summary>
    /// Add Customer entity to Customers.
    /// </summary>
    /// <param name="customer">
    ///	The Customer entity.
    /// </param>
    public virtual void AddToCustomers(Customer customer)
    {
      customer.Store = this;
      this.Customers.Add(customer);
    }

    #endregion
    
        
    public static readonly int Id_MaxLenth = 0;
    
        
    public static readonly int StoreName_MaxLenth = 200;
    
        
    public static readonly int StorePhoto_MaxLenth = 1000;
    
        
    public static readonly int CreatedById_MaxLenth = 0;
    
        
    public static readonly int CreatedTime_MaxLenth = 0;
    
        
    public static readonly int ModifiedById_MaxLenth = 0;
    
        
    public static readonly int ModifiedTime_MaxLenth = 0;
    
        
    public static readonly int Active_MaxLenth = 0;
    
    
  }
}