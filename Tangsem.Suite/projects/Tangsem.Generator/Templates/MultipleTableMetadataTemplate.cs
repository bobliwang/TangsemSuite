using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RazorGenerator.Templating;

using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates
{
	/// <summary>
	/// The MultipleTableMetadataTemplate class.
	/// </summary>
	public class MultipleTableMetadataTemplate : RazorTemplateBase
	{
		/// <summary>
		/// The generator configuration instance.
		/// </summary>
		public GeneratorConfiguration Configuration { get; set; }

		/// <summary>
		/// The list of TableMetadatas.
		/// </summary>
		public List<TableMetadata> TableMetadatas { get; set; }
	}
}
