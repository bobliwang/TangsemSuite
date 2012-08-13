using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tangsem.Generator.WebMvc3Demo.Extensions.Flexigrid
{
  public class FlexigridSearchSettings
  {
    public FlexigridSearchSettings(string url, IEnumerable<FlexigridSearchItem> searchItems = null, string searchFieldParamName = "qtype", string searchValueParamName = "q")
    {
      this.Url = url;
      this.SearchItems = searchItems ?? new FlexigridSearchItem[0];
      this.SearchFieldParamName = searchFieldParamName;
      this.SearchValueParamName = searchValueParamName;
    }

    public string Url { get; set; }

    public IEnumerable<FlexigridSearchItem> SearchItems { get; set; }

    public string SearchFieldParamName { get; set; }

    public string SearchValueParamName { get; set; }

    public bool IsInUse
    {
      get
      {
        return this.SearchItems != null && this.SearchItems.Any();
      }
    }

    public string SearchItemsJson
    {
      get
      {
        var searchItemsStr = string.Empty;
        if (this.SearchItems != null && this.SearchItems.Any())
        {
          searchItemsStr += "searchitems: [";
          searchItemsStr += string.Join(", ", this.SearchItems.Select(x => x.ToJson()));
          searchItemsStr += "]";
        }

        return searchItemsStr;
      }
    }
  }
}