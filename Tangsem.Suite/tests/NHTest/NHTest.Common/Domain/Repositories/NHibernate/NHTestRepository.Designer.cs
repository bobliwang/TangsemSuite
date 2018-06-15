using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Data.Domain;
using Tangsem.NHibernate.Domain;
using NHTest.Common.Domain.Entities;

namespace NHTest.Common.Domain.Repositories.NHibernate
{ 
  /// <summary>
  /// The NHTestRepository class.
  /// </summary>
  public partial class NHTestRepository : RepositoryBase, INHTestRepository
  {

    
    /// <summary>
    /// The IQueryable for Products.
    /// </summary>
    public virtual IQueryable<Product> Products
    {
      get
      {
        return this.GetEntities<Product>();
      }
    }

    
    
    /// <summary>
    /// The IQueryable for Orders.
    /// </summary>
    public virtual IQueryable<Order> Orders
    {
      get
      {
        return this.GetEntities<Order>();
      }
    }

        
    

    
    /// <summary>
    /// Get Product by primary key.
    /// </summary>
    public virtual Product LookupProductById(int id)
    {
      return this.LookupById<Product>(id);
    }
    
    /// <summary>
    /// Delete Product by primary key.
    /// </summary>
    public virtual Product DeleteProductById(int id)
    {
      return this.DeleteById<Product>(id);
    }
    
    /// <summary>
    /// Save a new Product instance.
    /// </summary>
    public virtual Product SaveProduct(Product product)
    {
      return this.Save<Product>(product);
    }
    
    /// <summary>
    /// Update an existing Product instance.
    /// </summary>
    public virtual Product UpdateProduct(Product product)
    {
      return this.Update<Product>(product);
    }
    
    /// <summary>
    /// Save or update an existing Product instance.
    /// </summary>
    public virtual Product SaveOrUpdateProduct(Product product)
    {
      return this.SaveOrUpdate<Product>(product);
    }

    
    
    /// <summary>
    /// Get Order by primary key.
    /// </summary>
    public virtual Order LookupOrderById(int id)
    {
      return this.LookupById<Order>(id);
    }
    
    /// <summary>
    /// Delete Order by primary key.
    /// </summary>
    public virtual Order DeleteOrderById(int id)
    {
      return this.DeleteById<Order>(id);
    }
    
    /// <summary>
    /// Save a new Order instance.
    /// </summary>
    public virtual Order SaveOrder(Order order)
    {
      return this.Save<Order>(order);
    }
    
    /// <summary>
    /// Update an existing Order instance.
    /// </summary>
    public virtual Order UpdateOrder(Order order)
    {
      return this.Update<Order>(order);
    }
    
    /// <summary>
    /// Save or update an existing Order instance.
    /// </summary>
    public virtual Order SaveOrUpdateOrder(Order order)
    {
      return this.SaveOrUpdate<Order>(order);
    }

    
  }
}

/*    
  @NOTE: The following entities are not IAuditableEntities:
     

     
  ------------------------------
  -- Product     ----
  ------------------------------
  ALTER TABLE Product ADD CreatedById INT NULL
  GO
  ALTER TABLE Product ADD ModifiedById INT NULL
  GO
  ALTER TABLE Product ADD CreatedTime DATETIME NULL
  GO
  ALTER TABLE Product ADD ModifiedTime DATETIME NULL
  GO
  ALTER TABLE Product ADD Active BIT NULL
  GO
         
       
  
     
  ------------------------------
  -- Order     ----
  ------------------------------
  ALTER TABLE Order ADD CreatedById INT NULL
  GO
  ALTER TABLE Order ADD ModifiedById INT NULL
  GO
  ALTER TABLE Order ADD CreatedTime DATETIME NULL
  GO
  ALTER TABLE Order ADD ModifiedTime DATETIME NULL
  GO
  ALTER TABLE Order ADD Active BIT NULL
  GO
         
       
  */