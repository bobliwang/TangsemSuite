using NHibernate;
using NHibernate.SqlCommand;
using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

using Tangsem.Identity.Domain.Entities;
using Tangsem.Identity.Stores;
using Tangsem.NHibernate.Interceptors;
using Tangsem.NHibernate.Tests;
using Xunit;
using Xunit.Abstractions;

namespace Tangsem.Identity.Tests
{
  public class UserStoreTests : TestBase
  {
    public UserStoreTests(ITestOutputHelper output): base(output)
    {
    }

    [Fact(DisplayName = "UserStore_TestSaveUserAsync")]
    public async Task UserStore_TestSaveUserAsync()
    {
      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      { 
        var userStore = new UserStore<AspNetUser>(repo);

        var guid = Guid.NewGuid();
        var username = $"user-{guid}";
        var user = await userStore.FindByNameAsync(username);

        Assert.Null(user);

        user = new AspNetUser { UserName = username };

        var result = await userStore.CreateAsync(user);

        Assert.True(result.Succeeded);
        Assert.True(user.Id >= 1);

        var normalizedUsername = user.UserName + "___normalized";
        await userStore.SetNormalizedUserNameAsync(user, normalizedUsername);
        await userStore.UpdateAsync(user);
        user = await userStore.FindByNameAsync(normalizedUsername);
        Assert.NotNull(user);

        result = await userStore.DeleteAsync(user);
        Assert.True(result.Succeeded);

        Assert.False(user.Active);
        user = await userStore.FindByNameAsync(normalizedUsername);
        Assert.Null(user);

        await repo.RollbackAsync();
      }
    }
  }
}
