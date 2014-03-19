using System;

namespace Tangsem.Common.Entities.Reos
{
  public interface IReosAuditableEntity
  {
    int? CreatedById { get; set; }

    int? ModifiedById { get; set; }

    DateTime CreatedDate { get; set; }

    DateTime ModifiedDate { get; set; }

    bool Active { get; set; }
  }
}