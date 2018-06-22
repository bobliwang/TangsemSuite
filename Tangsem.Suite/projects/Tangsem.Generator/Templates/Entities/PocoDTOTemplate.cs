using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.Entities
{
  public class PocoDTOTemplate : ASP._Templates_Entities_Poco_DTO_Designer_cshtml
  {
    public PocoDTOTemplate(GeneratorConfiguration configuration, TableMetadata tableMetadata)
    {
      this.Configuration = configuration;
      this.TableMetadata = tableMetadata;
    }

    public override string GetPathToSave(GeneratorConfiguration genConfig)
    {
      return this.Configuration.DTODirPath + "/" + this.TableMetadata.EntityName + "DTO.Designer.cs";
    }
  }
}