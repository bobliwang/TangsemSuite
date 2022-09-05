using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

using Tangsem.Common.Extensions;
using Tangsem.Common.ValueClasses;

using Tangsem.OpenApi.Extensions.SwaggerCodeGen.GenTemplates;

namespace Tangsem.OpenApi.Extensions.SwaggerCodeGen.Filters
{
  public class ApiCodeGenDocumentFilter : IDocumentFilter
  {
    public static readonly IDictionary<string, Func<OpenApiPathItem, OpenApiOperation>> PathItemOperationsMap =
      new Dictionary<string, Func<OpenApiPathItem, OpenApiOperation>>
      {
        ["get"] = pi => pi.Operations.TryGetValueByKey(OperationType.Get),
        ["post"] = pi => pi.Operations.TryGetValueByKey(OperationType.Post),
        ["put"] = pi => pi.Operations.TryGetValueByKey(OperationType.Put),
        ["delete"] = pi => pi.Operations.TryGetValueByKey(OperationType.Delete)
      };
      
    private IList<Type> _valueClassTypes;

    private IList<string> _tsModelsExtraImports;

    private IDictionary<string, Func<string>> _extendedCodeGenerators;

    public string ApiBaseUrlTokenName { get; set; } = "API_BASE_URL";

    public Func<ApiClientMethodGenParams, string> MethodTemplateFn { get; set; }

    public IDictionary<string, Func<string>> ExtendedCodeGenerators
    {
      get => this._extendedCodeGenerators ??= new Dictionary<string, Func<string>>();
      set => this._extendedCodeGenerators = value;
    }

    public IList<Type> ValueClassTypes
    {
      get => this._valueClassTypes ??= new List<Type>();
      set => this._valueClassTypes = value;
    }

    public IList<string> TsModelsExtraImports
    {
      get => this._tsModelsExtraImports ??= new List<string>();
      set => this._tsModelsExtraImports = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="swaggerDoc"></param>
    /// <param name="context"></param>
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
      var apiDescriptions = context.ApiDescriptions.ToList();

      foreach (var pathKvp in swaggerDoc.Paths)
      {
        var pathKey = pathKvp.Key;
        var openApiPathItem = pathKvp.Value;
        var operations = PathItemOperationsMap
                          .Select(x => new KeyValuePair<string, OpenApiOperation>(x.Key, x.Value(openApiPathItem)))
                          .Where(x => x.Value != null)
                          .ToList();

        foreach (var opKvp in operations)
        {
          var operation = opKvp.Value;

          if (!operation.Tags.Any(x => "autogen".EqualsInvariantCultureIgnoreCase(x.Name)))
          {
            continue;
          }

          var httpMethod = opKvp.Key;
          var api = apiDescriptions.FirstOrDefault(x => opKvp.Key.EqualsInvariantCultureIgnoreCase(x.HttpMethod) && $"/{x.RelativePath}" == pathKey);

          var actionDescriptor = api?.ActionDescriptor as ControllerActionDescriptor
                                 ?? throw new NullReferenceException($"{nameof(ControllerActionDescriptor)} is null for {pathKey}, httpMethod: {httpMethod}");

          operation.Set_AspNetMvcInfo(actionDescriptor.ActionName, actionDescriptor.ControllerName, actionDescriptor.ControllerTypeInfo.FullName);
        }
      }

      var apiModelsCodeGen = new TypeScriptModels(context, swaggerDoc) { ExtraImports = TsModelsExtraImports.ToList() };
      var apiModelsCode = this.MakeLintCompatible(apiModelsCodeGen.TransformText());
      swaggerDoc.Set_GeneratedModelsCode(apiModelsCode);

      var apiClientCodeGen = new ApiClientTemplate(context, swaggerDoc)
      {
        ApiBaseUrlTokenName = this.ApiBaseUrlTokenName,
        MethodTemplateFn = this.MethodTemplateFn,
      };

      var apiClientCode = this.MakeLintCompatible(apiClientCodeGen.TransformText());
      swaggerDoc.Set_GeneratedApiClientCode(apiClientCode);

      var generatedExtraEnumsCode = this.ValueClassTypes.Select(
        x =>
          {
            var values = x.GetProperty("Values", BindingFlags.Static | BindingFlags.Public)?.GetValue(null) as IList;

            var gen = new ValueClassToTsEnumTemplate
                        {
                          Values = values?.Cast<ValueClass>().ToList() ?? new List<ValueClass>()
                        };

            return gen.TransformText();
          }).JoinWith(Environment.NewLine);

      swaggerDoc.Set_GeneratedExtraEnumsCode(generatedExtraEnumsCode);

      foreach (var generatorKvp in this.ExtendedCodeGenerators)
      {
        var generatorKeyName = generatorKvp.Key;
        var generatedCode = generatorKvp.Value.Invoke();

        swaggerDoc.Extensions[generatorKeyName] = OpenApiGeneratedCode.FromCode(generatedCode);
      }
    }

    /// <summary>
    /// Trim and append newline so that lint is happy.
    /// </summary>
    private string MakeLintCompatible(string typeScriptCode)
    {
      return typeScriptCode.Trim() + Environment.NewLine;
    }
  }

}