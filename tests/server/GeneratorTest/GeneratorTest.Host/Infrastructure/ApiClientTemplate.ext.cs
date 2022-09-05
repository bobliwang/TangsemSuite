using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;

using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GeneratorTest.Host.Infrastructure
{
  public partial class ApiClientTemplate
  {
    public SwaggerDocument SwaggerDoc { get; set; }

    public DocumentFilterContext DocumentFilterContext { get; set; }

    public string ModelsModuleName { get; set; } = "models";
    public string ModelsTsFilePath { get; set; } = "./models";

    public string ApiClientClassName { get; set; } = "ApiClient";

    public bool IsRootProvider { get; set; } = true;


    public IList<ApiDescription> GetApiDescriptions()
    {
      var apiDescriptions = this.DocumentFilterContext.ApiDescriptionsGroups.Items.AsQueryable<ApiDescriptionGroup>().SelectMany(x => x.Items).ToList();

      return apiDescriptions;
    }
  }
}
