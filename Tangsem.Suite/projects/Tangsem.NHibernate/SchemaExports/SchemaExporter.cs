using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;

namespace Tangsem.NHibernate.SchemaExports
{
  public class SchemaExporter
  {
    public async Task<string> ExportSqlSchema<TThisConfiguration>(
      PersistenceConfiguration<TThisConfiguration> persistCfg,
      IEnumerable<Assembly> assemblies,
      Action<Configuration> cfgHandler = null,
      Func<string, string> sqlConverter = null
    ) where TThisConfiguration : PersistenceConfiguration<TThisConfiguration, ConnectionStringBuilder>
    {
      var config = Fluently
        .Configure(new Configuration())
        .Mappings(m =>
        {
          assemblies?.ToList().ForEach(assembly => m.FluentMappings.AddFromAssembly(assembly));
        })
        .Database(persistCfg)
        .BuildConfiguration();

      cfgHandler?.Invoke(config);
      
      var schemaExport = new SchemaExport(config);
      
      var sb = new StringBuilder();
      await schemaExport.ExecuteAsync(sql =>
      {
        sql = (sqlConverter != null) ? sqlConverter(sql) : sql;
        sb.AppendLine(sql);
      }, false, false);

      return sb.ToString();
    }
  }
}