using NHibernate;
using NHibernate.SqlCommand;

using Tangsem.Data.Domain;
using Tangsem.Identity.Domain.Repositories.NHibernate;
using Tangsem.NHibernate.Interceptors;
using Xunit.Abstractions;

namespace Tangsem.Identity.Tests
{
  public class TestBase
  {
    private readonly string connString = @"Data Source=.\SQLExpress;Initial Catalog=Tangsem-Identity;Integrated Security=True";

    private readonly TangsemIdentityRepositoryProvider repoProvider;

    private readonly ITestOutputHelper output;

    protected string lastSql;

    public TestBase(ITestOutputHelper output)
    {
      this.output = output;
      var interceptors = new IInterceptor[]
                           {
                             new AuditingInterceptor(new DefaultRepoContext()),
                             new SqlStringLogInterceptor(this.PrintSql)
                           };
      this.repoProvider = new TangsemIdentityRepositoryProvider(this.connString, interceptors);
    }

    protected void PrintSql(SqlString sql)
    {
      this.lastSql = sql.ToString();
      this.output.WriteLine(this.lastSql);
    }

    public IdentityRepository OpenRepository()
    {
      return this.repoProvider.CreateRepository();
    }
  }
}