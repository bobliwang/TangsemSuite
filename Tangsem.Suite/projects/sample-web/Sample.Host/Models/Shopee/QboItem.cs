using Newtonsoft.Json;

namespace Sample.Host.Models.Shopee
{
  public class QboItem
  {
    public string Name { get; set; }
    public AssetAccountRef IncomeAccountRef { get; set; }
    public AssetAccountRef ExpenseAccountRef { get; set; }
    public AssetAccountRef AssetAccountRef { get; set; }
    public string Type { get; set; }
    public bool TrackQtyOnHand { get; set; }
    public int QtyOnHand { get; set; }
    public string InvStartDate { get; set; }
    public string Description { get; internal set; }
    public string Sku { get; internal set; }
  }

  public class AssetAccountRef
  {
    [JsonProperty("value")]
    public string Value { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
  }

}