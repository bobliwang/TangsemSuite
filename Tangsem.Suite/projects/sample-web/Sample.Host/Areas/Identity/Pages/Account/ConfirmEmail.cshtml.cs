using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Tangsem.Identity.Domain.Entities;

namespace Sample.Host.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<AspNetUser> _userManager;

        public ConfirmEmailModel(UserManager<AspNetUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return this.RedirectToPage("/Index");
            }

            var user = await this._userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{userId}'.");
            }

            var result = await this._userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Error confirming email for user with ID '{userId}':");
            }

            return this.Page();
        }
    }
}
