using System;
using System.Collections.Generic;

namespace Tangsem.Generator.Metadata.TypeMapping
{
  public abstract class TypeMapper : ITypeMapper
  {
    private IDictionary<string, Type> _typeMapper = null;

    protected abstract IDictionary<string, Type> InitMappings();

    public virtual IDictionary<string, Type> TypeMappingDictionary
      => _typeMapper ?? (_typeMapper = this.InitMappings());

    public virtual Type this[string dataType]
      => this.TypeMappingDictionary[dataType];
  }
}