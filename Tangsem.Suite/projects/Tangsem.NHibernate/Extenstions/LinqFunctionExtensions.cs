using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

using Newtonsoft.Json;

using NHibernate;
using NHibernate.Dialect;
using NHibernate.Dialect.Function;
using NHibernate.Linq;

using Tangsem.Common.Extensions;

namespace Tangsem.NHibernate.Extenstions
{
  public static class LinqFunctionExtensions
  {
    public static bool IsLike(this string source, string pattern)
    {
      pattern = Regex.Escape(pattern);
      pattern = pattern.Replace("%", ".*?").Replace("_", ".");
      pattern = pattern.Replace(@"\[", "[").Replace(@"\]", "]").Replace(@"\^", "^");

      return Regex.IsMatch(source, pattern);
    }

    ////public static bool IsJsonStringLike(this IEnumerable list, string pattern)
    ////{
    ////  pattern = Regex.Escape(pattern);
    ////  pattern = pattern.Replace("%", ".*?").Replace("_", ".");
    ////  pattern = pattern.Replace(@"\[", "[").Replace(@"\]", "]").Replace(@"\^", "^");

    ////  return Regex.IsMatch(JsonConvert.SerializeObject(list), pattern);
    ////}

    public static int JsonArrayLength(this object[] source)
    {
      return source.Length;
    }

    public static bool AnyInJsonArray<T>(this T[] source, Expression<Func<T, bool>> expression)
    {
      if (source == null)
      {
        return false;
      }

      return source.AsQueryable().Any(expression);
    }

    public static string ToJsonString(this object source)
    {
      if (source == null)
      {
        return null;
      }

      return JsonConvert.SerializeObject(source);
    }
  }
}