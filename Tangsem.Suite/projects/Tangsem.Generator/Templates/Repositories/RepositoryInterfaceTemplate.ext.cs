using System.Collections.Generic;

using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.Repositories
{
  /// <summary>
  /// RepositoryInterfaceTemplate
  /// </summary>
  public partial class RepositoryInterfaceTemplate : IMultipleTableMetadataTemplate
  {
    public RepositoryInterfaceTemplate(GeneratorConfiguration configuration, List<TableMetadata> tableMetadatas)
    {
      this.Configuration = configuration;
      this.TableMetadatas = tableMetadatas;
    }

    public GeneratorConfiguration Configuration { get; set; }

    public List<TableMetadata> TableMetadatas { get; set; }

    public string GetPathToSave(GeneratorConfiguration genConfig)
    {
      return this.Configuration.IRepositoriesDirPath + "/I" + this.Configuration.RepositoryName + ".Designer.cs";
    }
  }
}
