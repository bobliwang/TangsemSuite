using System.Collections.Generic;

using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.Repositories
{

  public class RepositoryInterfaceTemplate : ASP._Templates_Repositories_IRepository_Designer_cshtml
  {
    public RepositoryInterfaceTemplate(GeneratorConfiguration configuration, List<TableMetadata> tableMetadatas)
    {
      this.Configuration = configuration;
      this.TableMetadatas = tableMetadatas;
    }

    public override string GetPathToSave(GeneratorConfiguration genConfig)
    {
      return this.Configuration.IRepositoriesDirPath + "/I" + this.Configuration.RepositoryName + ".Designer.cs";
    }
  }

  public class RepositoryClassTemplate : ASP._Templates_Repositories_Repository_Designer_cshtml
  {
    public RepositoryClassTemplate(GeneratorConfiguration configuration, List<TableMetadata> tableMetadatas)
    {
      this.Configuration = configuration;
      this.TableMetadatas = tableMetadatas;
    }

    public override string GetPathToSave(GeneratorConfiguration genConfig)
    {
      return this.Configuration.IRepositoriesDirPath + "/" + this.Configuration.OrmType.AsNamespacePart() + "/" + this.Configuration.RepositoryName + ".Designer.cs";
    }
  }
}
