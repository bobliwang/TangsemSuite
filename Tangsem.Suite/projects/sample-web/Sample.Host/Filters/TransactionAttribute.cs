
using Sample.Core.Domain.Repositories.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tangsem.Web.Mvc;

namespace Sample.Host.Filters
{
  public class TransactionAttribute : AbstractTransactionAttribute
  {
    public TransactionAttribute()
    {
      this.RepositoryType = typeof(SampleHostRepository);
    }
  }
}
