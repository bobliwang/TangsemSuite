using NHibernate;

namespace Tangsem.NHibernate.Tests.Domain.Repositories.NHibernate
{
  public partial class TestRepository
  {
    public TestRepository(ISession currentSession) : base(currentSession)
    {
    }
  }
}