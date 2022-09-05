using NHibernate;
using Tangsem.Data.Domain;
using Tangsem.NHibernate.Tests.Domain.Entities;
using Tangsem.NHibernate.Tests.Domain.Repositories.NHibernate;

namespace Tangsem.NHibernate.Tests
{
  public class NHTestRepositoryProvider : RepositoryProvider
  {
    public NHTestRepositoryProvider(string connectionString, IInterceptor[] interceptors)
      : base(connectionString, typeof(Product), interceptors)
    {
    }

    public override IRepository CreateRepositoryFromSession(ISession session)
    {
      return new TestRepository(session);
    }

    public new TestRepository CreateRepository()
    {
      return base.CreateRepository() as TestRepository;
    }
  }
}
