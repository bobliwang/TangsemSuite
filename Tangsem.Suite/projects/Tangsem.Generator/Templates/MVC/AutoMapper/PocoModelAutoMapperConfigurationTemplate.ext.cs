using System.Collections.Generic;

using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.MVC.AutoMapper
{
  public partial class PocoModelAutoMapperConfigurationTemplate: IMultipleTableMetadataTemplate
  {
    public PocoModelAutoMapperConfigurationTemplate(GeneratorConfiguration configuration, List<TableMetadata> tableMetadatas)
    {
      this.Configuration = configuration;
      this.TableMetadatas = tableMetadatas;
    }

    public GeneratorConfiguration Configuration { get; set; }


    public List<TableMetadata> TableMetadatas { get; set; }
    
    public string GetPathToSave(GeneratorConfiguration genConfig)
    {
      return this.Configuration.AutoMappingConfigsDirPath + "/AutoMapperProfile.Designer.cs";
    }
  }
}