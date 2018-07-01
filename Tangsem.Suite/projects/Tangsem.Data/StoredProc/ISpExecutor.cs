using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Tangsem.Data.StoredProc
{
  public interface ISpExecutor
  {
    string SpName { get; }

    IDbConnection DbConnection { get; }

    ISpExecutor AddParameter(string name, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input);

    DataTable ExecuteDataTable();

    IDataReader ExecuteReader();

    int ExecuteUpdate();

    T ExecuteScalar<T>();

    IList<T> ExecuteList<T>();
  }
}
