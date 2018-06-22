using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RazorGenerator.Templating;

using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates
{
  public interface ITemplateBase
  {
    GeneratorConfiguration Configuration { get; set; }

    string TransformText();

    string GetPathToSave(GeneratorConfiguration genConfig);
  }

	/// <summary>
	/// The TemplateBase class.
	/// </summary>
	public abstract class TemplateBase : RazorTemplateBase, ITemplateBase
  {
		/// <summary>
		/// The generator configuration instance.
		/// </summary>
		public virtual GeneratorConfiguration Configuration { get; set; }

    public virtual string GetPathToSave(GeneratorConfiguration genConfig)
    {
      throw new NotImplementedException();
    }
  }
}
