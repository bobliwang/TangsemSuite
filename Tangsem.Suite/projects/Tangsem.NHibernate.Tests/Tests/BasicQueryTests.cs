using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using GeneratorTest.Common.Domain.ViewModels;

using Tangsem.Data;
using Tangsem.NHibernate.Tests.Domain.Entities;

using Xunit;
using Xunit.Abstractions;
using Tangsem.NHibernate.Extensions;

namespace Tangsem.NHibernate.Tests.Tests
{
  public class BasicQueryTests : TestBase
  {
    public BasicQueryTests(ITestOutputHelper output)
      : base(output)
    {
    }

    [Fact(DisplayName = nameof(TestRowVersion))]
    public void TestRowVersion()
    {
      var customerId = Guid.NewGuid();
      using (var repo = this.OpenRepository())
      using (var tx = repo.BeginTransaction())
      {
        var cust = repo.SaveCustomer(new Customer { CustomerId = customerId, CustomerName = "RowVersion test" });
      }

      var task0 = Task.Run(
        () =>
          {
            using (var repo = this.OpenRepository())
            using (var tx = repo.BeginTransaction())
            {
              var cust = repo.LookupCustomerByCustomerId(customerId);

              cust.CustomerName += " at " + DateTime.Now;

              Thread.Sleep(500);
            }
          });
      
      var task1 = Task.Run(
        () =>
          {
            using (var repo = this.OpenRepository())
            using (var tx = repo.BeginTransaction())
            {
              var cust = repo.LookupCustomerByCustomerId(customerId);

              Thread.Sleep(1000);
              cust.CustomerName += " at " + DateTime.Now;
            }
          });

      try
      {
        Task.WaitAll(task0, task1);

        throw new Exception("UNEXPECTED_CODE_123");
      }
      catch(Exception ex)
      {
        Assert.NotEqual("UNEXPECTED_CODE_123", ex.Message);
      }
    }

    [Fact(DisplayName = nameof(TestIsLike))]
    public void TestIsLike()
    {
      using (var repo = this.OpenRepository())
      {
        repo.SaveProduct(new Product { Name = "test prod name like" });

        var prod = repo.Products.FirstOrDefault(x => LinqFunctionExtensions.IsLike(x.Name, "%prod%"));

        Assert.NotNull(prod);
        Assert.True(prod.Name.Contains("prod", StringComparison.InvariantCultureIgnoreCase));
      }
    }

    [Fact(DisplayName = nameof(TestIsNullOrEmpty))]
    public void TestIsNullOrEmpty()
    {
      using (var repo = this.OpenRepository())
      {
        repo.SaveProduct(new Product { Name = "MyProd" });

        var prod = repo.Products.FirstOrDefault(x => !string.IsNullOrEmpty(x.Name));

        Assert.NotNull(prod);
        Assert.NotNull(prod.Name);
        Assert.NotEmpty(prod.Name);
      }
    }

    [Fact(DisplayName = nameof(TestIsNullOrWhiteSpace))]
    public void TestIsNullOrWhiteSpace()
    {
      using (var repo = this.OpenRepository())
      {
        var prod = repo.Products.FirstOrDefault(x => !string.IsNullOrWhiteSpace(x.Name));

        Assert.NotNull(prod);
        Assert.True(!string.IsNullOrWhiteSpace(prod.Name));
      }
    }

    [Fact(DisplayName = nameof(OrderByTest))]
    public void OrderByTest()
    {
      using (var repo = this.OpenRepository())
      {
        var qry = repo.Products;

        var prods = qry.SortBy(new SortByModel { SortFieldName = "Id", Direction = "desc" }).ToList();
        var prods1 = prods.OrderByDescending(x => x.Id).ToList();

        Assert.True(prods.Count > 0);
        Assert.Equal(prods[0].Id, prods1[0].Id);
        Assert.Equal(prods.Last().Id, prods1.Last().Id);
      }
    }

    [Fact(DisplayName = nameof(JsonArrayLengthTest))]
    public void JsonArrayLengthTest()
    {
      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      {
        var spec = new ProductSpec {Name = "test spec 1", Value = "spec 1 value"};

        repo.SaveProduct(new Product
                           {
                             Name = "test prod 1",
                             SpecsJson = new[] { spec }
                           });

        repo.Flush();

        var prod = repo.Products.FirstOrDefault(x => x.SpecsJson.JsonArrayLength() > 0);
        Assert.NotNull(prod);
        Assert.True(prod.SpecsJson.Length > 0);

        repo.SaveProduct(new Product
                           {
                             Name = "test prod 1",
                             SpecsJson = new ProductSpec[0]
                           });

        repo.Flush();

        prod = repo.Products.FirstOrDefault(x => x.SpecsJson.JsonArrayLength() == 0);
        Assert.NotNull(prod);
        Assert.True(prod.SpecsJson == null || prod.SpecsJson.Length == 0);
      }
    }
  }
}