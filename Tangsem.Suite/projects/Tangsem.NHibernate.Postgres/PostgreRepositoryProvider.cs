using System;
using System.Linq;
using System.Reflection;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;

using Tangsem.Data.Domain;
using Tangsem.NHibernate.Dialects;
using Tangsem.NHibernate.Extensions;
using Tangsem.NHibernate.Postgres;

namespace Tangsem.NHibernate.Postgres
{
  public abstract class PostgreRepositoryProvider : RepositoryProvider
  {
    protected PostgreRepositoryProvider(string connectionString, Type sampleEntity, IInterceptor[] interceptors)
      : base(connectionString, sampleEntity, interceptors)
    {
    }

    public override FluentConfiguration ConfigWithAssemblies(params Assembly[] assemblies)
    {
      var config = new Configuration()
        .LinqToHqlGeneratorsRegistry<ExtendedLinqToHqlGeneratorsRegistry>()
        .SetNamingStrategy(new PostgreNamingStrategy());

      var postgreSql = PostgreSQLConfiguration.PostgreSQL82
        .ConnectionString(this.ConnectionString)
        .ShowSql()
        .MaxFetchDepth(this.MaxFetchDepth) // instead we can use include<> to specify which linked properties to fetch.
        .Dialect<PostgreSQL83Dialect>();

      return Fluently.Configure(config)
        .Database(postgreSql)
        .Mappings(
        m =>
          {
            assemblies.ToList().ForEach(assembly => m.FluentMappings.AddFromAssembly(assembly));
          });
    }
  }
}
