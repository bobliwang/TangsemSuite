using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel;

using Tangsem.NHibernate.UserTypes;


namespace Tangsem.Identity.Domain.Entities.Mappings.NHibernate
{
  /// <summary>
  /// The mapping configuration for AspNetRole.
  /// </summary>
  public partial class AspNetRoleMap : ClassMap<AspNetRole>
  {
    /// <summary>
    /// The default constructor.
    /// </summary>
    public AspNetRoleMap()
      : this(new AttributeStore(), new MappingProviderStore())
    {
    }

    /// <summary>
    /// The constructor.
    /// </summary>
    public AspNetRoleMap(AttributeStore attributes, MappingProviderStore providers)
      : base(attributes, providers)
    {
      this.Providers = providers;


      this.Table("[AspNetRole]");
      

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

    public MappingProviderStore Providers { get; private set; }

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
               
       // Name
       
      this.Map(x => x.Name).Column("Name")
          .Length(200)          .Not.Nullable()          ;
                
       // DisplayName
       
      this.Map(x => x.DisplayName).Column("DisplayName")
          .Length(500)                   ;
                
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
            
      this.HasMany<AspNetUserRole>(x => x.AspNetUserRoles)
        .KeyColumn("AspNetRoleId")
                .Inverse()
                .LazyLoad()
                .AsBag();
            
      this.HasMany<AspNetRoleClaim>(x => x.AspNetRoleClaims)
        .KeyColumn("AspNetRoleId")
                .Inverse()
                .LazyLoad()
                .AsBag();
      
    }
    
  }
}