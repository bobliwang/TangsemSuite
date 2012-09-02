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
  /// The mapping configuration for VState.
  /// </summary>
  public partial class VStateMap : ClassMap<VState>
  {
    /// <summary>
    /// The constructor.
    /// </summary>
    public VStateMap() : base()
    {
    }
    
    /// <summary>
    /// Map Table.
    /// </summary>
    protected override void MapTable(DbModelBuilder modelBuilder)
    {
      this.EntityTypeConfiguration.ToTable("v_State");
    }

    /// <summary>
    /// Map the Primary Key.
    /// </summary>
    protected override void MapId(DbModelBuilder modelBuilder)
    {
    }
    
    /// <summary>
    /// Map the Basic Columns.
    /// </summary>
    protected override void MapBasicColumns(DbModelBuilder modelBuilder)
    {

         this.EntityTypeConfiguration
             .Property(x => x.RowNum)
             .HasColumnName("RowNum");      
         this.EntityTypeConfiguration
             .Property(x => x.Id)
             .HasColumnName("Id").IsRequired();      
         this.EntityTypeConfiguration
             .Property(x => x.Name)
             .HasColumnName("Name").IsRequired();      
         this.EntityTypeConfiguration
             .Property(x => x.CountryId)
             .HasColumnName("CountryId");      
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
         this.EntityTypeConfiguration
             .Property(x => x.CountryName)
             .HasColumnName("CountryName");      
         this.EntityTypeConfiguration
             .Property(x => x.CountryCode)
             .HasColumnName("CountryCode");      
         this.EntityTypeConfiguration
             .Property(x => x.Continent)
             .HasColumnName("Continent");      
    }
    
    /// <summary>
    /// Map the MapRelationships.
    /// </summary>
    protected override void MapRelationships(DbModelBuilder modelBuilder)
    {

    }
  }
}