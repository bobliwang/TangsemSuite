using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Data.Domain;

using NHTest.Common.Domain.Entities;

namespace NHTest.Common.Domain.Repositories
{
	/// <summary>
	/// The INHTestRepository interface.
	/// </summary>
	public partial interface INHTestRepository : IRepository
	{

		
		/// <summary>
		/// Maps to database table/view Product. The IQueryable for Products.
		/// </summary>
		IQueryable<Product> Products { get; }

		
		
		/// <summary>
		/// Maps to database table/view Order. The IQueryable for Orders.
		/// </summary>
		IQueryable<Order> Orders { get; }

				
		

		
		/// <summary>
		/// Get Product by primary key.
		/// </summary>
		Product LookupProductById(int id);
		
		/// <summary>
		/// Delete Product by primary key.
		/// </summary>
		Product DeleteProductById(int id);
		
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
		/// Get Order by primary key.
		/// </summary>
		Order LookupOrderById(int id);
		
		/// <summary>
		/// Delete Order by primary key.
		/// </summary>
		Order DeleteOrderById(int id);
		
		/// <summary>
		/// Save a new Order instance.
		/// </summary>
		Order SaveOrder(Order order);
		
		/// <summary>
		/// Update an existing Order instance.
		/// </summary>
		Order UpdateOrder(Order order);
		
		/// <summary>
		/// Save or update an existing Order instance.
		/// </summary>
		Order SaveOrUpdateOrder(Order order);

		
	}
}