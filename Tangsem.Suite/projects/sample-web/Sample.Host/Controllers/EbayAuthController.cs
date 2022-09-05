using System;
using System.Threading.Tasks;

using eBay.ApiClient.Auth.OAuth2;
using eBay.ApiClient.Auth.OAuth2.Model;

using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Sample.Host.Controllers
{
  public class EbayAuthController : Controller
  {
    private readonly IConfiguration config;

    public EbayAuthController(IConfiguration config)
    {
      this.config = config;
    }

    [HttpGet("api/ebay/oauth/accepted")]
    public IActionResult OAuthAccepted()
    {
      CredentialUtil.Load("./ebay-config.yaml");

      var code = this.Request.Query["code"];
      
      try
      {
        var response = new OAuth2Api().ExchangeCodeForAccessToken(OAuthEnvironment.PRODUCTION, code);
        this.Set("ebaytkn", response.AccessToken.Token, 60);

        return this.Redirect("/apps/inventory-sync/ebay-orders");
      }
      catch (Exception ex)
      {
        return this.Ok(ex.ToString());
      }
    }

    [HttpGet("api/ebay/orders")]
    public IActionResult GetEBayOrders(string filter, string limit, string offset, string orderIds)
    {
      return this.Ok(this.GetOrders(filter, limit, offset, orderIds, this.Request.Cookies["ebaytkn"]));
    }

    public OrderSearchPagedCollection GetOrders(string filter, string limit, string offset, string orderIds, string accessToken)
    {
      ////var accessToken = this.Request.Cookies["ebaytkn"];
      var config = new Configuration();

      config.AddDefaultHeader("Authorization", $"Bearer {accessToken}");
      var orderApi = new OrderApi(config);

      var orders = orderApi.GetOrders(filter, limit, offset, orderIds);

      return orders;
    }

    public void Set(string key, string value, int? expireTime)
    {
      CookieOptions option = new CookieOptions();

      if (expireTime.HasValue)
        option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
      else
        option.Expires = DateTime.Now.AddMilliseconds(10);

      this.Response.Cookies.Append(key, value, option);
    }
  }
}