using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates
{
  public interface IMultipleTableMetadataTemplate : ITemplateBase
  {
    List<TableMetadata> TableMetadatas { get; set; }
  }
}
