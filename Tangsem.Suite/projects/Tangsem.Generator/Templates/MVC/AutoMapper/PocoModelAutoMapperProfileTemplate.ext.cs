using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.MVC.AutoMapper
{
  public partial class PocoModelAutoMapperProfileTemplate : ISingleTableMetadataTemplate
  {
    public TableMetadata TableMetadata { get; set; }

    public GeneratorConfiguration Configuration { get; set; }

    public PocoModelAutoMapperProfileTemplate(TableMetadata tableMetadata, GeneratorConfiguration configuration)
    {
      this.TableMetadata = tableMetadata;
      this.Configuration = configuration;
    }
  }
}