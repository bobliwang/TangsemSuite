using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using NHibernate;
using NHibernate.Linq;

using Tangsem.Common.Entities;
using Tangsem.Data.Domain;

namespace Tangsem.NHibernate.Domain
{
  /// <summary>
  /// The base class for all IRepository implementations which may directly connect to database.
  /// </summary>
  public abstract class RepositoryBase : IRepository
  {
    /// <summary>
    /// The _isDisposed field.
    /// </summary>
    private bool _isDisposed = false;

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
    /// Gets or sets the hibernate ISession object.
    /// </summary>
    public ISession CurrentSession { get; set; }

    /// <summary>
    /// Gets the database transaction.
    /// </summary>
    public ITransaction Transaction { get; protected set; }

    /// <summary>
    /// Is in active transaction.
    /// </summary>
    public bool IsInTransaction => this.Transaction?.IsActive == true;

    public void Dispose()
    {
      this.Dispose(true);
      System.GC.SuppressFinalize(this);
    }

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
      ////this.OnEntityInserting(entity);

      this.CurrentSession.Save(entity);

      return entity;
    }

    /// <summary>
    /// Saves an entity.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="entity">The entity.</param>
    /// <returns>The saved entity.</returns>
    public virtual async Task<T> SaveAsync<T>(T entity) where T : class
    {
      await this.CurrentSession.SaveAsync(entity);

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
    /// Saves or updates an entity.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="entity">The entity.</param>
    /// <returns>The saved or updated entity.</returns>
    public virtual async Task<T> SaveOrUpdateAsync<T>(T entity) where T : class
    {
      await this.CurrentSession.SaveOrUpdateAsync(entity);

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
    /// Updates an entity.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="entity">The entity.</param>
    /// <returns>The updated entity.</returns>
    public virtual async Task<T> UpdateAsync<T>(T entity) where T : class
    {
      await this.CurrentSession.UpdateAsync(entity);

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
    /// Gets an entity by id.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="id">The id value.</param>
    /// <returns>The found entity. Returns null if nothing is found.</returns>
    public virtual async Task<T> LookupByIdAsync<T>(object id) where T : class
    {
      var entity = await this.CurrentSession.GetAsync<T>(id);

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
    /// Deletes an entity and returns whether the operation is successful.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="entity">The entity</param>
    public virtual async Task DeleteAsync<T>(T entity) where T : class
    {
      await this.CurrentSession.DeleteAsync(entity);
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
    /// Deletes an entity by id.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="id">The id value.</param>
    /// <returns>The deleted entity if the operation is successful. Otherwise it returns null.</returns>
    public virtual async Task<T> DeleteByIdAsync<T>(object id) where T : class
    {
      // find the entity first.
      var entity = await this.LookupByIdAsync<T>(id);

      if (entity != null)
      {
        // delete the entity once it's found.
        await this.DeleteAsync(entity);
      }

      // return the deleted entity.
      return entity;
    }

    /// <summary>
    /// Virtual delete entity.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="entity">The entity object.</param>
    /// <returns>The virtual deleted entity.</returns>
    public virtual T VirtualDelete<T>(T entity) where T : class, IAuditableEntity
    {
      entity.Active = false;
      return this.Update(entity);
    }

    /// <summary>
    /// Virtual delete entity.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="entity">The entity object.</param>
    /// <returns>The virtual deleted entity.</returns>
    public virtual async Task<T> VirtualDeleteAsync<T>(T entity) where T : class, IAuditableEntity
    {
      entity.Active = false;
      return await this.UpdateAsync(entity);
    }

    /// <summary>
    /// Commit transaction to database.
    /// </summary>
    public virtual void Commit()
    {
      this.Transaction.Commit();
      this.Transaction = null;
    }

    /// <summary>
    /// Commit transaction to database.
    /// </summary>
    public virtual async Task CommitAsync()
    {
      await this.Transaction.CommitAsync();
      this.Transaction = null;
    }

    /// <summary>
    /// Rollback transaction.
    /// </summary>
    public virtual void Rollback()
    {
      this.Transaction.Rollback();
      this.Transaction = null;
    }

    /// <summary>
    /// Rollback transaction.
    /// </summary>
    public virtual async Task RollbackAsync()
    {
      await this.Transaction.RollbackAsync();
      this.Transaction = null;
    }
    
    /// <summary>
    /// Start a transaction.
    /// </summary>
    public virtual IDisposable BeginTransaction()
    {
      if (this.IsInTransaction)
      {
        throw new Exception("There is already an existing active transaction!");
      }

      this.Transaction = this.CurrentSession.BeginTransaction();

      return new RepositoryTransactionWrapper(this, this.Transaction);
    }

    /// <summary>
    /// Start a transaction at isolationLevel.
    /// </summary>
    /// <param name="isolationLevel">The IsolationLevel.</param>
    public IDisposable BeginTransaction(IsolationLevel isolationLevel)
    {
      if (this.IsInTransaction)
      {
        throw new Exception("There is already an existing active transaction!");
      }

      this.Transaction = this.CurrentSession.BeginTransaction(isolationLevel);

      return new RepositoryTransactionWrapper(this, this.Transaction);
    }

    /// <summary>
    /// Refresh entity
    /// </summary>
    public void Refresh<T>(T entity) where T : class
    {
      this.CurrentSession.Refresh(entity);
    }

    /// <summary>
    /// Refresh entity
    /// </summary>
    public async Task RefreshAsync<T>(T entity) where T : class
    {
      await this.CurrentSession.RefreshAsync(entity);
    }

    /// <summary>
    /// Clear current session.
    /// </summary>
    public void Clear()
    {
      this.CurrentSession.Clear();
    }

    /// <summary>
    /// Flush current session.
    /// </summary>
    public void Flush()
    {
      this.CurrentSession.Flush();
    }

    /// <summary>
    /// Flush current session.
    /// </summary>
    public async Task FlushAsync()
    {
      await this.CurrentSession.FlushAsync();
    }

    /// <summary>
    /// Gets or sets current user id.
    /// </summary>
    public int? CurrentUserId { get; set; }

    protected virtual void Dispose(bool disposing)
    {
      if (!this._isDisposed)
      {
        if (disposing)
        {
          try
          {
            if (this.IsInTransaction)
            {
              this.Transaction.Rollback();
            }
          }
          catch (Exception ex)
          {
            Trace.TraceError(ex.ToString());
          }

          this.CurrentSession?.Dispose();
        }

        // There are no unmanaged resources to release, but
        // if we add them, they need to be released here.
      }

      this._isDisposed = true;
    }
  }
}