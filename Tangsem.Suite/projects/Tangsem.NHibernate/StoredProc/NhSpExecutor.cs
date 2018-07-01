using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using NHibernate;
using NHibernate.Type;

using Tangsem.Common.Extensions;
using Tangsem.Data.StoredProc;

namespace Tangsem.NHibernate.StoredProc
{
  /// <summary>
  /// Implement according to http://stackoverflow.com/questions/1091521/how-do-i-call-a-stored-procedure-from-nhibernate-that-has-no-result.
  /// </summary>
  public class NhSpExecutor : SpExecutorBase
  {
    public NhSpExecutor(ISession session, string spName) : base(spName)
    {
      this.Session = session;
    }

    public ISession Session { get; private set; }
    
    public virtual ISpExecutor AddParameter(string name, object value, NullableType nullableType, ParameterDirection direction = ParameterDirection.Input)
    {
      return base.AddParameter(name, value, nullableType.SqlType.DbType, direction);
    }
    
    public override IList<T> ExecuteList<T>()
    {
      using (var cmd = this.CreateCommand())
      {
        var reader = cmd.ExecuteReader();

        var lst = new List<T>();

        while (reader.Read())
        {
          var obj = reader[0];

          if (obj == DBNull.Value)
          {
            lst.Add(default(T));
          }
          else
          {
            lst.Add((T) obj);
          }
        }

        reader.Close();

        this.PostExecute(cmd);

        return lst;
      }
    }

    public override IDbConnection DbConnection
    {
      get { return this.Session.Connection; }
    }

    protected override IDbCommand CreateCommand()
    {
      var cmd = base.CreateCommand();

      this.Session.Transaction.Enlist((DbCommand)cmd);
      
      return cmd;
    }

    public override IList<T> ExecuteObjects<T>()
    {
      return this.ExecuteDataTable().MapTo<T>();
    }
  }
}