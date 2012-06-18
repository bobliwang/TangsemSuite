using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Tangsem.Generator.WebMvc3Demo.Common.Domain.Repositories;

namespace Tangsem.Generator.WebMvc3Demo.Controllers
{
  public abstract partial class RepositoryController : Controller
  {
    protected RepositoryController(IMyRepository repository)
    {
      this.Repository = repository;
    }

    public IMyRepository Repository { get; private set; }
  }
}