using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tangsem.Generator.WebMvc3Demo.Controllers
{
  public partial class HomeController : Controller
  {
    public HomeController()
    {
    }

    public virtual ActionResult Index()
    {
      ViewBag.Message = "Welcome to ASP.NET MVC! ";

      return View();
    }

    public virtual ActionResult About()
    {
      return View();
    }
  }
}
