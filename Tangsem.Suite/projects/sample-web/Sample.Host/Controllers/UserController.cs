using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sample.Core.Domain.Entities;
using Sample.Core.Domain.Repositories;
using Sample.Host.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tangsem.Common.Extensions;
using Tangsem.NHibernate.Extenstions;

namespace Sample.Host.Controllers
{
  public class UserController : Controller
  {
    private readonly ISampleHostRepository repo;

    public UserController(ISampleHostRepository repo)
    {
      this.repo = repo;
    }

    [HttpGet("api/users")]
    public IActionResult GetUsers()
    {
      return this.Ok(this.repo.ApplicationUsers.Select(x => new { x.AspNetUser.UserName, x.Active, x.CreatedTime, AspNetUserId = x.AspNetUser.Id }).ToList());
    }

    [Transaction]
    [HttpGet("api/user/form")]
    public IActionResult GetUserForm()
    {
      var user = this.repo.AspNetUsers.FirstOrDefault();

      var form = this.repo.Forms.FirstOrDefault(x => x.AspNetUser.Id == user.Id);
      if (form == null)
      {
        form = new Form { AspNetUser = user };

        this.repo.SaveForm(form);
      }

      form.Title = $"My Title {DateTime.Now}";
      form.FormJson = JsonConvert.SerializeObject(new { form.Title, user.UserName }).ToCompressedBytes();

      if (!this.repo.FormSigners.Any(x => x.Active && x.Form.Id == form.Id))
      {
        var signer = new Signer
        {
          FirstName = "SF1",
          LastName = "SL1",
          Email = "SE",
        };
        this.repo.SaveSigner(signer);

        var formSigner = new FormSigner { Form = form, Signer = signer };
        this.repo.SaveFormSigner(formSigner);
      }

      this.repo.Commit();

      return this.Ok(new {
        form.Id,
        form.Title,
        formJson = form.FormJson.ToDecompressedString(),
        formSignerCount = this.repo.FormSigners.Count(x => x.Form.Id == form.Id),        
        RowVersion = form.RowVersion.ToRowVersionString() });
    }
  }
}
