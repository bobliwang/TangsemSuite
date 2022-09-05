using System;
using System.Collections.Generic;
using System.Text;

namespace Tangsem.Common.Extensions
{
  public static class TypeExtensions
  {
    /// <summary>
    /// Check if it is Nullable Type.
    /// </summary>
    public static bool IsNullableType(this Type type)
    {
      ////return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);

      return Nullable.GetUnderlyingType(type) != null;
    }

    /// <summary>
    /// Gets Nullable Underlying Type
    /// </summary>
    public static Type GetNullableUnderlyingType(this Type type)
    {
      ////return IsNullableType(type) ? type.GetGenericArguments()[0] : type;

      return Nullable.GetUnderlyingType(type);
    }

    /// <summary>
    /// Check if it is enum type or nullable enum type.
    /// </summary>
    public static bool IsEnumOrNullableEnum(this Type type)
    {
      if (type.IsEnum)
      {
        return true;
      }

      return type.GetNullableUnderlyingType()?.IsEnum == true;
    }

    /// <summary>
    /// Check if it is IEnumerable type.
    /// </summary>
    public static bool IsIEnumerableType(this Type type)
    {
      return typeof(System.Collections.IEnumerable).IsAssignableFrom(type);
    }
  }
}
