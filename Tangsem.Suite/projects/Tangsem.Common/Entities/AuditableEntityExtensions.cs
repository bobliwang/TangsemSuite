using System.Linq;

namespace Tangsem.Common.Entities
{
  public static class AuditableEntityExtensions
  {
    public static IQueryable<T> ActiveOnly<T>(this IQueryable<T> qry) where T : class, IAuditableEntity
    {
      return qry.Where(x => x.Active);
    }
  }
}