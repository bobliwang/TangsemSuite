using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.Entities
{
  public partial class PocoDTOTemplate : ISingleTableMetadataTemplate
  {
    public PocoDTOTemplate(GeneratorConfiguration configuration, TableMetadata tableMetadata)
    {
      this.Configuration = configuration;
      this.TableMetadata = tableMetadata;
    }

    public GeneratorConfiguration Configuration { get; set; }

    public TableMetadata TableMetadata { get; set; }

    public string GetPathToSave(GeneratorConfiguration genConfig)
    {
      return this.Configuration.DTODirPath + "/" + this.TableMetadata.EntityName + "DTO.Designer.cs";
    }
  }
}