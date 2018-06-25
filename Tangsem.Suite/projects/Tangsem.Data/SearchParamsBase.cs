using System.Linq;
using Tangsem.Common.Extensions.Linq;

namespace Tangsem.Data
{

  public class SortByModel
  {
    public string SortFieldName { get; set; }

    /// <summary>
    /// ASC or DESC. Case insensitive.
    /// </summary>
    public string Direction { get; set; }
  }

  public class SearchParamsBase: SortByModel
  {
    public int PageIndex { get; set; }

    public int PageSize { get; set; }

  }
}