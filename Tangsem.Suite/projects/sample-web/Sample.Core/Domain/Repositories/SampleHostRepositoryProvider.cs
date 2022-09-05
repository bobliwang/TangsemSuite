using System;

using NHibernate;
using Sample.Core.Domain.Entities;
using Sample.Core.Domain.Repositories.NHibernate;
using Tangsem.Data.Domain;
using Tangsem.Identity.Domain.Entities;
using Tangsem.Identity.Domain.Repositories.NHibernate;
using Tangsem.NHibernate;

namespace Sample.Core.Domain.Repositories
{
  public class SampleHostRepositoryProvider : RepositoryProvider
  {
    public SampleHostRepositoryProvider(string connectionString, params IInterceptor[] interceptors)
      : base(connectionString, new[] { typeof(AspNetUser), typeof(ShopeeShop) }, interceptors)
    {
      this.MaxFetchDepth = 0;
    }

    public override IRepository CreateRepositoryFromSession(ISession session)
    {
      return new SampleHostRepository { CurrentSession = session };
    }

    public new SampleHostRepository CreateRepository()
    {
      return base.CreateRepository() as SampleHostRepository;
    }
  }
}