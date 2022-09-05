using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using GeneratorTest.Common.Domain.Entities;
using GeneratorTest.Common.Domain.Repositories.NHibernate;
using NHibernate;
using NHibernate.Cfg;
using Tangsem.Data.Domain;
using Tangsem.NHibernate.Dialects;
using Tangsem.NHibernate.Domain;
using Tangsem.NHibernate.Extenstions;
using Tangsem.NHibernate.Interceptors;
using Tangsem.NHibernate.Service;

namespace GeneratorTest.Common.Domain.Repositories
{

  public class GeneratorTestRepositoryBuilder : IRepositoryProvider
  {

    private readonly string _connectionString;

    private ISessionFactory _sessionFactory;


    public GeneratorTestRepositoryBuilder(string connectionString)
    {
      this._connectionString = connectionString;
    }

    public ISessionFactory CreateSessionFactory()
    {
      return this.BuildFluentConfiguration().BuildSessionFactory();
    }

    public FluentConfiguration BuildFluentConfiguration()
    {

      var config = new Configuration().LinqToHqlGeneratorsRegistry<ExtendedLinqToHqlGeneratorsRegistry>();

      return Fluently
        .Configure(config)
        .Database(MsSqlConfiguration.MsSql2012.ConnectionString(this._connectionString)
          .ShowSql()
          .MaxFetchDepth(3)
          .Dialect<MsSql2012DialectExt>())
        .Mappings(m =>
          m.FluentMappings.AddFromAssemblyOf<Product>());
    }

    public IRepository CreateRepository(IDataContext dataContext)
    {

      var ai = new AuditingInterceptor { DataContext = dataContext };
      var session = this.SessionFactory
        .WithOptions()
        .Interceptor(ai)
        .OpenSession();

      return new GeneratorTestRepository { CurrentSession = session };
    }

    public ISessionFactory SessionFactory
    {
      get
      {
        if (this._sessionFactory == null)
        {
          this._sessionFactory = this.CreateSessionFactory();
        }

        return this._sessionFactory;
      }
    }
  }
}