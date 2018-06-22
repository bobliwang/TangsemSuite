using System.Collections.Generic;

using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.Angular
{
  public partial class NgApiService: IMultipleTableMetadataTemplate
  {
    public NgApiService()
    {
    }

    public List<TableMetadata> TableMetadatas { get; set; }

    public GeneratorConfiguration Configuration { get; set; }
  }
}