using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Tangsem.Common.DataAccess
{
  public class Parameter
  {
    public Parameter()
    {
      this.Direction = ParameterDirection.Input;
    }

    public Parameter(string name, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
    {
      this.Name = name;
      this.Value = value;
      this.DbType = dbType;
      this.Direction = direction;
    }

    public DbType DbType { get; set; }

    public object Value { get; set; }

    public string Name { get; set; }

    public ParameterDirection Direction { get; set; }
  }
}
