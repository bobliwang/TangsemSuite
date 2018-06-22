using System.IO;

using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.MVC.Controllers
{
  public partial class ApiControllerTemplate: ISingleTableMetadataTemplate
  {
    public ApiControllerTemplate(GeneratorConfiguration configuration, TableMetadata tableMetadata)
    {
      this.Configuration = configuration;
      this.TableMetadata = tableMetadata;
    }

    public GeneratorConfiguration Configuration { get; set; }

    public TableMetadata TableMetadata { get; set; }
    
    public string GetPathToSave(GeneratorConfiguration genConfig)
    {
      return Path.Combine(this.Configuration.OutputDir, "asp-net-core", "Controllers", $"{this.TableMetadata.EntityName}ApiController.Designer.cs");
    }
  }
}