using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.SqlCommand;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using NHibernate.Cfg;
using Tangsem.Common.Extensions;
using Tangsem.Identity.Domain.Entities;
using Tangsem.Identity.Stores;
using Tangsem.NHibernate;
using Tangsem.NHibernate.Dialects;
using Tangsem.NHibernate.Extensions;
using Tangsem.NHibernate.Interceptors;
using Tangsem.NHibernate.Tests;
using Xunit;
using Xunit.Abstractions;
using NHibernate.Tool.hbm2ddl;
using System.Text;
using NHibernate.Dialect;
using Tangsem.NHibernate.SchemaExports;
using Environment = NHibernate.Cfg.Environment;

namespace Tangsem.Identity.Tests
{
  public class TestRole
  {
    public string RoleName1 { get; set; }
  }

  public class RoleStoreTests : TestBase
  {

    public RoleStoreTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "Export SqlSchema for Sqlite")]
    public async Task ExportSchema()
    {
      Assembly[] assemblies = { typeof(AspNetUser).Assembly };
      var persCfg = SQLiteConfiguration.Standard.Dialect<SQLiteDialect>();

      var s1 = new SQLiteDialect();
      var sql = await new SchemaExporter().ExportSqlSchema(
        persCfg,
        assemblies,

        cfg => cfg.ClassMappings.ToList().ForEach(cm =>
        {
          var oldName = cm.Table.Name;

          s1.QuoteForTableName(oldName);
          var newName = oldName.Replace("[", string.Empty).Replace("]", string.Empty);

          cm.Table.Name = newName;
        }),

        sql => new StringBuilder(";")
                    .AppendLine()
                    .AppendLine(sql)
                    .ToString()
      );
      
      await File.WriteAllTextAsync("c:/temp/identity.sql", sql);
    }

    [Fact(DisplayName = "RoleStore_TestJsonValue")]
    public async Task RoleStore_TestJsonValue()
    {
      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      {
        ////var role = new AspNetRole { Name = JSON.Stringify(new { RoleName = "abc" }), Active = true };
        ////repo.SaveAspNetRole(role);

        var role1 = repo.AspNetRoles.FirstOrDefault(x => x.Name.JsonValue<string>("$.roleName") == "abc");

        // NHibernate.QueryException : No data type for node: MethodNode
        ////var roles = repo.AspNetRoles.Select(x => x.Name.JsonValue_String("$.roleName")).ToList();

        await repo.RollbackAsync();
      }

    }

    [Fact(DisplayName = "RoleStore_TestRoles")]
    public async System.Threading.Tasks.Task RoleStore_TestRoles()
    {
      using (var repo = this.OpenRepository())
      using (repo.BeginTransaction())
      {
        var userStore = new UserStore<AspNetUser>(repo);

        var guid = Guid.NewGuid();
        var username = $"user-{guid}";
        var user = new AspNetUser { UserName = username };

        var result = await userStore.CreateAsync(user);

        Assert.True(result.Succeeded);
        Assert.True(user.Id >= 1, "User id is 0");

        // add role
        var roleStore = new RoleStore<AspNetRole>(repo);
        var roleName = $"Role-{Guid.NewGuid()}";
        result = await roleStore.CreateAsync(new AspNetRole { Name = roleName });

        Assert.True(result.Succeeded);
        var role = await roleStore.FindByNameAsync(roleName);

        Assert.NotNull(role);
        Assert.True(role.Id >= 1, "role id is 0");

        await userStore.AddToRoleAsync(user, roleName);

        var isInRole = await userStore.IsInRoleAsync(user, roleName);
        Assert.True(isInRole, nameof(isInRole));

        var roles = await userStore.GetRolesAsync(user);
        Assert.Equal(1, roles.Count);
        Assert.Equal(roleName, roles[0]);

        await userStore.RemoveFromRoleAsync(user, roleName);
        roles = await userStore.GetRolesAsync(user);
        Assert.Equal(0, roles.Count);

        await repo.RollbackAsync();
      }
    }
  }
}
