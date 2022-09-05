using System.Collections.Generic;
using System.Linq;

using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace Tangsem.OpenApi.Extensions.SwaggerCodeGen.GenTemplates
{
  public partial class TypeScriptModels
  {
    private List<string> _extraImports;

    public TypeScriptModels(DocumentFilterContext documentFilterContext, OpenApiDocument swaggerDoc)
    {
      this.DocumentFilterContext = documentFilterContext;
      this.SwaggerDoc = swaggerDoc;
    }

    public OpenApiDocument SwaggerDoc { get; }

    public DocumentFilterContext DocumentFilterContext { get; }

    public List<string> ExtraImports
    {
      get
      {
        return this._extraImports ??= new List<string>();
      }

      set
      {
        this._extraImports = value;
      }
    }

    public IList<string> GetGeneratedEnumsCode()
    {
      return this.SwaggerDoc.Components.Schemas
                 .Where(x => x.Value.IsEnum())
                 .OrderBy(x => x.Key)
                 .Select(
                   kvp =>
                     {
                       var code = kvp.Value.GetGenCode_GeneratedTypeScriptModel()?.Code;

                       return code;
                     }).ToList();
    }

    /// <summary>
    /// Collects 'generatedTypeScriptModel' from each schema and combine them into generated typescript models as a whole.
    /// </summary>
    /// <returns></returns>
    public IList<string> GetGenerateClassesCode()
    {
      return this.SwaggerDoc.Components.Schemas
        .Where(x => !x.Value.IsEnum() && !x.Key.EndsWith("SearchResultModel"))
        .OrderBy(x => x.Key)
        .Select(
          kvp =>
            {
              var code = kvp.Value.GetGenCode_GeneratedTypeScriptModel()?.Code;

              return code;
            }).ToList();
    }
  }
}
