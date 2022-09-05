using System;
using System.Collections.Generic;
using System.Text;

using NHibernate.Cfg;

namespace Tangsem.NHibernate.Postgres
{
  public class PostgreNamingStrategy : INamingStrategy
  {
    private INamingStrategy _defaultStrategy = DefaultNamingStrategy.Instance;

    public string ClassToTableName(string className)
    {
      return this._defaultStrategy.ClassToTableName(className);
    }

    public string PropertyToColumnName(string propertyName)
    {
      return this._defaultStrategy.PropertyToColumnName(propertyName);
    }

    public string TableName(string tableName)
    {
      return $@"""{tableName}""";
    }

    public string ColumnName(string columnName)
    {
      return $@"""{columnName}""";
    }

    public string PropertyToTableName(string className, string propertyName)
    {
      return this._defaultStrategy.PropertyToTableName(className, propertyName);
    }

    public string LogicalColumnName(string columnName, string propertyName)
    {
      return this._defaultStrategy.LogicalColumnName(columnName, propertyName);
    }
  }
}
