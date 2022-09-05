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
  /// The mapping configuration for ShopeeShopUser.
  /// </summary>
  public partial class ShopeeShopUserMap : ClassMap<ShopeeShopUser>
  {
    /// <summary>
    /// The constructor.
    /// </summary>
    public ShopeeShopUserMap()
    {

      this.Table("[ShopeeShopUser]");
      

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
               
         // AspNetUserId
       
                
         this.Map(x => x.AspNetUserId).Column("AspNetUserId")

                  .Not.Nullable()          ;
                
         // LastLoginTime
       
                
         this.Map(x => x.LastLoginTime).Column("LastLoginTime")

                           ;
                
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
            this.References<ShopeeShop>(x => x.ShopeeShop)
                .Fetch.Join()
                .Column("ShopeeShopId")
      .Not.Nullable();      
    }
    
    /// <summary>
    /// Map the Incoming References.
    /// </summary>
    private void MapIncomingReferences()
    {
            this.HasMany<ShopeeItemPullHistory>(x => x.ShopeeItemPullHistories)
        .KeyColumn("ShopeeShopUserId")
                .Inverse()
                .LazyLoad()
                .AsBag();
      
    }
      }
}