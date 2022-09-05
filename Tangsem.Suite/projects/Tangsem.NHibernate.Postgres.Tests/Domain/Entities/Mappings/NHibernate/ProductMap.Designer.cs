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
  /// The mapping configuration for Product.
  /// </summary>
  public partial class ProductMap : ClassMap<Product>
  {
    /// <summary>
    /// The default constructor.
    /// </summary>
    public ProductMap()
      : this(new AttributeStore(), new MappingProviderStore())
    {
    }

    /// <summary>
    /// The constructor.
    /// </summary>
    public ProductMap(AttributeStore attributes, MappingProviderStore providers)
      : base(attributes, providers)
    {
      this.Providers = providers;

      this.Schema("public");

      this.Table("Product");
      

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
               
       // ProductName
       
      this.Map(x => x.ProductName).Column("ProductName")
          .Length(200)                   ;
                
       // CreatedDate
       
      this.Map(x => x.CreatedDate).Column("CreatedDate")
                  .Not.Nullable()          ;
                
       // ExtdProps
       
      this.Map(x => x.ExtdProps).Column("ExtdProps").CustomType<JsonType<Tangsem.NHibernate.Tests.PostgreTest1.Models.PictureModel[]>>()
                  ;
        
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
            
      this.HasMany<ProductCategoryMap>(x => x.ProductCategoryMaps)
        .KeyColumn("ProductId")
                .Inverse()
                .LazyLoad()
                .AsBag();
            
      this.HasMany<ProductPhoto>(x => x.ProductPhotos)
        .KeyColumn("ProductId")
                .Inverse()
                .LazyLoad()
                .AsBag();
      
    }
    
  }
}