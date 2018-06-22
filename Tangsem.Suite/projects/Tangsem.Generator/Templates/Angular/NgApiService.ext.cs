using System.Collections.Generic;

using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.Angular
{
  public partial class NgApiService: IMultipleTableMetadataTemplate
  {
    public NgApiService(GeneratorConfiguration configuration, List<TableMetadata> tableMetadatas)
    {
      this.Configuration = configuration;
      this.TableMetadatas = tableMetadatas;
    }

    public List<TableMetadata> TableMetadatas { get; set; }

    public GeneratorConfiguration Configuration { get; set; }

    public string GetPathToSave(GeneratorConfiguration genConfig)
    {
      return this.Configuration.NgServicesFolder + "/api.service.ts";
    }
  }
}