using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

using Tangsem.Identity;
using Tangsem.Identity.Domain.Entities;
using Tangsem.Identity.Domain.Repositories.NHibernate;
using Microsoft.AspNetCore.Identity;

using Sample.Core.Domain.Repositories;

namespace Sample.Host.Controllers
{
  public class AccountController : ControllerBase
  {
    public ISampleHostRepository repo;

    private readonly SignInManager<AspNetUser> signInManager;

    private readonly UserManager<AspNetUser> userManager;

    public AccountController(
      ISampleHostRepository repo,
      SignInManager<AspNetUser> signInManager,
      UserManager<AspNetUser> userManager) {

      this.repo = repo;
      this.signInManager = signInManager;
      this.userManager = userManager;
    }
    [HttpGet("AccessDeniedPage")]
    public async Task<string> AccessDenied()
    {
      return await Task.FromResult("AccessDeniedPage");
    }

    [HttpGet("LoginPage")]
    public async Task<string> Login()
    {
      return await Task.FromResult("LoginPage");
    }

    [HttpGet("Account/SignIn")]
    public async Task<IActionResult> SignIn()
    {
      var signInResult = await this.signInManager.PasswordSignInAsync("bobliwang@gmail.com", "Abc123!", true, true);
      
      return this.Ok(new { signInResult.Succeeded } );
    }


    [HttpGet("Account/SignOut")]
    public async Task<IActionResult> SignOut()
    {
      await this.signInManager.SignOutAsync();

      return this.Ok("SignedOut");
    }
  }
}
