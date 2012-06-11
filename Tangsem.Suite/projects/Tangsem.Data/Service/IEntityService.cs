using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Tangsem.Data.Domain;

namespace Tangsem.Data.Service
{
  public interface IEntityService<T> where T : class
  {
    /// <summary>
    /// Gets the repository.
    /// </summary>
    IRepository Repository { get; }

    /// <summary>
    /// Saves an entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>The saved entity.</returns>
    T Save(T entity);

    /// <summary>
    /// Saves or updates an entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>The saved or updated entity.</returns>
    T SaveOrUpdate(T entity);

    /// <summary>
    /// Updates an entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>The updated entity.</returns>
    T Update(T entity);

    /// <summary>
    /// Gets an entity by id.
    /// </summary>
    /// <param name="id">The id value.</param>
    /// <returns>The found entity. Returns null if nothing is found.</returns>
    T LookupById(object id);

    /// <summary>
    /// Deletes an entity and returns whether the operation is successful.
    /// </summary>
    /// <param name="entity">The entity</param>
    void Delete(T entity);

    /// <summary>
    /// Deletes an entity by id.
    /// </summary>
    /// <param name="id">The id value.</param>
    /// <returns>The deleted entity if the operation is successful. Otherwise it returns null.</returns>
    T DeleteById(object id);

    /// <summary>
    /// The count.
    /// </summary>
    /// <param name="expression">
    /// The criterion expression.
    /// </param>
    /// <returns>
    /// The count value.
    /// </returns>
    int Count(Expression<Func<T, bool>> expression);

    /// <summary> Get paged entity list. </summary>
    /// <param name="firstResult"> The first result. </param>
    /// <param name="maxResults"> The max results. </param>
    /// <param name="expression"> The criterion expression. </param>
    /// <param name="sortBys"> The orders. </param>
    /// <returns> The entities. </returns>
    IList<T> GetPagedEntities(int firstResult, int maxResults, Expression<Func<T, bool>> expression = null, IEnumerable<SortBy<T>> sortBys = null);

    /// <summary> Get entity list. </summary>
    /// <param name="expression"> The criterion expression. </param>
    /// <param name="sortBys"> The orders. </param>
    /// <returns> The entities. </returns>
    IList<T> GetEntities(Expression<Func<T, bool>> expression = null, IEnumerable<SortBy<T>> sortBys = null);

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
  }
}
