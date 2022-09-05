using System;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Type;
using Tangsem.Common.Entities.Reos;
using Tangsem.Common.Extensions;

namespace Tangsem.NHibernate.Interceptors
{
  public class ReosAuditingInterceptor : EmptyInterceptor
  {
    public int? CurrentUserId { get; set; }
    
    public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, IType[] types)
    {
      if (entity is IReosAuditableEntity)
      {
        this.OnSaveAuditableEntity(state, propertyNames);

        return true;
      }

      return false;
    }

    public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, IType[] types)
    {
      if (entity is IReosAuditableEntity)
      {
        this.OnFlushDirtyAuditableEntity(currentState, propertyNames);

        return true;
      }

      return false;
    }

    private void OnSaveAuditableEntity(object[] state, string[] propertyNames)
    {
      for (var i = 0; i < propertyNames.Length; i++)
      {
        if (nameof(IReosAuditableEntity.CreatedDate) == propertyNames[i])
        {
          state[i] = DateTime.UtcNow;
        }
        else if (nameof(IReosAuditableEntity.CreatedById) == propertyNames[i])
        {
          state[i] = this.CurrentUserId;
        }
        else if (nameof(IReosAuditableEntity.Active) == propertyNames[i])
        {
          state[i] = true;
        }
      }
    }

    private void OnFlushDirtyAuditableEntity(object[] currentState, string[] propertyNames)
    {
      for (var i = 0; i < propertyNames.Length; i++)
      {
        if (nameof(IReosAuditableEntity.ModifiedDate) == propertyNames[i])
        {
          currentState[i] = DateTime.UtcNow;
        }
        else if (nameof(IReosAuditableEntity.ModifiedById) == propertyNames[i])
        {
          currentState[i] = this.CurrentUserId;
        }
      }
    }
  }
}