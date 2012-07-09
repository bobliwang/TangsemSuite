using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Tangsem.Common.Entities;
using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities.DTOs;
using Tangsem.Generator.WebMvc3Demo.Common.Domain.Repositories;
using Tangsem.Generator.WebMvc3Demo.ViewModels;

namespace Tangsem.Generator.WebMvc3Demo.Controllers
{
  public partial class CategoryController : RepositoryController
  {
    public CategoryController(IMyRepository repository)
      : base(repository)
    {
    }

    [HttpGet]
    public virtual ActionResult ListCategories(CategoryViewModel vm)
    {
      var qry = vm.GetQueryable(this.Repository.Categories).ActiveOnly();
      ////vm.Categories = qry.ToList();
      vm.Categories = qry;

      if (this.Request.IsAjaxRequest())
      {
        return this.PartialView(MVC.Category.Views.CatsGrid, vm.Categories);
      }

      return this.View(vm);
    }
  }
}