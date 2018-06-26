using NHibernate;

using Tangsem.Data.Domain;
using Tangsem.NHibernate.Domain;

namespace Tangsem.NHibernate.Service
{
  public interface IRepositoryProvider
  {
    ISessionFactory SessionFactory { get; }

    RepositoryBase CreateRepository(IDataContext dataContext);
  }
}