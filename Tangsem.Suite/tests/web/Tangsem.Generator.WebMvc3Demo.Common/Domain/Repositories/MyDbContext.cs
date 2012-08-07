
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

using Tangsem.EF.Mappings;
using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities;
using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities.Mappings;

namespace Tangsem.Generator.WebMvc3Demo.Common.Domain.Repositories
{
  public class MyDbContext : DbContext
  {
    public MyDbContext(string nameOrConnectionString)
      : base(nameOrConnectionString)
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      var types = new[] { typeof(CategoryMap), typeof(StateMap), typeof(VStateMap), typeof(CountryMap) };

      foreach (var type in types)
      {
        var map = Activator.CreateInstance(type) as IClassMap;

        map.Map(modelBuilder);
      }
    }
  }
}
