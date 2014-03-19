using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Tangsem.Common.DataAccess
{
  public static class DataReaderExtension
  {
    public static List<T> GetList<T>(this IDataReader dataReader) where T : class , new()
    {
      var type = typeof(T);
      var columns = GetPropertyColumnAttributes(type);

      var list = new List<T>();

      while (dataReader.Read())
      {
        var obj = new T();

        foreach (var col in columns)
        {
          var val = dataReader[col.ColumnName];
          if (val == System.DBNull.Value)
          {
            val = null;
          }

          col.PropertyInfo.SetValue(obj, val, null);
        }

        list.Add(obj);
      }

      return list;
    }

    private static List<PropertyColumnAttribute> GetPropertyColumnAttributes(Type type)
    {
      var columns = new List<PropertyColumnAttribute>();

      var propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

      foreach (var pi in propertyInfos.Where(p => p.CanRead && p.CanWrite))
      {
        var propertyAttrs = pi.GetCustomAttributes(true);
        var column = propertyAttrs.FirstOrDefault(pa => pa is PropertyColumnAttribute) as PropertyColumnAttribute;

        if (column != null)
        {
          column.PropertyInfo = pi;
          if (string.IsNullOrWhiteSpace(column.ColumnName))
          {
            column.ColumnName = pi.Name;
          }
          columns.Add(column);
        }
      }
      return columns;
    }
  }
}
