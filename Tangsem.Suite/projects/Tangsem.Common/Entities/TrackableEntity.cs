using System;
using System.Collections.Generic;
using System.Text;

namespace Tangsem.Common.Entities
{
  /// <summary>
  /// The TrackableEntity class.
  /// </summary>
  public class TrackableEntity : ITrackableEntity
  {
    public virtual int? CreatedById { get; set; }

    public virtual int? ModifiedById { get; set; }

    public virtual DateTime? CreatedTime { get; set; }

    public virtual DateTime? ModifiedTime { get; set; }

    public virtual bool? Active { get; set; }
  }
}
