using System.Collections.Generic;

namespace Tangsem.Data
{
  public class SearchResultModel<T>
  {
    public int PageIndex { get; set; }

    public int PageSize { get; set; }

    public int RowsCount { get; set; }

    public IList<T> PagedData { get; set; }
  }
}