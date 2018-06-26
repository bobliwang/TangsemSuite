using Newtonsoft.Json;

namespace GeneratorTest.Common.Domain.ViewModels
{
  public class ProductSpec
  {
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("value")]
    public string Value { get; set; }
  }
}