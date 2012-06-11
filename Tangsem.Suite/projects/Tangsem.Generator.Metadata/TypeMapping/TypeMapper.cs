using System;
using System.Collections.Generic;

namespace Tangsem.Generator.Metadata.TypeMapping
{
  public abstract class TypeMapper : ITypeMapper
  {
    private IDictionary<string, Type> _typeMapper = null;

    public virtual IDictionary<string, Type> TypeMappingDictionary
    {
      get
      {
        return _typeMapper ?? (_typeMapper = this.InitMappings());
      }
    }

    protected abstract IDictionary<string, Type> InitMappings();

    public virtual Type this[string dataType]
    {
      get
      {
        return this.TypeMappingDictionary[dataType];
      }
    }
  }
}