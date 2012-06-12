using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;

using FluentNHibernate.Mapping;

namespace Tangsem.Generator.NHibernateTest.Domain.Entities.Mappings
{
	/// <summary>
	/// The mapping configuration for State.
	/// </summary>
	public class StateMap : ClassMap<State>
	{
		/// <summary>
		/// The constructor.
		/// </summary>
		public StateMap()
		{
			// primary key mapping
			this.MapId();

			// basic columns mapping
			this.MapBasicColumns();

			// outgoing references mapping
			this.MapOutgoingReferences();

			// incoming references mapping
			this.MapIncomingReferences();
		}

		/// <summary>
		/// Map the Primary Key.
		/// </summary>
		private void MapId()
		{
			this.Id(x => x.Id)
				.Column("Id")
				.GeneratedBy
				.Native();
		}

		/// <summary>
		/// Map the Basic Columns.
		/// </summary>
		private void MapBasicColumns()
		{

			this.Map(x => x.Name)
				.Column("Name").Not.Nullable();
		}

		/// <summary>
		/// Map the Outgoing References.
		/// </summary>
		private void MapOutgoingReferences()
		{

			this.References<Country>(x => x.Country)
				.Fetch.Join()
				.Column("CountryId");
		}

		/// <summary>
		/// Map the Incoming References.
		/// </summary>
		private void MapIncomingReferences()
		{

		}
	}
}
