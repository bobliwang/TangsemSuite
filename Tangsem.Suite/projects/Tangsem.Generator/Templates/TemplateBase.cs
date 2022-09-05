using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates
{
  public interface ITemplateBase
  {
    GeneratorConfiguration Configuration { get; set; }

    string TransformText();

    string GetPathToSave(GeneratorConfiguration genConfig);
  }
}
