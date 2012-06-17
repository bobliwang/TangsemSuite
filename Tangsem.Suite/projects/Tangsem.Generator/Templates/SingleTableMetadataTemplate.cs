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
	public class SingleTableMetadataTemplate : TemplateBase
	{
		/// <summary>
		/// The table metadata.
		/// </summary>
		public virtual TableMetadata TableMetadata { get; set; }
	}
}
