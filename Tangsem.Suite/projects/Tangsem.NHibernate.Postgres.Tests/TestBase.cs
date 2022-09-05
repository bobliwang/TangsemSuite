using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

using NHibernate;
using NHibernate.Tool.hbm2ddl;

using Tangsem.NHibernate.Interceptors;
using Tangsem.NHibernate.Tests.PostgreTest1.Domain.Entities;
using Tangsem.NHibernate.Tests.PostgreTest1.Domain.Repositories.NHibernate;

using System.IO;

using Tangsem.Data.Domain;

using Xunit.Abstractions;

using SqlString = NHibernate.SqlCommand.SqlString;

namespace Tangsem.NHibernate.Postgres.Tests
{
  public abstract class TestBase
  {
    private readonly string connString = @"Host=localhost;Username=postgres;Password=Abc123!;Database=test1";

    private readonly PostgreTest1RepositoryProvider _postgreTest1RepositoryProvider;

    protected readonly ITestOutputHelper output;
    protected string lastSql;

    protected TestBase(ITestOutputHelper output)
    {
      this.output = output;
      var interceptors = new IInterceptor[]
                           {
                             new AuditingInterceptor(new DefaultRepoContext()),
                             new SqlStringLogInterceptor((sql) => this.PrintSql(sql)),
                           };
      this._postgreTest1RepositoryProvider = new PostgreTest1RepositoryProvider(this.connString, interceptors);

      var fluentConfig = this._postgreTest1RepositoryProvider.ConfigWithAssemblies(typeof(Product).Assembly);
      var config = fluentConfig.BuildConfiguration();

      using (var sw = new StringWriter())
      {
        new SchemaExport(config).Create(sw, false);

        var sql = sw.ToString();
      }
    }

    public PostgreTest1Repository OpenRepository()
    {
      return this._postgreTest1RepositoryProvider.CreateRepository();
    }

    protected void PrintSql(SqlString sql)
    {
      this.lastSql = sql.ToString();
      this.output.WriteLine(this.lastSql);
    }
  }
}
