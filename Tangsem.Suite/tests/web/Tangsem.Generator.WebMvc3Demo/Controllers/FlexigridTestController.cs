using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Tangsem.Common.Entities;
using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities.DTOs;
using Tangsem.Generator.WebMvc3Demo.Common.Domain.Repositories;
using Tangsem.Generator.WebMvc3Demo.ViewModels;

namespace Tangsem.Generator.WebMvc3Demo.Controllers
{
  public partial class FlexigridTestController : RepositoryController
  {
    public FlexigridTestController(IMyRepository repository)
      : base(repository)
    {
    }

    [HttpGet]
    public virtual ActionResult SearchCategories(string qtype, string q)
    {
      var vm = new CategoryViewModel();
      var qry = vm.GetQueryable(qtype, q, this.Repository.Categories).ActiveOnly();
      vm.Categories = qry;
      Debug.WriteLine("#####" + this.Request.RawUrl);
      if (this.Request.IsAjaxRequest())
      {
        return this.PartialView(MVC.FlexigridTest.Views._Flexigrid, vm.Categories);
      }

      return this.View(MVC.FlexigridTest.Views.Index, vm);
    }

    [HttpPost]
    public virtual ActionResult DeleteCategory(int id)
    {
      var deletedCategory = this.Repository.DeleteCategoryById(id);

      return this.Json(new { deleted = (deletedCategory != null) });
    }

    public virtual JsonResult Autocomplete(string term)
    {
      var filteredItems = this.Repository.Categories.Where(cat => cat.Name.Contains(term)).Select(cat => new { label = cat.Name, value = cat.Id }).ToList();
      return Json(filteredItems, JsonRequestBehavior.AllowGet);
    }
  }
}