using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

    /// <summary>
    /// Property Id mapping to State.Id
    /// </summary>
    public virtual int Id { get; set; }

    /// <summary>
    /// Property Name mapping to State.Name
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// Property CountryId mapping to State.CountryId
    /// </summary>
    public virtual int? CountryId { get; set; }

    /// <summary>
    /// Property CreatedById mapping to State.CreatedById
    /// </summary>
    public virtual int? CreatedById { get; set; }
  }
}