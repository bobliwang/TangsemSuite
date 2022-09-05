using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;

using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GeneratorTest.Host.Infrastructure
{
  public class SwaggerAddEnumDescriptions : IDocumentFilter
  {
    public static readonly IDictionary<string, Func<PathItem, Operation>> PathItemOperationsMap = new Dictionary<string, Func<PathItem, Operation>>
        {
          ["get"] = pi => pi.Get,
          ["post"] = pi => pi.Post,
          ["put"] = pi => pi.Put,
          ["delete"] = pi => pi.Delete
        };


  public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
    {
      // add enum descriptions to result models
      foreach (var schemaDictionaryItem in swaggerDoc.Definitions)
      {
        var schema = schemaDictionaryItem.Value;
        foreach (var propertyDictionaryItem in schema.Properties)
        {
          var propertySchema = propertyDictionaryItem.Value;
          IList<object> propertyEnums = propertySchema.Enum;
          if (propertyEnums != null && propertyEnums.Count > 0)
          {
            propertySchema.Description += this.DescribeEnum(propertyEnums);
          }
        }
      }

      var apiDescriptions = context.ApiDescriptionsGroups.Items.AsQueryable<ApiDescriptionGroup>().SelectMany(x => x.Items).ToList();

      // add enum descriptions to input parameters
      if (swaggerDoc.Paths.Count > 0)
      {

        foreach (var kvp in swaggerDoc.Paths)
        {
          var pathItem = kvp.Value;

          this.DescribeEnumParameters(pathItem.Parameters);
          
          // head, patch, options, delete left out
          var possibleParameterisedOperations = PathItemOperationsMap
                                                  .Values
                                                  .Select(func => func(pathItem))
                                                  .Where(x => x != null)
                                                  .ToList();
          
          foreach (var x in possibleParameterisedOperations)
          {
            this.DescribeEnumParameters(x.Parameters);
          }
        }
      }
      
      foreach (var pathKvp in swaggerDoc.Paths)
      {
        var pathKey = pathKvp.Key;
        var pathInfo = pathKvp.Value;
        var operations = PathItemOperationsMap.Select(x => new KeyValuePair<string, Operation>(x.Key, x.Value(pathInfo)))
            .Where(x => x.Value != null)
            .ToList();

        foreach (var opKvp in operations)
        {
          var operation = opKvp.Value;

          if (!operation.Tags.Any(x => "autogen".Equals(x, StringComparison.InvariantCultureIgnoreCase)))
          {
            continue;
          }

          var httpMethod = opKvp.Key;
          var api = apiDescriptions.FirstOrDefault(
            x => opKvp.Key.Equals(x.HttpMethod, StringComparison.InvariantCultureIgnoreCase)
                 && $"/{x.RelativePath}" == pathKey);

          var actionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;
          if (actionDescriptor == null)
          {
            throw new NullReferenceException(
              $"ControllerActionDescriptor is null for {pathKey}, httpMethod: {httpMethod}");
          }

          operation.Extensions["aspNetMvcInfo"] = new
                                                    {
                                                      actionDescriptor.ActionName,
                                                      actionDescriptor.ControllerName,
                                                      controllerClassFullName =
                                                        actionDescriptor.ControllerTypeInfo.FullName,
                                                    };
        }
      }

      swaggerDoc.Extensions["generatedModelsCode"] = this.MakeLintCompatible(
            new TypeScriptModels { DocumentFilterContext = context, SwaggerDoc = swaggerDoc }.TransformText());

      swaggerDoc.Extensions["generatedApiClientCode"] = this.MakeLintCompatible(
        new ApiClientTemplate { DocumentFilterContext = context, SwaggerDoc = swaggerDoc }.TransformText());

    }

    private string MakeLintCompatible(string typeScriptCode)
    {
      return typeScriptCode.Trim() + Environment.NewLine;
    }

    private void DescribeEnumParameters(IList<IParameter> parameters)
    {
      if (parameters != null)
      {
        foreach (IParameter param in parameters)
        {
          // // IList<object> paramEnums = param.Enum;
          // // if (paramEnums != null && paramEnums.Count > 0)
          // // {
          // //     param.Description += DescribeEnum(paramEnums);
          // // }
        }
      }
    }

    private string DescribeEnum(IList<object> enums)
    {
      List<string> enumDescriptions = new List<string>();
      foreach (object enumOption in enums)
      {
        Console.WriteLine($"ENUM {enumOption} {enumOption.GetType()}");
        if (enumOption is string)
        {
          enumDescriptions.Add($"{enumOption} = {enumOption}");

        }
        else
        {
          enumDescriptions.Add($"{enumOption.GetType().Name}.{enumOption} = {(int)enumOption}");
        }
      }
      return string.Join(", ", enumDescriptions.ToArray());
    }

  }
}