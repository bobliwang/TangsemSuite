using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tangsem.Data.Domain
{
  public class RepositoryContext
  {
    private static RepositoryContext instance = new RepositoryContext();

    public static RepositoryContext Instance
    {
      get
      {
        return instance;
      }

      set
      {
        instance = value;
      }
    }

    public static IRepository CurrentRepository
    {
      get
      {
        return instance.ThreadLocal.Value;
      }

      set
      {
        instance.ThreadLocal.Value = value;
      }
    }

    public ThreadLocal<IRepository> ThreadLocal { get; set; }
  }
}
