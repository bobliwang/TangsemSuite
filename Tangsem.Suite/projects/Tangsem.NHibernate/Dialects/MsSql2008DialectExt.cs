using NHibernate;
using NHibernate.Dialect;
using NHibernate.Dialect.Function;

namespace Tangsem.NHibernate.Dialects
{
    public class MsSql2008DialectExt : MsSql2008Dialect
    {
        public MsSql2008DialectExt()
        {
            this.RegisterFunction("dbo.fn_GetJsonArrayLength", new StandardSQLFunction("dbo.fn_GetJsonArrayLength", NHibernateUtil.Int32));
        }
    }
}