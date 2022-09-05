using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Tangsem.Common.Extensions;

namespace Tangsem.OpenApi.Extensions.SwaggerCodeGen.GenTemplates
{
  public partial class SingleTsModelTemplate
  {
    public SingleTsModelTemplate(OpenApiSchema openApiSchema, Type type)
    {
      this.OpenApiSchema = openApiSchema;
      this.Type = type;
    }

    public Type Type { get; }

    public OpenApiSchema OpenApiSchema { get; }

    public bool IsEnumOrNullableEnum(Type type) => type.IsEnumOrNullableEnum();

    public IList<object> GetEnumValues(Type enumType)
    {
      var values = Enum.GetValues(enumType).Cast<object>().ToList();

      return values;
    }

    public string GetModelClassDescription()
    {
      return this.OpenApiSchema.Description;
    }

    public string GetPropertyDescription(string propName)
    {
      var schema = this.OpenApiSchema.Properties.TryGetValueByKey(propName.LowerFirst());
      if (schema == null)
      {
        schema = this.OpenApiSchema.Properties.TryGetValueByKey(propName);
      }

      return schema?.Description;
    }
  }
}
