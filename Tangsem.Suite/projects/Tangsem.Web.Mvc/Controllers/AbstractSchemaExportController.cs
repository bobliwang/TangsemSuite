
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;
using System.Text;
using Tangsem.NHibernate;

namespace Tangsem.Web.Mvc.Controllers
{
  public abstract class AbstractSchemaExportController : Controller
  {
    public IConfiguration Config { get; }

    protected AbstractSchemaExportController(IConfiguration config)
    {
      this.Config = config;
    }

    public abstract string ConnectionStringName { get; }

    public abstract RepositoryProvider GetRepositoryProvider(string connStr);

    public abstract Assembly[] Assemblies { get; }

    protected IActionResult GetSqlSchemaInternal()
    {
      var connString = this.Config.GetConnectionString(this.ConnectionStringName);
      var sql = this.RebuildDatabaseFromModels(connString);
      return this.Ok(sql);
    }

    private string RebuildDatabaseFromModels(string connStr)
    {
      return this.GetRepositoryProvider(connStr)
                .ExportSchema(this.Assemblies);
    }
  }
}
