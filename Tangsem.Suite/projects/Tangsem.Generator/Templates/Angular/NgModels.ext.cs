
using System.Collections.Generic;

using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.Angular
{
  public partial class NgModels : IMultipleTableMetadataTemplate
  {
    public GeneratorConfiguration Configuration { get; set; }

    public List<TableMetadata> TableMetadatas { get; set; }
  }
}