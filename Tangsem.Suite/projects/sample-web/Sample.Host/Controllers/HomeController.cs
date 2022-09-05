using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;

using Sample.Core.Domain.Repositories;
using Sample.Host.Filters;
using Sample.Host.Services;

using Tangsem.Identity;
using Tangsem.Identity.Domain.Entities;
using Tangsem.Identity.Domain.Repositories.NHibernate;

namespace Sample.Host.Controllers
{
  public class HomeController : ControllerBase
  {
    public HomeController()
    {
    }

    // GET api/values
    [HttpGet("")]
    public IActionResult Get()
    {
      return this.File("~/apps/inventory-sync/index.html", "text/html");
    }
  }
}
