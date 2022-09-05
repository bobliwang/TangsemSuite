using System.Text.Encodings.Web;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

using Tangsem.Identity.Domain.Entities;

namespace Sample.Host.Areas.Identity.Pages
{
  public static class IdentityExtensions
  {
    public static async Task SendConfirmationEmail<TUser>(this IEmailSender emailSender,
                                                    string emailAddress,
                                                    TUser user,
                                                    UserManager<TUser> userManager,
                                                    IUrlHelper urlHelper,
                                                    string scheme) where TUser: AspNetUser
    {
      if (!user.EmailConfirmed)
      {
        var code = await userManager.GenerateEmailConfirmationTokenAsync(user);

        var callbackUrl = urlHelper.Page(
          "/Account/ConfirmEmail",
          pageHandler: null,
          values: new { userId = user.Id, code = code },
          protocol: scheme);

        await emailSender.SendEmailAsync(emailAddress, "Confirm your email",
          $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
      }
    }
  }
}