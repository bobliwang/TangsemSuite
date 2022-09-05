using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

using Jose;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Tangsem.Identity.Domain.Entities;

namespace Sample.Host.Services
{
  public interface IQuickBooksService
  {
    Task<string> PostAsync(string endPoint, string body);


    Task<TResp> PostAsync<TReq, TResp>(string endPoint, TReq body);


    Task<string> GetAsync(string endPoint);


    Task<TResp> GetAsync<TResp>(string endPoint);
  }

  public class LoggingEvents
  {
    public const int HttpPost = 1000;
  }

  public class QboHttpClientParams
  {
    public string CompanyId { get; set; }

    public string AccessToken { get; set; }
  }

  /// <summary>
  /// Please refer to https://github.com/ehalsey/IntuitOpenIdConnect/blob/master/TestIntuitOICD/Services/QuickBooksService.cs
  /// </summary>
  public class QuickBooksService : IQuickBooksService
  {
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<AspNetUser> _userManager;
    private readonly ILogger _logger;

    public QuickBooksService(
      IConfiguration configuration,
      IHttpContextAccessor httpContextAccessor,
      UserManager<AspNetUser> userManager,
      ILogger<QuickBooksService> logger)
    {
      this._configuration = configuration;
      this._httpContextAccessor = httpContextAccessor;
      this._userManager = userManager;
      this._logger = logger;
    }

    public async Task<string> PostAsync(string endPoint, string json)
    {
      var qboParams = await this.GetQboHttpClientParamsAsync();
      using (var httpClient = this.GetQboHttpClient(qboParams.CompanyId, qboParams.AccessToken))
      {
        return await this.MakePostRequest(httpClient, endPoint, json);
      }
    }

    public async Task<TResp> PostAsync<TReq, TResp>(string endPoint, TReq body)
    {
      var reqText = JsonConvert.SerializeObject(body);
      var respText = await this.PostAsync(endPoint, reqText);

      return JsonConvert.DeserializeObject<TResp>(respText);
    }

    public async Task<string> GetAsync(string endPoint)
    {
      var qboParams = await this.GetQboHttpClientParamsAsync();
      if (string.IsNullOrWhiteSpace(endPoint))
      {
        endPoint = $"/companyinfo/{qboParams.CompanyId}";
      }

      using (var httpClient = this.GetQboHttpClient(qboParams.CompanyId, qboParams.AccessToken))
      {
        return await this.MakeGetRequest(httpClient, endPoint);
      }
    }

    public async Task<TResp> GetAsync<TResp>(string endPoint)
    {
      var respText = await this.GetAsync(endPoint);
      return JsonConvert.DeserializeObject<TResp>(respText);
    }

    public async Task<QboHttpClientParams> GetQboHttpClientParamsAsync()
    {
      var httpContextUser = this._httpContextAccessor.HttpContext.User;
      var user = await this._userManager.GetUserAsync(httpContextUser);
      if (user == null)
      {
        throw new ApplicationException($"Unable to load user with ID '{this._userManager.GetUserId(httpContextUser)}'.");
      }

      if (!httpContextUser.Identity.IsAuthenticated)
      {
        throw new Exception("NotAuthenticated");
      }

      // access token
      var accessToken = await this._userManager.GetAuthenticationTokenAsync(
                                  user,
                                  Constants.LoginProviders.QuickBook,
                                  "access_token");

      if (string.IsNullOrWhiteSpace(accessToken))
      {
        throw new Exception("access_token not found");
      }

      // company id
      var idToken = await this._userManager.GetAuthenticationTokenAsync(
                      user,
                      Constants.LoginProviders.QuickBook,
                      "id_token");
      var payload = JWT.Payload(idToken);
      dynamic parsedPayload = JToken.Parse(payload);
      var companyId = $"{parsedPayload.realmid}";

      return new QboHttpClientParams { AccessToken = accessToken, CompanyId = companyId };
    }

    private async Task<string> MakeGetRequest(HttpClient httpClient, string relativeEndpoint)
    {
      var response = await httpClient.GetAsync(relativeEndpoint);
      response.EnsureSuccessStatusCode();
      
      return await response.Content.ReadAsStringAsync();
    }

    private async Task<string> MakePostRequest(HttpClient httpClient, string relativeEndpoint, string json)
    {
      var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
      var response = await httpClient.PostAsync(relativeEndpoint, content);
      response.EnsureSuccessStatusCode();

      return await response.Content.ReadAsStringAsync();
    }

    private HttpClient GetQboHttpClient(string companyId, string externalAccessToken)
    {
      var baseUrl = $"https://{this._configuration["qboAccountingApiBaseUrl"]}//v3/company/{companyId}";
      var httpClient = new HttpClient
                         {
                           BaseAddress = new Uri(baseUrl)
                         };

      httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", externalAccessToken);

      return httpClient;
    }

  }
}