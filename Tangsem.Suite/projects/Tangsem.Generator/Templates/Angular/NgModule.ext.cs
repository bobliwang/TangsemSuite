using System.Collections.Generic;
using System.IO;

using Tangsem.Common.Extensions;
using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.Angular
{
  public partial class NgModule: IMultipleTableMetadataTemplate
  {
    public NgModule(GeneratorConfiguration configuration, List<TableMetadata> tableMetadatas)
    {
      this.Configuration = configuration;
      this.TableMetadatas = tableMetadatas;
    }

    public GeneratorConfiguration Configuration { get; set; }

    public List<TableMetadata> TableMetadatas { get; set; }

    public string GetPathToSave(GeneratorConfiguration genConfig)
    {
      return Path.Combine(
        this.Configuration.NgAppFolder,
        this.Configuration.RepositoryName.Lf() + "-module.ts"
      );
    }
  }
}