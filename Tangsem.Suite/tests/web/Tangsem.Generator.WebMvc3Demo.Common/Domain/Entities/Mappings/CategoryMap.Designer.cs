using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FluentNHibernate.Mapping;

namespace Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities.Mappings
{
	/// <summary>
	/// The mapping configuration for Category.
	/// </summary>
	public partial class CategoryMap : ClassMap<Category>
	{
		/// <summary>
		/// The constructor.
		/// </summary>
		public CategoryMap()
		{
			this.Table("Category");
			

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
			this.Map(x => x.ShortDescription)
                .Column("ShortDescription");			
			this.Map(x => x.Description)
                .Column("Description");			
			this.Map(x => x.ParentId)
                .Column("ParentId");			
			this.Map(x => x.KeyWords)
                .Column("KeyWords");			
			this.Map(x => x.CreatedById)
                .Column("CreatedById");			
			this.Map(x => x.ModifiedById)
                .Column("ModifiedById");			
			this.Map(x => x.CreatedTime)
                .Column("CreatedTime");			
			this.Map(x => x.ModifiedTime)
                .Column("ModifiedTime");			
			this.Map(x => x.Active)
                .Column("Active");			
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