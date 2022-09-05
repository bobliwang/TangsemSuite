using NHibernate;

using Tangsem.Data.Domain;
using Tangsem.Identity.Domain.Entities;
using Tangsem.Identity.Domain.Repositories.NHibernate;
using Tangsem.NHibernate;

namespace Tangsem.Identity
{
  public class TangsemIdentityRepositoryProvider : RepositoryProvider
  {
    public TangsemIdentityRepositoryProvider(string connectionString, IInterceptor[] interceptors)
      : base(connectionString, typeof(AspNetUser), interceptors)
    {
    }

    public override IRepository CreateRepositoryFromSession(ISession session) =>
      new IdentityRepository(session, null);

    public new IdentityRepository CreateRepository() =>
      base.CreateRepository() as IdentityRepository;
  }
}