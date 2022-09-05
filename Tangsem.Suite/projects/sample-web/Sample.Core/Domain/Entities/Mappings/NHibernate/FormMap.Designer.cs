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
  /// The mapping configuration for Form.
  /// </summary>
  public partial class FormMap : ClassMap<Form>
  {
    /// <summary>
    /// The constructor.
    /// </summary>
    public FormMap()
    {

      this.Table("[Form]");
      

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
               
         // Title
       
                
         this.Map(x => x.Title).Column("Title")

          .Length(250)                   ;
                
         // FormJson
       
                
         this.Map(x => x.FormJson).Column("FormJson")

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
                
         // RowVersion
       
                this.Version(x => x.RowVersion).Generated.Always();
           }

        
    /// <summary>
    /// Map the Outgoing References.
    /// </summary>
    private void MapOutgoingReferences()
    {
            this.References<AspNetUser>(x => x.AspNetUser)
                .Fetch.Join()
                .Column("AspNetUserId")
      .Not.Nullable();      
    }
    
    /// <summary>
    /// Map the Incoming References.
    /// </summary>
    private void MapIncomingReferences()
    {
            this.HasMany<FormSigner>(x => x.FormSigners)
        .KeyColumn("FormId")
                .Inverse()
                .LazyLoad()
                .AsBag();
      
    }
      }
}