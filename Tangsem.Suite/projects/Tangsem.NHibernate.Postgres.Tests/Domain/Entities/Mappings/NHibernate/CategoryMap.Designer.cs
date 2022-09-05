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
  /// The mapping configuration for Category.
  /// </summary>
  public partial class CategoryMap : ClassMap<Category>
  {
    /// <summary>
    /// The default constructor.
    /// </summary>
    public CategoryMap()
      : this(new AttributeStore(), new MappingProviderStore())
    {
    }

    /// <summary>
    /// The constructor.
    /// </summary>
    public CategoryMap(AttributeStore attributes, MappingProviderStore providers)
      : base(attributes, providers)
    {
      this.Providers = providers;

      this.Schema("public");

      this.Table("Category");
      

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
               
       // CategoryName
       
      this.Map(x => x.CategoryName).Column("CategoryName")
          .Length(200)                   ;
                
       // CreatedDate
       
      this.Map(x => x.CreatedDate).Column("CreatedDate")
                  .Not.Nullable()          ;
                
       // ExtdProps
       
      this.Map(x => x.ExtdProps).Column("ExtdProps")
          .Length(int.MaxValue)                   ;
       
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
        .KeyColumn("CategoryId")
                .Inverse()
                .LazyLoad()
                .AsBag();
      
    }
    
  }
}