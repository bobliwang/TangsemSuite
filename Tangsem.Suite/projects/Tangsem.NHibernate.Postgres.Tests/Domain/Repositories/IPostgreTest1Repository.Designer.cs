using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Data.Domain;

using Tangsem.NHibernate.Tests.PostgreTest1.Domain.Entities;

namespace Tangsem.NHibernate.Tests.PostgreTest1.Domain.Repositories
{
	/// <summary>
	/// The IPostgreTest1Repository interface.
	/// </summary>
	public partial interface IPostgreTest1Repository : IRepository
	{

		
		/// <summary>
		/// Maps to database table/view Product. The IQueryable for Products.
		/// </summary>
		IQueryable<Product> Products { get; }

		
		
		/// <summary>
		/// Maps to database table/view ProductCategoryMap. The IQueryable for ProductCategoryMaps.
		/// </summary>
		IQueryable<ProductCategoryMap> ProductCategoryMaps { get; }

		
		
		/// <summary>
		/// Maps to database table/view Category. The IQueryable for Categories.
		/// </summary>
		IQueryable<Category> Categories { get; }

		
		
		/// <summary>
		/// Maps to database table/view ProductPhoto. The IQueryable for ProductPhotos.
		/// </summary>
		IQueryable<ProductPhoto> ProductPhotos { get; }

				
		

		
		/// <summary>
		/// Get Product by primary key.
		/// </summary>
		Product LookupProductById(long id);
		
		/// <summary>
		/// Delete Product by primary key.
		/// </summary>
		Product DeleteProductById(long id);
		
		/// <summary>
		/// Save a new Product instance.
		/// </summary>
		Product SaveProduct(Product product);
		
		/// <summary>
		/// Update an existing Product instance.
		/// </summary>
		Product UpdateProduct(Product product);
		
		/// <summary>
		/// Save or update an existing Product instance.
		/// </summary>
		Product SaveOrUpdateProduct(Product product);

		
		
		/// <summary>
		/// Get ProductCategoryMap by primary key.
		/// </summary>
		ProductCategoryMap LookupProductCategoryMapById(long id);
		
		/// <summary>
		/// Delete ProductCategoryMap by primary key.
		/// </summary>
		ProductCategoryMap DeleteProductCategoryMapById(long id);
		
		/// <summary>
		/// Save a new ProductCategoryMap instance.
		/// </summary>
		ProductCategoryMap SaveProductCategoryMap(ProductCategoryMap productCategoryMap);
		
		/// <summary>
		/// Update an existing ProductCategoryMap instance.
		/// </summary>
		ProductCategoryMap UpdateProductCategoryMap(ProductCategoryMap productCategoryMap);
		
		/// <summary>
		/// Save or update an existing ProductCategoryMap instance.
		/// </summary>
		ProductCategoryMap SaveOrUpdateProductCategoryMap(ProductCategoryMap productCategoryMap);

		
		
		/// <summary>
		/// Get Category by primary key.
		/// </summary>
		Category LookupCategoryById(long id);
		
		/// <summary>
		/// Delete Category by primary key.
		/// </summary>
		Category DeleteCategoryById(long id);
		
		/// <summary>
		/// Save a new Category instance.
		/// </summary>
		Category SaveCategory(Category category);
		
		/// <summary>
		/// Update an existing Category instance.
		/// </summary>
		Category UpdateCategory(Category category);
		
		/// <summary>
		/// Save or update an existing Category instance.
		/// </summary>
		Category SaveOrUpdateCategory(Category category);

		
		
		/// <summary>
		/// Get ProductPhoto by primary key.
		/// </summary>
		ProductPhoto LookupProductPhotoById(long id);
		
		/// <summary>
		/// Delete ProductPhoto by primary key.
		/// </summary>
		ProductPhoto DeleteProductPhotoById(long id);
		
		/// <summary>
		/// Save a new ProductPhoto instance.
		/// </summary>
		ProductPhoto SaveProductPhoto(ProductPhoto productPhoto);
		
		/// <summary>
		/// Update an existing ProductPhoto instance.
		/// </summary>
		ProductPhoto UpdateProductPhoto(ProductPhoto productPhoto);
		
		/// <summary>
		/// Save or update an existing ProductPhoto instance.
		/// </summary>
		ProductPhoto SaveOrUpdateProductPhoto(ProductPhoto productPhoto);

		
	}
}