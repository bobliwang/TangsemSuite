using System;
using System.Collections.Generic;

using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

using Tangsem.Common.Extensions;
using Tangsem.OpenApi.Extensions.SwaggerCodeGen.GenTemplates;

using static System.Console;

namespace Tangsem.OpenApi.Extensions.SwaggerCodeGen.Filters
{
  /// <summary>
  /// For each data schema we add generated "dotnetAssemblyQualifiedName" and "generatedTypeScriptModel", or "skipCodeGen".
  /// </summary>
  public class ApiCodeGenSchemaFilter : ISchemaFilter
  {
    private IList<Type> _ignoredGenericTypes;

    public IList<Type> IgnoredGenericTypes
    {
      get => this._ignoredGenericTypes ??= new List<Type>();
      set => this._ignoredGenericTypes = value;
    }

    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
      var type = context.Type;

      if (type == null)
      {
        return;
      }

      var typeName = context.Type?.FullName;

      if (type.IsEnumOrNullableEnum())
      {
        WriteLine(">>>>>>>>>> SCHEMA ENUM:" + typeName);
        var generatedTypeScriptModel = new SingleTsModelTemplate(schema, type).TransformText();
        schema.Set_GeneratedTypeScriptModel(generatedTypeScriptModel);
      }

      if (schema.Type == "object")
      {
        WriteLine(">>>>>>>>>> SCHEMA CLASS:" + typeName);
        var skipCodeGen = type.IsGenericType && this.IgnoredGenericTypes.Contains(type.GetGenericTypeDefinition());
        schema.Set_DotnetAssemblyQualifiedName(type.AssemblyQualifiedName);

        if (skipCodeGen)
        {
          schema.Extensions.Add(nameof(skipCodeGen), OpenApiGeneratedCode.FromCode("true"));
        }
        else
        {
          var generatedTypeScriptModel = new SingleTsModelTemplate(schema, type).TransformText();
          schema.Set_GeneratedTypeScriptModel(generatedTypeScriptModel);
        }
      }
    }
  }
}
