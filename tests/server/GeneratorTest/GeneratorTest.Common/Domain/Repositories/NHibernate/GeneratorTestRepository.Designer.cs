using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Data.Domain;
using Tangsem.NHibernate.Domain;
using GeneratorTest.Common.Domain.Entities;

namespace GeneratorTest.Common.Domain.Repositories.NHibernate
{ 
  /// <summary>
  /// The GeneratorTestRepository class.
  /// </summary>
  public partial class GeneratorTestRepository : RepositoryBase, IGeneratorTestRepository
  {

    
    /// <summary>
    /// The IQueryable for Poses.
    /// </summary>
    public virtual IQueryable<Pos> Poses
    {
      get
      {
        return this.GetEntities<Pos>();
      }
    }

    
    
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
    /// The IQueryable for Customers.
    /// </summary>
    public virtual IQueryable<Customer> Customers
    {
      get
      {
        return this.GetEntities<Customer>();
      }
    }

    
    
    /// <summary>
    /// The IQueryable for Stores.
    /// </summary>
    public virtual IQueryable<Store> Stores
    {
      get
      {
        return this.GetEntities<Store>();
      }
    }

        
    

    
    /// <summary>
    /// Get Pos by primary key.
    /// </summary>
    public virtual Pos LookupPosById(int id)
    {
      return this.LookupById<Pos>(id);
    }
    
    /// <summary>
    /// Delete Pos by primary key.
    /// </summary>
    public virtual Pos DeletePosById(int id)
    {
      return this.DeleteById<Pos>(id);
    }
    
    /// <summary>
    /// Save a new Pos instance.
    /// </summary>
    public virtual Pos SavePos(Pos pos)
    {
      return this.Save<Pos>(pos);
    }
    
    /// <summary>
    /// Update an existing Pos instance.
    /// </summary>
    public virtual Pos UpdatePos(Pos pos)
    {
      return this.Update<Pos>(pos);
    }
    
    /// <summary>
    /// Save or update an existing Pos instance.
    /// </summary>
    public virtual Pos SaveOrUpdatePos(Pos pos)
    {
      return this.SaveOrUpdate<Pos>(pos);
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

    
    
    /// <summary>
    /// Get Customer by primary key.
    /// </summary>
    public virtual Customer LookupCustomerByCustomerId(System.Guid customerId)
    {
      return this.LookupById<Customer>(customerId);
    }
    
    /// <summary>
    /// Delete Customer by primary key.
    /// </summary>
    public virtual Customer DeleteCustomerByCustomerId(System.Guid customerId)
    {
      return this.DeleteById<Customer>(customerId);
    }
    
    /// <summary>
    /// Save a new Customer instance.
    /// </summary>
    public virtual Customer SaveCustomer(Customer customer)
    {
      return this.Save<Customer>(customer);
    }
    
    /// <summary>
    /// Update an existing Customer instance.
    /// </summary>
    public virtual Customer UpdateCustomer(Customer customer)
    {
      return this.Update<Customer>(customer);
    }
    
    /// <summary>
    /// Save or update an existing Customer instance.
    /// </summary>
    public virtual Customer SaveOrUpdateCustomer(Customer customer)
    {
      return this.SaveOrUpdate<Customer>(customer);
    }

    
    
    /// <summary>
    /// Get Store by primary key.
    /// </summary>
    public virtual Store LookupStoreById(int id)
    {
      return this.LookupById<Store>(id);
    }
    
    /// <summary>
    /// Delete Store by primary key.
    /// </summary>
    public virtual Store DeleteStoreById(int id)
    {
      return this.DeleteById<Store>(id);
    }
    
    /// <summary>
    /// Save a new Store instance.
    /// </summary>
    public virtual Store SaveStore(Store store)
    {
      return this.Save<Store>(store);
    }
    
    /// <summary>
    /// Update an existing Store instance.
    /// </summary>
    public virtual Store UpdateStore(Store store)
    {
      return this.Update<Store>(store);
    }
    
    /// <summary>
    /// Save or update an existing Store instance.
    /// </summary>
    public virtual Store SaveOrUpdateStore(Store store)
    {
      return this.SaveOrUpdate<Store>(store);
    }

    
  }
}