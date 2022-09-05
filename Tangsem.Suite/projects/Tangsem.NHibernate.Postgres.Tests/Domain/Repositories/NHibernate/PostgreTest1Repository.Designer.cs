using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Data.Domain;
using Tangsem.NHibernate.Domain;
using Tangsem.NHibernate.Tests.PostgreTest1.Domain.Entities;

namespace Tangsem.NHibernate.Tests.PostgreTest1.Domain.Repositories.NHibernate
{ 
  /// <summary>
  /// The PostgreTest1Repository class.
  /// </summary>
  public partial class PostgreTest1Repository : RepositoryBase, IPostgreTest1Repository
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
    /// The IQueryable for ProductCategoryMaps.
    /// </summary>
    public virtual IQueryable<ProductCategoryMap> ProductCategoryMaps
    {
      get
      {
        return this.GetEntities<ProductCategoryMap>();
      }
    }

    
    
    /// <summary>
    /// The IQueryable for Categories.
    /// </summary>
    public virtual IQueryable<Category> Categories
    {
      get
      {
        return this.GetEntities<Category>();
      }
    }

    
    
    /// <summary>
    /// The IQueryable for ProductPhotos.
    /// </summary>
    public virtual IQueryable<ProductPhoto> ProductPhotos
    {
      get
      {
        return this.GetEntities<ProductPhoto>();
      }
    }

        
    

    
    /// <summary>
    /// Get Product by primary key.
    /// </summary>
    public virtual Product LookupProductById(long id)
    {
      return this.LookupById<Product>(id);
    }
    
    /// <summary>
    /// Delete Product by primary key.
    /// </summary>
    public virtual Product DeleteProductById(long id)
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
    /// Get ProductCategoryMap by primary key.
    /// </summary>
    public virtual ProductCategoryMap LookupProductCategoryMapById(long id)
    {
      return this.LookupById<ProductCategoryMap>(id);
    }
    
    /// <summary>
    /// Delete ProductCategoryMap by primary key.
    /// </summary>
    public virtual ProductCategoryMap DeleteProductCategoryMapById(long id)
    {
      return this.DeleteById<ProductCategoryMap>(id);
    }
    
    /// <summary>
    /// Save a new ProductCategoryMap instance.
    /// </summary>
    public virtual ProductCategoryMap SaveProductCategoryMap(ProductCategoryMap productCategoryMap)
    {
      return this.Save<ProductCategoryMap>(productCategoryMap);
    }
    
    /// <summary>
    /// Update an existing ProductCategoryMap instance.
    /// </summary>
    public virtual ProductCategoryMap UpdateProductCategoryMap(ProductCategoryMap productCategoryMap)
    {
      return this.Update<ProductCategoryMap>(productCategoryMap);
    }
    
    /// <summary>
    /// Save or update an existing ProductCategoryMap instance.
    /// </summary>
    public virtual ProductCategoryMap SaveOrUpdateProductCategoryMap(ProductCategoryMap productCategoryMap)
    {
      return this.SaveOrUpdate<ProductCategoryMap>(productCategoryMap);
    }

    
    
    /// <summary>
    /// Get Category by primary key.
    /// </summary>
    public virtual Category LookupCategoryById(long id)
    {
      return this.LookupById<Category>(id);
    }
    
    /// <summary>
    /// Delete Category by primary key.
    /// </summary>
    public virtual Category DeleteCategoryById(long id)
    {
      return this.DeleteById<Category>(id);
    }
    
    /// <summary>
    /// Save a new Category instance.
    /// </summary>
    public virtual Category SaveCategory(Category category)
    {
      return this.Save<Category>(category);
    }
    
    /// <summary>
    /// Update an existing Category instance.
    /// </summary>
    public virtual Category UpdateCategory(Category category)
    {
      return this.Update<Category>(category);
    }
    
    /// <summary>
    /// Save or update an existing Category instance.
    /// </summary>
    public virtual Category SaveOrUpdateCategory(Category category)
    {
      return this.SaveOrUpdate<Category>(category);
    }

    
    
    /// <summary>
    /// Get ProductPhoto by primary key.
    /// </summary>
    public virtual ProductPhoto LookupProductPhotoById(long id)
    {
      return this.LookupById<ProductPhoto>(id);
    }
    
    /// <summary>
    /// Delete ProductPhoto by primary key.
    /// </summary>
    public virtual ProductPhoto DeleteProductPhotoById(long id)
    {
      return this.DeleteById<ProductPhoto>(id);
    }
    
    /// <summary>
    /// Save a new ProductPhoto instance.
    /// </summary>
    public virtual ProductPhoto SaveProductPhoto(ProductPhoto productPhoto)
    {
      return this.Save<ProductPhoto>(productPhoto);
    }
    
    /// <summary>
    /// Update an existing ProductPhoto instance.
    /// </summary>
    public virtual ProductPhoto UpdateProductPhoto(ProductPhoto productPhoto)
    {
      return this.Update<ProductPhoto>(productPhoto);
    }
    
    /// <summary>
    /// Save or update an existing ProductPhoto instance.
    /// </summary>
    public virtual ProductPhoto SaveOrUpdateProductPhoto(ProductPhoto productPhoto)
    {
      return this.SaveOrUpdate<ProductPhoto>(productPhoto);
    }

    
  }
}

/*    
  @NOTE: The following entities are not IAuditableEntities:
     

     
  ------------------------------
  -- Product     ----
  ------------------------------
  ALTER TABLE [Product] ADD CreatedById INT NULL
  GO
  ALTER TABLE [Product] ADD ModifiedById INT NULL
  GO
  ALTER TABLE [Product] ADD CreatedTime [datetime2](7) NULL
  GO
  ALTER TABLE [Product] ADD ModifiedTime [datetime2](7) NULL
  GO
  ALTER TABLE [Product] ADD Active BIT NOT NULL
  GO
         
       
  
     
  ------------------------------
  -- ProductCategoryMap     ----
  ------------------------------
  ALTER TABLE [ProductCategoryMap] ADD CreatedById INT NULL
  GO
  ALTER TABLE [ProductCategoryMap] ADD ModifiedById INT NULL
  GO
  ALTER TABLE [ProductCategoryMap] ADD CreatedTime [datetime2](7) NULL
  GO
  ALTER TABLE [ProductCategoryMap] ADD ModifiedTime [datetime2](7) NULL
  GO
  ALTER TABLE [ProductCategoryMap] ADD Active BIT NOT NULL
  GO
         
       
  
     
  ------------------------------
  -- Category     ----
  ------------------------------
  ALTER TABLE [Category] ADD CreatedById INT NULL
  GO
  ALTER TABLE [Category] ADD ModifiedById INT NULL
  GO
  ALTER TABLE [Category] ADD CreatedTime [datetime2](7) NULL
  GO
  ALTER TABLE [Category] ADD ModifiedTime [datetime2](7) NULL
  GO
  ALTER TABLE [Category] ADD Active BIT NOT NULL
  GO
         
       
  
     
  ------------------------------
  -- ProductPhoto     ----
  ------------------------------
  ALTER TABLE [ProductPhoto] ADD CreatedById INT NULL
  GO
  ALTER TABLE [ProductPhoto] ADD ModifiedById INT NULL
  GO
  ALTER TABLE [ProductPhoto] ADD CreatedTime [datetime2](7) NULL
  GO
  ALTER TABLE [ProductPhoto] ADD ModifiedTime [datetime2](7) NULL
  GO
  ALTER TABLE [ProductPhoto] ADD Active BIT NOT NULL
  GO
         
       
  */