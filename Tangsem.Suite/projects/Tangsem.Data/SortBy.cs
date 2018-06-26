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

      return qry.OrderBy(sortByModel.SortFieldName, sortByModel.Direction);
    }


    public static IQueryable<T> SkipAndTake<T>(this IQueryable<T> qry, SearchParamsBase searchParam)
    {
      if (searchParam == null)
      {
        return qry;
      }

      if (searchParam.PageIndex != null && searchParam.PageSize != null)
      {
        qry = qry.Skip(searchParam.PageIndex.Value * searchParam.PageSize.Value);
      }

      if (searchParam.PageSize != null)
      {
        qry = qry.Take(searchParam.PageSize.Value);
      }

      return qry;
    }
  }

  ////internal class Person
  ////{
  ////  public int Age { get; set; }

  ////  public string Name { get; set; }

  ////  public Person Parent { get; set; }
  ////}
}
