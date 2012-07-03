using System;
using System.Collections.Generic;
using System.Text;

namespace Tangsem.Common.Entities
{
  /// <summary>
  /// The AuditableEntity class.
  /// </summary>
  public class AuditableEntity : IAuditableEntity
  {
    public virtual int? CreatedById { get; set; }

    public virtual int? ModifiedById { get; set; }

    public virtual DateTime? CreatedTime { get; set; }

    public virtual DateTime? ModifiedTime { get; set; }

    public virtual bool? Active { get; set; }
  }
}
