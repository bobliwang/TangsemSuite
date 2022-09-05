using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.Entities
{
  public partial class PocoTemplate : ISingleTableMetadataTemplate
  {
    public PocoTemplate(GeneratorConfiguration configuration, TableMetadata tableMetadata)
    {
      this.Configuration = configuration;
      this.TableMetadata = tableMetadata;
    }
    
    public GeneratorConfiguration Configuration { get; set; }

    public TableMetadata TableMetadata { get; set; }
    
    public string GetPathToSave(GeneratorConfiguration genConfig)
    {
      return this.Configuration.EntitiesDirPath + "/" + this.TableMetadata.EntityName + ".Designer.cs";
    }

    public bool IsOutgoingRef(ColumnMetadata col)
    {
      return this.Configuration.GenRelationship && col.IsOutgoingRefKey;
    }
  }
}
