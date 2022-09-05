using System;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json.Linq;

namespace Sample.Host
{
  public class QuickBookAuthSetup
  {
    public AuthenticationBuilder QuickBookAuth(IServiceCollection services, IConfiguration configuration)
    {
      return services.AddAuthentication(sharedOptions => { }).AddCookie(o =>
      {
        o.Events = new CookieAuthenticationEvents
        {
          OnValidatePrincipal = context =>
          {
            if (context.Properties.Items.ContainsKey(".Token.expires_at"))
            {
              var expire = DateTime.Parse(context.Properties.Items[".Token.expires_at"]);
              if (expire > DateTime.Now) //TODO:change to check expires in next 5 mintues.
              {
                System.Diagnostics.Debug.WriteLine($"Access token has expired, user: {context.HttpContext.User.Identity.Name}");

                //TODO: send refresh token to ASOS. Update tokens in context.Properties.Items
                //context.Properties.Items["Token.access_token"] = newToken;
                context.ShouldRenew = true;
              }
            }
            return Task.FromResult(0);
          }
        };
      })
      .AddOpenIdConnect(Constants.LoginProviders.QuickBook, Constants.LoginProviders.QuickBook, opts => { this.ConfigOpenIdOptions(configuration, opts); });
    }

    private void ConfigOpenIdOptions(IConfiguration configuration, OpenIdConnectOptions opts)
    {
      opts.Authority = "QuickBooks";
      opts.UseTokenLifetime = true;
      opts.ClientId = configuration["intuit:oidc:clientid"];
      opts.ClientSecret = configuration["intuit:oidc:clientsecret"];
      opts.ResponseType = OpenIdConnectResponseType.Code;
      opts.MetadataAddress = "https://developer.api.intuit.com/.well-known/openid_sandbox_configuration/";
      opts.ProtocolValidator.RequireNonce = false;
      opts.SaveTokens = true;
      opts.GetClaimsFromUserInfoEndpoint = true;
      opts.ClaimActions.MapUniqueJsonKey("given_name", "givenName");
      opts.ClaimActions.MapUniqueJsonKey("family_name", "familyName");

      //should work but because the middleware checks for claims w/ the same value and the claim for "email" already exists it doesn't get mapped.
      opts.ClaimActions.MapUniqueJsonKey(ClaimTypes.Email, "email");
      opts.Scope.Add("phone");
      opts.Scope.Add("email");
      opts.Scope.Add("address");
      opts.Scope.Add("com.intuit.quickbooks.accounting");
      opts.Events = new OpenIdConnectEvents
      {
        OnAuthenticationFailed = context => this.OnAuthenticationFailed(context),
        OnUserInformationReceived = context => this.OnUserInformationReceived(context),
        OnAuthorizationCodeReceived = context => this.OnAuthorizationCodeReceived(context)
      };
    }

    private Task OnAuthorizationCodeReceived(AuthorizationCodeReceivedContext context)
    {
      return Task.CompletedTask;

      //var request = context.HttpContext.Request;
      ////  //var currentUri = UriHelper.BuildAbsolute(request.Scheme, request.Host, request.PathBase, request.Path);
      ////  //var credential = new ClientCredential(ClientId, ClientSecret);
      ////  //var authContext = new AuthenticationContext(Authority, AuthPropertiesTokenCache.ForCodeRedemption(context.Properties));

      ////  //var result = await authContext.AcquireTokenByAuthorizationCodeAsync(
      ////  //    context.ProtocolMessage.Code, new Uri(currentUri), credential, Resource);

      ////  //context.HandleCodeRedemption(result.AccessToken, result.IdToken);

      ////  return Task.CompletedTask; 
    }

    private Task OnAuthenticationFailed(AuthenticationFailedContext context)
    {
      context.HandleResponse();

      context.Response.StatusCode = 500;
      context.Response.ContentType = "text/plain";

      return context.Response.WriteAsync(context.Exception.ToString());
    }

    private Task OnUserInformationReceived(UserInformationReceivedContext context)
    {
      var identity = (ClaimsIdentity)context.Principal.Identity;
      var fullName = GetFullName(context);
      if (fullName.Length > 0)
      {
        identity.AddClaim(new Claim("name", fullName, "Intuit"));
      }

      var email = GetEmail(context);
      if (email.Length > 0)
      {
        identity.AddClaim(new Claim(ClaimTypes.Email, email, null, "Intuit"));
      }

      var token = context.Properties.GetTokenValue("access_token");
      identity.AddClaim(new Claim("access_token", token));
      token = context.Properties.GetTokenValue("refresh_token");
      identity.AddClaim(new Claim("refresh_token", token));

      context.Principal.AddIdentity(identity);

      context.Properties.StoreTokens(context.Properties.GetTokens());

      return Task.CompletedTask;
    }

    private static string GetEmail(UserInformationReceivedContext context)
    {
      string email = "";

      if (context.User.TryGetValue("email", out var emailToken))
      {
        email = emailToken.Value<string>();
      }
      return email;
    }

    private static string GetFullName(UserInformationReceivedContext context)
    {
      string fullName = "";

      if (context.User.TryGetValue("givenName", out var givenName))
      {
        fullName = givenName.Value<string>() + " ";
      }
      if (context.User.TryGetValue("familyName", out var familyName))
      {
        fullName += familyName.Value<string>();
      }

      return fullName;
    }
  }
}