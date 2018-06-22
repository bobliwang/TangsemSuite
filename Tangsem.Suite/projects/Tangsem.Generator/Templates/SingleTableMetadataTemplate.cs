using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RazorGenerator.Templating;

using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates
{
  public interface ISingleTableMetadataTemplate: ITemplateBase
  {
    TableMetadata TableMetadata { get; set; }
  }

  /// <summary>
  /// The OneFilePerTableMetadataTemplate class.
  /// </summary>
  public class SingleTableMetadataTemplate : TemplateBase, ISingleTableMetadataTemplate
  {
		/// <summary>
		/// The table metadata.
		/// </summary>
		public virtual TableMetadata TableMetadata { get; set; }
	}
}
