using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities;

namespace Tangsem.Generator.WebMvc3Demo.ViewModels
{
  public class StateViewModel
  {
    public StateViewModel()
    {
      this.StateQry = new StateQry();
    }

    public StateQry StateQry { get; set; }

    public List<State> States { get; set; }
  }
}