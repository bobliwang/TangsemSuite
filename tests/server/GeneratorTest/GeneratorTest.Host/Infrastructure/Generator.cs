using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;

using Swashbuckle.AspNetCore.Swagger;

namespace GeneratorTest.Host.Infrastructure
{
  public static class Generator
  {
    public static string UpperCaseFirst(string text)
    {
      if (string.IsNullOrWhiteSpace(text))
      {
        return text;
      }

      return text.Substring(0, 1).ToUpperInvariant() + text.Substring(1);
    }

    public static string LowerCaseFirst(string text)
    {
      if (string.IsNullOrWhiteSpace(text))
      {
        return text;
      }

      return text.Substring(0, 1).ToLowerInvariant() + text.Substring(1);
    }

    public static string PropertyExpression(string name, Schema prop)
    {
      if (prop.Enum != null && prop.Enum.Count > 0)
      {
        return $"{name}?: {UpperCaseFirst(name)}";
      }

      if (!string.IsNullOrEmpty(prop.Ref))
      {
        return $"{name}?: {GetTypeNameFromRef(prop.Ref)}";
      }

      if (prop.Items != null)
      {
        if (prop.Items.Ref != null)
        {
          return $"{name}?: {GetTypeNameFromRef(prop.Items.Ref)}[]";
        }

        if (prop.Items.Type != null)
        {
          return $"{name}?: {MapToTsType(prop.Items.Type)}[]";
        }
      }

      return $"{name}?: {MapToTsType(prop.Type)}";
    }


    public static string GetTypeNameFromRef(string refText)
    {
      return refText.Substring(refText.LastIndexOf('/') + 1);
    }

    public static string MapToTsType(string typeText)
    {
      if ("integer".Equals(typeText))
      {
        return "number";
      }

      return typeText;
    }

    public static string GetParameterType(IParameter parameter, string moduleName = "")
    {
      if (parameter is NonBodyParameter nonBodyParam)
      {
        return MapToTsType(nonBodyParam.Type);
      }
      else if (parameter is BodyParameter bodyParam)
      {
        var refTypeName = GetTypeNameFromRef(bodyParam.Schema.Ref);

        return string.IsNullOrEmpty(moduleName) ? refTypeName : $"{moduleName}.{refTypeName}";
      }

      return "NOTSUPPORTED_PARAM_TYPE";
    }

    public static string GetApiActonName(ControllerActionDescriptor actionDescriptor, ApiDescription api)
    {
      if (actionDescriptor.ActionName.Equals(api.HttpMethod, StringComparison.InvariantCultureIgnoreCase))
      {
        return $"{LowerCaseFirst(actionDescriptor.ActionName)}{actionDescriptor.ControllerName}";
      }

      return $"{LowerCaseFirst(actionDescriptor.ActionName)}";
    }

    public static string PathParamsString(IList<NonBodyParameter> pathParams, string moduleName)
    {
      return string.Join(", ", pathParams.Select(p => $"{LowerCaseFirst(p.Name)}?: {GetParameterType(p, moduleName)}"));
    }

    public static string BodyParamsString(
      IList<BodyParameter> bodyParameters,
      IList<NonBodyParameter> pathParams,
      string moduleName)
    {
      return (pathParams.Any() && bodyParameters.Any() ? ", " : string.Empty)
             + string.Join(", ", bodyParameters.Select(p => $"{LowerCaseFirst(p.Name)}?: {GetParameterType(p, moduleName)}"));
    }

    public static string QueryStringParamsString(
      IList<NonBodyParameter> queryStringParams,
      IList<BodyParameter> bodyParameters,
      IList<NonBodyParameter> pathParams,
      string moduleName)
    {
      if (!queryStringParams.Any())
      {
        return string.Empty;
      }

      return (bodyParameters.Any() || pathParams.Any() ? ", " : "")
             + "qryParams?: {"
             + string.Join(", ", queryStringParams.Select(p => $"{LowerCaseFirst(p.Name)}?: {GetParameterType(p, moduleName)}"))
             + "}";
    }

    public static string ApiCallParamStrings(
      IList<NonBodyParameter> queryStringParams,
      IList<BodyParameter> bodyParameters,
      IList<NonBodyParameter> pathParams,
      string moduleName)
    {
      return PathParamsString(pathParams, moduleName)
             + BodyParamsString(bodyParameters, pathParams, moduleName)
             + QueryStringParamsString(queryStringParams, bodyParameters, pathParams, moduleName);
    }

    public static string GetResponseType(Operation operation, string moduleName = "")
    {
      var firstSuccessResponse = operation.Responses.FirstOrDefault(x => x.Key == "200").Value;

      if (firstSuccessResponse == null || firstSuccessResponse.Schema == null)
      {
        return "any";
      }

      try
      {
        var typeName = string.Empty;

        if (firstSuccessResponse.Schema.Items != null)
        {
          if (!string.IsNullOrEmpty(firstSuccessResponse.Schema.Items.Ref))
          {
            typeName = $"{GetTypeNameFromRef(firstSuccessResponse.Schema.Items.Ref)}[]";
          }
          else
          {
            return $"{firstSuccessResponse.Schema.Items.Type}[]";
          }
        }
        else
        {
          if (!string.IsNullOrEmpty(firstSuccessResponse.Schema.Ref))
          {
            if (firstSuccessResponse.Schema.Ref.Contains("[") && firstSuccessResponse.Schema.Ref.Contains("]")
                                                              && !firstSuccessResponse.Schema.Ref.Contains("[]"))
            {
              // "$ref": "#/definitions/SearchResultModel[CustomerDTO]"
              typeName = $"{GetTypeNameFromRef(firstSuccessResponse.Schema.Ref)}";

              var subTypeName = typeName.Substring(typeName.IndexOf("[") + 1, typeName.IndexOf("]") - typeName.IndexOf("[") - 1);

              return $"{moduleName}.{typeName.Substring(0, typeName.IndexOf("["))}<{moduleName}.{subTypeName}>";
            }
            else
            {
              typeName = $"{GetTypeNameFromRef(firstSuccessResponse.Schema.Ref)}";
            }
          }
          else if ("object".Equals(firstSuccessResponse.Schema.Type, StringComparison.InvariantCultureIgnoreCase))
          {
            return "any";
          }
          else
          {
            return $"{firstSuccessResponse.Schema.Type}";
          }
        }

        if (!typeName.EndsWith("[]"))
        {
          typeName = typeName.Replace("[", "<").Replace("]", ">");
        }

        return string.IsNullOrEmpty(moduleName) ? typeName : $"{moduleName}.{typeName}";
      }
      catch (Exception ex)
      {
        return $"{operation.OperationId} {ex.Message}";
      }

    }
  }
}
