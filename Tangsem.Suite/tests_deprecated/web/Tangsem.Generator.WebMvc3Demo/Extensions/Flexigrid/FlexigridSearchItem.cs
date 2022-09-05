using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;

namespace Tangsem.Generator.WebMvc3Demo.Extensions.Flexigrid
{
  public class FlexigridSearchItem
  {
    public string Display { get; set; }

    public string Name { get; set; }

    public bool IsDefault { get; set; }

    public string ToJson()
    {
      var sb = new StringBuilder();
      sb.AppendLine("{display:'" + this.Display + "', ");
      sb.AppendLine("name:'" + this.Name+ "', ");
      sb.AppendLine("isdefault:'" + this.IsDefault+ "'}");

      return sb.ToString();
    }
  }
}