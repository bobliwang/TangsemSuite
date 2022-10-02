using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

using Tangsem.Data.Domain;
using Tangsem.NHibernate.Dialects;
using Tangsem.NHibernate.Extensions;
using Tangsem.NHibernate.Interceptors;

namespace Tangsem.NHibernate
{
  /// <summary>
  /// The abstract RepositoryProvider class.
  /// </summary>
  public abstract class RepositoryProvider
  {
    private ISessionFactory _sessionFactory;

    private readonly IList<IInterceptor> _interceptors;

    private readonly IList<Type> _sampleEntities;

    public int MaxFetchDepth { get; set; } = 3;

    private static readonly object LockObj = new object();

    protected RepositoryProvider(string connectionString, Type sampleEntity, params IInterceptor[] interceptors)
    {
      this.ConnectionString = connectionString;
      this._sampleEntities = new [] { sampleEntity };
      this._interceptors = (interceptors ?? new IInterceptor[0]).ToList();
    }

    protected RepositoryProvider(string connectionString, Type[] sampleEntities, params IInterceptor[] interceptors)
    {
      this.ConnectionString = connectionString;
      this._sampleEntities = sampleEntities;
      this._interceptors = (interceptors ?? new IInterceptor[0]).ToList();
    }

    public string ConnectionString { get; private set; }

    /// <summary>
    /// The abstract method creating a new repository with ISession passed in.
    /// </summary>
    public abstract IRepository CreateRepositoryFromSession(ISession session);

    public ISessionFactory SessionFactory
    {
      get
      {
        if (this._sessionFactory == null)
        {
          lock (LockObj)
          {
            if (this._sessionFactory == null)
            {
              this._sessionFactory = this.CreateSessionFactory(this._sampleEntities.Select(x => x.Assembly).Distinct().ToArray());
            }
          }
        }

        return this._sessionFactory;
      }
    }

    public ISessionBuilder GetSessionBuilder()
    {
      return this.SessionFactory
                 .WithOptions()
                 .Interceptor(new CompositeInterceptors(this._interceptors.ToArray()));
    }

    public IRepository CreateRepository()
    {
      var session = this.GetSessionBuilder().OpenSession();
      return this.CreateRepositoryFromSession(session);
    }

    /// <summary>
    /// Creates a FluentConfiguration with listed assemblies
    /// </summary>
    public virtual FluentConfiguration ConfigWithAssemblies(params Assembly[] assemblies)
    { 
      var config = new Configuration().LinqToHqlGeneratorsRegistry<ExtendedLinqToHqlGeneratorsRegistry>();

      var msSqlConfig = MsSqlConfiguration.MsSql2008.ConnectionString(this.ConnectionString).ShowSql()
        .MaxFetchDepth(this.MaxFetchDepth) // instead we can use include<> to specify which linked properties to fetch.
        .Dialect<MsSql2012DialectExt>();

      return Fluently.Configure(config).Database(msSqlConfig).Mappings(
        m =>
          {
            assemblies?.ToList().ForEach(assembly => m.FluentMappings.AddFromAssembly(assembly));
          });
    }

    /// <summary>
    /// Creates a ISessionFactory instance.
    /// </summary>
    public virtual ISessionFactory CreateSessionFactory(Assembly[] assemblies)
    {
      return this.ConfigWithAssemblies(assemblies).BuildSessionFactory();
    }
  }

  public static class RepositoryProviderExtensions
  {
    public static T MaxFetchDepth<T>(this T repoProvider, int maxDepth) where T: RepositoryProvider
    {
      repoProvider.MaxFetchDepth = maxDepth;

      return repoProvider;
    }

    public static string ExportSchema<T>(this T repoProvider, Assembly[] assemblies) where T : RepositoryProvider
    {
      if (assemblies.Any())
      {
        repoProvider
          .ConfigWithAssemblies(assemblies);
      }

      var config = repoProvider
                    .ConfigWithAssemblies(assemblies)
                    .BuildConfiguration();

      var schemaExport = new SchemaExport(config);
      var sb = new StringBuilder();
      schemaExport.Execute(sql => sb.AppendLine(sql), false, false);

      return sb.ToString();
    }
  }
}