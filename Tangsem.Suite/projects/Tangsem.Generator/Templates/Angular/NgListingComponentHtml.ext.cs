﻿using System.IO;

using Tangsem.Common.Extensions;
using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.Angular
{
  public partial class NgListingComponentHtml : ISingleTableMetadataTemplate
  {
    public NgListingComponentHtml(GeneratorConfiguration configuration, TableMetadata tableMetadata)
    {
      this.Configuration = configuration;
      this.TableMetadata = tableMetadata;
    }

    public GeneratorConfiguration Configuration { get; set; }


    public TableMetadata TableMetadata { get; set; }



    public string GetPathToSave(GeneratorConfiguration genConfig)
    {
      return Path.Combine(
        this.Configuration.NgAppFolder,
        "components",
        this.TableMetadata.EntityName.Lf(),
        $"{this.TableMetadata.EntityName.Lf()}-listing.component.html");
    }
  }
}