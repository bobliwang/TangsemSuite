using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FluentNHibernate.Mapping;

using Tangsem.NHibernate.UserTypes;

namespace GeneratorTest.Common.Domain.Entities.Mappings.NHibernate
{
	/// <summary>
	/// The mapping configuration for Store.
	/// </summary>
	public partial class StoreMap : ClassMap<Store>
	{
		/// <summary>
		/// The constructor.
		/// </summary>
		public StoreMap()
    {
			this.Table("[Store]");
			

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

			   
			   // StoreName

         
         this.Map(x => x.StoreName).Column("StoreName")

 .Length(200)  .Not.Nullable();
        
			 
			   
			   // StorePhoto

         
         this.Map(x => x.StorePhoto).Column("StorePhoto")

 .Length(1000) ;
        
			 
			   
			   // CreatedById

         
         this.Map(x => x.CreatedById).Column("CreatedById")

;
        
			 
			   
			   // CreatedTime

         
         this.Map(x => x.CreatedTime).Column("CreatedTime")

;
        
			 
			   
			   // ModifiedById

         
         this.Map(x => x.ModifiedById).Column("ModifiedById")

;
        
			 
			   
			   // ModifiedTime

         
         this.Map(x => x.ModifiedTime).Column("ModifiedTime")

;
        
			 
			   
			   // Active

         
         this.Map(x => x.Active).Column("Active")

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

			this.HasMany<Customer>(x => x.Customers)
				.KeyColumn("StoreId")
                .Inverse()
                .LazyLoad()
                .AsBag();
			
		}
    	}
}