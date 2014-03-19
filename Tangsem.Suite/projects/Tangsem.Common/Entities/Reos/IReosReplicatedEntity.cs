using System;

namespace Tangsem.Common.Entities.Reos
{
  public interface IReosReplicatedEntity
  {
    bool Replicated { get; set; }

    byte[] RowVersion { get; set; }

    Guid Rowguid { get; set; }
  }
}