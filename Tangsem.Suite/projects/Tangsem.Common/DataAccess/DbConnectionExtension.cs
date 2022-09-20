using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Tangsem.Common.DataAccess
{
  public static class DbConnectionExtension
  {
    public static IDataReader ExecuteReader(this IDbConnection conn, string sql)
    {
      var cmd = conn.CreateCommand();
      cmd.CommandText = sql;
      
      return cmd.ExecuteReader();
    }

    public static IDataReader ExecuteReader(this IDbConnection conn, string sql, IEnumerable<Parameter> parameters = null)
    {
      var cmd = conn.CreateCommand();
      cmd.CommandText = sql;

      if (parameters != null)
      {
        AddParametersToCommand(cmd, parameters);
      }

      return cmd.ExecuteReader();
    }
    
    public static T ExecuteScalar<T>(this IDbConnection conn, string sql)
    {
      var cmd = conn.CreateCommand();
      cmd.CommandText = sql;

      return (T) cmd.ExecuteScalar();
    }

    public static T ExecuteScalar<T>(this IDbConnection conn, string sql, IEnumerable<Parameter> parameters)
    {
      var cmd = conn.CreateCommand();
      cmd.CommandText = sql;

      AddParametersToCommand(cmd, parameters);

      return (T) cmd.ExecuteScalar();
    }

    private static void AddParametersToCommand(IDbCommand cmd, IEnumerable<Parameter> parameters)
    {
      var dbParams = parameters.Select(
        p =>
          {
            var dbParam = cmd.CreateParameter();

            dbParam.ParameterName = p.Name;
            dbParam.Value = p.Value;
            dbParam.DbType = p.DbType;
            dbParam.Direction = p.Direction;

            return dbParam;
          }
        ).ToList();

      foreach(var dbParam in dbParams)
      {
        cmd.Parameters.Add(dbParam);
      }
    }
  }
}
