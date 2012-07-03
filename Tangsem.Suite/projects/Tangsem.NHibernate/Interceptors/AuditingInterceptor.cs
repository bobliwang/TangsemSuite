using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.SqlCommand;
using NHibernate.Type;

using Tangsem.Common.Entities;

namespace Tangsem.NHibernate.Interceptors
{
  /// <summary>
  /// The AuditingInterceptor class.
  /// </summary>
  public class AuditingInterceptor : EmptyInterceptor
  {
    public int? CurrentUserId { get; set; }

    public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, IType[] types)
    {
      this.OnEntityInserting(entity);

      return base.OnSave(entity, id, state, propertyNames, types);
    }

    public override void PreFlush(ICollection entitites)
    {
      foreach (var entity in entitites)
      {
        this.OnEntityUpdating(entity);
      }

      base.PreFlush(entitites);
    }

    private void OnEntityInserting(object entity)
    {
      var auditableEntity = entity as IAuditableEntity;
      if (auditableEntity != null)
      {
        var now = DateTime.Now;
        auditableEntity.CreatedTime = now;
        auditableEntity.CreatedById = this.CurrentUserId;

        if (!auditableEntity.Active.HasValue)
        {
          auditableEntity.Active = true;
        }
      }
    }

    private void OnEntityUpdating(object entity)
    {
      var auditableEntity = entity as IAuditableEntity;
      if (auditableEntity != null)
      {
        var now = DateTime.Now;
        auditableEntity.ModifiedTime = now;
        auditableEntity.ModifiedById = this.CurrentUserId;
      }
    }
  }
}
