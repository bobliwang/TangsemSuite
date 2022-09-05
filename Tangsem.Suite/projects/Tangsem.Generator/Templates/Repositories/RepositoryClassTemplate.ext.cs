namespace Tangsem.Generator.Templates.Repositories
{
  using System.Collections.Generic;

  using Tangsem.Generator.Metadata;
  using Tangsem.Generator.Settings;

  /// <summary>
  /// RepositoryClassTemplate
  /// </summary>
  public partial class RepositoryClassTemplate : IMultipleTableMetadataTemplate
  {
    public RepositoryClassTemplate(GeneratorConfiguration configuration, List<TableMetadata> tableMetadatas)
    {
      this.Configuration = configuration;
      this.TableMetadatas = tableMetadatas;
    }

    public GeneratorConfiguration Configuration { get; set; }

    public List<TableMetadata> TableMetadatas { get; set; }

    public string GetPathToSave(GeneratorConfiguration genConfig)
    {
      return this.Configuration.IRepositoriesDirPath + "/" + this.Configuration.OrmType.AsNamespacePart() + "/" + this.Configuration.RepositoryName + ".Designer.cs";
    }
  }
}