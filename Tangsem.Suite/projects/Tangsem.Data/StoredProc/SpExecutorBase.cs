using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Tangsem.Data.StoredProc
{
  public abstract class SpExecutorBase : ISpExecutor
  {
    protected IList<SpParam> _params = new List<SpParam>();

    private int? _timeout;


    protected SpExecutorBase(string spName)
    {
      this.SpName = spName;
    }

    public string SpName { get; protected set; }

    public abstract IDbConnection DbConnection { get; }


    protected IList<SpParam> Params
    {
      get { return this._params; }
      set { this._params = value; }
    }


    public ISpExecutor AddParameter(string name, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
    {
      var param = this.Params.FirstOrDefault(x => name.Equals(x.Name, StringComparison.InvariantCultureIgnoreCase));

      // update the param if it exists.
      if (param != null)
      {
        param.Value = value;
        param.DbType = dbType;
        param.Direction = direction;
      }
      else
      {
        this.Params.Add(new SpParam { Name = name, Value = value, DbType = dbType, Direction = direction });
      }

      return this;
    }

    public DataTable ExecuteDataTable()
    {
      var dt = new DataTable();

      using (var cmd = this.CreateCommand())
      {
        var reader = cmd.ExecuteReader();
        dt.Load(reader);
        reader.Close();

        this.PostExecute(cmd);
      }

      return dt;
    }



    public T ExecuteScalar<T>()
    {
      using (var cmd = this.CreateCommand())
      {
        var value = cmd.ExecuteScalar();

        this.PostExecute(cmd);

        if (value == DBNull.Value)
        {
          return default(T);
        }

        return (T)value;
      }
    }

    public IDataReader ExecuteReader()
    {
      using (var cmd = this.CreateCommand())
      {
        var reader = cmd.ExecuteReader();

        return reader;
      }
    }

    public virtual int ExecuteUpdate()
    {
      using (var cmd = this.CreateCommand())
      {
        var value = cmd.ExecuteNonQuery();

        this.PostExecute(cmd);

        return value;
      }
    }

    public virtual IList<T> ExecuteList<T>()
    {
      return this.ExecuteObjects<T>();
    }

    public abstract IList<T> ExecuteObjects<T>();


    public ISpExecutor Timeout(int? timeout)
    {
      this._timeout = timeout;

      return this;
    }

    protected virtual IDbCommand CreateCommand()
    {
      var cmd = this.DbConnection.CreateCommand();

      if (this.SpName.ToLowerInvariant().StartsWith("p_"))
      {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = this.SpName;
      }
      else
      {
        cmd.CommandType = CommandType.Text;
        var paramsText = string.Join(",", this.Params.Select(p => "@" + p.Name));
        cmd.CommandText = $"SELECT * FROM dbo.{this.SpName}({paramsText})";
      }

      if (this._timeout != null)
      {
        cmd.CommandTimeout = this._timeout.Value;  
      }

      foreach (var param in this.Params)
      {
        var cmdParam = cmd.CreateParameter();
        cmdParam.ParameterName = param.Name;
        cmdParam.Value = param.Value ?? DBNull.Value;
        cmdParam.Direction = param.Direction;
        cmdParam.DbType = param.DbType;

        cmd.Parameters.Add(cmdParam);
      }

      return cmd;
    }

    protected virtual void PostExecute(IDbCommand cmd)
    {
      this.UpdateOutputParamValues(cmd);
    }

    protected void UpdateOutputParamValues(IDbCommand cmd)
    {
      foreach (var param in this.Params)
      {
        if (param.Direction == ParameterDirection.Output || param.Direction == ParameterDirection.InputOutput)
        {
          var dbParam = cmd.Parameters[param.Name] as IDataParameter;
          param.Value = dbParam.Value;
        }
      }
    }
  }
}