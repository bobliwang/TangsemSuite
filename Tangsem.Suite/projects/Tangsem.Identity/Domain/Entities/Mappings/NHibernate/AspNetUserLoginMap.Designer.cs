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
  /// The mapping configuration for AspNetUserLogin.
  /// </summary>
  public partial class AspNetUserLoginMap : ClassMap<AspNetUserLogin>
  {
    /// <summary>
    /// The default constructor.
    /// </summary>
    public AspNetUserLoginMap()
      : this(new AttributeStore(), new MappingProviderStore())
    {
    }

    /// <summary>
    /// The constructor.
    /// </summary>
    public AspNetUserLoginMap(AttributeStore attributes, MappingProviderStore providers)
      : base(attributes, providers)
    {
      this.Providers = providers;


      this.Table("[AspNetUserLogin]");
      

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
               
       // LoginProvider
       
      this.Map(x => x.LoginProvider).Column("LoginProvider")
          .Length(200)          .Not.Nullable()          ;
                
       // ProviderKey
       
      this.Map(x => x.ProviderKey).Column("ProviderKey")
          .Length(200)          .Not.Nullable()          ;
                
       // ProviderDisplayName
       
      this.Map(x => x.ProviderDisplayName).Column("ProviderDisplayName")
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
            
      this.References<AspNetUser>(x => x.AspNetUser)
                .Fetch.Join().Column("AspNetUserId")
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