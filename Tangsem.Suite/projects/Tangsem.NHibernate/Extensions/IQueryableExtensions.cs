using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using NHibernate.Linq;

namespace Tangsem.NHibernate.Extensions
{
  public static class IQueryableExtensions
  {
    public static INhFetchRequest<TOriginating, TRelated> Include<TOriginating, TRelated>(this IQueryable<TOriginating> query, Expression<Func<TOriginating, IEnumerable<TRelated>>> relatedObjectSelector)
    {
      return query.FetchMany(relatedObjectSelector);
    }

    public static INhFetchRequest<TOriginating, TRelated> Include<TOriginating, TRelated>(this IQueryable<TOriginating> query, Expression<Func<TOriginating, TRelated>> relatedObjectSelector)
    {
      return query.Fetch(relatedObjectSelector);
    }
  }
}
