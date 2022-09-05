using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tangsem.Common.ValueClasses
{
  public partial class ValueClassToTsEnumTemplate
  {
    public Type Type => this.Values.FirstOrDefault()?.GetType();

    public string TsEnumName => this.Type.Name;

    public IList<ValueClass> Values { get; set; }
  }
}
