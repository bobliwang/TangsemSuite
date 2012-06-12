using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tangsem.Generator.NHibernateTest.Domain.Entities
{
	public partial class Country
	{
		public virtual void AddState(State state)
		{
			state.Country = this;
			this.States.Add(state);
		}
	}
}
