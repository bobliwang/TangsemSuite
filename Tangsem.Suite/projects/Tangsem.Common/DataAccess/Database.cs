using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Tangsem.Common.DataAccess
{
  public class Database
  {
    public Database(IDbConnection connection)
    {
      this.Connection = connection;
    }

    public IDbConnection Connection { get; set; }

    public List<T> ExecuteList<T>(string sql, IEnumerable<Parameter> parameters = null) where T : class, new()
    {
      using (var dr = this.ExecuteReader(sql, parameters))
      {
        return dr.GetList<T>();
      }
    }

    public IDataReader ExecuteReader(string sql, IEnumerable<Parameter> parameters = null)
    {
      using (var cmd = this.Connection.CreateCommand())
      {
        cmd.CommandText = sql;

        if (parameters != null)
        {
          AddParametersToCommand(cmd, parameters);
        }

        return cmd.ExecuteReader();
      }
    }

    /// <summary>
    /// Returns a data table.
    /// </summary>
    /// <param name="sql"> The sql string. </param>
    /// <param name="parameters"> The parameters. </param>
    /// <returns> The data table. </returns>
    public DataTable ExecuteDataTable(string sql, IEnumerable<Parameter> parameters = null)
    {
      using (var dr = this.ExecuteReader(sql, parameters))
      {
        var dataTable = new DataTable();
        dataTable.Load(dr);

        return dataTable;
      }
    }

    public T ExecuteScalar<T>(string sql, IEnumerable<Parameter> parameters)
    {
      using (var cmd = this.Connection.CreateCommand())
      {
        cmd.CommandText = sql;

        AddParametersToCommand(cmd, parameters);

        return (T)cmd.ExecuteScalar();
      }
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

      foreach (var dbParam in dbParams)
      {
        cmd.Parameters.Add(dbParam);
      }
    }
  }
}
