using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.MVC.AutoMapper
{
  public partial class PocoModelAutoMapperProfileTemplate : ISingleTableMetadataTemplate
  {
    public PocoModelAutoMapperProfileTemplate(GeneratorConfiguration configuration, TableMetadata tableMetadata)
    {
      this.Configuration = configuration;
      this.TableMetadata = tableMetadata;
    }

    public TableMetadata TableMetadata { get; set; }

    public GeneratorConfiguration Configuration { get; set; }

    public string GetPathToSave(GeneratorConfiguration genConfig)
    {
      return this.Configuration.AutoMappingConfigsDirPath + "/" + this.TableMetadata.EntityName + "MapperProfile.Designer.cs";
    }
  }
}