using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sample.Host
{
  public static class FacebookAuthentication
  {
    public static AuthenticationBuilder FacebookAuth(this AuthenticationBuilder authBuilder, IConfiguration configuration)
    {
      // it doesn't work with ngrok some how.

      return authBuilder
         .AddFacebook(options =>
          {
            options.AppId = configuration["auth:facebook:appid"];
            options.AppSecret = configuration["auth:facebook:appsecret"];
            options.SaveTokens = true;
          });
    }

    public static AuthenticationBuilder GoogleAuth(this AuthenticationBuilder authBuilder, IConfiguration configuration)
    {
      // it doesn't work with ngrok some how.

      return authBuilder
        .AddGoogle(options =>
          {
            options.ClientId = configuration["Authentication:Google:ClientId"];
            options.ClientSecret = configuration["Authentication:Google:ClientSecret"];
            options.SaveTokens = true;
          });
    }

    ////public static AuthenticationBuilder EBayAuth(this AuthenticationBuilder authBuilder, IConfiguration configuration)
    ////{
    ////  //authBuilder.add
    ////}
  }
}