using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tangsem.Common.Entities
{
  /// <summary>
  /// The ITrackableEntity interface.
  /// </summary>
  public interface ITrackableEntity
  {
    int? CreatedById { get; set; }

    int? ModifiedById { get; set; }

    DateTime? CreatedTime { get; set; }

    DateTime? ModifiedTime { get; set; }

    bool? Active { get; set; }
  }
}
