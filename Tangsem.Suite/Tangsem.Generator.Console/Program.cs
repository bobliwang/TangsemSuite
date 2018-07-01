using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Console
{
  class Program
  {
    static void Main(string[] args)
    {
      //var path = @"Test.xml";

      var path = @"TMobility-Express.xml";

      if (args != null && args.Length > 0)
      {
        path = args[0];
      }

      var gen = new Gen(GeneratorConfiguration.FromFile(path));
      gen.Run();
    }
  }
}
