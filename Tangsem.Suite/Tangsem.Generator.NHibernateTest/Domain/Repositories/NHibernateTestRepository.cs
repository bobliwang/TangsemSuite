using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tangsem.Data.Domain;
using Tangsem.Generator.NHibernateTest.Domain.Entities;
using Tangsem.NHibernate.Domain;

namespace Tangsem.Generator.NHibernateTest.Domain.Repositories
{
	public class NHibernateTestRepository : RepositoryBase, IRepository
	{
		public IQueryable<Country> Countries
		{
			get
			{
				return this.GetEntities<Country>();
			}
		}

		public IQueryable<State> States
		{
			get
			{
				return this.GetEntities<State>();
			}
		}
	}
}
