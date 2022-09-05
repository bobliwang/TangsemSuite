using System;
using System.Linq;
using GeneratorTest.Common.Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Tangsem.Data.Domain;

namespace GeneratorTest.Common.Tests
{
  [TestClass]
  public class UnitTest1
  {

    public static readonly string ConnString = @"Data Source=.\SQLExpress;Initial Catalog=test;Integrated Security=True";

    private readonly GeneratorTestRepositoryBuilder _repositoryBuilder = new GeneratorTestRepositoryBuilder(ConnString);

    [TestMethod]
    public void TestMethod1()
    {
      using (var repo = this.GetRepo())
      {
        var customers = repo.Customers.ToList();

        foreach (var c in customers)
        {
          Console.WriteLine("Customer: " + c.CustomerName);

        }
      }
    }

    [TestMethod]
    public void TestLinqCSharpJoin()
    {
      using (var repo = this.GetRepo())
      {
        var objs = repo.Poses.Join(repo.Stores, p => p.StoreId, s => s.Id, (x, y) => new {x.Id, x.Name, y.StoreName})
          .ToList();

        foreach (var obj in objs)
        {
          Console.WriteLine("Object: " + JsonConvert.SerializeObject(obj));
        }
        
      }
    }

    [TestMethod]
    public void TestLinqQryJoin()
    {
      using (var repo = this.GetRepo())
      {
        var objs = 
            (
              from p in repo.Poses
              join s in repo.Stores
              on p.StoreId equals s.Id
              select new { p.Id, p.Name, s.StoreName }
            )
          .ToList();

        foreach (var obj in objs)
        {
          Console.WriteLine("Object: " + JsonConvert.SerializeObject(obj));
        }

      }
    }

    private IGeneratorTestRepository GetRepo()
    {
      return this._repositoryBuilder.CreateRepository(new MockDataContext()) as IGeneratorTestRepository;
    }
  }

  class MockDataContext : IDataContext
  {
    public int CurrentUserId { get; } = 100;
  }
}
