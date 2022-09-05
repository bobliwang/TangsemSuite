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
  /// The mapping configuration for AspNetRoleClaim.
  /// </summary>
  public partial class AspNetRoleClaimMap : ClassMap<AspNetRoleClaim>
  {
    /// <summary>
    /// The default constructor.
    /// </summary>
    public AspNetRoleClaimMap()
      : this(new AttributeStore(), new MappingProviderStore())
    {
    }

    /// <summary>
    /// The constructor.
    /// </summary>
    public AspNetRoleClaimMap(AttributeStore attributes, MappingProviderStore providers)
      : base(attributes, providers)
    {
      this.Providers = providers;


      this.Table("[AspNetRoleClaim]");
      

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
               
       // ClaimType
       
      this.Map(x => x.ClaimType).Column("ClaimType")
          .Length(1024)                   ;
                
       // ClaimValue
       
      this.Map(x => x.ClaimValue).Column("ClaimValue")
          .Length(1024)                   ;
                
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
            
      this.References<AspNetRole>(x => x.AspNetRole)
                .Fetch.Join().Column("AspNetRoleId")
      .Not.Nullable();      
    }
    
    /// <summary>
    /// Map the Incoming References.
    /// </summary>
    private void MapIncomingReferences()
    {
      
    }
    
  }
}