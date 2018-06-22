using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RazorGenerator.Templating;

using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates
{
  public interface IMultipleTableMetadataTemplate : ITemplateBase
  {
    List<TableMetadata> TableMetadatas { get; set; }
  }


  /// <summary>
  /// The MultipleTableMetadataTemplate class.
  /// </summary>
  public class MultipleTableMetadataTemplate : TemplateBase, IMultipleTableMetadataTemplate
  {
		/// <summary>
		/// The list of TableMetadatas.
		/// </summary>
		public virtual List<TableMetadata> TableMetadatas { get; set; }
	}
}
