using System.Configuration;

using AutoMapper;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

using NHibernate;
using NHibernate.Dialect;

using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities;
using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities.DTOs;
using Tangsem.Generator.WebMvc3Demo.Common.Domain.Repositories;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Tangsem.Generator.WebMvc3Demo.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Tangsem.Generator.WebMvc3Demo.App_Start.NinjectWebCommon), "Stop")]


namespace Tangsem.Generator.WebMvc3Demo.App_Start
{
  using System;
  using System.Web;

  using Microsoft.Web.Infrastructure.DynamicModuleHelper;

  using Ninject;
  using Ninject.Web.Common;

  public static class NinjectWebCommon
  {
    private static readonly Bootstrapper bootstrapper = new Bootstrapper();

    private static ISessionFactory sessionFactory;

    private static ISessionFactory SessionFactory
    {
      get
      {
        if (sessionFactory == null)
        {
          var connString = ConfigurationManager.ConnectionStrings["TangsemGeneratorNHibernateTest"].ConnectionString;

          sessionFactory = Fluently.Configure()
                                        .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connString).ShowSql().MaxFetchDepth(3).Dialect<MsSql2008Dialect>())
                                        .Mappings(m =>
                                          m.FluentMappings.AddFromAssemblyOf<Country>())
                                        .BuildSessionFactory();
        }

        return sessionFactory;
      }
    }

    /// <summary>
    /// Starts the application
    /// </summary>
    public static void Start()
    {
      DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
      DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
      bootstrapper.Initialize(CreateKernel);
    }

    /// <summary>
    /// Stops the application.
    /// </summary>
    public static void Stop()
    {
      bootstrapper.ShutDown();
    }

    /// <summary>
    /// Creates the kernel that will manage your application.
    /// </summary>
    /// <returns>The created kernel.</returns>
    private static IKernel CreateKernel()
    {
      var kernel = new StandardKernel();
      kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
      kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

      RegisterServices(kernel);
      return kernel;
    }

    /// <summary>
    /// Load your modules or register your services here!
    /// </summary>
    /// <param name="kernel">The kernel.</param>
    private static void RegisterServices(IKernel kernel)
    {
      kernel.Bind<IMyRepository>()
            .To<MyRepository>()
            .InRequestScope()
            .WithPropertyValue("CurrentSession", ctx => SessionFactory.OpenSession())
            .OnActivation<MyRepository>((ctx, repo) => repo.BeginTransaction())
            .OnDeactivation<MyRepository>((ctx, repo) => repo.Close());


      InitAutoMapper(kernel);
    }

    private static void Close(this IMyRepository repo)
    {
      try
      {
        repo.Commit();
      }
      catch
      {
        try
        {
          repo.Rollback();
        }
        catch
        {
        }
      }
      finally
      {
        try
        {
          repo.Dispose();
        }
        catch
        {
        }
      }
    }

    private static void InitAutoMapper(IKernel kernel)
    {
      Mapper.CreateMap<CountryDTO, Country>();

      Mapper.CreateMap<StateDTO, State>()
        .ForMember(s => s.Country,
                   c => c.MapFrom(s => s.CountryId.HasValue ? kernel.Get<IMyRepository>().LookupCountryById(s.CountryId.Value) : null));
    }
  }
}
