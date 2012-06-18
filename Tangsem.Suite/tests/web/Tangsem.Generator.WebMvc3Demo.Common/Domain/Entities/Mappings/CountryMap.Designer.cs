using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FluentNHibernate.Mapping;

namespace Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities.Mappings
{
	/// <summary>
	/// The mapping configuration for Country.
	/// </summary>
	public partial class CountryMap : ClassMap<Country>
	{
		/// <summary>
		/// The constructor.
		/// </summary>
		public CountryMap()
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
			this.Map(x => x.CountryCode)
                .Column("CountryCode");			
			this.Map(x => x.Continent)
                .Column("Continent");			
		}
		
		/// <summary>
		/// Map the Outgoing References.
		/// </summary>
		private void MapOutgoingReferences()
		{

		}
		
		/// <summary>
		/// Map the Incoming References.
		/// </summary>
		private void MapIncomingReferences()
		{

			this.HasMany<State>(x => x.States)
				.KeyColumn("CountryId")
                .Inverse()
                .LazyLoad()
                .AsBag();
			
		}
	}
}