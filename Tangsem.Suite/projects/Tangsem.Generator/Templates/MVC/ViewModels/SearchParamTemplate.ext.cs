using System.IO;

using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.MVC.ViewModels
{
  public partial class SearchParamTemplate: ISingleTableMetadataTemplate
  {
    public SearchParamTemplate(GeneratorConfiguration configuration, TableMetadata tableMetadata)
    {
      this.Configuration = configuration;
      this.TableMetadata = tableMetadata;
    }

    public GeneratorConfiguration Configuration { get; set; }

    public TableMetadata TableMetadata { get; set; }


    public string GetPathToSave(GeneratorConfiguration genConfig)
    {
      return Path.Combine(this.Configuration.OutputDir, "asp-net-core", "ViewModels", "SearchParams", $"{this.TableMetadata.EntityName}SearchParam.cs");
    }

  }
}