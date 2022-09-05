using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;

using Sample.Core.Domain.Repositories;
using Sample.Host.Filters;
using Sample.Host.Services;

using Tangsem.Identity;
using Tangsem.Identity.Domain.Entities;
using Tangsem.Identity.Domain.Repositories.NHibernate;

namespace Sample.Host.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    private readonly UserManager<AspNetUser> userManager;

    private readonly ISampleHostRepository identityRepository;

    private readonly IUserStore<AspNetUser> userStore;

    private readonly IQuickBooksService quickbookService;
    
    private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;

    private readonly AuthMessageSender messageSender;

    public ValuesController(ISampleHostRepository identityRepository, UserManager<AspNetUser> userManager, IUserStore<AspNetUser> userStore, IQuickBooksService quickbookService, IConfiguration configuration, AuthMessageSender messageSender)
    {
      this.identityRepository = identityRepository;
      this.userManager = userManager;
      this.userStore = userStore;
      this.quickbookService = quickbookService;
      this._configuration = configuration;
      this.messageSender = messageSender;
    }

    [HttpGet("ping/quickbook")]
    [Authorize]
    public async Task<IActionResult> PingQuickBook()
    {
      var result = await this.quickbookService.GetAsync("");

      return this.Ok(result);
    }

    // GET api/values
    [HttpGet]
    public IActionResult Get()
    {
      var html = string.Join("<p>", new[]
                                   {
                                     "/api/values/TestTwilio",
                                     "/api/values/ManagerRoleOnly",
                                     "/api/values/ManagerRoleUpdateUser2Only",
                                     "/api/values/SuperAdminOnly",
                                     "/api/values/AnyManagers",
                                     "/api/values/Delete",
                                     "/api/values/AnySignedInUser",
                                     "/api/values/ping/quickbook",
                                     "/Account/SignIn",
                                     "/Account/SignOut",
                                     "/apps/inventory-sync",
                                     this._configuration["shopeeAuthUrl"],
                                   }.Select(x => $"<a href='{x}'>{x}</a>"));

      return this.Content(html, "text/html");
    }

    [HttpGet("TestTwilio")]
    public async Task<string> TestTwilio(string phoneNumber, string msg)
    {
      await this.messageSender.SendSmsAsync(phoneNumber, msg);

      return "Sent";
    }

    [HttpGet("GetCurrentIdentityInfo")]
    public async Task<string> GetCurrentIdentityInfo()
    {
      var currentIdentity = this.HttpContext.User.Identity;
      var aspNetUser = await this.userManager.GetUserAsync(this.HttpContext.User);
      
      var info = new
                   {
                     currentIdentity.AuthenticationType,
                     currentIdentity.Name,
                     claims = await this.userManager.GetClaimsAsync(aspNetUser)
      };

      return JsonConvert.SerializeObject(info);
    }
    
    [HttpGet("ManagerRoleOnly")]
    [Authorize(Roles = "Manager")]
    public async Task<ActionResult<string>> ManagerRoleOnly()
    {
      return "ManagerRoleOnlyResult - " + await this.GetCurrentIdentityInfo();
    }

    [HttpGet("ManagerRoleUpdateUser2Only")]
    [Authorize(Roles = "Manager")]
    [Transaction]
    public ActionResult<string> ManagerRoleUpdateUser2Only()
    {

      var user = this.identityRepository.LookupAspNetUserById(2);
      user.PhoneNumber = "12345";

      var user2 = this.identityRepository.LookupAspNetUserById(2);

      return this.Ok("Last updated by: " + user2.ModifiedById);
    }

    [HttpGet("SuperAdminOnly")]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<ActionResult<string>> SuperAdminOnlyResult()
    {
      return "SuperAdminOnlyResult - " + await this.GetCurrentIdentityInfo();
    }

    [HttpGet("AnyManagers")]
    [Authorize(Roles = "SuperAdmin, Manager")]
    public async Task<ActionResult<string>> AnyManagers()
    {
      return "AnyManagersResult - " + await this.GetCurrentIdentityInfo();
    }

    [HttpGet("Delete")]
    [Authorize(Policy = "DeletePermissionPolicy")]
    public async Task<IActionResult> Delete()
    {
      return this.Ok("DeletePermissionPolicy - " + await this.GetCurrentIdentityInfo());
    }

    [HttpGet("AnySignedInUser")]
    [Authorize]
    public IActionResult AnySignedInUser()
    {
      return this.Ok("OK!");
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
