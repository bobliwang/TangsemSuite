using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

using NHTest.Common.Domain.Repositories;
using NHTest.Common.Domain.Repositories.NHibernate;
using NHTest.Common.Services;
using NHTest.NHTest.Common.Domain.ViewModels;

using Tangsem.Data;
using Tangsem.NHibernate.Extenstions;

namespace NHTest
{
  [TestClass]
  public class UnitTest1
  {
    private NHTestRepositoryProvider _nhTestRepositoryProvider =
      new NHTestRepositoryProvider(@"Data Source=.\SQLExpress;Initial Catalog=test;Integrated Security=True");

    [TestMethod]
    public void TestUpdate()
    {
      using (var repo = this.OpenRepository())
      {
        repo.BeginTransaction();

        var idx = 0;
        foreach(var prod in repo.Products.ToList())
        {
          idx++;
          var specs = new List<ProductSpec>();

          specs.Add(new ProductSpec { Name = $"Color {idx}", Value = "Black", Description = "Black Color" });
          specs.Add(new ProductSpec
          {
            Name = "Dimension",
            Value = $"{prod.Id * 10} x {prod.Id * 20}",
            Description = $"{prod.Id * 10}mm x {prod.Id * 20}mm"
          });

          prod.SpecsJson = specs.ToArray();

          repo.UpdateProduct(prod);
        }

        repo.Commit();
      }
    }

    [TestMethod]
    public void TestOrderBy()
    {
      using (var repo = this.OpenRepository())
      {
        var qry = repo.Products;

        var prods = qry.SortBy(new SortByModel { SortFieldName = "Id", Direction = "desc" }).ToList();



      }
    }

    [TestMethod]
    public void TestIsNullOrEmpty()
    {
      using(var repo = this.OpenRepository())
      {
        var prod = repo.Products.FirstOrDefault(x => !string.IsNullOrEmpty(x.Name));

        Console.WriteLine("Prod " + JsonConvert.SerializeObject(prod));
      }
    }

    [TestMethod]
    public void TestIsNullOrWhiteSpace()
    {
      using (var repo = this.OpenRepository())
      {
        var prod = repo.Products.FirstOrDefault(x => !string.IsNullOrWhiteSpace(x.Name));

        Console.WriteLine("Prod " + JsonConvert.SerializeObject(prod));
      }
    }

    [TestMethod]
    public void TestIsLike()
    {
      using (var repo = this.OpenRepository())
      {
        var prod = repo.Products.FirstOrDefault(x => x.Name.IsLike("%prod%"));

        Console.WriteLine("Prod " + JsonConvert.SerializeObject(prod));
      }
    }

    [TestMethod]
    public void TestArrayLength()
    {
      using (var repo = this.OpenRepository())
      {
        var prod = repo.Products.FirstOrDefault(x => x.SpecsJson.JsonArrayLength() > 0);
        Console.WriteLine("Prod " + JsonConvert.SerializeObject(prod));

        prod = repo.Products.FirstOrDefault(x => x.SpecsJson.JsonArrayLength() == 0);
        Console.WriteLine("Prod " + JsonConvert.SerializeObject(prod));
      }
    }

    [TestMethod]
    public void TestJsonArrayTest()
    {
      using (var repo = this.OpenRepository())
      {
        var prod = repo.Products.FirstOrDefault(x => x.SpecsJson.Any(s => s.Name == "iPhone 6"));
        Console.WriteLine("Prod " + JsonConvert.SerializeObject(prod));
      }
    }

    public INHTestRepository OpenRepository()
    {
      return this._nhTestRepositoryProvider.CreateRepository();
    }
  }
}
