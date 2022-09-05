using System;
using System.Collections.Generic;
using System.Linq;

using GeneratorTest.Common.Domain.ViewModels;

using Tangsem.NHibernate.Tests.Domain.Entities;

using Xunit;
using Xunit.Abstractions;

namespace Tangsem.NHibernate.Tests.Tests
{
  public class UnitTest1 : TestBase
  {
    public UnitTest1(ITestOutputHelper output)
      : base(output)
    {
    }

    [Fact(DisplayName = nameof(PagingTest))]
    public void PagingTest()
    {
      var count0 = 0;
      var count1 = 0;
      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction(System.Data.IsolationLevel.Serializable))
      {
        count0 = repo.Customers.Count();

        var custs = new List<Customer>();

        for (var i = 0; i < 100; i++)
        {
          custs.Add(repo.SaveCustomer(new Customer { CustomerName = "ZCust " + i.ToString().PadLeft(2, '0') }));
        }

        repo.Flush();

        var custIds = custs.Select(x => x.CustomerId).ToList();

        var paged = repo.Customers.Where(x => custIds.Contains(x.CustomerId) && x.Active).Skip(10).Take(20).ToList();
        Assert.Equal(20, paged.Count);

        paged = repo.Customers.Where(x => custIds.Contains(x.CustomerId) && !x.Active).Skip(10).Take(20).ToList();
        Assert.Empty(paged);

        foreach (var cust in custs)
        {
          repo.Delete(cust);
        }

        count1 = repo.Customers.Count();
      }

      Assert.Equal(count0, count1);
    }

    [Fact(DisplayName = nameof(JsonColumnUpdateAndRead))]
    public void JsonColumnUpdateAndRead()
    {
      var prodName = $"Prod {Guid.NewGuid()}";
      Product prod;
      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      {
        prod = new Product { Name = prodName, UnitPrice = 100 };
        repo.SaveProduct(prod);

        var specs =  new []
                       {
                         new ProductSpec { Name = $"Color", Value = "Black", Description = "Black Color" },
                         new ProductSpec
                           {
                             Name = "Dimension",
                             Value = $"{prod.Id * 10} x {prod.Id * 20}",
                             Description = $"{prod.Id * 10}mm x {prod.Id * 20}mm"
                           }
                       };
        prod.SpecsJson = specs;
      }

      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      {
        var reloadedProd = repo.Products.FirstOrDefault(x => x.Name == prodName);

        Assert.NotNull(reloadedProd);
        Assert.NotNull(reloadedProd.SpecsJson);
        Assert.NotEmpty(reloadedProd.SpecsJson);
        Assert.Equal(2, reloadedProd.SpecsJson.Length);
        Assert.Equal("Dimension", reloadedProd.SpecsJson[1].Name);

        Assert.False(object.ReferenceEquals(prod, reloadedProd));

        repo.Delete(reloadedProd);
      }
    }

    [Fact(DisplayName = nameof(SaveAndVirtualDeleteTest))]
    public void SaveAndVirtualDeleteTest()
    {
      var prodName = $"prod {Guid.NewGuid()}";
      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      {
        var prod = new Product { Name = prodName, UnitPrice = 200 };
        Assert.True(prod.Active);
        repo.SaveProduct(prod);
        repo.Flush();
        Assert.StartsWith("insert", this.lastSql, StringComparison.InvariantCultureIgnoreCase);
        Assert.True(prod.Active);

        repo.VirtualDelete(prod);
        repo.Flush();
        Assert.StartsWith("update", this.lastSql, StringComparison.InvariantCultureIgnoreCase);
        Assert.False(prod.Active);

        var result = repo.Products.Where(x => x.Name == prodName).Select(x => new { x.Id, x.Active }).FirstOrDefault();
        Assert.NotNull(result);
        Assert.Equal(prod.Id, result.Id);
        Assert.Equal(prod.Active, result.Active);

        repo.Delete(prod);
        repo.Flush();
        Assert.StartsWith("delete", this.lastSql, StringComparison.InvariantCultureIgnoreCase);
      }
    }

    [Fact(DisplayName = nameof(DeleteTest))]
    public void DeleteTest()
    {
      var prodName = $"prod {Guid.NewGuid()}";
      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      {
        var prod = new Product { Name = prodName, UnitPrice = 200 };
        repo.SaveProduct(prod);

        var cust = new Customer { CustomerName = "Test Cust 1" };
        repo.SaveCustomer(cust);

        var order = new Order { Product = prod };
        order.OrderTotal = 200;
        order.CustomerName = "Test Cust1";
        order.Customer = cust;

        repo.SaveOrder(order);
      }

      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      {
        foreach (var p in repo.Products.Where(x => x.Name == prodName).ToList())
        {
          foreach (var o in p.Orders.ToList())
          {
            if (o.Customer != null)
            {
              repo.Delete(o.Customer);
            }

            repo.Delete(o);
          }

          repo.Delete(p);
        }

        repo.Flush();

        var list = repo.Products.Where(x => x.Name == prodName).ToList();
        Assert.Empty(list);
      }
    }
  }
}
