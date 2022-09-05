using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FluentNHibernate.Mapping;

using Tangsem.NHibernate.UserTypes;

using Tangsem.Identity.Domain.Entities;
namespace Sample.Core.Domain.Entities.Mappings.NHibernate
{
  /// <summary>
  /// The mapping configuration for ShopeeShop.
  /// </summary>
  public partial class ShopeeShopMap : ClassMap<ShopeeShop>
  {
    /// <summary>
    /// The constructor.
    /// </summary>
    public ShopeeShopMap()
    {

      this.Table("[ShopeeShop]");
      

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
               
         // ShopId
       
                
         this.Map(x => x.ShopId).Column("ShopId")

          .Length(50)          .Not.Nullable()          ;
                
         // ShopName
       
                
         this.Map(x => x.ShopName).Column("ShopName")

          .Length(500)                   ;
                
         // Status
       
                
         this.Map(x => x.Status).Column("Status")

          .Length(200)                   ;
                
         // CreatedTime
       
                
         this.Map(x => x.CreatedTime).Column("CreatedTime")

                           ;
                
         // ModifiedTime
       
                
         this.Map(x => x.ModifiedTime).Column("ModifiedTime")

                           ;
                
         // CreatedById
       
                
         this.Map(x => x.CreatedById).Column("CreatedById")

                           ;
                
         // ModifiedById
       
                
         this.Map(x => x.ModifiedById).Column("ModifiedById")

                           ;
                
         // Active
       
                
         this.Map(x => x.Active).Column("Active")

                  .Not.Nullable()          ;
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
            this.HasMany<ShopeeShopUser>(x => x.ShopeeShopUsers)
        .KeyColumn("ShopeeShopId")
                .Inverse()
                .LazyLoad()
                .AsBag();
      
    }
      }
}