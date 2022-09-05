using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Tangsem.Common.Extensions.Linq;
using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities;
using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities.DTOs;

namespace Tangsem.Generator.WebMvc3Demo.ViewModels
{
  public class CategoryViewModel
  {
    public CategoryViewModel()
    {
      this.SearchParams = new CategoryDTO();
    }

    public IQueryable<Category> GetQueryable(IQueryable<Category> qry)
    {
      if (!string.IsNullOrWhiteSpace(this.SearchParams.Name))
      {
        qry = qry.Where(x => x.Name.Contains(this.SearchParams.Name));
      }

      if (!string.IsNullOrWhiteSpace(this.SearchParams.ShortDescription))
      {
        qry = qry.Where(x => x.ShortDescription.Contains(this.SearchParams.ShortDescription));
      }

      return qry;
    }

    public IQueryable<Category> GetQueryable(string qtype, string q, IQueryable<Category> qry)
    {
      if (!string.IsNullOrEmpty(qtype) && !string.IsNullOrEmpty(q))
      {
        qry = qry.Where(qtype + ".Contains(@0)", q);
      }

      return qry;
    }

    public IQueryable<Category> Categories { get; set; }


    public CategoryDTO SearchParams { get; set; }
  }
}