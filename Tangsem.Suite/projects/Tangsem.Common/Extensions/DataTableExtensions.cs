using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using Tangsem.Common.DataAccess;

namespace Tangsem.Common.Extensions
{
  public static class DataTableExtensions
  {
    public static List<T> MapTo<T>(this DataTable dataTable, Func<DataRow, T> mapFunc) where T : new()
    {
      var list = new List<T>();

      foreach (DataRow row in dataTable.Rows)
      {
        list.Add(mapFunc(row));
      }

      return list;
    }

    public static List<T> MapTo<T>(this DataTable dataTable, Action<T, DataRow> mapAction)
    {
      var list = new List<T>();

      foreach (DataRow row in dataTable.Rows)
      {
        var t = Activator.CreateInstance<T>();

        mapAction(t, row);
        list.Add(t);
      }

      return list;
    }

    public static List<T> MapTo<T>(this DataTable dataTable, params Tuple<Expression<Func<T, object>>, string>[] maps)
    {
      var list = new List<T>();

      var propertyColumnMaps = maps.Select(x => new { PropertyInfo = x.Item1.GetPropertyInfo(), ColumnName = x.Item2 })
          .Where(x => x.PropertyInfo.CanWrite)
          .ToArray();

      foreach (DataRow row in dataTable.Rows)
      {
        var t = Activator.CreateInstance<T>();

        foreach (var map in propertyColumnMaps)
        {
          var val = row[map.ColumnName];
          if (val == DBNull.Value)
          {
            val = null;
          }

          map.PropertyInfo.SetValue(t, val, null);
        }

        list.Add(t);
      }

      return list;
    }

    public static Tuple<Expression<Func<T, object>>, string> MapToProperty<T>(this string columnName, Expression<Func<T, object>> expr)
    {
      return new Tuple<Expression<Func<T, object>>, string>(expr, columnName);
    }

    public static List<T> MapTo<T>(this DataTable dataTable)
    {
      var type = typeof(T);
      var columns = GetPropertyColumnAttributes(type);

      var list = new List<T>();

      foreach (DataRow row in dataTable.Rows)
      {
        var t = Activator.CreateInstance<T>();

        var dataColumnNames = dataTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName);

        foreach (var col in columns.Where(c => dataColumnNames.Contains(c.ColumnName)))
        {
          var val = row[col.ColumnName];
          if (val == DBNull.Value)
          {
            val = null;
          }

          col.PropertyInfo.SetValue(t, val, null);
        }

        list.Add(t);
      }

      return list;
    }

    private static List<PropertyColumnAttribute> GetPropertyColumnAttributes(Type type)
    {
      var columns = new List<PropertyColumnAttribute>();

      var propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

      var readableAndWritableProperties = propertyInfos.Where(p => p.CanRead && p.CanWrite).ToList();

      foreach (var pi in readableAndWritableProperties)
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

      if (!columns.Any())
      {
        foreach (var pi in readableAndWritableProperties)
        {
          columns.Add(new PropertyColumnAttribute { ColumnName = pi.Name, PropertyInfo = pi });
        }
      }

      return columns;
    }
  }
}