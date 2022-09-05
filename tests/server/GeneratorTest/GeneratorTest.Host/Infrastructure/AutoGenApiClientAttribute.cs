using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace GeneratorTest.Host.Infrastructure
{
  [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
  public class AutoGenApiClientAttribute: SwaggerOperationAttribute
  {
    public static readonly string AutoGenTag = "AutoGen";

    public AutoGenApiClientAttribute(string[] tags = null)
    {
      this.Tags = new [] { AutoGenTag }.Union(tags ?? new string[0]).ToArray();
    }
  }
}
