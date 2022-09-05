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
  /// The mapping configuration for AspNetUser.
  /// </summary>
  public partial class AspNetUserMap : ClassMap<AspNetUser>
  {
    /// <summary>
    /// The default constructor.
    /// </summary>
    public AspNetUserMap()
      : this(new AttributeStore(), new MappingProviderStore())
    {
    }

    /// <summary>
    /// The constructor.
    /// </summary>
    public AspNetUserMap(AttributeStore attributes, MappingProviderStore providers)
      : base(attributes, providers)
    {
      this.Providers = providers;


      this.Table("[AspNetUser]");
      

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
               
       // UserName
       
      this.Map(x => x.UserName).Column("UserName")
          .Length(250)          .Not.Nullable()          ;
                
       // Email
       
      this.Map(x => x.Email).Column("Email")
          .Length(250)                   ;
                
       // EmailConfirmed
       
      this.Map(x => x.EmailConfirmed).Column("EmailConfirmed")
                  .Not.Nullable()          ;
                
       // PasswordHash
       
      this.Map(x => x.PasswordHash).Column("PasswordHash")
          .Length(2000)                   ;
                
       // PhoneNumber
       
      this.Map(x => x.PhoneNumber).Column("PhoneNumber")
          .Length(50)                   ;
                
       // PhoneNumberConfirmed
       
      this.Map(x => x.PhoneNumberConfirmed).Column("PhoneNumberConfirmed")
                  .Not.Nullable()          ;
                
       // TwoFactorEnabled
       
      this.Map(x => x.TwoFactorEnabled).Column("TwoFactorEnabled")
                  .Not.Nullable()          ;
                
       // LockoutEnd
       
      this.Map(x => x.LockoutEnd).Column("LockoutEnd")
                           ;
                
       // LockoutEnabled
       
      this.Map(x => x.LockoutEnabled).Column("LockoutEnabled")
                  .Not.Nullable()          ;
                
       // AccessFailedCount
       
      this.Map(x => x.AccessFailedCount).Column("AccessFailedCount")
                  .Not.Nullable()          ;
                
       // SecurityStamp
       
      this.Map(x => x.SecurityStamp).Column("SecurityStamp")
          .Length(1024)                   ;
                
       // ConcurrencyStamp
       
      this.Map(x => x.ConcurrencyStamp).Column("ConcurrencyStamp")
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
                
       // AuthenticatorKey
       
      this.Map(x => x.AuthenticatorKey).Column("AuthenticatorKey")
          .Length(300)                   ;
                
       // NormalizedUserName
       
      this.Map(x => x.NormalizedUserName).Column("NormalizedUserName")
          .Length(300)                   ;
                
       // NormalizedEmail
       
      this.Map(x => x.NormalizedEmail).Column("NormalizedEmail")
          .Length(300)                   ;
       
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
        .KeyColumn("AspNetUserId")
                .Inverse()
                .LazyLoad()
                .AsBag();
            
      this.HasMany<AspNetUserClaim>(x => x.AspNetUserClaims)
        .KeyColumn("AspNetUserId")
                .Inverse()
                .LazyLoad()
                .AsBag();
            
      this.HasMany<AspNetUserLogin>(x => x.AspNetUserLogins)
        .KeyColumn("AspNetUserId")
                .Inverse()
                .LazyLoad()
                .AsBag();
            
      this.HasMany<AspNetUserToken>(x => x.AspNetUserTokens)
        .KeyColumn("AspNetUserId")
                .Inverse()
                .LazyLoad()
                .AsBag();
            
      this.HasMany<ApplicationUser>(x => x.ApplicationUsers)
        .KeyColumn("AspNetUserId")
                .Inverse()
                .LazyLoad()
                .AsBag();
      
    }
    
  }
}