using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

using AutoMapper;

using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities;
using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities.DTOs;
using Tangsem.Generator.WebMvc3Demo.Common.Domain.Repositories;
using Tangsem.Generator.WebMvc3Demo.ViewModels;

namespace Tangsem.Generator.WebMvc3Demo.Controllers
{
  public partial class StateController : RepositoryController
  {
    public StateController(IMyRepository repository)
      : base(repository)
    {
    }


    public virtual ActionResult ListStates()
    {
      var qry = new StateQry();
      var states = qry.CreateQry(this.Repository.States).ToList();

      var vm = new StateViewModel { StateQry = qry, States = states };

      return this.View(vm);
    }

    public virtual ActionResult Add()
    {
      return this.View(new StateDTO());
    }

    [HttpPost]
    public virtual ActionResult Add(StateDTO stateDTO)
    {
      var state = Mapper.Map<StateDTO, State>(stateDTO);

      this.Repository.Save(state);

      return this.RedirectToAction(MVC.State.ListStates());
    }

    public JsonResult QryStates(string stateQryStr)
    {
      var js = new JavaScriptSerializer();
      var stateQry = js.Deserialize<StateQry>(stateQryStr);

      var qry = stateQry.CreateQry(this.Repository.States);

      return this.Json(new { States =  qry.ToList() });
    }
  }
}