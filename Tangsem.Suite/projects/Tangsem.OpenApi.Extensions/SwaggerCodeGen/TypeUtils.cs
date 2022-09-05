using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Tangsem.Common.Extensions;

namespace Tangsem.OpenApi.Extensions.SwaggerCodeGen
{
  public static class TypeUtils
  {
    /// <summary>
    /// Finds all the types from the type.
    /// </summary>
    public static List<Type> FindAllTypes(Type type)
    {
      var mappings = GetPrimitiveTypeMappings();
      var types = new List<Type> { type };

      try
      {
        var props = GetProperties(type);
        foreach (var prop in props)
        {
          if (prop.PropertyType.IsNullableType())
          {
            var underlyingType = prop.PropertyType.GetNullableUnderlyingType();
            if (!mappings.TryGetValue(underlyingType.Name.ToLower(), out string tsTypeName))
            {
              if (!types.Contains(underlyingType))
              {
                types.AddRange(FindAllTypes(underlyingType));
              }
            }
          }
          else if (prop.PropertyType.IsIEnumerableType())
          {
            var elementType = prop.PropertyType.GetGenericArguments().FirstOrDefault();
            if (elementType == null)
            {
              continue;
            }

            if (!mappings.TryGetValue(elementType.Name.ToLower(), out string tsTypeName))
            {
              if (!types.Contains(elementType))
              {
                types.AddRange(FindAllTypes(elementType));
              }

            }
          }
          else if (!mappings.TryGetValue(prop.PropertyType.Name.ToLower(), out string tsTypeName))
          {
            if (!types.Contains(prop.PropertyType))
            {
              types.AddRange(FindAllTypes(prop.PropertyType));
            }
          }
        }

        return types.Distinct().ToList();

      }
      catch (Exception)
      {
        return types;
      }
    }

    /// <summary>
    /// Get the ts type name for a dotnet type.
    /// </summary>
    public static string MapToTsType(Type type)
    {
      var csharpTypeName = type.Name;

      if (csharpTypeName.Contains("Dictionary"))
      {
        return "{ [key: string]: any }";
      }

      if (csharpTypeName == "Object")
      {
        return "any";
      }

      if (type == typeof(DateTime) || type == typeof(DateTime?) || type == typeof(DateTimeOffset) || type == typeof(DateTimeOffset?))
      {
        return "DateLike";
      }

      if (type == typeof(byte[]))
      {
        return "string";
      }

      // nullable
      if (type.IsNullableType())
      {
        var underlyingType = type.GetNullableUnderlyingType();

        return MapToTsType(underlyingType);
      }

      // IEnumerable such as IList, List, Array
      if (type.IsIEnumerableType())
      {
        var elementType = type.GetGenericArguments().FirstOrDefault();
        if (elementType != null)
        {
          return MapToTsType(elementType) + "[]";
        }
      }

      // Array type
      if (csharpTypeName.EndsWith("[]"))
      {
        var primitiveElType = MapToPrimitiveTypeName(csharpTypeName.Substring(0, csharpTypeName.LastIndexOf("[]")));

        if (primitiveElType.IsNullOrEmpty())
        {
          return csharpTypeName;
        }

        return primitiveElType + "[]";
      }

      var primaryTypeName = MapToPrimitiveTypeName(csharpTypeName);

      if (!primaryTypeName.IsNullOrEmpty())
      {
        return primaryTypeName;
      }

      return csharpTypeName;
    }

    public static string MapToPrimitiveTypeName(string csharpTypeName)
    {
      // Supported C# to TypeScript mappings.
      var mappings = GetPrimitiveTypeMappings();

      if (mappings.TryGetValue(csharpTypeName.ToLowerInvariant(), out string tsTypeName))
      {
        return tsTypeName;
      }


      return string.Empty;
    }

    public static IList<PropertyInfo> GetProperties(Type type)
    {
      return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                 .GroupBy(p => p.Name)
                 .Select(grp => grp.OrderByDescending(p => p.DeclaringType?.Name).FirstOrDefault())
                 .ToArray();
    }

    public static IDictionary<string, string> GetPrimitiveTypeMappings()
    {
      var mappings = new Dictionary<string, string>
                       {
                         ["string"] = "string",
                         ["guid"] = "string",
                         ["datetime"] = "string | Date | Moment",
                         ["int32"] = "number",
                         ["int64"] = "number",
                         ["double"] = "number",
                         ["decimal"] = "number",
                         ["boolean"] = "boolean"
                       };

      return mappings;
    }

  }
}
