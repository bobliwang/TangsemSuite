using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities;
using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities.DTOs;

namespace Tangsem.Generator.WebMvc3Demo.ViewModels
{
  public class CategoryViewModel
  {
    public CategoryViewModel()
    {
      this.SearchParams = new CategoryDTO();
      this.Categories = new List<Category>();
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

    public List<Category> Categories { get; set; }

    public CategoryDTO SearchParams { get; set; }
  }
}