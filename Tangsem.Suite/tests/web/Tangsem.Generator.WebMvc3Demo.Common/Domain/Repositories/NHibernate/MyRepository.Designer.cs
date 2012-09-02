using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Data.Domain;
using Tangsem.NHibernate.Domain;
using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities;

namespace Tangsem.Generator.WebMvc3Demo.Common.Domain.Repositories.NHibernate
{ 
  /// <summary>
  /// The MyRepository class.
  /// </summary>
  public partial class MyRepository : RepositoryBase, IMyRepository
  {

    
    /// <summary>
    /// The IQueryable for Countries.
    /// </summary>
    public virtual IQueryable<Country> Countries
    {
      get
      {
        return this.GetEntities<Country>();
      }
    }

    
    
    /// <summary>
    /// The IQueryable for States.
    /// </summary>
    public virtual IQueryable<State> States
    {
      get
      {
        return this.GetEntities<State>();
      }
    }

    
    
    /// <summary>
    /// The IQueryable for VStates.
    /// </summary>
    public virtual IQueryable<VState> VStates
    {
      get
      {
        return this.GetEntities<VState>();
      }
    }

    
    
    /// <summary>
    /// The IQueryable for Categories.
    /// </summary>
    public virtual IQueryable<Category> Categories
    {
      get
      {
        return this.GetEntities<Category>();
      }
    }

        
    

    
    /// <summary>
    /// Get Country by primary key.
    /// </summary>
    public virtual Country LookupCountryById(int id)
    {
      return this.LookupById<Country>(id);
    }
    
    /// <summary>
    /// Delete Country by primary key.
    /// </summary>
    public virtual Country DeleteCountryById(int id)
    {
      return this.DeleteById<Country>(id);
    }
    
    /// <summary>
    /// Save a new Country instance.
    /// </summary>
    public virtual Country SaveCountry(Country country)
    {
      return this.Save<Country>(country);
    }
    
    /// <summary>
    /// Update an existing Country instance.
    /// </summary>
    public virtual Country UpdateCountry(Country country)
    {
      return this.Update<Country>(country);
    }
    
    /// <summary>
    /// Save or update an existing Country instance.
    /// </summary>
    public virtual Country SaveOrUpdateCountry(Country country)
    {
      return this.SaveOrUpdate<Country>(country);
    }

    
    
    /// <summary>
    /// Get State by primary key.
    /// </summary>
    public virtual State LookupStateById(int id)
    {
      return this.LookupById<State>(id);
    }
    
    /// <summary>
    /// Delete State by primary key.
    /// </summary>
    public virtual State DeleteStateById(int id)
    {
      return this.DeleteById<State>(id);
    }
    
    /// <summary>
    /// Save a new State instance.
    /// </summary>
    public virtual State SaveState(State state)
    {
      return this.Save<State>(state);
    }
    
    /// <summary>
    /// Update an existing State instance.
    /// </summary>
    public virtual State UpdateState(State state)
    {
      return this.Update<State>(state);
    }
    
    /// <summary>
    /// Save or update an existing State instance.
    /// </summary>
    public virtual State SaveOrUpdateState(State state)
    {
      return this.SaveOrUpdate<State>(state);
    }

    
    
    /// <summary>
    /// Get Category by primary key.
    /// </summary>
    public virtual Category LookupCategoryById(int id)
    {
      return this.LookupById<Category>(id);
    }
    
    /// <summary>
    /// Delete Category by primary key.
    /// </summary>
    public virtual Category DeleteCategoryById(int id)
    {
      return this.DeleteById<Category>(id);
    }
    
    /// <summary>
    /// Save a new Category instance.
    /// </summary>
    public virtual Category SaveCategory(Category category)
    {
      return this.Save<Category>(category);
    }
    
    /// <summary>
    /// Update an existing Category instance.
    /// </summary>
    public virtual Category UpdateCategory(Category category)
    {
      return this.Update<Category>(category);
    }
    
    /// <summary>
    /// Save or update an existing Category instance.
    /// </summary>
    public virtual Category SaveOrUpdateCategory(Category category)
    {
      return this.SaveOrUpdate<Category>(category);
    }

    
  }
}