using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Data.Domain;
using Tangsem.NHibernate.Domain;

using Tangsem.Generator.NHibernateTest.Domain.Entities;

namespace Tangsem.Generator.NHibernateTest.Domain.Repositories
{
	/// <summary>
	/// The NHibernateTestRepository class.
	/// </summary>
	public partial class NHibernateTestRepository : RepositoryBase, IRepository
	{
		
		
		/// <summary>
		/// The IQueryable for Countries.
		/// </summary>
		public virtual IQueryable<Country> Countries
		{
			get
			{
				return this.GetEntities<Country>();
			}
		}

				
		
		/// <summary>
		/// The IQueryable for States.
		/// </summary>
		public virtual IQueryable<State> States
		{
			get
			{
				return this.GetEntities<State>();
			}
		}

				
		
		
		
		/// <summary>
		/// Get Country by primary key.
		/// </summary>
		public virtual Country GetCountryById(int id)
		{
			return this.LookupById<Country>(id);
		}

				
		
		/// <summary>
		/// Get State by primary key.
		/// </summary>
		public virtual State GetStateById(int id)
		{
			return this.LookupById<State>(id);
		}

		
	}
}