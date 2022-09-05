using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.OpenApi.Models;
using Tangsem.Common.Extensions;

namespace Tangsem.OpenApi.Extensions.SwaggerCodeGen
{
  public static class OpenApiDocumentExtensions
  {
    /// <summary>
    /// Checks if schema is a enum type.
    /// </summary>
    public static bool IsEnum(this OpenApiSchema schema)
    {
      return schema.Enum?.Any() == true;
    }

    public static string GetBodyParamName(this OpenApiRequestBody requestBody)
    {
      if (requestBody.Extensions.TryGetValue(SwaggerExtendedPropKeys.RequestBodyParamName, out var extension))
      {
        var code = (extension as OpenApiGeneratedCode)?.Code;

        if (!code.IsNullOrWhiteSpace())
        {
          return code;
        }
      }

      return SwaggerExtendedPropKeys.DefaultRequestBodyParamName;
    }

    public static List<Type> GetEnumTypes(this OpenApiDocument swaggerDoc)
    {
      var types = swaggerDoc.Components.Schemas.SelectMany(
        schemaKvp =>
          {
            var cmpEnum = schemaKvp.Value;

            // one component type may have several enum types.
            // full c# enum type names.
            var enumTypeNames = cmpEnum.Properties
                                      .Values
                                      .Where(x => x.IsEnum())
                                      .Select(x => x.Type)
                                      .Distinct()
                                      .ToList();

            
            return enumTypeNames
                    .Select(GetTypeFromTypeName)
                    .ToList();
          }).Distinct()
        .OrderBy(x => x.Name)
        .ToList();

      return types;
    }

    public static List<Type> GetComponentSchemaTypes(this OpenApiDocument swaggerDoc)
    {
      var types = swaggerDoc.Components.Schemas.SelectMany(
          schemaKvp =>
            {
              var cmpEnum = schemaKvp.Value;

              // one component type may have several enum types.
              // full c# enum type names.
              var enumTypeNames = cmpEnum.Properties
                .Values
                .Where(x => !x.IsEnum() && x.Type == "object")
                .Select(x => x.Type)
                .Distinct()
                .ToList();


              return enumTypeNames
                .Select(GetTypeFromTypeName)
                .ToList();
            }).Distinct()
        .OrderBy(x => x.Name)
        .ToList();

      return types;
    }

    public static Type GetTypeFromTypeName(string typeNameWithAssemblyName)
    {
      return Type.GetType(typeNameWithAssemblyName);
    }

    public static OpenApiGeneratedCode GetGenCode_GeneratedTypeScriptModel(this OpenApiSchema schema)
    {
      return schema.Extensions.TryGetValue(SwaggerExtendedPropKeys.GeneratedTypeScriptModel, out var code) ? code as OpenApiGeneratedCode : null;
    }
  }
}
