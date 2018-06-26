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
	/// The mapping configuration for Pos.
	/// </summary>
	public partial class PosMap : ClassMap<Pos>
	{
		/// <summary>
		/// The constructor.
		/// </summary>
		public PosMap()
    {
			this.Table("[Pos]");
			

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

 .Length(50)  .Not.Nullable();
        
			 
			   
			   // CreatedById

         
         this.Map(x => x.CreatedById).Column("CreatedById")

;
        
			 
			   
			   // ModifiedById

         
         this.Map(x => x.ModifiedById).Column("ModifiedById")

;
        
			 
			   
			   // CreatedTime

         
         this.Map(x => x.CreatedTime).Column("CreatedTime")

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

		}
    	}
}