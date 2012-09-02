using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.Entity;

using Tangsem.EF.Mappings;
/* http://msdn.microsoft.com/en-us/library/hh295843(v=vs.103) */
namespace Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities.Mappings.EF
{
  /// <summary>
  /// The mapping configuration for State.
  /// </summary>
  public partial class StateMap : ClassMap<State>
  {
    /// <summary>
    /// The constructor.
    /// </summary>
    public StateMap() : base()
    {
    }
    
    /// <summary>
    /// Map Table.
    /// </summary>
    protected override void MapTable(DbModelBuilder modelBuilder)
    {
      this.EntityTypeConfiguration.ToTable("State");
    }

    /// <summary>
    /// Map the Primary Key.
    /// </summary>
    protected override void MapId(DbModelBuilder modelBuilder)
    {

        this.EntityTypeConfiguration
            .HasKey(x => x.Id)
            .Property(x => x.Id)
            .HasColumnName("Id");
        }
    
    /// <summary>
    /// Map the Basic Columns.
    /// </summary>
    protected override void MapBasicColumns(DbModelBuilder modelBuilder)
    {

         this.EntityTypeConfiguration
             .Property(x => x.Name)
             .HasColumnName("Name").IsRequired();      
         this.EntityTypeConfiguration
             .Property(x => x.CreatedById)
             .HasColumnName("CreatedById");      
         this.EntityTypeConfiguration
             .Property(x => x.ModifiedById)
             .HasColumnName("ModifiedById");      
         this.EntityTypeConfiguration
             .Property(x => x.CreatedTime)
             .HasColumnName("CreatedTime");      
         this.EntityTypeConfiguration
             .Property(x => x.ModifiedTime)
             .HasColumnName("ModifiedTime");      
         this.EntityTypeConfiguration
             .Property(x => x.Active)
             .HasColumnName("Active");      
    }
    
    /// <summary>
    /// Map the MapRelationships.
    /// </summary>
    protected override void MapRelationships(DbModelBuilder modelBuilder)
    {
      
        this.EntityTypeConfiguration
            .HasOptional(x => x.Country)
        .WithMany(x => x.States)
        .Map(m => m.MapKey("CountryId"));
      
    }
  }
}