using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Console
{
  class Program
  {
    static void Main(string[] args)
    {
      //var path = @"GeneratorTest.json";
      //var path = @"PostgreTest.json";

      ////var path = @"Tangsem.Identity.json";
      //var path = @"ShopeeAndQuickbook.json";

      ////var path = @"TMobility-Express.xml";

      ////var path = "TestPhoenix.xml";
      var path = "AWS_Aurora.json";

      ////var path = "docu-flow.json";

      if (args != null && args.Length > 0)
      {
        path = args[0];
      }

      var gen = new Gen(GeneratorConfiguration.FromFile(path));
      gen.Run();
    }
  }
}
