using System;

using FluentNHibernate.Conventions;

namespace Sample.Core.Domain.Entities
{
  public partial class ShopeeItemPullHistory
  {
    ////public virtual string RowVersionAsString
    ////{
    ////  get { return this.RowVersion.IsEmpty() ? null : Convert.ToBase64String(this.RowVersion); }

    ////  set { this.RowVersion = value.IsEmpty() ? null : Convert.FromBase64String(value); }
    ////}
  }
}