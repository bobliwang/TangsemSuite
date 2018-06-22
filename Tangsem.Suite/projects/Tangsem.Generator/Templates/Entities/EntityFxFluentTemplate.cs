using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.Entities
{
  public class EntityFxFluentTemplate : ASP._Templates_Entities_Poco_EF_Fluent_Designer_cshtml
  {
    public EntityFxFluentTemplate(GeneratorConfiguration configuration, TableMetadata tableMetadata)
    {
      this.Configuration = configuration;
      this.TableMetadata = tableMetadata;
    }

    public override string GetPathToSave(GeneratorConfiguration genConfig)
    {
      return this.Configuration.MappingDirPath + "/" + this.TableMetadata.EntityName + "Map.Designer.cs";
    }
  }
}