using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.Entities
{
  partial class PocoNHibernateFluentTemplate : ISingleTableMetadataTemplate
  {
    public PocoNHibernateFluentTemplate(GeneratorConfiguration configuration, TableMetadata tableMetadata)
    {
      this.Configuration = configuration;
      this.TableMetadata = tableMetadata;
    }

    public GeneratorConfiguration Configuration { get; set; }

    public TableMetadata TableMetadata { get; set; }

    public string GetPathToSave(GeneratorConfiguration genConfig)
    {
      return this.Configuration.MappingDirPath + "/" + this.TableMetadata.EntityName + "Map.Designer.cs";
    }

    public Func<string, string> TableNameInMapping = (tableName) => $"[{tableName}]";
  }
}
