using System.IO;

using NHibernate;
using NHibernate.SqlCommand;
using NHibernate.Tool.hbm2ddl;

using Tangsem.Data.Domain;
using Tangsem.NHibernate.Interceptors;
using Tangsem.NHibernate.Tests.Domain.Entities;
using Tangsem.NHibernate.Tests.Domain.Repositories.NHibernate;

using Xunit.Abstractions;

namespace Tangsem.NHibernate.Tests
{
  public abstract class TestBase
  {
    private readonly string connString = @"Data Source=.\SQLExpress;Initial Catalog=test;Integrated Security=True";

    private readonly NHTestRepositoryProvider _nhTestRepositoryProvider;

    protected readonly ITestOutputHelper output;
    protected string lastSql;

    protected TestBase(ITestOutputHelper output)
    {
      this.output = output;
      var interceptors = new IInterceptor[]
                           {
                             new AuditingInterceptor(new DefaultRepoContext()),
                             new SqlStringLogInterceptor(this.PrintSql),
                           };
      this._nhTestRepositoryProvider = new NHTestRepositoryProvider(this.connString, interceptors);

      var fluentConfig = this._nhTestRepositoryProvider.ConfigWithAssemblies(typeof(Product).Assembly);
      var config = fluentConfig.BuildConfiguration();

      using (var sw = new StringWriter())
      {
        new SchemaExport(config).Create(sw, false);

        var sql = sw.ToString();
      }
    }

    public TestRepository OpenRepository()
    {
      return this._nhTestRepositoryProvider.CreateRepository();
    }

    protected void PrintSql(SqlString sql)
    {
      this.lastSql = sql.ToString();
      this.output.WriteLine(this.lastSql);
    }
  }
}