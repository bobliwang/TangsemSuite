using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tangsem.Generator.Metadata;

namespace Tangsem.Generator.Templates
{
  public interface ISingleTableMetadataTemplate : ITemplateBase
  {
    TableMetadata TableMetadata { get; set; }
  }
}
