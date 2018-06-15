using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FluentNHibernate.Mapping;

using Tangsem.NHibernate.UserTypes;

namespace NHTest.Common.Domain.Entities.Mappings.NHibernate
{
	/// <summary>
	/// The mapping configuration for Product.
	/// </summary>
	public partial class ProductMap : ClassMap<Product>
	{
		/// <summary>
		/// The constructor.
		/// </summary>
		public ProductMap()
    {
			this.Table("[Product]");
			

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

			   
			   // Name

         
         this.Map(x => x.Name).Column("Name")

 .Length(500)  .Not.Nullable();
        
			 
			   
			   // UnitPrice

         
         this.Map(x => x.UnitPrice).Column("UnitPrice")

 .Not.Nullable();
        
			 
			   
			   // SpecsJson
         
         this.Map(x => x.SpecsJson).Column("SpecsJson").CustomType<JsonType<NHTest.Common.Domain.ViewModels.ProductSpec[]>>()
;
        
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