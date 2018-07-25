using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;

using NHTest.Common.Domain.Entities;
using NHTest.Common.Domain.Repositories;
using NHTest.Common.Domain.Repositories.NHibernate;

using Tangsem.Data.Domain;
using Tangsem.NHibernate.Dialects;
using Tangsem.NHibernate.Extenstions;
using Tangsem.NHibernate.Interceptors;

namespace NHTest.Common.Services
{
  public class DummyDataContext : IDataContext
  {


    public int CurrentUserId { get; set; }
  }

  public class NHTestRepositoryProvider
  {
    private string _connectionString;

    private ISessionFactory _sessionFactory;


    public NHTestRepositoryProvider(string connectionString)
    {
      this._connectionString = connectionString;
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

    public INHTestRepository CreateRepository()
    {
      var ai = new AuditingInterceptor(new DummyDataContext { CurrentUserId = 1 });

      var session = this.SessionFactory
        .WithOptions()
        .Interceptor(ai)
        .OpenSession();

      return new NHTestRepository(session);
    }

    public ISessionFactory CreateSessionFactory()
    {
      var config = new Configuration().LinqToHqlGeneratorsRegistry<ExtendedLinqToHqlGeneratorsRegistry>();

      var msSqlConfig = MsSqlConfiguration.MsSql2008.ConnectionString(_connectionString).ShowSql()
                          .MaxFetchDepth(3).Dialect<MsSql2008DialectExt>();

      return Fluently
        .Configure(config)
        .Database(msSqlConfig)
        .Mappings(m =>
          m.FluentMappings.AddFromAssemblyOf<Product>())
        .BuildSessionFactory();
    }

    ////private string GetConnString()
    ////{
    ////  var connString = @"Data Source=.\SQLExpress;Initial Catalog=tmobi-express;Integrated Security=True";

    ////  return connString;
    ////}
  }
}
