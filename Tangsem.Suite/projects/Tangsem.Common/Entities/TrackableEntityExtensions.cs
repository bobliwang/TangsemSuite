using System.Linq;

namespace Tangsem.Common.Entities
{
  public static class TrackableEntityExtensions
  {
    public static IQueryable<T> ActiveOnly<T>(this IQueryable<T> qry) where T : ITrackableEntity
    {
      return qry.Where(x => x.Active);
    }
  }
}