using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.MVC.Controllers
{
  public partial class ApiControllerBaseTemplate : ISingleTableMetadataTemplate
  {
    public ApiControllerBaseTemplate(GeneratorConfiguration configuration, TableMetadata tableMetadata)
    {
      this.Configuration = configuration;
      this.TableMetadata = tableMetadata;
    }

    public GeneratorConfiguration Configuration { get; set; }

    public TableMetadata TableMetadata { get; set; }

    public string GetPathToSave(GeneratorConfiguration genConfig)
    {
      return Path.Combine(this.Configuration.OutputDir, "asp-net-core", "Controllers", "Base", $"{this.TableMetadata.EntityName}ApiControllerBase.Designer.cs");
    }
  }
}
