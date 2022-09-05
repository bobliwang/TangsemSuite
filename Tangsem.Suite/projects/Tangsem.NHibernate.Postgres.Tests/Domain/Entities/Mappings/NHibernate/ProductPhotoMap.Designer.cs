using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel;

using Tangsem.NHibernate.UserTypes;


namespace Tangsem.NHibernate.Tests.PostgreTest1.Domain.Entities.Mappings.NHibernate
{
  /// <summary>
  /// The mapping configuration for ProductPhoto.
  /// </summary>
  public partial class ProductPhotoMap : ClassMap<ProductPhoto>
  {
    /// <summary>
    /// The default constructor.
    /// </summary>
    public ProductPhotoMap()
      : this(new AttributeStore(), new MappingProviderStore())
    {
    }

    /// <summary>
    /// The constructor.
    /// </summary>
    public ProductPhotoMap(AttributeStore attributes, MappingProviderStore providers)
      : base(attributes, providers)
    {
      this.Providers = providers;

      this.Schema("public");

      this.Table("ProductPhoto");
      

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
               
       // CreatedDate
       
      this.Map(x => x.CreatedDate).Column("CreatedDate")
                  .Not.Nullable()          ;
                
       // ExtdProps
       
      this.Map(x => x.ExtdProps).Column("ExtdProps")
          .Length(int.MaxValue)                   ;
                
       // ImageData
       
      this.Map(x => x.ImageData).Column("ImageData")
          .Length(int.MaxValue)                   ;
       
    }

        
    /// <summary>
    /// Map the Outgoing References.
    /// </summary>
    private void MapOutgoingReferences()
    {
            
      this.References<Product>(x => x.Product)
                .Fetch.Join().Column("ProductId")
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