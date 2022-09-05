using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Tangsem.Identity;
using Tangsem.Identity.Domain.Entities;

namespace Sample.Host
{
  public partial class Startup
  {
    private void ConfigIdentityOptions(IdentityOptions options)
    {
      options.SignIn.RequireConfirmedEmail = true;

      // Password settings.
      options.Password.RequireDigit = true;
      options.Password.RequireLowercase = true;
      options.Password.RequireNonAlphanumeric = true;
      options.Password.RequireUppercase = true;
      options.Password.RequiredLength = 6;
      options.Password.RequiredUniqueChars = 1;

      // Lockout settings.
      options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
      options.Lockout.MaxFailedAccessAttempts = 5;
      options.Lockout.AllowedForNewUsers = true;

      // User settings.
      options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
      options.User.RequireUniqueEmail = false;
    }

    private void SetupIdentityAndAuth(IServiceCollection services)
    {
      services.Configure<CookiePolicyOptions>(
              options =>
              {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
              });

      var builder = services.AddIdentity<AspNetUser, AspNetRole>().AddHibernateStores().AddDefaultTokenProviders();
      builder.AddDefaultUI();
      services.ConfigureApplicationCookie(ops =>
      {
        ops.LoginPath = new PathString("/LoginPage");
        ops.AccessDeniedPath = new PathString("/AccessDeniedPage");

        ops.Events = new CookieAuthenticationEvents
        {
          OnRedirectToAccessDenied = async ctx =>
          {
            // this would override 'ops.AccessDeniedPath = new PathString("/AccessDeniedPage");', by returning 403 status code only.
            ctx.Response.StatusCode = await Task.FromResult((int)HttpStatusCode.Forbidden);
          }
        };
      });

      services.Configure<IdentityOptions>(options => this.ConfigIdentityOptions(options));
      this.SetupQuickBookAuth(services);

      // FOR TEST: policy based authorization.
      services.AddAuthorization(options =>
      {
        options.AddPolicy("DeletePermissionPolicy", policy => policy.RequireClaim("Permission", "DeletePermission"));
      });
    }

    private void SetupQuickBookAuth(IServiceCollection services)
    {
      new QuickBookAuthSetup()
              .QuickBookAuth(services, this.configuration)
              .FacebookAuth(this.configuration)
              .GoogleAuth(this.configuration)
              .AddOAuth("Ebay", "Ebay",
                options =>
                {
                  options.ClientId = this.configuration["auth.ebay.client_id"];
                  options.ClientSecret = this.configuration["auth.ebay.client_secret"];
                  options.CallbackPath = this.configuration["auth.ebay.callback_path"];

                  options.AuthorizationEndpoint = this.configuration["auth.ebay.auth_endpoint"];
                  options.TokenEndpoint = this.configuration["auth.ebay.token_endpoint"];

                  options.SaveTokens = true;
                  var scopesText = this.configuration["auth.ebay.scopes"];
                  var scopes = scopesText.Split(' ');

                  foreach (var scope in scopes)
                  {
                    options.Scope.Add(scope);
                  }

                  options.Events = new OAuthEvents
                  {
                    OnCreatingTicket = async context =>
                    {
                      var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                      request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                      request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);

                      var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead,
                                                        context.HttpContext.RequestAborted);
                      response.EnsureSuccessStatusCode();

                      var user = JObject.Parse(await response.Content.ReadAsStringAsync());

                      context.RunClaimActions(user);
                    }
                  };
                });
    }
  }
}
