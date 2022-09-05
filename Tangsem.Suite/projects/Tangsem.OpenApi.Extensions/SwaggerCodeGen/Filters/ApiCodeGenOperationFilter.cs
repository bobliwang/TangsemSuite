using System.Linq;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace Tangsem.OpenApi.Extensions.SwaggerCodeGen.Filters
{
  /// <summary>
  /// Injects requestBodyParamName to an api (operation).
  /// </summary>
  public class ApiCodeGenOperationFilter : IOperationFilter
  {
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
      if (operation.RequestBody == null)
      {
        return;
      }

      var parameterDescription = context.ApiDescription.ParameterDescriptions.FirstOrDefault(x => x.ParameterDescriptor?.BindingInfo?.BindingSource == BindingSource.Body);

      if (parameterDescription == null)
      {
        return;
      }

      operation.RequestBody.Extensions.Add(SwaggerExtendedPropKeys.RequestBodyParamName, OpenApiGeneratedCode.FromCode(parameterDescription.Name));
    }
  }
}
