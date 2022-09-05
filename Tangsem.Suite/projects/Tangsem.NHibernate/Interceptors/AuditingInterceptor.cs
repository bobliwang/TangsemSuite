using System;
using System.Linq.Expressions;

using NHibernate;
using NHibernate.SqlCommand;
using NHibernate.Type;

using Tangsem.Common.Entities;
using Tangsem.Common.Extensions;
using Tangsem.Data.Domain;

namespace Tangsem.NHibernate.Interceptors
{
  /// <summary>
  /// The AuditingInterceptor class.
  /// </summary>
  public class AuditingInterceptor : EmptyInterceptor
  { 
    public IDataContext DataContext { get; set; }
    
    public AuditingInterceptor(IDataContext dataContext)
    {
      this.DataContext = dataContext;
    }

    public int? CurrentUserId => this.DataContext?.CurrentUserId;

    public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, IType[] types)
    {
      if (entity is IAuditableEntity)
      {
        this.OnSaveAuditableEntity(state, propertyNames);

        return true;
      }

      return false;
    }

    public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, IType[] types)
    {
      if (entity is IAuditableEntity)
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
        if (nameof(IAuditableEntity.CreatedTime) == propertyNames[i])
        {
          state[i] = DateTime.UtcNow;
        }
        else if (nameof(IAuditableEntity.CreatedById) == propertyNames[i])
        {
          state[i] = this.CurrentUserId;
        }
        ////else if (nameof(IAuditableEntity.Active) == propertyNames[i])
        ////{
        ////  state[i] = true;
        ////}
      }
    }

    private void OnFlushDirtyAuditableEntity(object[] currentState, string[] propertyNames)
    {
      for (var i = 0; i < propertyNames.Length; i++)
      {
        if (nameof(IAuditableEntity.ModifiedTime) == propertyNames[i])
        {
          currentState[i] = DateTime.UtcNow;
        }
        else if (nameof(IAuditableEntity.ModifiedById) == propertyNames[i])
        {
          currentState[i] = this.CurrentUserId;
        }
      }
    }
  }
}
