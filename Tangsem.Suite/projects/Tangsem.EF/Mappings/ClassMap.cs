using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Tangsem.EF.Mappings
{
  public class ClassMap<TEntity>
    where TEntity : class
  {
    public ClassMap()
    {
    }

    protected EntityTypeConfiguration<TEntity> EntityTypeConfiguration { get; set; }

    public virtual void Map(DbModelBuilder modelBuilder)
    {
      this.EntityTypeConfiguration = modelBuilder.Entity<TEntity>();

      this.MapTable(modelBuilder);
      this.MapId(modelBuilder);
      this.MapBasicColumns(modelBuilder);
      this.MapRelationships(modelBuilder);
    }

    protected virtual void MapTable(DbModelBuilder modelBuilder)
    {
    }

    protected virtual void MapId(DbModelBuilder modelBuilder)
    {
    }

    protected virtual void MapBasicColumns(DbModelBuilder modelBuilder)
    {
    }

    protected virtual void MapRelationships(DbModelBuilder modelBuilder)
    {
    }
  }
}
