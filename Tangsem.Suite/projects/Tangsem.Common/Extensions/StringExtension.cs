using System;
using System.Collections.Generic;
using System.Linq;

namespace Tangsem.Common.Extensions
{
  public static partial class StringExtension
  {
    public static bool EqualsInvariantCultureIgnoreCase(this string str1, string str2)
    {
      if (str1 == null)
      {
        return str2 == null;
      }

      return str1.Equals(str2, StringComparison.InvariantCultureIgnoreCase);
    }

    public static string ToEntityName(this string tableName)
    {
      var entityName = FromNameInDb(tableName);

      if (entityName.IsPlural())
      {
        return entityName.Singularize();
      }

      return entityName;
    }

    public static string ToMethodParamName(this string name)
    {
      return name.LowerFirst();
    }

    public static string ToPropertyName(this string columnName)
    {
      return FromNameInDb(columnName);
    }

    public static string LowerFirst(this string name)
    {
      return name.Substring(0, 1).ToLower() + name.Substring(1);
    }

    public static string UpperFirst(this string name)
    {
      return name.Substring(0, 1).ToUpper() + name.Substring(1);
    }


    public static string Lf(this string name)
    {
      return name.LowerFirst();
    }

    public static string Uf(this string name)
    {
      return name.UpperFirst();
    }

    private static string FromNameInDb(string nameInDb)
    {
      // if nameInDb letters are all in lower case or upper case
      if (nameInDb.ToLower() == nameInDb || nameInDb.ToUpper() == nameInDb)
      {
        var sections = nameInDb.Split(' ', '_');

        var propertyName = sections.Select(x => x.Substring(0, 1).ToUpper() + x.Substring(1).ToLower()).JoinWith("");

        return propertyName;
      }

      var name = nameInDb.Replace("_", "");

      return name.Substring(0, 1).ToUpper() + name.Substring(1);
    }

    /// <summary>
    /// Java style substring. Between start (included) and end (excluded).
    /// </summary>
    /// <param name="str">The original string.</param>
    /// <param name="start">The start value (included).</param>
    /// <param name="end">The end value (excluded).</param>
    /// <returns>The substring between start and end.</returns>
    public static string Between(this string str, int start, int end)
    {
      return str.Substring(start, end - start);
    }

    /// <summary>
    /// Format a string.
    /// </summary>
    public static string FormatBy(this string format, params object[] args)
    {
      return string.Format(format, args);
    }

    public static bool IsNullOrEmpty(this string str)
    {
      return string.IsNullOrEmpty(str);
    }

    public static bool IsNullOrWhiteSpace(this string str)
    {
      return string.IsNullOrWhiteSpace(str);
    }

    public static string DefaultNullOrEmptyTo(this string str, string defaultText)
    {
      return str.IsNullOrEmpty() ? defaultText : str;
    }

    public static string DefaultNullOrWhitespaceTo(this string str, string defaultText)
    {
      return str.IsNullOrWhiteSpace() ? defaultText : str;
    }

    /// <summary>
    /// Join enumerable strings with a separator and returns a single string.
    /// </summary>
    public static string JoinWith(this IEnumerable<string> strings, string separator)
    {
      return string.Join(separator, strings);
    }
    
    public static string ToRowVersionString(this byte[] rowVersion)
    {
      return BitConverter.ToString(rowVersion).Replace("-", string.Empty);
    }

    public static string UrlConcat(this string part1, string part2)
    {
      if (part1 == null)
      {
        part1 = string.Empty;
      }

      if (part2 == null)
      {
        part2 = string.Empty;
      }

      if (part1.EndsWith("/") && part2.StartsWith("/"))
      {
        return part1 + part2.Substring(1);
      }

      if (!part1.EndsWith("/") && !part2.StartsWith("/"))
      {
        return part1 + "/" + part2;
      }

      return part1 + part2;
    }
  }
}
