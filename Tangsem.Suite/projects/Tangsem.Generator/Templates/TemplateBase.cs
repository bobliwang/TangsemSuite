using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RazorGenerator.Templating;

using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates
{
	/// <summary>
	/// The TemplateBase class.
	/// </summary>
	public abstract class TemplateBase : RazorTemplateBase
	{
		/// <summary>
		/// The generator configuration instance.
		/// </summary>
		public virtual GeneratorConfiguration Configuration { get; set; }
	}
}
