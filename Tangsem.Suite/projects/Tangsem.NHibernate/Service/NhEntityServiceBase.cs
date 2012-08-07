using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using NHibernate;

using Tangsem.Data;
using Tangsem.Data.Domain;
using Tangsem.Data.Service;
using Tangsem.NHibernate.Domain;

namespace Tangsem.NHibernate.Service
{
  public class NhEntityServiceBase<TEntity> : Tangsem.Data.Service.EntityServiceBase<TEntity>
    where TEntity : class
  {

    /// <summary>
    /// Creates a model without repository.
    /// </summary>
    public NhEntityServiceBase()
    {
    }

    /// <summary>
    /// Creates a model with repository.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public NhEntityServiceBase(IRepository repository)
      : base(repository)
    {
    }

    /// <summary>
    /// Get current nhibernate session.
    /// </summary>
    public virtual ISession CurrentSession
    {
      get
      {
        var dbRepo = this.Repository as RepositoryBase;
        if (dbRepo != null)
        {
          return dbRepo.CurrentSession;
        }

        throw new Exception("Current Repository is not an instance of " + typeof(RepositoryBase).FullName + ". You may not get NHibernate session.");
      }
    }
  }
}