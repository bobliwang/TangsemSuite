using System;
using System.Collections.Generic;

namespace Tangsem.Generator.Metadata.TypeMapping
{
  public interface ITypeMapper
  {
    IDictionary<string, Type> TypeMappingDictionary { get; }

    Type this[string dataType] { get; }
  }
}