using System;
using System.Linq;

using Tangsem.Common.Extensions.Linq;

namespace Tangsem.Data
{
  public class SortBy<T> where T : class
  {
    public static SortBy<T> Create(Func<T, IComparable> propertyExpression, bool isDescending = false)
    {
      return new SortBy<T>(propertyExpression, isDescending);
    }

    public SortBy(Func<T, IComparable> propertyExpression, bool isDescending = false)
    {
      this.PropertyExpression = propertyExpression;
      this.IsDescending = isDescending;
    }

    /// <summary>
    /// Gets or sets the sorting property.
    /// </summary>
    public Func<T, IComparable> PropertyExpression { get; set; }

    /// <summary>
    /// Gets or sets whether sorting by descending order.
    /// </summary>
    public bool IsDescending { get; set; }
  }

  public static class QryExtensions
  {
    public static IQueryable<T> SortBy<T>(this IQueryable<T> qry, SortByModel sortByModel)
    {
      if (string.IsNullOrWhiteSpace(sortByModel.SortFieldName))
      {
        return qry;
      }

      return qry.OrderBy(sortByModel.SortFieldName + " " + sortByModel.Direction);
    }

    /// <summary>
    /// SkipAndTake with pageIndex and pageSize.
    /// </summary>
    public static IQueryable<T> SkipAndTake<T>(this IQueryable<T> qry, int? pageIndex, int? pageSize)
    {
      if (pageIndex != null && pageSize != null)
      {
        qry = qry.Skip(pageIndex.Value * pageSize.Value);
      }

      if (pageSize != null)
      {
        qry = qry.Take(pageSize.Value);
      }

      return qry;
    }

    /// <summary>
    /// SkipAndTake with pageIndex and pageSize from SearchParamsBase.
    /// </summary>
    public static IQueryable<T> SkipAndTake<T>(this IQueryable<T> qry, SearchParamsBase searchParam)
    {
      if (searchParam == null)
      {
        return qry;
      }

      return qry.SkipAndTake(searchParam.PageIndex, searchParam.PageSize);
    }
  }
}
