using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FluentNHibernate.Mapping;

namespace Tangsem.Generator.NHibernateTest.Domain.Entities.Mappings
{
	/// <summary>
	/// The mapping configuration for VState.
	/// </summary>
	public partial class VStateMap : ClassMap<VState>
	{
		/// <summary>
		/// The constructor.
		/// </summary>
		public VStateMap()
		{
			this.Table("v_State");
			

			this.ReadOnly();
			
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

			this.Id(x => x.RowNum)
				.Column("RowNum");	
					  
		}
		
		/// <summary>
		/// Map the Basic Columns.
		/// </summary>
		private void MapBasicColumns()
		{

			this.Map(x => x.RowNum)
                .Column("RowNum");			
			this.Map(x => x.Id)
                .Column("Id").Not.Nullable();			
			this.Map(x => x.Name)
                .Column("Name").Not.Nullable();			
			this.Map(x => x.CountryId)
                .Column("CountryId");			
			this.Map(x => x.CountryName)
                .Column("CountryName");			
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

		}
	}
}