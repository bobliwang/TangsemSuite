
using Microsoft.OpenApi.Models;
using Tangsem.Common.Extensions;

namespace Tangsem.OpenApi.Extensions.SwaggerCodeGen
{
  internal static class SwaggerExtendedPropKeys
  {
    /// <summary>
    /// The key for request body parameter name in generated post/put method.
    /// </summary>
    public const string RequestBodyParamName = "requestBodyParamName";

    /// <summary>
    /// The default parameter name of request body.
    /// </summary>
    public const string DefaultRequestBodyParamName = "requestBody";

    public const string GeneratedTypeScriptModel = "generatedTypeScriptModel";

    public const string GeneratedModelsCode = "generatedModelsCode";

    public const string GeneratedApiClientCode = "generatedApiClientCode";

    public const string AspNetMvcInfo = "aspNetMvcInfo";

    public const string GeneratedExtraEnumsCode = "generatedExtraEnumsCode";

    public const string DotnetAssemblyQualifiedName = "dotnetAssemblyQualifiedName";

    /// <summary>
    /// Get_RequestBodyParamName
    /// </summary>
    public static string Get_RequestBodyParamName(this OpenApiRequestBody reqBody)
    {
      return (reqBody.Extensions[RequestBodyParamName] as OpenApiGeneratedCode)?.Code;
    }

    /// <summary>
    /// Set_GeneratedExtraEnumsCode
    /// </summary>
    public static void Set_GeneratedExtraEnumsCode(this OpenApiDocument openApiDoc, string code)
    {
      openApiDoc.Extensions[GeneratedExtraEnumsCode] = OpenApiGeneratedCode.FromCode(code);
    }

    /// <summary>
    /// Set_GeneratedModelsCode
    /// </summary>
    public static void Set_GeneratedModelsCode(this OpenApiDocument openApiDoc, string code)
    {
      openApiDoc.Extensions[GeneratedModelsCode] = OpenApiGeneratedCode.FromCode(code);
    }

    /// <summary>
    /// Set_GeneratedApiClientCode
    /// </summary>
    public static void Set_GeneratedApiClientCode(this OpenApiDocument openApiDoc, string code)
    {
      openApiDoc.Extensions[GeneratedApiClientCode] = OpenApiGeneratedCode.FromCode(code);
    }

    public static void Set_GeneratedTypeScriptModel(this OpenApiSchema openApiSchema, string code)
    {
      // schema.Extensions.Add("dotnetAssemblyQualifiedName", OpenApiGeneratedCode.FromCode(type.AssemblyQualifiedName));
      openApiSchema.Extensions.Add(GeneratedTypeScriptModel, OpenApiGeneratedCode.FromCode(code));
    }

    public static void Set_DotnetAssemblyQualifiedName(this OpenApiSchema openApiSchema, string code)
    {
      openApiSchema.Extensions.Add(DotnetAssemblyQualifiedName, OpenApiGeneratedCode.FromCode(code));
    }


    /// <summary>
    /// Set_AspNetMvcInfo
    /// </summary>
    public static void Set_AspNetMvcInfo(this OpenApiOperation openApiOperation, string actionName, string controllerName, string controllerClassFullName)
    {
      var jsonText = JSON.Stringify(new
      {
        actionName = actionName,
        controllerName = controllerName,
        controllerClassFullName = controllerClassFullName,
      });

      openApiOperation.Extensions[AspNetMvcInfo] = OpenApiGeneratedCode.FromCode(jsonText);
    }
  }
}
