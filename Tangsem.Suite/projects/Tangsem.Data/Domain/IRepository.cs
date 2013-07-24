using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Common.Entities;

namespace Tangsem.Data.Domain
{
  /// <summary>
  /// The repository interface.
  /// </summary>
  public interface IRepository : IDisposable
  {
    /// <summary>
    /// Gets the entity query by entity type.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <returns>The entity query by entity type.</returns>
    IQueryable<T> GetEntities<T>() where T : class;

    /// <summary>
    /// Saves an entity.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="entity">The entity.</param>
    /// <returns>The saved entity.</returns>
    T Save<T>(T entity) where T : class;

    /// <summary>
    /// Saves or updates an entity.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="entity">The entity.</param>
    /// <returns>The saved or updated entity.</returns>
    T SaveOrUpdate<T>(T entity) where T : class;

    /// <summary>
    /// Updates an entity.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="entity">The entity.</param>
    /// <returns>The updated entity.</returns>
    T Update<T>(T entity) where T : class;

    /// <summary>
    /// Gets an entity by id.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="id">The id value.</param>
    /// <returns>The found entity. Returns null if nothing is found.</returns>
    T LookupById<T>(object id) where T : class;

    /// <summary>
    /// Deletes an entity and returns whether the operation is successful.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="entity">The entity</param>
    void Delete<T>(T entity) where T : class;

    /// <summary>
    /// Deletes an entity by id.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="id">The id value.</param>
    /// <returns>The deleted entity if the operation is successful. Otherwise it returns null.</returns>
    T DeleteById<T>(object id) where T : class;

    /// <summary>
    /// Virutal delete entity.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="entity">The enitity object.</param>
    /// <returns>The virtual deleted entity.</returns>
    T VirtualDelete<T>(T entity) where T : class, IAuditableEntity;

    /// <summary>
    /// Commit transaction to database.
    /// </summary>
    void Commit();

    /// <summary>
    /// Rollback transaction.
    /// </summary>
    void Rollback();

    /// <summary>
    /// Start a transaction.
    /// </summary>
    void BeginTransaction();

    /// <summary>
    /// Start a transaction at isolationLevel.
    /// </summary>
    /// <param name="isolationLevel">The IsolationLevel.</param>
    void BeginTransaction(IsolationLevel isolationLevel);

    /// <summary>
    /// Gets or sets current user id.
    /// </summary>
    int? CurrentUserId { get; set; }
  }
}
