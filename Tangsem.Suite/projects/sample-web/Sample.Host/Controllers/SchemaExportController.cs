
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sample.Core.Domain.Entities;
using Sample.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tangsem.Identity.Domain.Entities;
using Tangsem.NHibernate;
using Tangsem.Web.Mvc.Controllers;

namespace Sample.Host.Controllers
{
  public class SchemaExportController : AbstractSchemaExportController
  {
    public SchemaExportController(IConfiguration config) : base(config)
    {
    }

    public override string ConnectionStringName => Constants.ConnectionStringName;

    public override Assembly[] Assemblies => new[] { typeof(AspNetUser).Assembly, typeof(ShopeeShop).Assembly };

    public override RepositoryProvider GetRepositoryProvider(string connStr)
    {
      return new SampleHostRepositoryProvider(connStr);
    }

    [HttpGet("api/db/schema")]
    public IActionResult GetSqlSchema()
    { 
      return this.GetSqlSchemaInternal();
    }
  }
}
