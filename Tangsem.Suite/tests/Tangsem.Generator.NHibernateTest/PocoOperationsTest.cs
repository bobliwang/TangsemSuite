using System;
using System.Configuration;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using NHibernate;
using NHibernate.Dialect;
using NHibernate.Linq;

using Tangsem.Common.Extensions.Linq;
using Tangsem.Generator.NHibernateTest.Domain.Entities;
using Tangsem.Generator.NHibernateTest.Domain.Repositories;

namespace Tangsem.Generator.NHibernateTest
{
  [TestClass]
  public class PocoOperationsTest
  {
    /// <summary>
    /// The SessionFactory.
    /// </summary>
    public ISessionFactory SessionFactory { get; private set; }

    [TestInitialize]
    public void Init()
    {
      this.SessionFactory = this.CreateSessionFactory();
    }

    [TestMethod]
    public void Test_ShowStatesUnderCountries()
    {
      using (var repo = this.CreateRepository())
      {
        var countries = repo.Countries.FetchMany(c => c.States).ToList();

        foreach (var country in countries)
        {
          Console.WriteLine(country.Name);

          foreach (var state in country.States)
          {
            Console.WriteLine("\t" + state.Name);
          }
        }
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
                         .FetchMany(x => x.States)
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
                         .Fetch(x => x.Country)
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

    /// <summary>
    /// Create the repository.
    /// </summary>
    /// <returns>The repository.</returns>
    private NHibernateTestRepository CreateRepository()
    {
      return new NHibernateTestRepository { CurrentSession = this.SessionFactory.OpenSession() };
    }

    /// <summary>
    /// Create the SessionFactory.
    /// </summary>
    /// <returns>The session factory.</returns>
    private ISessionFactory CreateSessionFactory()
    {
      var connString = ConfigurationManager.ConnectionStrings["TangsemGeneratorNHibernateTest"].ConnectionString;

      return Fluently
        .Configure()
        .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connString).ShowSql().MaxFetchDepth(3).Dialect<MsSql2008Dialect>())
        .Mappings(m =>
          m.FluentMappings.AddFromAssemblyOf<Country>())
        .BuildSessionFactory();
    }

  }
}
