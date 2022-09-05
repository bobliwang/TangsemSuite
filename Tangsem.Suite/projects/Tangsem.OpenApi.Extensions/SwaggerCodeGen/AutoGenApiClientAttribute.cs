using System;
using System.Linq;

using Swashbuckle.AspNetCore.Annotations;

namespace Tangsem.OpenApi.Extensions.SwaggerCodeGen
{
  [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
  public class AutoGenApiClientAttribute : SwaggerOperationAttribute
  {
    public static readonly string AutoGenTag = "AutoGen";

    public AutoGenApiClientAttribute(string[] tags = null)
    {
      this.Tags = new[] { AutoGenTag }.Union(tags ?? new string[0]).ToArray();
    }
  }
}
