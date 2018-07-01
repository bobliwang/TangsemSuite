using System.Collections.Generic;

using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.StoredProc
{
  public partial class StoredProc: IMultipleTableMetadataTemplate
  {
    public StoredProc(GeneratorConfiguration configuration, List<TableMetadata> tableMetadatas)
    {
      this.Configuration = configuration;
      this.TableMetadatas = tableMetadatas;
    }

    public string GetPathToSave(GeneratorConfiguration genConfig)
    {
      return this.Configuration.IRepositoriesDirPath + "/" + this.Configuration.OrmType.AsNamespacePart() + "/" + this.Configuration.RepositoryName + "StoredProcs.Designer.cs";
    }

    public GeneratorConfiguration Configuration { get; set; }

    public List<TableMetadata> TableMetadatas { get; set; }
  }
}