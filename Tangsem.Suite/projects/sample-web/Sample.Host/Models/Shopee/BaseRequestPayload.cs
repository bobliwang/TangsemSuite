using System;

using Newtonsoft.Json;

namespace Sample.Host.Models.Shopee
{
  public class BaseRequestPayload
  {
    [JsonProperty("partner_id")]
    public int PartnerId { get; set; }

    [JsonProperty("shopid")]
    public int ShopId { get; set; }

    [JsonProperty("timestamp")]
    public long Timestamp { get; set; } = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds / 1000);
  }


  public class BaseListingRequestPayload : BaseRequestPayload
  {
    [JsonProperty("pagination_offset")]
    public int PaginationOffset { get; set; } = 0;


    [JsonProperty("pagination_entries_per_page")]
    public int PaginationEntriesPerPage { get; set; } = 100;
  }
}