using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sample.Host.Models.Shopee;

namespace Sample.Host.Services
{
  public class ShopeeService
  {
    public ShopeeService(IConfiguration config)
    {
      this.ApiBaseUrl = config["shopeeApiBaseUrl"];
      this.PartnerId = int.Parse(config["shopeePartnerId"]);
      this.Key = config["shopeeKey"];
    }

    public string Key { get; set; }

    public int PartnerId { get; set; }

    /*
/api/v1/shop/get
/api/v1/items/get
/api/v1/item/get
/api/v1/orders/basics
/api/v1/orders/get
/api/v1/orders/detail */

    public string ApiBaseUrl { get; private set; }

    public async Task<string> GetShopInfoAsync(string shopId)
    {
      var req = new BaseRequestPayload { PartnerId = this.PartnerId, ShopId = int.Parse(shopId) };

      return await this.PostAsync("/api/v1/shop/get", req);
    }

    public async Task<string> GetItemsAsync(string shopId)
    {
      var req = new BaseListingRequestPayload { PartnerId = this.PartnerId, ShopId = int.Parse(shopId) };

      return await this.PostAsync("/api/v1/items/get", req);
    }

    public async Task<string> GetItemAsync(string shopId, int itemId)
    {
      var payload = new BaseRequestPayload { PartnerId = this.PartnerId, ShopId = int.Parse(shopId) };
      dynamic req = JObject.Parse(JsonConvert.SerializeObject(payload));
      req.item_id = itemId; 

      return await this.PostAsync("/api/v1/item/get", req);
    }

    public async Task<string> PostAsync<T>(string endPoint, T payload)
    {
      using (var http = new HttpClient())
      {
        var url = $"{this.ApiBaseUrl}{endPoint}";

        //new { partner_id = this.PartnerId, shopid = shopId, timestamp = }
        var reqText = JsonConvert.SerializeObject(payload, Formatting.None);

        var signature = this.Sign($"{url}|{reqText}", this.Key);
        http.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", signature);
        var content = new StringContent(reqText, Encoding.UTF8, "application/json");
        var response = await http.PostAsync(url, content);

        var text = await response.Content.ReadAsStringAsync();

        return text;
      }
    }

    private string Sign(string input, string key)
    {
      using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
      {
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(input));

        return ByteToString(computedHash);
      }
    }

    public static string ByteToString(byte[] buff)
    {
      var sbinary = string.Empty;

      for (var i = 0; i < buff.Length; i++)
      {
        sbinary += buff[i].ToString("X2"); // hex format
      }

      return sbinary;
    }
  }
}