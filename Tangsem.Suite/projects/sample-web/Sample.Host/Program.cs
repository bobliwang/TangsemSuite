using System.Net;
using System.Net.Sockets;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Sample.Host
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateWebHostBuilder(args).Build().Run();
    }
        
    public static string GetLocalIpAddress()
    {
      var host = Dns.GetHostEntry(Dns.GetHostName());
      foreach (var ip in host.AddressList)
      {
        if (ip.AddressFamily == AddressFamily.InterNetwork)
        {
          return ip.ToString();
        }
      }

      return string.Empty;
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
#if DEBUG
          .UseKestrel(options =>
            {
              options.AddServerHeader = false;
              options.Listen(IPAddress.Parse(GetLocalIpAddress()), 5001);
              options.Listen(IPAddress.Parse(GetLocalIpAddress()), 5000, listenOptions => { listenOptions.UseHttps("./localhost.pfx", "YourSecurePassword"); });
              options.ListenLocalhost(5001);
              options.ListenLocalhost(5000, listenOptions => { listenOptions.UseHttps("./localhost.pfx", "YourSecurePassword"); });
            })
#endif
            .ConfigureAppConfiguration((hostingContext, config) =>
             {
               var env = hostingContext.HostingEnvironment;
               config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                     .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
               config.AddEnvironmentVariables();

             })
           .ConfigureLogging((hostingContext, logging) =>
            {
              logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
              logging.AddConsole();
              logging.AddDebug();
              logging.AddEventSourceLogger();
            })
          ////.UseUrls("http://192.168.0.15:5000", "http://localhost:5000")
           .UseStartup<Startup>();
  }
}
