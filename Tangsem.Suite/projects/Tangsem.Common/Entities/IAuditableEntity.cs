using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tangsem.Common.Entities
{
  /// <summary>
  /// The IAuditableEntity interface.
  /// </summary>
  public interface IAuditableEntity
  {
    int? CreatedById { get; set; }

    int? ModifiedById { get; set; }

    DateTime? CreatedTime { get; set; }

    DateTime? ModifiedTime { get; set; }

    bool? Active { get; set; }
  }
}