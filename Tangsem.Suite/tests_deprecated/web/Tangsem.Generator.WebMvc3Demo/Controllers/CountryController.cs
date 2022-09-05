using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AutoMapper;

using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities;
using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities.DTOs;
using Tangsem.Generator.WebMvc3Demo.Common.Domain.Repositories;

namespace Tangsem.Generator.WebMvc3Demo.Controllers
{
  public partial class CountryController : RepositoryController
  {
    public CountryController(IMyRepository repository)
      : base(repository)
    {
    }

    public virtual ActionResult ListCountries()
    {
      var countries = this.Repository.Countries.ToList();

      return this.View(countries);
    }

    public virtual ActionResult Add()
    {
      return this.View(new CountryDTO());
    }

    [HttpPost]
    public virtual ActionResult Add(CountryDTO countryDTO)
    {
      var country = Mapper.Map<CountryDTO, Country>(countryDTO);

      this.Repository.Save(country);

      return this.RedirectToAction(MVC.Country.ListCountries());
    }
  }
}