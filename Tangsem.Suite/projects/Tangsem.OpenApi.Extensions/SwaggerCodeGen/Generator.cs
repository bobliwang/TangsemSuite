using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;

using Tangsem.Common.Extensions;

namespace Tangsem.OpenApi.Extensions.SwaggerCodeGen
{
  public static class Generator
  {
    public static string LowerFirst(string text)
    {
      if (string.IsNullOrWhiteSpace(text))
      {
        return text;
      }

      return text.Substring(0, 1).ToLowerInvariant() + text.Substring(1);
    }

    public static string DateLikeDeclaration() => "export type DateLike = string | Moment | Date;";

    /// <summary>
    /// Gets the params for the api call.
    /// </summary>
    public static string ApiCallParamStrings(
      IList<OpenApiParameter> queryStringParams,
      OpenApiRequestBody requestBody,
      IList<OpenApiParameter> pathParams,
      string moduleName)
    {
      return PathParamsString(pathParams, moduleName)
             + BodyParamsString(requestBody, pathParams, moduleName)
             + QueryStringParamsString(queryStringParams, requestBody, pathParams, moduleName);
    }

    /// <summary>
    /// Gets the endpoint name of the operation.
    /// </summary>
    public static string GetApiActionName(ControllerActionDescriptor actionDescriptor, ApiDescription api)
    {
      if (actionDescriptor.ActionName.Equals(api.HttpMethod, StringComparison.InvariantCultureIgnoreCase))
      {
        return $"{LowerFirst(actionDescriptor.ActionName)}{actionDescriptor.ControllerName}";
      }

      return $"{LowerFirst(actionDescriptor.ActionName)}";
    }

    /// <summary>
    /// Gets the response type name of the operation.
    /// </summary>
    public static string GetResponseType(OpenApiOperation operation, string moduleName = "")
    {
      var firstSuccessResponse = operation.Responses.FirstOrDefault(x => x.Key == "200").Value;

      if (firstSuccessResponse?.Content == null)
      {
        return "any";
      }

      try
      {
        var typeName = string.Empty;
        var schema = firstSuccessResponse.Content.Values.FirstOrDefault()?.Schema;
        var itemsSchema = schema?.Items;

        if (itemsSchema != null)
        {
          if (!itemsSchema.Reference?.Id.IsNullOrEmpty() == true)
          {
            typeName = $"{GetTypeNameFromRef(itemsSchema.Reference.Id)}[]";
          }
          else
          {
            return $"{itemsSchema.Type}[]";
          }
        }
        else
        {
          if (HasRef(schema))
          {
            // "$ref": "#/definitions/SearchResultModel[CustomerDTO]"
            if (schema.Reference.Id.Contains("[")
                && schema.Reference.Id.Contains("]")
                && !schema.Reference.Id.Contains("[]"))
            {
              typeName = $"{GetTypeNameFromRef(schema.Reference.Id)}";
              var subTypeName = typeName.Substring(typeName.IndexOf("[") + 1, typeName.IndexOf("]") - typeName.IndexOf("[") - 1);

              return $"{typeName.Substring(0, typeName.IndexOf("["))}<{moduleName}.{subTypeName}>";
            }
            else
            {
              typeName = $"{GetTypeNameFromRef(schema.Reference.Id)}";
            }
          }
          else if ("object".Equals(schema?.Type, StringComparison.InvariantCultureIgnoreCase))
          {
            return "any";
          }
          else
          {
            if ((schema?.Type).IsNullOrEmpty())
            {
              return "any";
            }

            return schema?.Type;
          }
        }

        if (!typeName.EndsWith("[]"))
        {
          typeName = typeName.Replace("[", "<").Replace("]", ">");
        }

        if (typeName.EndsWith("SearchResultModel"))
        {
          return $"SearchResultModel<{moduleName}.{typeName.Substring(0, typeName.Length - "SearchResultModel".Length)}>";
        }

        return string.IsNullOrEmpty(moduleName) ? typeName : $"{moduleName}.{typeName}";
      }
      catch (Exception ex)
      {
        return $"{operation.OperationId} {ex.Message}";
      }

    }

    private static bool HasRef(OpenApiSchema schema)
    {
      return schema?.Reference != null && !schema.Reference.Id.IsNullOrWhiteSpace();
    }

    private static string GetTypeNameFromRef(string refText)
    {
      return refText.Substring(refText.LastIndexOf('/') + 1);
    }

    private static string MapToTsType(string typeText, OpenApiSchema itemsSchema = null)
    {
      if ("integer".Equals(typeText))
      {
        return "number";
      }

      if ("object".Equals(typeText))
      {
        return "any";
      }

      if ("array".Equals(typeText))
      {
        if (itemsSchema != null)
        {
          return GetTypeNameFromRef(itemsSchema.Reference.Id) + "[]";
        }

        return "any[]";
      }

      return typeText;
    }

    private static string GetParameterType(OpenApiParameter parameter, string moduleName = "")
    {
      return MapToTsType(parameter.Schema.Type);
    }

    private static string PathParamsString(IList<OpenApiParameter> pathParams, string moduleName)
    {
      return string.Join(", ", pathParams.Select(p => $"{LowerFirst(p.Name)}?: {GetParameterType(p, moduleName)}"));
    }

    private static string BodyParamsString(
      OpenApiRequestBody bodyParameters,
      IList<OpenApiParameter> pathParams,
      string moduleName)
    {
      if (bodyParameters == null)
      {
        return string.Empty;
      }

      var paramName = bodyParameters.Get_RequestBodyParamName();
      if (paramName.IsNullOrEmpty())
      {
        paramName = "payload";
      }

      return (pathParams.Any() ? ", " : string.Empty)
             + $"{paramName}?: {moduleName}.{GetTypeNameFromRef(bodyParameters.Content.Values.First().Schema.Reference.Id)}";
    }

    private static string QueryStringParamsString(
      IList<OpenApiParameter> queryStringParams,
      OpenApiRequestBody bodyParameters,
      IList<OpenApiParameter> pathParams,
      string moduleName)
    {
      if (!queryStringParams.Any())
      {
        return string.Empty;
      }

      return (bodyParameters != null || pathParams.Any() ? ", " : "")
             + "qryParams?: {"
             + string.Join(", ", queryStringParams.Select(p => $"{LowerFirst(p.Name)}?: {GetParameterType(p, moduleName)}"))
             + "}";
    }
  }
}
