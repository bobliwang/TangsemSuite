using System;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


using Microsoft.VisualStudio.TestTools.UnitTesting;

using Tangsem.Common.Entities;
using Tangsem.Common.Extensions.Linq;
using Tangsem.EF.Mappings;

using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities;
using Tangsem.Generator.WebMvc3Demo.Common.Domain.Repositories;
using Tangsem.Generator.WebMvc3Demo.Common.Domain.Repositories.EF;

namespace Tangsem.Generator.NHibernateTest
{
  [TestClass]
  public class EfPocoOperationsTest
  {
    public const int CurrentUserId = 5;

    private int _a = 0;

    [TestMethod]
    public void Test_ShowStatesUnderCountries()
    {

      var sw = Stopwatch.StartNew();

      using (var repo = this.CreateRepository())
      {
        Console.WriteLine("1 Time used:" + sw.Elapsed.TotalSeconds + " secs");

        var countries = repo.Countries.ActiveOnly().Include(c => c.States).ToList();

        foreach (var country in countries)
        {
          Console.WriteLine(country.Name);

          foreach (var state in country.States)
          {
            Console.WriteLine("\t" + state.Name);
          }
        }

        Console.WriteLine("2 Time used:" + sw.Elapsed.TotalSeconds + " secs");
      }
    }

    [TestMethod]
    public void Test_LoadCountryAustralia()
    {
      using (var repo = this.CreateRepository())
      {
        var au = repo.LookupById<Country>(1);

        Console.WriteLine("CountryId 1: " + au.Name);
      }
    }

    [TestMethod]
    public void Test_LoadEntityByIdTwice_ShouldUseCache()
    {
      using (var repo = this.CreateRepository())
      {
        var au0 = repo.LookupById<Country>(1);

        var au1 = repo.LookupById<Country>(1);

        Assert.IsTrue(object.ReferenceEquals(au0, au1));

        var au2 = repo.Countries.FirstOrDefault(x => x.Name == "Australia");

        Assert.IsTrue(object.ReferenceEquals(au0, au2));

        var countries = repo.Countries.ToList();

        var nz1 = repo.LookupById<Country>(2);

        nz1.Continent += "1";

        var nz2 = repo.Countries.FirstOrDefault(x => x.Id == 2);

        Assert.AreEqual(nz1.Continent, nz2.Continent);

        Assert.IsTrue(object.ReferenceEquals(nz1, nz2));
      }
    }

    [TestMethod]
    public void Test_CreateTasmaniaForAu()
    {
      Console.WriteLine("============= Adding =============");

      using (var repo = this.CreateRepository())
      {
        var au = repo.LookupById<Country>(1);
        repo.BeginTransaction();
        var state = new State { Name = "Tasmania" };

        au.AddToStates(state);

        Console.WriteLine("Relationship created in memory.");

        repo.Save(state);

        Console.WriteLine("State Saved.");
        repo.Commit();
        Console.WriteLine("Transaction Committed.");
      }

      Console.WriteLine("============= Searching and Deleting =============");
      using (var repo = this.CreateRepository())
      {
        var au = repo.LookupById<Country>(1);

        var tas = au.States.FirstOrDefault(x => x.Name == "Tasmania");

        Console.WriteLine("Show all Australian States:");
        var auStates = au.States.ToList();
        foreach (var st in auStates)
        {
          Console.WriteLine(st.Name + ":" + st.Country.Name);
        }

        Assert.IsNotNull(tas, "Tasmania for Australia is not found!");

        Assert.IsNotNull(tas.Active);
        Assert.IsTrue(tas.Active.Value);
        Assert.IsNotNull(tas.CreatedById);

        repo.BeginTransaction();
        repo.Delete(tas);
        Console.WriteLine("Tasmania Deleted.");
        Console.WriteLine("Tasmania found: " + repo.States.Any(x => x.Name == "Tasmania"));
        repo.Commit();
      }

      Console.WriteLine("============= Check if Deleted =============");
      using (var repo = this.CreateRepository())
      {
        var au = repo.LookupById<Country>(1);

        var tas = au.States.FirstOrDefault(x => x.Name == "Tasmania");

        Assert.IsNull(tas, "Tasmania for Australia is not deleted!");
      }
    }

    [TestMethod]
    public void TestView()
    {
      using (var repo = this.CreateRepository())
      {
        foreach (var vstate in repo.VStates.ToList())
        {
          Console.WriteLine(vstate.CountryName + "." + vstate.Name);
        }
      }
    }

    [TestMethod]
    public void TestEagerFetch_OneToMany_WithSubQry()
    {
      using (var repo = this.CreateRepository())
      {
        var countries = repo.Countries
                         .Include(x => x.States)
                         .Where(x => x.States.Count() > 1)
                         .ToList();

        foreach (var country in countries)
        {
          Console.WriteLine(country.States.ToList().Count);
        }
      }
    }

    [TestMethod]
    public void TestLazyLoad_OneToMany_WithSubQry()
    {
      using (var repo = this.CreateRepository())
      {
        var countries = repo.Countries
                         .Where(x => x.States.Count() > 1)
                         .ToList();

        foreach (var country in countries)
        {
          Console.WriteLine(country.States.ToList().Count);
        }
      }
    }

    [TestMethod]
    public void TestEagerFetch_ManyToOne()
    {
      using (var repo = this.CreateRepository())
      {
        var states = repo.States
                         .ToList();

        foreach (var state in states)
        {
          Console.WriteLine(state.Country.Name + "." + state.Name);
        }
      }
    }

    [TestMethod]
    public void TestLazyLoad_ManyToOne()
    {
      using (var repo = this.CreateRepository())
      {
        var states = repo.States
                         .ToList();

        foreach (var state in states)
        {
          Console.WriteLine(state.Country.Name + "." + state.Name);
        }
      }
    }

    [TestMethod]
    public void TestDynamicQuery()
    {
      using (var repo = this.CreateRepository())
      {
        foreach (var state in repo.States.Where("Country.Name.StartsWith(@0)", "China").ToList())
        {
          Console.WriteLine(state.Country.Name + "." + state.Name);
        }
      }
    }

    [TestMethod]
    public void TestAuditableEntity()
    {
      var cat = new Category();
      cat.Name = "Test category";
      cat.ShortDescription = "Category for testing.";

      using (var repo = this.CreateRepository())
      {
        repo.BeginTransaction();

        foreach (var c in repo.Categories.ToList())
        {
          repo.VirtualDelete(c);
        }

        repo.SaveCategory(cat);
        repo.Commit();
      }

      using (var repo = this.CreateRepository())
      {
        cat = repo.Categories.FirstOrDefault(x => !x.Active.HasValue || x.Active.Value);

        Assert.IsNotNull(cat, "Category 'Test category' is null!");
        Assert.AreEqual(cat.Active, true);
        Assert.AreEqual(CurrentUserId, cat.CreatedById);
        Assert.IsNotNull(cat.CreatedTime, "cat.CreatedTime");
      }
    }

    [TestMethod]
    public void Test_CreatingCategories()
    {
      using (var repo = this.CreateRepository())
      {
        var oldCount = repo.Categories.Count();

        repo.BeginTransaction();

        for (var i = 1; i <= 100; i++)
        {
          var cat = new Category { Name = "Category_" + i, ShortDescription = "Short Description for " + i, Description = "Description " + i };

          repo.SaveCategory(cat);
        }

        repo.Commit();

        var newCount = repo.Categories.Count();

        Assert.AreEqual(100, newCount - oldCount);
      }
    }

    /// <summary>
    /// Create the repository.
    /// </summary>
    /// <returns>The repository.</returns>
    private IMyRepository CreateRepository()
    {
      var dbContext = new MyDbContext(this.GetConnString());
      return new MyRepository { CurrentDbContext = dbContext, CurrentUserId = 1 };
    }


    private string GetConnString()
    {
      var connString = ConfigurationManager.ConnectionStrings["TangsemGeneratorNHibernateTest"].ConnectionString;

      return connString;
    }
  }
}
