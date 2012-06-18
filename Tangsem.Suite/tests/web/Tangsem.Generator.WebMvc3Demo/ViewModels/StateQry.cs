using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities;
using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities.DTOs;

namespace Tangsem.Generator.WebMvc3Demo.ViewModels
{
  public class StateQry
  {
    public virtual int? Id { get; set; }

    public virtual string Name { get; set; }

    public virtual int? CountryId { get; set; }

    public StateQry()
    {
      this.Comparator_Id = (int)Comparators.Eq;
      this.Comparator_Name = (int)Comparators.Like;
      this.Comparator_CountryId = (int)Comparators.Eq;
    }

    public int Comparator_Id { get; set; }

    public int Comparator_Name { get; set; }

    public int Comparator_CountryId { get; set; }

    public List<SelectListItem> CompareOperators
    {
      get
      {
        return Enum.GetValues(typeof(Comparators)).Cast<Comparators>().Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
      }
    }

    public IQueryable<State> CreateQry(IQueryable<State> states)
    {
      var qry = states;

      if (this.Id.HasValue)
      {
        if (this.Comparator_Id == (int)Comparators.Eq)
        {
          qry = qry.Where(x => x.Id == this.Id);
        }
      }

      if (this.Name != null)
      {
        if (this.Comparator_Name == (int)Comparators.Like)
        {
          qry = qry.Where(x => x.Name == this.Name);
        }
      }

      return qry;
    }
  }
}