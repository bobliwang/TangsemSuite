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
	/// The OneFilePerTableMetadataTemplate class.
	/// </summary>
	public class SingleTableMetadataTemplate : RazorTemplateBase
	{
		/// <summary>
		/// The table metadata.
		/// </summary>
		public TableMetadata TableMetadata { get; set; }

		/// <summary>
		/// The generator configuration instance.
		/// </summary>
		public GeneratorConfiguration Configuration { get; set; }
	}
}
