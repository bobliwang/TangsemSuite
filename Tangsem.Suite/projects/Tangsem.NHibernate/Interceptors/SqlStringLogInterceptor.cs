using System;

using NHibernate;
using NHibernate.SqlCommand;

namespace Tangsem.NHibernate.Interceptors
{
  public class SqlStringLogInterceptor : EmptyInterceptor
  {
    public SqlStringLogInterceptor(Action<SqlString> logAction)
    {
      this.LogAction = logAction;
    }

    public Action<SqlString> LogAction { get; }

    public override SqlString OnPrepareStatement(SqlString sql)
    {
      this.LogAction(sql);
      return sql;
    }
  }
}