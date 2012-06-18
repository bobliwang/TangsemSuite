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

		public virtual ActionResult ListStates(StateViewModel vm)
		{
			var states = vm.StateQry.CreateQry(this.Repository.States).ToList();

			vm.States = states;

			vm.StateQry.CountryOptions = this.Repository
											.Countries
											.ToList()
											.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
			return this.View(vm);
		}

		public virtual ActionResult SearchStates(string qry)
		{
			var js = new JavaScriptSerializer();
			var statesQry = js.Deserialize<StateQry>(qry);
			var states = statesQry.CreateQry(this.Repository.States).ToList();

			return this.Json(new { States = states }, JsonRequestBehavior.AllowGet);
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

		public virtual JsonResult QryStates(string stateQryStr)
		{
			var js = new JavaScriptSerializer();
			var stateQry = js.Deserialize<StateQry>(stateQryStr);

			var qry = stateQry.CreateQry(this.Repository.States);

			return this.Json(new { States = qry.ToList() });
		}
	}
}