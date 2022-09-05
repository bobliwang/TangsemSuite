using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using Tangsem.Identity;
using Tangsem.Identity.Domain.Entities;
using Tangsem.NHibernate.Domain;
using Tangsem.NHibernate.Interceptors;

using Sample.Core.Domain.Repositories;
using Sample.Host.Services;
using System.IO;
using Microsoft.AspNetCore.Identity.UI.Services;
using Sample.Core.Domain.Repositories.NHibernate;
using Microsoft.Extensions.Logging;

namespace Sample.Host
{
  public partial class Startup
  {
    public static readonly object LockObj = new object();

    private readonly string connString;

    private readonly IHostingEnvironment env;

    private readonly Microsoft.Extensions.Logging.ILoggerFactory loggerFactory;

    private readonly IConfiguration configuration;

    private readonly ILogger<Startup> logger;

    public Startup(IHostingEnvironment env, IConfiguration configuration, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory)
    {
      this.logger = loggerFactory.CreateLogger<Startup>();

      this.env = env;
      this.configuration = configuration;
      this.loggerFactory = loggerFactory;

      this.connString = configuration.GetConnectionString(Constants.ConnectionStringName);
    }

    public SampleHostRepositoryProvider RepoProvider { get; private set; }

    public HttpUserDataContext<AspNetUser> HttpUserDataContext = new HttpUserDataContext<AspNetUser>(null);

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddResponseCompression();
      this.InjectServices(services);

      services.Configure<AuthMessageSenderOptions>(this.configuration);
      this.SetupIdentityAndAuth(services);

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }

    
    private void InjectServices(IServiceCollection services)
    {
      // DI the services
      services.AddHttpContextAccessor();

      services.AddSingleton<IConfiguration>(this.configuration);
      services.AddScoped<HttpUserDataContext<AspNetUser>>();
      services.AddScoped(serviceProvider => this.InitRepositoryProvider(serviceProvider).CreateRepository());
      services.AddScoped<ISampleHostRepository>(serviceProvider => serviceProvider.GetService<SampleHostRepository>());
      services.AddScoped<RepositoryBase>(serviceProvider => serviceProvider.GetService<SampleHostRepository>());
      services.AddScoped<IQuickBooksService, QuickBooksService>();
      services.AddScoped<ShopeeService>();

      services.AddTransient<IEmailSender, AuthMessageSender>();
      services.AddTransient<AuthMessageSender>();
    }

    public SampleHostRepositoryProvider InitRepositoryProvider(IServiceProvider serviceProvider)
    {
      if (this.RepoProvider == null)
      {
        lock (LockObj)
        {
          if (this.RepoProvider == null)
          {
            var sqlLogger = this.loggerFactory.CreateLogger<SqlStringLogInterceptor>();

            this.HttpUserDataContext = new HttpUserDataContext<AspNetUser>(serviceProvider.GetService<IHttpContextAccessor>());
            var interceptors = new IInterceptor[]
                                 {
                                   new AuditingInterceptor(this.HttpUserDataContext),
                                   new SqlStringLogInterceptor(
                                     sqlString => sqlLogger.LogInformation($">>> SQL BEGIN: {sqlString}{Environment.NewLine}<<<SQL END" ))
                                 };
            this.RepoProvider = new SampleHostRepositoryProvider(this.connString, interceptors);
          }
        }
      }

      return this.RepoProvider;
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseAuthentication();
      app.UseResponseCompression();
      app.Use(async (context, next) =>
      { 
        var path = context.Request.Path.Value;
        this.logger.LogDebug($"[REQ-PATH]: {path}");

        // config angular app loading path.
        const string appName = "inventory-sync";
        if (path.StartsWith($"/apps/{appName}") && !Path.HasExtension(path))
        {
          this.logger.LogInformation($"Loading {appName} app.");
          context.Request.Path = $"/apps/{appName}/index.html";
        }

        await next();
      });

      app.Use((context, next) =>
        {
          if (context.Request.Headers["x-forwarded-proto"] == "https")
          {
            context.Request.Scheme = "https";
          }
          return next();
        });

      // app.UseFileServer();
      app.UseStaticFiles();
      ////app.UseHsts();
      ////app.UseHttpsRedirection();

      app.UseMvc();
    }

  }
}
