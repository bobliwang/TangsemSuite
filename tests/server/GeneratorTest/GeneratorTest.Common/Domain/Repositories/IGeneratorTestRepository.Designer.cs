using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Data.Domain;

using GeneratorTest.Common.Domain.Entities;

namespace GeneratorTest.Common.Domain.Repositories
{
	/// <summary>
	/// The IGeneratorTestRepository interface.
	/// </summary>
	public partial interface IGeneratorTestRepository : IRepository
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
		/// Maps to database table/view Pos. The IQueryable for Poses.
		/// </summary>
		IQueryable<Pos> Poses { get; }

				
		

		
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

		
		
		/// <summary>
		/// Get Pos by primary key.
		/// </summary>
		Pos LookupPosById(int id);
		
		/// <summary>
		/// Delete Pos by primary key.
		/// </summary>
		Pos DeletePosById(int id);
		
		/// <summary>
		/// Save a new Pos instance.
		/// </summary>
		Pos SavePos(Pos pos);
		
		/// <summary>
		/// Update an existing Pos instance.
		/// </summary>
		Pos UpdatePos(Pos pos);
		
		/// <summary>
		/// Save or update an existing Pos instance.
		/// </summary>
		Pos SaveOrUpdatePos(Pos pos);

		
	}
}