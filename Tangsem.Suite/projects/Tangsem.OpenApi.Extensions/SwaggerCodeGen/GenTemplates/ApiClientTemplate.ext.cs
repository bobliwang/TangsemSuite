using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;
using Tangsem.Common.Extensions;

namespace Tangsem.OpenApi.Extensions.SwaggerCodeGen.GenTemplates
{
  public partial class ApiClientTemplate
  {
    public ApiClientTemplate(DocumentFilterContext documentFilterContext, OpenApiDocument swaggerDoc)
    {
      this.DocumentFilterContext = documentFilterContext;
      this.SwaggerDoc = swaggerDoc;
    }

    public Func<ApiClientMethodGenParams, string> MethodTemplateFn { get; set; }

    public OpenApiDocument SwaggerDoc { get; }

    public DocumentFilterContext DocumentFilterContext { get; }

    public string ModelsModuleName { get; set; } = "apiModels";

    public string ApiClientClassName { get; set; } = "ApiClient";

    public string ApiBaseUrlTokenName { get; set; }

    public bool IsRootProvider { get; set; } = true;
    
    public IList<ApiDescription> GetApiDescriptions()
    {
      var apiDescriptions = this.DocumentFilterContext.ApiDescriptions.ToList();

      return apiDescriptions;
    }

    public string GenerateApiClientMethods(Func<ApiClientMethodGenParams, string> fn)
    {
      var apiDescriptions = this.GetApiDescriptions();

      var sb = new StringBuilder();

      foreach (var pathKvp in this.SwaggerDoc.Paths.OrderBy(x => x.Key))
      {
        var pathKey = pathKvp.Key;
        var pathInfo = pathKvp.Value;
        var operations = new Dictionary<string, Func<OpenApiPathItem, OpenApiOperation>>
        {
          ["get"] = pi => pi.Operations.TryGetValueByKey(OperationType.Get),
          ["post"] = pi => pi.Operations.TryGetValueByKey(OperationType.Post),
          ["put"] = pi => pi.Operations.TryGetValueByKey(OperationType.Put),
          ["delete"] = pi => pi.Operations.TryGetValueByKey(OperationType.Delete)
        }.Select(x => new KeyValuePair<string, OpenApiOperation>(x.Key, x.Value(pathInfo))).Where(x => x.Value != null);


        foreach (var opKvp in operations)
        {
          OpenApiOperation operation = opKvp.Value;

          if (!operation.Tags.Any(x => "autogen".Equals(x.Name, StringComparison.InvariantCultureIgnoreCase)))
          {
            continue;
          }

          var httpMethod = opKvp.Key;
          ApiDescription api = apiDescriptions.FirstOrDefault(x =>
            opKvp.Key.Equals(x.HttpMethod, StringComparison.InvariantCultureIgnoreCase) &&
            $"/{x.RelativePath}" == pathKey);

          var genParams = new ApiClientMethodGenParams(api, operation, pathKey, this.ModelsModuleName);

          sb.AppendLine();
          sb.AppendLine("  " + fn(genParams).Trim());
        }
      }

      return sb.ToString();
    }
  }

  /// <summary>
  /// MethodGenParams
  /// </summary>
  public record ApiClientMethodGenParams(
    ApiDescription Api,
    OpenApiOperation Operation,
    string PathKey,
    string ModelsModuleName
  )
  {
    public string HttpMethod
      => this.Api.HttpMethod.ToLower();

    public ControllerActionDescriptor ActionDescriptor
      => this.Api.ActionDescriptor as ControllerActionDescriptor;

    public IList<OpenApiParameter> NonBodyParameters
      => this.Operation.Parameters ?? Array.Empty<OpenApiParameter>();

    public OpenApiRequestBody BodyParameters
      => this.Operation.RequestBody;

    public List<OpenApiParameter> PathParams
      => this.NonBodyParameters.Where(x => x.In == ParameterLocation.Path).ToList();
    public List<OpenApiParameter> QueryStringParams
      => this.NonBodyParameters.Where(x => !this.PathKey.Contains("{" + x.Name + "}")).ToList();

    public bool IsBlobResponse => this.Api.IsBinaryResponse();

    public string ResponseType => IsBlobResponse ? "blob" : Generator.GetResponseType(this.Operation, this.ModelsModuleName);
  }

  /// <summary>
  /// ApiDescriptionExtensions
  /// </summary>
  public static class ApiDescriptionExtensions
  {
    public static bool IsBinaryResponse(this ApiDescription apiDescription)
    {
      var produce = apiDescription.ActionDescriptor.EndpointMetadata.OfType<ProducesAttribute>().FirstOrDefault();
      if (produce == null)
      {
        return false;
      }

      return produce.ContentTypes.Any(
        x => "application/pdf".Equals(x, StringComparison.InvariantCultureIgnoreCase)
             || "application/octet-stream".Equals(x, StringComparison.InvariantCultureIgnoreCase)
      );
    }
  }
}
