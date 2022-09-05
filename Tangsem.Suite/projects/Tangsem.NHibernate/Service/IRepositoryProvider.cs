using NHibernate;

using Tangsem.Data.Domain;
using Tangsem.NHibernate.Domain;

namespace Tangsem.NHibernate.Service
{
  public interface IRepositoryProvider
  {
    ISessionFactory SessionFactory { get; }

    IRepository CreateRepository(IDataContext dataContext);
  }

  public interface IRepositoryProvider<out TRepository> : IRepositoryProvider
    where TRepository: IRepository
  {
    new TRepository CreateRepository(IDataContext dataContext);
  }
}