using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using NHibernate;
using NHibernate.SqlCommand;
using NHibernate.Type;

using Tangsem.Common.Entities;
using Tangsem.Common.Extensions;

namespace Tangsem.NHibernate.Interceptors
{
  /// <summary>
  /// The AuditingInterceptor class.
  /// </summary>
  public class AuditingInterceptor : EmptyInterceptor
  {
    private static readonly Expression<Func<IAuditableEntity, object>> Expr_CreatedTime = x => x.CreatedTime;
    private static readonly Expression<Func<IAuditableEntity, object>> Expr_CreatedById = x => x.CreatedById;
    private static readonly Expression<Func<IAuditableEntity, object>> Expr_ModifiedTime = x => x.ModifiedTime;
    private static readonly Expression<Func<IAuditableEntity, object>> Expr_ModifiedById = x => x.ModifiedById;
    private static readonly Expression<Func<IAuditableEntity, object>> Expr_Active = x => x.Active;

    private static readonly string PN_CreatedTime = Expr_CreatedTime.GetPropertyInfo().Name;
    private static readonly string PN_CreatedById = Expr_CreatedById.GetPropertyInfo().Name;
    private static readonly string PN_ModifiedTime = Expr_ModifiedTime.GetPropertyInfo().Name;
    private static readonly string PN_ModifiedById = Expr_ModifiedById.GetPropertyInfo().Name;
    private static readonly string PN_Active = Expr_Active.GetPropertyInfo().Name;



    public int? CurrentUserId { get; set; }

    public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, IType[] types)
    {
      if (entity is IAuditableEntity)
      {
        for (var i = 0; i < propertyNames.Length; i++)
        {
          if (PN_CreatedTime == propertyNames[i])
          {
            state[i] = DateTime.UtcNow;
          }
          else if (PN_CreatedById == propertyNames[i])
          {
            state[i] = this.CurrentUserId;
          }
          else if (PN_Active == propertyNames[i])
          {
            state[i] = true;
          }
        }

        return true;
      }

      return false;
    }

    public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, IType[] types)
    {
      if (entity is IAuditableEntity)
      {
        for (var i = 0; i < propertyNames.Length; i++)
        {
          if (PN_ModifiedTime == propertyNames[i])
          {
              currentState[i] = DateTime.UtcNow;
          }
          else if (PN_ModifiedById == propertyNames[i])
          {
            currentState[i] = this.CurrentUserId;
          }
        }

        return true;
      }

      return false;
    }
  }
}
