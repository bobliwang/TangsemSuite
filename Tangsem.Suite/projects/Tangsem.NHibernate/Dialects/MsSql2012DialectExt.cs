using NHibernate;
using NHibernate.Dialect;
using NHibernate.Dialect.Function;

namespace Tangsem.NHibernate.Dialects
{
  public class MsSql2012DialectExt : MsSql2012Dialect
  {
    public MsSql2012DialectExt()
    {
      this.RegisterFunction("dbo.fn_GetJsonArrayLength", new StandardSQLFunction("dbo.fn_GetJsonArrayLength", NHibernateUtil.Int32));
    }
  }
}