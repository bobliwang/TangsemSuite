using System;
using System.Linq;

using Tangsem.NHibernate.Tests.Domain.Entities;

using Xunit;
using Xunit.Abstractions;
using Tangsem.NHibernate.Extensions;

namespace Tangsem.NHibernate.Tests.Tests
{
  public class RelationQueryTests : TestBase
  {
    public RelationQueryTests(ITestOutputHelper output)
      : base(output)
    {
    }

    [Fact(DisplayName = nameof(LeftJoin_Include_Test))]
    public void LeftJoin_Include_Test()
    {
      var store = new Store { StoreName = $"Store {Guid.NewGuid()}" };
      var cust = new Customer { CustomerName = $"Customer {Guid.NewGuid()}" };

      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      {
        repo.SaveStore(store);
        cust.Store = store;
        repo.SaveCustomer(cust);

        repo.Flush();
        Assert.StartsWith("insert", this.lastSql, StringComparison.InvariantCultureIgnoreCase);

        var cust1 = repo.Customers.Where(x => x.CustomerName == cust.CustomerName).Include(x => x.Store).FirstOrDefault();

        Assert.True(this.lastSql.Contains("left outer join", StringComparison.InvariantCultureIgnoreCase));

        Assert.NotNull(cust1);
        Assert.Equal(cust.CustomerId, cust1.CustomerId);

        Assert.NotNull(cust.Store);
        Assert.Equal(store.Id, cust.Store.Id);
        
        repo.Delete(cust1);
        repo.Delete(cust1.Store);
      }
    }

    [Fact(DisplayName = nameof(LeftJoin_AnonymousTypeCreation_Test))]
    public void LeftJoin_AnonymousTypeCreation_Test()
    {
      var store = new Store { StoreName = $"Store {Guid.NewGuid()}" };
      var cust = new Customer { CustomerName = $"Customer {Guid.NewGuid()}" };

      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      {
        repo.SaveStore(store);
        cust.Store = store;
        repo.SaveCustomer(cust);

        repo.Flush();
        Assert.StartsWith("insert", this.lastSql, StringComparison.InvariantCultureIgnoreCase);

        var combined = repo.Customers.Where(x => x.CustomerName == cust.CustomerName).Select(x =>
          new {
                  Customer = x,
                  x.Store,
                }).FirstOrDefault();

        Assert.True(this.lastSql.Contains("left outer join", StringComparison.InvariantCultureIgnoreCase));

        Assert.NotNull(combined);
        Assert.Equal(cust.CustomerId, combined.Customer.CustomerId);

        Assert.NotNull(cust.Store);
        Assert.Equal(store.Id, cust.Store.Id);

        repo.Delete(combined.Customer);
        repo.Delete(combined.Store);
      }
    }

    [Fact(DisplayName = nameof(NoLeftJoin_ManyToOne_Test))]
    public void NoLeftJoin_ManyToOne_Test()
    {
      var store = new Store { StoreName = $"Store {Guid.NewGuid()}" };
      var cust = new Customer { CustomerName = $"Customer {Guid.NewGuid()}" };

      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      {
        repo.SaveStore(store);
        cust.Store = store;
        repo.SaveCustomer(cust);
        repo.Flush();
        Assert.StartsWith("insert", this.lastSql, StringComparison.InvariantCultureIgnoreCase);
      }

      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      {
        var cust1 = repo.Customers.FirstOrDefault(x => x.CustomerName == cust.CustomerName);
        // left join should not be there.
        Assert.False(this.lastSql.Contains("left outer join", StringComparison.InvariantCultureIgnoreCase));
        Assert.False(this.lastSql.Contains("left join", StringComparison.InvariantCultureIgnoreCase));

        Assert.NotNull(cust1);
        Assert.Equal(cust.CustomerId, cust1.CustomerId);

        Assert.NotNull(cust.Store);
        Assert.StartsWith("select", this.lastSql, StringComparison.InvariantCultureIgnoreCase);
        Assert.Equal(store.Id, cust.Store.Id);
        repo.Delete(cust1);
        repo.Delete(cust1.Store);
      }
    }

    [Fact(DisplayName = nameof(NoLeftJoin_OneToMany_Test))]
    public void NoLeftJoin_OneToMany_Test()
    {
      var store = new Store { StoreName = $"Store {Guid.NewGuid()}" };
      var cust = new Customer { CustomerName = $"Customer {Guid.NewGuid()}" };

      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      {
        repo.SaveStore(store);
        cust.Store = store;
        repo.SaveCustomer(cust);
        repo.Flush();
        Assert.StartsWith("insert", this.lastSql, StringComparison.InvariantCultureIgnoreCase);
      }

      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      {
        var store1 = repo.Stores.FirstOrDefault(x => x.StoreName == store.StoreName);
        Assert.False(this.lastSql.Contains("left outer join", StringComparison.InvariantCultureIgnoreCase));
        Assert.False(this.lastSql.Contains("left join", StringComparison.InvariantCultureIgnoreCase));

        Assert.NotNull(store1);
        Assert.Equal(store.Id, store1.Id);

        Assert.NotNull(store1.Customers);
        Assert.Equal(1, store1.Customers.Count);
        Assert.Equal(cust.CustomerName, store1.Customers[0].CustomerName);

        repo.Delete(store1.Customers[0]);
        repo.Delete(store1);
      }
    }

    [Fact(DisplayName = nameof(LeftJoin_ShouldBeUsed_In_LookbyId_Test))]
    public void LeftJoin_ShouldBeUsed_In_LookbyId_Test()
    {
      var store = new Store { StoreName = $"Store {Guid.NewGuid()}" };
      var cust = new Customer { CustomerName = $"Customer {Guid.NewGuid()}" };

      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      {
        repo.SaveStore(store);
        cust.Store = store;
        repo.SaveCustomer(cust);
        repo.Flush();
        Assert.StartsWith("insert", this.lastSql, StringComparison.InvariantCultureIgnoreCase);
      }

      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      {
        var cust1 = repo.LookupCustomerByCustomerId(cust.CustomerId);

        // this is really up to MaxFetchDepth > 0
        Assert.True(this.lastSql.Contains("left outer join", StringComparison.InvariantCultureIgnoreCase));

        Assert.NotNull(cust1);
        Assert.Equal(cust.CustomerId, cust1.CustomerId);

        Assert.NotNull(cust.Store);
        Assert.Equal(store.Id, cust.Store.Id);
        repo.Delete(cust1);
        repo.Delete(cust1.Store);
      }
    }

    [Fact(DisplayName = nameof(LeftJoin_OneToMany_Test))]
    public void LeftJoin_OneToMany_Test()
    {
      var store = new Store { StoreName = $"Store {Guid.NewGuid()}" };
      var cust = new Customer { CustomerName = $"Customer {Guid.NewGuid()}" };

      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      {
        repo.SaveStore(store);
        cust.Store = store;
        repo.SaveCustomer(cust);
      }

      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      {
        var store1 = repo.Stores.Include(x => x.Customers).FirstOrDefault(x => x.StoreName == store.StoreName);

        Assert.True(this.lastSql.Contains("left outer join", StringComparison.InvariantCultureIgnoreCase));

        Assert.NotNull(store1);
        Assert.Equal(store.Id, store1.Id);

        Assert.NotNull(store1.Customers);
        Assert.Equal(1, store1.Customers.Count);
        Assert.Equal(cust.CustomerName, store1.Customers[0].CustomerName);

        repo.Delete(store1.Customers[0]);
        repo.Delete(store1);
      }
    }

    [Fact(DisplayName = nameof(LeftJoin_OneToMany_And_LengthFilterOnManyEnd_Test))]
    public void LeftJoin_OneToMany_And_LengthFilterOnManyEnd_Test()
    {
      var store = new Store { StoreName = $"Store {Guid.NewGuid()}" };
      var cust = new Customer { CustomerName = $"Customer {Guid.NewGuid()}" };

      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      {
        repo.SaveStore(store);
        cust.Store = store;
        repo.SaveCustomer(cust);
      }

      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      {
        var store1 = repo.Stores.Include(x => x.Customers).FirstOrDefault(x => x.StoreName == store.StoreName && x.Customers.Count > 0);

        Assert.True(this.lastSql.Contains("left outer join", StringComparison.InvariantCultureIgnoreCase));
        Assert.True(this.lastSql.Contains(
          "select cast(count(*) as INT) from [Customer]",
          StringComparison.InvariantCultureIgnoreCase));

        Assert.NotNull(store1);
        Assert.Equal(store.Id, store1.Id);

        Assert.NotNull(store1.Customers);
        Assert.Equal(1, store1.Customers.Count);
        Assert.Equal(cust.CustomerName, store1.Customers[0].CustomerName);

        repo.Delete(store1.Customers[0]);
        repo.Delete(store1);
      }
    }
  }
}
