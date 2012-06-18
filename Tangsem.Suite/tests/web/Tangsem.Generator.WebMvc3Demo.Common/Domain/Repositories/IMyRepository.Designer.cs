using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Data.Domain;
using Tangsem.NHibernate.Domain;

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

		
	}
}