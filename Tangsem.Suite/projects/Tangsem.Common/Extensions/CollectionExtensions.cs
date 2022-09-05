using System;
using System.Collections.Generic;
using System.Linq;

namespace Tangsem.Common.Extensions
{
  public static class CollectionExtensions
  {
    public static bool IsNullOrEmpty<T>(this ICollection<T> coll)
    {
      if (coll == null)
      {
        return true;
      }

      return !coll.Any();
    }

    public static List<List<T>> ChunkBy<T>(this IList<T> source, int chunkSize)
    {
      return source
        .Select((x, i) => new { Index = i, Value = x })
        .GroupBy(x => x.Index / chunkSize)
        .Select(x => x.Select(v => v.Value).ToList())
        .ToList();
    }

    public static HashSet<string> ToHashSet(this IEnumerable<string> source)
    {
      return new HashSet<string>(source);
    }

    public static HashSet<string> ToHashSetIgnoreCase(this IEnumerable<string> source)
    {
      return new HashSet<string>(source, StringComparer.OrdinalIgnoreCase);
    }

    public static TValue TryGetValueByKey<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
      where TValue : class
    {
      TValue val = null;

      dict?.TryGetValue(key, out val);

      return val;
    }
  }
}