using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

using NHibernate.Linq;

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

    public static int JsonArrayLength(this object[] source)
    {
      return source.Length;
    }
  }
}