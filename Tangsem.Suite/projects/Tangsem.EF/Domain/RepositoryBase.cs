using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Transactions;

using Tangsem.Common.Entities;
using Tangsem.Data.Domain;

using IsolationLevel = System.Data.IsolationLevel;

namespace Tangsem.EF.Domain
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
    /// Constructor with currentDbContext as param.
    /// </summary>
    /// <param name="currentDbContext">The current DbContext.</param>
    protected RepositoryBase(DbContext currentDbContext)
    {
      this.CurrentDbContext = currentDbContext;
    }

    /// <summary>
    /// Gets or sets the hiberante ISession object.
    /// </summary>
    public DbContext CurrentDbContext { get; set; }

    public bool IsInTransaction
    {
      get
      {
        return false;
      }
    }

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
      return this.CurrentDbContext.Set<T>();
    }

    /// <summary>
    /// Saves an entity.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="entity">The entity.</param>
    /// <returns>The saved entity.</returns>
    public virtual T Save<T>(T entity) where T : class
    {
      this.CurrentDbContext.Set<T>().Add(entity);

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
      if (this.CurrentDbContext.Entry(entity).State == EntityState.Detached)
      {
        this.CurrentDbContext.Set<T>().Attach(entity);
      }
      else
      {
        this.CurrentDbContext.Set<T>().Add(entity);
      }

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
      this.CurrentDbContext.Set<T>().Attach(entity);

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
      var entity = this.CurrentDbContext.Set<T>().Find(id);

      return entity;
    }

    /// <summary>
    /// Deletes an entity and returns whether the operation is successful.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="entity">The entity</param>
    public virtual void Delete<T>(T entity) where T : class
    {
      this.CurrentDbContext.Set<T>().Remove(entity);
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
    /// Virutal delete entity.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="entity">The enitity object.</param>
    /// <returns>The virtual deleted entity.</returns>
    public virtual T VirtualDelete<T>(T entity) where T : class, IAuditableEntity
    {
      entity.Active = false;
      return this.Update(entity);
    }

    /// <summary>
    /// Commit transaction to database.
    /// </summary>
    public virtual void Commit()
    {
      foreach (var entry in this.CurrentDbContext.ChangeTracker.Entries())
      {
        var ae = entry.Entity as IAuditableEntity;

        if (ae != null)
        {
          if (entry.State == EntityState.Added)
          {
            ae.CreatedById = this.CurrentUserId;
            ae.CreatedTime = DateTime.UtcNow;

            if (!ae.Active.HasValue)
            {
              ae.Active = true;
            }
          }
          else if (entry.State == EntityState.Modified)
          {
            ae.ModifiedById = this.CurrentUserId;
            ae.ModifiedTime = DateTime.UtcNow;
          }
        }
      }

      using (var scope = new TransactionScope())
      {
        this.CurrentDbContext.SaveChanges();
        scope.Complete();
      }
    }

    /// <summary>
    /// Rollback transaction.
    /// </summary>
    public virtual void Rollback()
    {
      // do nothing.
    }

    /// <summary>
    /// Start a transaction.
    /// </summary>
    public virtual void BeginTransaction()
    {
      // do nothing.
    }

    /// <summary>
    /// Start a transaction at isolationLevel.
    /// </summary>
    /// <param name="isolationLevel">The IsolationLevel.</param>
    public void BeginTransaction(IsolationLevel isolationLevel)
    {
      // do nothing.
    }

    /// <summary>
    /// Gets or sets current user id.
    /// </summary>
    public int? CurrentUserId { get; set; }

    public void Refresh<T>(T entity) where T : class
    {
      this.CurrentDbContext.Entry(entity).Reload();
    }

    public void Clear()
    {
      // https://stackoverflow.com/questions/27423059/how-do-i-clear-tracked-entities-in-entity-framework
      var changedEntriesCopy = this.CurrentDbContext.ChangeTracker.Entries()
        .Where(e => e.State == EntityState.Added ||
                    e.State == EntityState.Modified ||
                    e.State == EntityState.Deleted).ToList();

      foreach (var entity in changedEntriesCopy)
      {
        this.CurrentDbContext.Entry(entity.Entity).State = EntityState.Detached;
      }
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!_isDisposed)
      {
        if (disposing)
        {
          if (this.CurrentDbContext != null)
          {
            this.CurrentDbContext.Dispose();
          }
        }

        // There are no unmanaged resources to release, but
        // if we add them, they need to be released here.
      }
      _isDisposed = true;
    }
  }
}