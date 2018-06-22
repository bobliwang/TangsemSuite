using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.Entities
{
  public class PocoTemplate : ASP._Templates_Entities_Poco_Designer_cshtml
  {
    public PocoTemplate(GeneratorConfiguration configuration, TableMetadata tableMetadata)
    {
      this.Configuration = configuration;
      this.TableMetadata = tableMetadata;
    }

    public override string GetPathToSave(GeneratorConfiguration genConfig)
    {
      return this.Configuration.EntitiesDirPath + "/" + this.TableMetadata.EntityName + ".Designer.cs";
    }
  }
}
