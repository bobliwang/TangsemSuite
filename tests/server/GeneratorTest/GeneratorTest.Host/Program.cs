using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace GeneratorTest.Host
{
  public class Program
  {
    public static void Main(string[] args)
    {
      ////var connStr = @"Data Source=.\SQLExpress;Initial Catalog=test;Integrated Security=True";
      ////RebuildDatabaseFromModels(connStr);


      BuildWebHost(args).Run();
    }

    private static void RebuildDatabaseFromModels(string connStr)
    {
      var configContainer = new GeneratorTestRepositoryBuilder(connStr).BuildFluentConfiguration();
      var config = configContainer.BuildConfiguration();

      new NHibernate.Tool.hbm2ddl.SchemaExport(config).Execute(true, true, false);
    }

    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseUrls("http://localhost:5000")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>()
            .Build();
  }
}
