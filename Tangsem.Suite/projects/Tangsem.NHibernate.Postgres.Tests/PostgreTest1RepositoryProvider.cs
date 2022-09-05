using System.Linq;
using System.Reflection;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

using NHibernate;

using Tangsem.Data.Domain;
using Tangsem.NHibernate.Tests.PostgreTest1.Domain.Entities;
using Tangsem.NHibernate.Tests.PostgreTest1.Domain.Repositories.NHibernate;

namespace Tangsem.NHibernate.Postgres.Tests
{
  public class PostgreTest1RepositoryProvider : PostgreRepositoryProvider
  {
    public PostgreTest1RepositoryProvider(string connectionString, IInterceptor[] interceptors)
      : base(connectionString, typeof(Product), interceptors)
    {
    }

    public override IRepository CreateRepositoryFromSession(ISession session)
    {
      return new PostgreTest1Repository { CurrentSession = session };
    }

    public new PostgreTest1Repository CreateRepository()
    {
      return base.CreateRepository() as PostgreTest1Repository;
    }
  }
}
