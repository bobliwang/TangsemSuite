using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.Logging;

using NHibernate;

namespace Tangsem.Identity.Domain.Repositories.NHibernate
{
  public partial class IdentityRepository
  {
    private readonly ILogger _logger;

    public IdentityRepository(ISession currentSession, ILogger logger)
      : base(currentSession)
    {
      this._logger = logger;
    }

    protected override void Dispose(bool disposing)
    {
      this._logger?.LogDebug("** Dispose **" + this.GetType().FullName);

      base.Dispose(disposing);
    }
  }
}
