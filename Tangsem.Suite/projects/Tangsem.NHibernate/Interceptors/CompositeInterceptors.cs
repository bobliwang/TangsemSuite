using System.Collections;
using System.Linq;

using NHibernate;
using NHibernate.SqlCommand;
using NHibernate.Type;

namespace Tangsem.NHibernate.Interceptors
{
  public class CompositeInterceptors : IInterceptor
  {
    private readonly IInterceptor[] interceptors;

    public CompositeInterceptors(IInterceptor[] interceptors)
    {
      this.interceptors = interceptors;
    }

    public bool OnLoad(object entity, object id, object[] state, string[] propertyNames, IType[] types)
    {
      var result = false;
      foreach (var interceptor in this.interceptors)
      {
        result = result || interceptor.OnLoad(entity, id, state, propertyNames, types);
      }

      return result;
    }

    public bool OnFlushDirty(
      object entity,
      object id,
      object[] currentState,
      object[] previousState,
      string[] propertyNames,
      IType[] types)
    {
      var result = false;
      foreach (var interceptor in this.interceptors)
      {
        result |=interceptor.OnFlushDirty(entity, id, currentState, previousState, propertyNames, types);
      }

      return result;
    }

    public bool OnSave(object entity, object id, object[] state, string[] propertyNames, IType[] types)
    {
      var result = false;

      foreach (var interceptor in this.interceptors)
      {
        result |= interceptor.OnSave(entity, id, state, propertyNames, types);
      }

      return result;
    }

    public void OnDelete(object entity, object id, object[] state, string[] propertyNames, IType[] types)
    {
      foreach (var interceptor in this.interceptors)
      {
        interceptor.OnDelete(entity, id, state, propertyNames, types);
      }
    }

    public void OnCollectionRecreate(object collection, object key)
    {
      foreach (var interceptor in this.interceptors)
      {
        interceptor.OnCollectionRecreate(collection, key);
      }
    }

    public void OnCollectionRemove(object collection, object key)
    {
      foreach (var interceptor in this.interceptors)
      {
        interceptor.OnCollectionRemove(collection, key);
      }
    }

    public void OnCollectionUpdate(object collection, object key)
    {
      foreach (var interceptor in this.interceptors)
      {
        interceptor.OnCollectionUpdate(collection, key);
      }
    }

    public void PreFlush(ICollection entities)
    {
      foreach (var interceptor in this.interceptors)
      {
        interceptor.PreFlush(entities);
      }
    }

    public void PostFlush(ICollection entities)
    {
      foreach (var interceptor in this.interceptors)
      {
        interceptor.PostFlush(entities);
      }
    }

    public bool? IsTransient(object entity)
    {
      return EmptyInterceptor.Instance.IsTransient(entity);
    }

    public int[] FindDirty(
      object entity,
      object id,
      object[] currentState,
      object[] previousState,
      string[] propertyNames,
      IType[] types)
    {
      return EmptyInterceptor.Instance.FindDirty(entity, id, currentState, previousState, propertyNames, types);
    }

    public object Instantiate(string entityName, object id)
    {
      return this.interceptors.LastOrDefault()?.Instantiate(entityName, id);
    }

    public string GetEntityName(object entity)
    {
      return this.interceptors.LastOrDefault()?.GetEntityName(entity);
    }

    public object GetEntity(string entityName, object id)
    {
      return this.interceptors.LastOrDefault()?.GetEntity(entityName, id);
    }

    public void AfterTransactionBegin(ITransaction tx)
    {
      foreach (var interceptor in this.interceptors)
      {
        interceptor.AfterTransactionBegin(tx);
      }
    }

    public void BeforeTransactionCompletion(ITransaction tx)
    {
      foreach (var interceptor in this.interceptors)
      {
        interceptor.BeforeTransactionCompletion(tx);
      }
    }

    public void AfterTransactionCompletion(ITransaction tx)
    {
      foreach (var interceptor in this.interceptors)
      {
        interceptor.AfterTransactionCompletion(tx);
      }
    }

    public SqlString OnPrepareStatement(SqlString sql)
    { 
      foreach (var interceptor in this.interceptors)
      {
        sql = interceptor.OnPrepareStatement(sql);
      }

      return sql;
    }

    public void SetSession(ISession session)
    {
      foreach (var interceptor in this.interceptors)
      {
        interceptor.SetSession(session);
      }
    }
  }
}