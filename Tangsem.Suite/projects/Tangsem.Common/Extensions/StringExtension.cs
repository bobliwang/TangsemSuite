using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tangsem.Common.Extensions
{
  public static class StringExtension
  {
    private static readonly IList<string> Unpluralizables =
      new List<string>
    {
      "equipment",
      "information",
      "rice",
      "money",
      "species",
      "series",
      "fish",
      "sheep",
      "deer"
    };

    private static readonly IDictionary<string, string> Singularizations =
      new Dictionary<string, string>
    {
      // Start with the rarest cases, and move to the most common
      {"people", "person"},
      {"oxen", "ox"},
      {"children", "child"},
      {"feet", "foot"},
      {"teeth", "tooth"},
      {"geese", "goose"},
      // And now the more standard rules.
      {"(.*)ives$", "$1ife"},
      {"(.*)ves$", "$1f"},
      // ie, wolf, wife
      {"(.*)men$", "$1man"},
      {"(.+[aeiou])ys$", "$1y"},
      {"(.+[^aeiou])ies$", "$1y"},
      {"(.+)zes$", "$1"},
      {"([m|l])ice$", "$1ouse"},
      {"matrices", @"matrix"},
      {"indices", @"index"},
      {"(.+[^aeiou])ices$","$1ice"},
      {"(.*)ices", @"$1ex"},
      // ie, Matrix, Index
      {"(octop|vir)i$", "$1us"},
      {"(.+(s|x|sh|ch))es$", @"$1"},
      {"(.+[^s])s$", @"$1"}
    };

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


    private static string FromNameInDb(string nameInDb)
    {
      // if nameInDb letters are all in lower case or upper case
      if (nameInDb.ToLower() == nameInDb || nameInDb.ToUpper() == nameInDb)
      {
        var sections = nameInDb.Split(new[] { ' ', '_' });

        var propertyName = string.Join("", sections.Select(x => x.Substring(0, 1).ToUpper() + x.Substring(1).ToLower()));

        return propertyName;
      }
      else
      {
        var name = nameInDb.Replace("_", "");

        return name.Substring(0, 1).ToUpper() + name.Substring(1);
      }
    }


    public static string Singularize(this string word)
    {
      if (!Unpluralizables.Contains(word.ToLowerInvariant()))
      {
        foreach (var singularization in Singularizations)
        {
          if (Regex.IsMatch(word, singularization.Key))
          {
            return Regex.Replace(word, singularization.Key, singularization.Value);
          }
        }
      }

      return word;
    }

    public static string Pluralize(this string word)
    {
      if (!Unpluralizables.Contains(word.ToLowerInvariant()))
      {
        var g = new Regex(@"s\b|z\b|x\b|sh\b|ch\b");
        var matches = g.Matches(word);

        if (matches.Count > 0)
        {
          return word + "es"; //Sketches
        }

        if (word.EndsWith("y"))
        {
          var g2 = new Regex(@"(ay|ey|iy|oy|uy)\b");
          if (g2.Matches(word).Count <= 0) //e.g. cities 
          {
            return word.Substring(0, word.Length - 1) + @"ies";
          }
          else
          {
            return word + "s";
          }
        }
        else
        {
          return word + "s";
        }
      }

      return word;
    }

    public static bool IsPlural(this string word)
    {
      if (Unpluralizables.Contains(word.ToLowerInvariant()))
      {
        return true;
      }

      foreach (var singularization in Singularizations)
      {
        if (Regex.IsMatch(word, singularization.Key))
        {
          return true;
        }
      }

      return false;
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
    /// <param name="format">The string format.</param>
    /// <param name="args">The args.</param>
    /// <returns>The formatted string.</returns>
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
  }
}
