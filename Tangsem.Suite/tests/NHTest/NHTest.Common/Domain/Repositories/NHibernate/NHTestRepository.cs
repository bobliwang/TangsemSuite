
using NHibernate;

namespace NHTest.Common.Domain.Repositories.NHibernate
{
    public partial class NHTestRepository
    {
        public NHTestRepository(ISession currentSession)
            : base(currentSession)
        {
        }
    }
}