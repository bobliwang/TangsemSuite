using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tangsem.Common.Extensions
{
  public static partial class StringExtension
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
          "deer",
          "news",
          "vnews",
          "v_news",
        };

    private static readonly IDictionary<string, string> Singularizations =
      new Dictionary<string, string>
        {
          // Start with the rarest cases, and move to the most common
          {"pos", @"pos"},
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

    public static string Singularize(this string word)
    {
      if (Unpluralizables.Contains(word.ToLowerInvariant()))
      {
        return word;
      }

      foreach (var singularization in Singularizations)
      {
        if (Regex.IsMatch(word, singularization.Key, RegexOptions.IgnoreCase))
        {
          return Regex.Replace(word, singularization.Key, singularization.Value);
        }
      }

      return word;
    }

    public static string Pluralize(this string word)
    {
      if (Unpluralizables.Contains(word.ToLowerInvariant()))
      {
        return word;
      }

      var g = new Regex(@"s\b|z\b|x\b|sh\b|ch\b");
      var matches = g.Matches(word);

      if (matches.Count > 0)
      {
        // Sketches
        return word + "es";
      }

      if (!word.EndsWith("y"))
      {
        return word + "s";
      }

      var g2 = new Regex(@"(ay|ey|iy|oy|uy)\b");
      if (g2.Matches(word).Count <= 0) //e.g. cities 
      {
        return word.Substring(0, word.Length - 1) + "ies";
      }

      return word + "s";

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
  }
}
