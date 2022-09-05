using System;
using System.Collections.Generic;
using System.Text;

using NHibernate.Linq;

namespace Tangsem.NHibernate.Extensions
{
  /// <summary>
  /// https://nhibernate.info/doc/nhibernate-reference/querylinq.html
  /// </summary>
  public static class SQLServer2017JsonExtensions
  {
    /// <summary>
    /// Maps to SQL Server JSON_VALUE function.
    /// Example: SELECT TextBox1 = JSON_VALUE(VariableValues, '$.startForm.textbox1') FROM [WorkflowInstance]
    /// </summary>
    /// <param name="jsonText"></param>
    /// <returns></returns>
    [LinqExtensionMethod("JSON_VALUE")]
    public static int JsonValue_Int(this string jsonText, string jsonPath)
    {
      // No need to implement it in .Net, unless you wish to call it
      // outside IQueryable context too.
      throw new NotImplementedException("This call should be translated " +
                                        "to SQL and run db side, but it has been run with .Net runtime");
    }

    [LinqExtensionMethod("JSON_VALUE")]
    public static string JsonValue_String(this string jsonText, string jsonPath)
    {
      // No need to implement it in .Net, unless you wish to call it
      // outside IQueryable context too.
      throw new NotImplementedException("This call should be translated " +
                                        "to SQL and run db side, but it has been run with .Net runtime");
    }

    [LinqExtensionMethod("JSON_VALUE")]
    public static TValue JsonValue<TValue>(this string jsonText, string jsonPath)
    {
      // No need to implement it in .Net, unless you wish to call it
      // outside IQueryable context too.
      throw new NotImplementedException("This call should be translated " +
                                        "to SQL and run db side, but it has been run with .Net runtime");
    }
  }
}
