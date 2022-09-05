namespace Tangsem.Generator.Metadata;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class CSharpTypeNameProvider
{
  public static readonly ReadOnlyDictionary<Type, string> PrimitiveTypeNameMap = new(new Dictionary<Type, string>
    {
      { typeof(int), "int" },
      { typeof(long), "long" },
      { typeof(double), "double" },
      { typeof(float), "float" },
      { typeof(bool), "bool" },
      { typeof(Guid), "Guid" },
      { typeof(DateTime), "DateTime" },

      { typeof(string), "string" },
      { typeof(byte[]), "byte[]" },
    });
}