using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Data.Domain;
//using Tangsem.NHibernate.Domain;

using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities;

namespace Tangsem.Generator.WebMvc3Demo.Common.Domain.Repositories
{
	/// <summary>
	/// The IMyRepository interface.
	/// </summary>
	public partial interface IMyRepository : IRepository
	{

		
		/// <summary>
		/// The IQueryable for Countries.
		/// </summary>
		IQueryable<Country> Countries { get; }

		
		
		/// <summary>
		/// The IQueryable for States.
		/// </summary>
		IQueryable<State> States { get; }

		
		
		/// <summary>
		/// The IQueryable for VStates.
		/// </summary>
		IQueryable<VState> VStates { get; }

		
		
		/// <summary>
		/// The IQueryable for Categories.
		/// </summary>
		IQueryable<Category> Categories { get; }

				
		

		
		/// <summary>
		/// Get Country by primary key.
		/// </summary>
		Country LookupCountryById(int id);
		
		/// <summary>
		/// Delete Country by primary key.
		/// </summary>
		Country DeleteCountryById(int id);
		
		/// <summary>
		/// Save a new Country instance.
		/// </summary>
		Country SaveCountry(Country country);
		
		/// <summary>
		/// Update an existing Country instance.
		/// </summary>
		Country UpdateCountry(Country country);
		
		/// <summary>
		/// Save or update an existing Country instance.
		/// </summary>
		Country SaveOrUpdateCountry(Country country);

		
		
		/// <summary>
		/// Get State by primary key.
		/// </summary>
		State LookupStateById(int id);
		
		/// <summary>
		/// Delete State by primary key.
		/// </summary>
		State DeleteStateById(int id);
		
		/// <summary>
		/// Save a new State instance.
		/// </summary>
		State SaveState(State state);
		
		/// <summary>
		/// Update an existing State instance.
		/// </summary>
		State UpdateState(State state);
		
		/// <summary>
		/// Save or update an existing State instance.
		/// </summary>
		State SaveOrUpdateState(State state);

		
		
		/// <summary>
		/// Get Category by primary key.
		/// </summary>
		Category LookupCategoryById(int id);
		
		/// <summary>
		/// Delete Category by primary key.
		/// </summary>
		Category DeleteCategoryById(int id);
		
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

		
	}
}