using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tangsem.Common.Extensions;

namespace Tangsem.Common.ValueClasses
{
  public class ValueClass
  {
    public ValueClass(string name, object value)
    {
      this.Name = name;
      this.Value = value;
    }

    public string Name { get; set; }

    public object Value { get; set; }

    public string ToTsEnumValueDef()
    {
      const string singleQuote = "'";

      var sb = new StringBuilder(this.Name + " = ");
      if (this.Value is string txtVal)
      {
        return sb.Append(singleQuote + txtVal + singleQuote).Append(",").ToString();
      }

      return sb.Append(this.Value).ToString();
    }
  }

  public class ValueClass<TValue> : ValueClass
  {
    public ValueClass(string name, TValue value) : base(name, value)
    {
    }

    public new TValue Value
    {
      get => (TValue)base.Value;
      set => base.Value = value;
    }
  }

  public static class ValueClassExtensions
  {
    public static string ConvertToTsEnum<TValue>(this IList<ValueClass<TValue>> values)
    {
      var type = values.FirstOrDefault()?.GetType();

      if (type == null)
      {
        return string.Empty;
      }

      return $@"
/**
 * ValueClass {type.FullName} to enum
 */
export enum {type.FullName} {{
      { values.Select(x => x.ToTsEnumValueDef())
              .ToList()
              .JoinWith(", " + Environment.NewLine) }
}}
";
    }
  }
}
