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
	/// The mapping configuration for Order.
	/// </summary>
	public partial class OrderMap : ClassMap<Order>
	{
		/// <summary>
		/// The constructor.
		/// </summary>
		public OrderMap()
    {
			this.Table("[Order]");
			

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

			   
			   // CustomerName

         
         this.Map(x => x.CustomerName).Column("CustomerName")

 .Length(200) ;
        
			 
			   
			   // OrderTotal

         
         this.Map(x => x.OrderTotal).Column("OrderTotal")

 .Not.Nullable();
        
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