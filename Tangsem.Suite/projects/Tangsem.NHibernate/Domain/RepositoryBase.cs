using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

using Tangsem.Data.Domain;

namespace Tangsem.NHibernate.Domain
{
  /// <summary>
  /// The base class for all IRepository implementations which may directly connect to database.
  /// </summary>
  public abstract class RepositoryBase : IRepository
  {
    /// <summary>
    /// Default constructor.
    /// </summary>
    protected RepositoryBase()
    {
    }

    /// <summary>
    /// Constructor with currentSession as param.
    /// </summary>
    /// <param name="currentSession">The current session.</param>
    protected RepositoryBase(ISession currentSession)
    {
      this.CurrentSession = currentSession;
    }

    /// <summary>
    /// Gets or sets the hiberante ISession object.
    /// </summary>
    public virtual ISession CurrentSession { get; set; }

    /// <summary>
    /// Gets the database transaction.
    /// </summary>
    public virtual ITransaction Transaction { get; protected set; }

    /// <summary>
    /// Gets the entity query by entity type. Please use entities properties from subclasses. e.g. XXXRepository.Users instead of this.GetEntities(User).
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <returns>The entity query by entity type.</returns>
    public virtual IQueryable<T> GetEntities<T>() where T : class
    {
      return this.CurrentSession.Query<T>();
    }

    /// <summary>
    /// Saves an entity.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="entity">The entity.</param>
    /// <returns>The saved entity.</returns>
    public virtual T Save<T>(T entity) where T : class
    {
      this.CurrentSession.Save(entity);

      return entity;
    }

    /// <summary>
    /// Saves or updates an entity.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="entity">The entity.</param>
    /// <returns>The saved or updated entity.</returns>
    public virtual T SaveOrUpdate<T>(T entity) where T : class
    {
      this.CurrentSession.SaveOrUpdate(entity);

      return entity;
    }

    /// <summary>
    /// Updates an entity.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="entity">The entity.</param>
    /// <returns>The updated entity.</returns>
    public virtual T Update<T>(T entity) where T : class
    {
      this.CurrentSession.Update(entity);

      return entity;
    }

    /// <summary>
    /// Gets an entity by id.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="id">The id value.</param>
    /// <returns>The found entity. Returns null if nothing is found.</returns>
    public virtual T LookupById<T>(object id) where T : class
    {
      var entity = this.CurrentSession.Get<T>(id);

      return entity;
    }

    /// <summary>
    /// Deletes an entity and returns whether the operation is successful.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="entity">The entity</param>
    public virtual void Delete<T>(T entity) where T : class
    {
      this.CurrentSession.Delete(entity);
    }

    /// <summary>
    /// Deletes an entity by id.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="id">The id value.</param>
    /// <returns>The deleted entity if the operation is successful. Otherwise it returns null.</returns>
    public virtual T DeleteById<T>(object id) where T : class
    {
      // find the entity first.
      var entity = this.LookupById<T>(id);

      if (entity != null)
      {
        // delete the entity once it's found.
        this.Delete(entity);
      }

      // return the deleted entity.
      return entity;
    }

    /// <summary>
    /// Commit transaction to database.
    /// </summary>
    public virtual void Commit()
    {
      Transaction.Commit();
    }

    /// <summary>
    /// Rollback transaction.
    /// </summary>
    public virtual void Rollback()
    {
      Transaction.Rollback();
    }

    /// <summary>
    /// Start a transaction.
    /// </summary>
    public virtual void BeginTransaction()
    {
      if (this.Transaction != null && this.Transaction.IsActive)
      {
        throw new Exception("There is already an existing active transaction!");
      }

      this.Transaction = this.CurrentSession.BeginTransaction();
    }
  }
}