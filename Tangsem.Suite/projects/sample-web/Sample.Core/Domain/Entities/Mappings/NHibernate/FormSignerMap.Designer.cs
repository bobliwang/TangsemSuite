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
  /// The mapping configuration for FormSigner.
  /// </summary>
  public partial class FormSignerMap : ClassMap<FormSigner>
  {
    /// <summary>
    /// The constructor.
    /// </summary>
    public FormSignerMap()
    {

      this.Table("[FormSigner]");
      

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
            this.References<Form>(x => x.Form)
                .Fetch.Join()
                .Column("FormId")
      .Not.Nullable();            this.References<Signer>(x => x.Signer)
                .Fetch.Join()
                .Column("SignerId")
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