using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneratorTest.Common.Domain.Mappings.AutoMapper;
using GeneratorTest.Common.Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GeneratorTest.Host
{
  public class Startup
  {
    public IConfiguration Configuration { get; private set; }

    public GeneratorTestRepositoryBuilder RepositoryBuilder { get; private set; }

    public Startup(IHostingEnvironment environment)
    {
      var msg = $"Startup - Env: {environment.EnvironmentName}";
      Console.WriteLine(msg);

      //create configuration
      this.Configuration = new ConfigurationBuilder()
        .SetBasePath(environment.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables()
        .Build();

      this.RepositoryBuilder = new GeneratorTestRepositoryBuilder(this.Configuration.GetConnectionString("TestDatabase"));
    }


    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddSingleton(sp => new GeneratorTestRepositoryAutoMapperConfiguration().Configure().CreateMapper());

      // CORS
      services.AddCors();

      services.AddMvc();

      services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      services.AddScoped(sp =>
      { 
        var repo = this.RepositoryBuilder.CreateRepository(new FakeDataContext());
        return (IGeneratorTestRepository) repo;
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseStaticFiles();
      this.EnableCORS(app);

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc();
    }
    private void EnableCORS(IApplicationBuilder app)
    {
      // CORS
      app.UseCors(builder =>
      {
        builder
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials();
      });
    }
  }
}
