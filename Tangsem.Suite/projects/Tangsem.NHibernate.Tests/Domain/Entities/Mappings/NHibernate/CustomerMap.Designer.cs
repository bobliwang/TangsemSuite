using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FluentNHibernate.Mapping;

using Tangsem.NHibernate.UserTypes;

namespace Tangsem.NHibernate.Tests.Domain.Entities.Mappings.NHibernate
{
  /// <summary>
  /// The mapping configuration for Customer.
  /// </summary>
  public partial class CustomerMap : ClassMap<Customer>
  {
    /// <summary>
    /// The constructor.
    /// </summary>
    public CustomerMap()
    {

      this.Table("[Customer]");
      

      // primary key mapping
      this.MapId();
      
      // basic columns mapping
      this.MapBasicColumns();
      
      // outgoing references mapping
      this.MapOutgoingReferences();
      
      // incoming references mapping
      this.MapIncomingReferences();

      this.DynamicUpdate();

      this.CustomMappingConfig();
    }

    partial void CustomMappingConfig();
    
    /// <summary>
    /// Map the Primary Key.
    /// </summary>
    private void MapId()
    {
            
      this.Id(x => x.CustomerId)
          .Column("CustomerId")
          .GeneratedBy.Assigned();	
            
    }
    
    /// <summary>
    /// Map the Basic Columns.
    /// </summary>
    private void MapBasicColumns()
    {
               
         // CustomerName
       
                
         this.Map(x => x.CustomerName).Column("CustomerName")

          .Length(50)          .Not.Nullable()          ;
                
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

                  .Not.Nullable()          ;
                
         // RowVersion
       
                this.Version(x => x.RowVersion).Generated.Always();
           }

        
    /// <summary>
    /// Map the Outgoing References.
    /// </summary>
    private void MapOutgoingReferences()
    {
            this.References<Store>(x => x.Store)
                .Fetch.Join()
                .Column("StoreId")
      ;      
    }
    
    /// <summary>
    /// Map the Incoming References.
    /// </summary>
    private void MapIncomingReferences()
    {
            this.HasMany<Order>(x => x.Orders)
        .KeyColumn("CustomerId")
                .Inverse()
                .LazyLoad()
                .AsBag();
      
    }
      }
}