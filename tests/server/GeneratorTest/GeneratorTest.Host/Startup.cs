using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneratorTest.Common.Domain.Mappings.AutoMapper;
using GeneratorTest.Common.Domain.Repositories;
using GeneratorTest.Host.Infrastructure;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Swashbuckle.AspNetCore.Swagger;

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
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {


      services.AddSingleton(sp => new TestRepositoryAutoMapperConfiguration().Configure(new AppRepoProvider(sp)).CreateMapper());

      // CORS
      services.AddCors();

      services.AddMvc();

      // Register the Swagger generator, defining 1 or more Swagger documents
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });

        //// c.DescribeAllEnumsAsStrings();
        //// c.TagActionsBy(x => (x.ActionDescriptor as ControllerActionDescriptor).ControllerName);

        c.DocumentFilter<SwaggerAddEnumDescriptions>();
      });

      services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

      services.AddScoped(sp =>
      {
        var repo = this.RepositoryBuilder.CreateRepository(new FakeDataContext());
        return (IGeneratorTestRepository)repo;
      });

      return services.BuildServiceProvider();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
    {
      app.UseStaticFiles();
      this.EnableCORS(app);

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();


        // Enable middleware to serve generated Swagger as a JSON endpoint.
        app.UseSwagger();

        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
        // specifying the Swagger JSON endpoint.
        app.UseSwaggerUI(c =>
        {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });
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

  public class AppRepoProvider : IRepoProvider
  {
    public AppRepoProvider(IServiceProvider serviceProvider)
    {
      this.ServiceProvider = serviceProvider;
    }

    public IServiceProvider ServiceProvider { get; private set; }

    public IGeneratorTestRepository Get()
    {
      return this.ServiceProvider.GetService<IGeneratorTestRepository>();
    }
  }

}
