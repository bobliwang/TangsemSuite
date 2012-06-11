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
  public class EntityServiceBase<TEntity> : IEntityService<TEntity>
    where TEntity : class
  {

    /// <summary>
    /// Creates a model without repository.
    /// </summary>
    public EntityServiceBase()
    {
    }

    /// <summary>
    /// Creates a model with repository.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public EntityServiceBase(IRepository repository)
    {
      this.Repository = repository;
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

  	/// <summary>
    /// The repository.
    /// </summary>
    public virtual IRepository Repository { get; private set; }

    /// <summary>
    /// Saves an entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>The saved entity.</returns>
    public virtual TEntity Save(TEntity entity)
    {
      return this.Repository.Save(entity);
    }

    /// <summary>
    /// Saves or updates an entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>The saved or updated entity.</returns>
    public virtual TEntity SaveOrUpdate(TEntity entity)
    {
      return this.Repository.SaveOrUpdate(entity);
    }

    /// <summary>
    /// Updates an entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>The updated entity.</returns>
    public virtual TEntity Update(TEntity entity)
    {
      return this.Repository.Update(entity);
    }

    /// <summary>
    /// Gets an entity by id.
    /// </summary>
    /// <param name="id">The id value.</param>
    /// <returns>The found entity. Returns null if nothing is found.</returns>
    public virtual TEntity LookupById(object id)
    {
      return this.Repository.LookupById<TEntity>(id);
    }

    /// <summary>
    /// Deletes an entity and returns whether the operation is successful.
    /// </summary>
    /// <param name="entity">The entity</param>
    public virtual void Delete(TEntity entity)
    {
      this.Repository.Delete(entity);
    }

    /// <summary>
    /// Deletes an entity by id.
    /// </summary>
    /// <param name="id">The id value.</param>
    /// <returns>The deleted entity if the operation is successful. Otherwise it returns null.</returns>
    public virtual TEntity DeleteById(object id)
    {
      return this.Repository.DeleteById<TEntity>(id);
    }

    /// <summary>
    /// The count.
    /// </summary>
    /// <param name="expression">
    /// The criterion expression.
    /// </param>
    /// <returns>
    /// The count.
    /// </returns>
    public virtual int Count(Expression<Func<TEntity, bool>> expression)
    {
      return this.Repository.GetEntities<TEntity>().Count(expression);
    }

  	/// <summary> Get paged entity list. </summary>
    /// <param name="firstResult"> The first result. </param>
    /// <param name="maxResults"> The max results. </param>
    /// <param name="expression"> The criterion expression. </param>
    /// <param name="sortBys"> The sortBys. </param>
    /// <returns> The entities. </returns>
    public virtual IList<TEntity> GetPagedEntities(int firstResult, int maxResults, Expression<Func<TEntity, bool>> expression = null, IEnumerable<SortBy<TEntity>> sortBys = null)
    {
      var query = this.Repository.GetEntities<TEntity>();

      // add criterion if expression is not null.
      if (expression != null)
      {
        query = query.Where(expression);
      }

      // no orders are presented, skip order sorting processing.
      if (sortBys == null || !sortBys.Any())
      {
        return query.Skip(firstResult).Take(maxResults).ToList();
      }

      // do the first sort.
      var firstSortBy = sortBys.First();
      var sortQry = firstSortBy.IsDescending
                      ? query.OrderByDescending(firstSortBy.PropertyExpression)
                      : query.OrderBy(firstSortBy.PropertyExpression);

      foreach (var sortBy in sortBys.Skip(1))
      {
        sortQry = sortBy.IsDescending
                    ? sortQry.ThenByDescending(sortBy.PropertyExpression)
                    : sortQry.ThenBy(sortBy.PropertyExpression);
      }

      return sortQry.Skip(firstResult).Take(maxResults).ToList();
    }

    /// <summary> Get entity list. </summary>
    /// <param name="expression"> The criterion expression. </param>
    /// <param name="sortBys"> The sortBys. </param>
    /// <returns> The entities. </returns>
    public virtual IList<TEntity> GetEntities(Expression<Func<TEntity, bool>> expression = null, IEnumerable<SortBy<TEntity>> sortBys = null)
    {
      return this.GetPagedEntities(0, int.MaxValue, expression, sortBys);
    }

    /// <summary>
    /// Commit transaction to database.
    /// </summary>
    public virtual void Commit()
    {
      this.Repository.Commit();
    }

    /// <summary>
    /// Rollback transaction.
    /// </summary>
    public virtual void Rollback()
    {
      this.Repository.Rollback();
    }

    /// <summary>
    /// Start a transaction.
    /// </summary>
    public virtual void BeginTransaction()
    {
      this.Repository.BeginTransaction();
    }
  }
}