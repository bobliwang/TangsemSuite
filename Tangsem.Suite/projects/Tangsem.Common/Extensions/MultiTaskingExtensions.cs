using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tangsem.Common.Extensions
{
  public static class MultiTaskingExtensions
  {
    public static async Task ExecuteInParallel<T>(this IList<T> list, Func<T, Task> func, int parallelism = 2)
    {
      if (parallelism < 1)
      {
        throw new ArgumentException(nameof(parallelism) + " should be greater than 1");
      }

      var sem = new SemaphoreSlim(parallelism);

      var tasks = list.AsParallel().Select(
        async (x) =>
          {
            await sem.WaitAsync();
            try
            {
              await func(x);
            }
            finally
            {
              sem.Release();
            }
          });

      await Task.WhenAll(tasks);
    }

    public static async Task<IList<R>> ExecuteInParallel<T, R>(this IList<T> list, Func<T, Task<R>> func, int parallelism = 2)
    {
      if (parallelism < 1)
      {
        throw new ArgumentException(nameof(parallelism) + " should be greater than 1");
      }

      var sem = new SemaphoreSlim(parallelism);

      var tasks = list.AsParallel().Select(
        async (x) =>
          {
            await sem.WaitAsync();
            try
            {
              var r = await func(x);

              return r;
            }
            finally
            {
              sem.Release();
            }
          });

      return await Task.WhenAll(tasks);
    }
  }
}
