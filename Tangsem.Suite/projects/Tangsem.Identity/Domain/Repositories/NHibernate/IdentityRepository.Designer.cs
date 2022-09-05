using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Tangsem.Data.Domain;
using Tangsem.NHibernate.Domain;
using Tangsem.Identity.Domain.Entities;

namespace Tangsem.Identity.Domain.Repositories.NHibernate
{ 
  /// <summary>
  /// The IdentityRepository class.
  /// </summary>
  public partial class IdentityRepository : RepositoryBase, IIdentityRepository
  {

    
    /// <summary>
    /// The IQueryable for ApplicationUsers.
    /// </summary>
    public virtual IQueryable<ApplicationUser> ApplicationUsers
    {
      get
      {
        return this.GetEntities<ApplicationUser>();
      }
    }

    
    
    /// <summary>
    /// The IQueryable for AspNetUsers.
    /// </summary>
    public virtual IQueryable<AspNetUser> AspNetUsers
    {
      get
      {
        return this.GetEntities<AspNetUser>();
      }
    }

    
    
    /// <summary>
    /// The IQueryable for AspNetUserRoles.
    /// </summary>
    public virtual IQueryable<AspNetUserRole> AspNetUserRoles
    {
      get
      {
        return this.GetEntities<AspNetUserRole>();
      }
    }

    
    
    /// <summary>
    /// The IQueryable for AspNetRoles.
    /// </summary>
    public virtual IQueryable<AspNetRole> AspNetRoles
    {
      get
      {
        return this.GetEntities<AspNetRole>();
      }
    }

    
    
    /// <summary>
    /// The IQueryable for AspNetRoleClaims.
    /// </summary>
    public virtual IQueryable<AspNetRoleClaim> AspNetRoleClaims
    {
      get
      {
        return this.GetEntities<AspNetRoleClaim>();
      }
    }

    
    
    /// <summary>
    /// The IQueryable for AspNetUserClaims.
    /// </summary>
    public virtual IQueryable<AspNetUserClaim> AspNetUserClaims
    {
      get
      {
        return this.GetEntities<AspNetUserClaim>();
      }
    }

    
    
    /// <summary>
    /// The IQueryable for AspNetUserLogins.
    /// </summary>
    public virtual IQueryable<AspNetUserLogin> AspNetUserLogins
    {
      get
      {
        return this.GetEntities<AspNetUserLogin>();
      }
    }

    
    
    /// <summary>
    /// The IQueryable for AspNetUserTokens.
    /// </summary>
    public virtual IQueryable<AspNetUserToken> AspNetUserTokens
    {
      get
      {
        return this.GetEntities<AspNetUserToken>();
      }
    }

        
    

    
    /// <summary>
    /// Get ApplicationUser by primary key.
    /// </summary>
    public virtual ApplicationUser LookupApplicationUserById(int id)
    {
      return this.LookupById<ApplicationUser>(id);
    }
    
    /// <summary>
    /// Get ApplicationUser by primary key.
    /// </summary>
    public virtual async Task<ApplicationUser> LookupApplicationUserByIdAsync(int id)
    {
      return await this.LookupByIdAsync<ApplicationUser>(id);
    }
    
    /// <summary>
    /// Delete ApplicationUser by primary key.
    /// </summary>
    public virtual ApplicationUser DeleteApplicationUserById(int id)
    {
      return this.DeleteById<ApplicationUser>(id);
    }
    
    /// <summary>
    /// Delete ApplicationUser by primary key.
    /// </summary>
    public virtual async Task<ApplicationUser> DeleteApplicationUserByIdAsync(int id)
    {
      return await this.DeleteByIdAsync<ApplicationUser>(id);
    }
    
    /// <summary>
    /// Save a new ApplicationUser instance.
    /// </summary>
    public virtual ApplicationUser SaveApplicationUser(ApplicationUser applicationUser)
    {
      return this.Save<ApplicationUser>(applicationUser);
    }
    
    /// <summary>
    /// Save a new ApplicationUser instance.
    /// </summary>
    public virtual async Task<ApplicationUser> SaveApplicationUserAsync(ApplicationUser applicationUser)
    {
      return await this.SaveAsync<ApplicationUser>(applicationUser);
    }
    
    /// <summary>
    /// Update an existing ApplicationUser instance.
    /// </summary>
    public virtual ApplicationUser UpdateApplicationUser(ApplicationUser applicationUser)
    {
      return this.Update<ApplicationUser>(applicationUser);
    }
    
    /// <summary>
    /// Update an existing ApplicationUser instance.
    /// </summary>
    public virtual async Task<ApplicationUser> UpdateApplicationUserAsync(ApplicationUser applicationUser)
    {
      return await this.UpdateAsync<ApplicationUser>(applicationUser);
    }
    
    /// <summary>
    /// Save or update an existing ApplicationUser instance.
    /// </summary>
    public virtual ApplicationUser SaveOrUpdateApplicationUser(ApplicationUser applicationUser)
    {
      return this.SaveOrUpdate<ApplicationUser>(applicationUser);
    }
    
    /// <summary>
    /// Save or update an existing ApplicationUser instance.
    /// </summary>
    public virtual async Task<ApplicationUser> SaveOrUpdateApplicationUserAsync(ApplicationUser applicationUser)
    {
      return await this.SaveOrUpdateAsync<ApplicationUser>(applicationUser);
    }

    
    
    /// <summary>
    /// Get AspNetUser by primary key.
    /// </summary>
    public virtual AspNetUser LookupAspNetUserById(int id)
    {
      return this.LookupById<AspNetUser>(id);
    }
    
    /// <summary>
    /// Get AspNetUser by primary key.
    /// </summary>
    public virtual async Task<AspNetUser> LookupAspNetUserByIdAsync(int id)
    {
      return await this.LookupByIdAsync<AspNetUser>(id);
    }
    
    /// <summary>
    /// Delete AspNetUser by primary key.
    /// </summary>
    public virtual AspNetUser DeleteAspNetUserById(int id)
    {
      return this.DeleteById<AspNetUser>(id);
    }
    
    /// <summary>
    /// Delete AspNetUser by primary key.
    /// </summary>
    public virtual async Task<AspNetUser> DeleteAspNetUserByIdAsync(int id)
    {
      return await this.DeleteByIdAsync<AspNetUser>(id);
    }
    
    /// <summary>
    /// Save a new AspNetUser instance.
    /// </summary>
    public virtual AspNetUser SaveAspNetUser(AspNetUser aspNetUser)
    {
      return this.Save<AspNetUser>(aspNetUser);
    }
    
    /// <summary>
    /// Save a new AspNetUser instance.
    /// </summary>
    public virtual async Task<AspNetUser> SaveAspNetUserAsync(AspNetUser aspNetUser)
    {
      return await this.SaveAsync<AspNetUser>(aspNetUser);
    }
    
    /// <summary>
    /// Update an existing AspNetUser instance.
    /// </summary>
    public virtual AspNetUser UpdateAspNetUser(AspNetUser aspNetUser)
    {
      return this.Update<AspNetUser>(aspNetUser);
    }
    
    /// <summary>
    /// Update an existing AspNetUser instance.
    /// </summary>
    public virtual async Task<AspNetUser> UpdateAspNetUserAsync(AspNetUser aspNetUser)
    {
      return await this.UpdateAsync<AspNetUser>(aspNetUser);
    }
    
    /// <summary>
    /// Save or update an existing AspNetUser instance.
    /// </summary>
    public virtual AspNetUser SaveOrUpdateAspNetUser(AspNetUser aspNetUser)
    {
      return this.SaveOrUpdate<AspNetUser>(aspNetUser);
    }
    
    /// <summary>
    /// Save or update an existing AspNetUser instance.
    /// </summary>
    public virtual async Task<AspNetUser> SaveOrUpdateAspNetUserAsync(AspNetUser aspNetUser)
    {
      return await this.SaveOrUpdateAsync<AspNetUser>(aspNetUser);
    }

    
    
    /// <summary>
    /// Get AspNetUserRole by primary key.
    /// </summary>
    public virtual AspNetUserRole LookupAspNetUserRoleById(int id)
    {
      return this.LookupById<AspNetUserRole>(id);
    }
    
    /// <summary>
    /// Get AspNetUserRole by primary key.
    /// </summary>
    public virtual async Task<AspNetUserRole> LookupAspNetUserRoleByIdAsync(int id)
    {
      return await this.LookupByIdAsync<AspNetUserRole>(id);
    }
    
    /// <summary>
    /// Delete AspNetUserRole by primary key.
    /// </summary>
    public virtual AspNetUserRole DeleteAspNetUserRoleById(int id)
    {
      return this.DeleteById<AspNetUserRole>(id);
    }
    
    /// <summary>
    /// Delete AspNetUserRole by primary key.
    /// </summary>
    public virtual async Task<AspNetUserRole> DeleteAspNetUserRoleByIdAsync(int id)
    {
      return await this.DeleteByIdAsync<AspNetUserRole>(id);
    }
    
    /// <summary>
    /// Save a new AspNetUserRole instance.
    /// </summary>
    public virtual AspNetUserRole SaveAspNetUserRole(AspNetUserRole aspNetUserRole)
    {
      return this.Save<AspNetUserRole>(aspNetUserRole);
    }
    
    /// <summary>
    /// Save a new AspNetUserRole instance.
    /// </summary>
    public virtual async Task<AspNetUserRole> SaveAspNetUserRoleAsync(AspNetUserRole aspNetUserRole)
    {
      return await this.SaveAsync<AspNetUserRole>(aspNetUserRole);
    }
    
    /// <summary>
    /// Update an existing AspNetUserRole instance.
    /// </summary>
    public virtual AspNetUserRole UpdateAspNetUserRole(AspNetUserRole aspNetUserRole)
    {
      return this.Update<AspNetUserRole>(aspNetUserRole);
    }
    
    /// <summary>
    /// Update an existing AspNetUserRole instance.
    /// </summary>
    public virtual async Task<AspNetUserRole> UpdateAspNetUserRoleAsync(AspNetUserRole aspNetUserRole)
    {
      return await this.UpdateAsync<AspNetUserRole>(aspNetUserRole);
    }
    
    /// <summary>
    /// Save or update an existing AspNetUserRole instance.
    /// </summary>
    public virtual AspNetUserRole SaveOrUpdateAspNetUserRole(AspNetUserRole aspNetUserRole)
    {
      return this.SaveOrUpdate<AspNetUserRole>(aspNetUserRole);
    }
    
    /// <summary>
    /// Save or update an existing AspNetUserRole instance.
    /// </summary>
    public virtual async Task<AspNetUserRole> SaveOrUpdateAspNetUserRoleAsync(AspNetUserRole aspNetUserRole)
    {
      return await this.SaveOrUpdateAsync<AspNetUserRole>(aspNetUserRole);
    }

    
    
    /// <summary>
    /// Get AspNetRole by primary key.
    /// </summary>
    public virtual AspNetRole LookupAspNetRoleById(int id)
    {
      return this.LookupById<AspNetRole>(id);
    }
    
    /// <summary>
    /// Get AspNetRole by primary key.
    /// </summary>
    public virtual async Task<AspNetRole> LookupAspNetRoleByIdAsync(int id)
    {
      return await this.LookupByIdAsync<AspNetRole>(id);
    }
    
    /// <summary>
    /// Delete AspNetRole by primary key.
    /// </summary>
    public virtual AspNetRole DeleteAspNetRoleById(int id)
    {
      return this.DeleteById<AspNetRole>(id);
    }
    
    /// <summary>
    /// Delete AspNetRole by primary key.
    /// </summary>
    public virtual async Task<AspNetRole> DeleteAspNetRoleByIdAsync(int id)
    {
      return await this.DeleteByIdAsync<AspNetRole>(id);
    }
    
    /// <summary>
    /// Save a new AspNetRole instance.
    /// </summary>
    public virtual AspNetRole SaveAspNetRole(AspNetRole aspNetRole)
    {
      return this.Save<AspNetRole>(aspNetRole);
    }
    
    /// <summary>
    /// Save a new AspNetRole instance.
    /// </summary>
    public virtual async Task<AspNetRole> SaveAspNetRoleAsync(AspNetRole aspNetRole)
    {
      return await this.SaveAsync<AspNetRole>(aspNetRole);
    }
    
    /// <summary>
    /// Update an existing AspNetRole instance.
    /// </summary>
    public virtual AspNetRole UpdateAspNetRole(AspNetRole aspNetRole)
    {
      return this.Update<AspNetRole>(aspNetRole);
    }
    
    /// <summary>
    /// Update an existing AspNetRole instance.
    /// </summary>
    public virtual async Task<AspNetRole> UpdateAspNetRoleAsync(AspNetRole aspNetRole)
    {
      return await this.UpdateAsync<AspNetRole>(aspNetRole);
    }
    
    /// <summary>
    /// Save or update an existing AspNetRole instance.
    /// </summary>
    public virtual AspNetRole SaveOrUpdateAspNetRole(AspNetRole aspNetRole)
    {
      return this.SaveOrUpdate<AspNetRole>(aspNetRole);
    }
    
    /// <summary>
    /// Save or update an existing AspNetRole instance.
    /// </summary>
    public virtual async Task<AspNetRole> SaveOrUpdateAspNetRoleAsync(AspNetRole aspNetRole)
    {
      return await this.SaveOrUpdateAsync<AspNetRole>(aspNetRole);
    }

    
    
    /// <summary>
    /// Get AspNetRoleClaim by primary key.
    /// </summary>
    public virtual AspNetRoleClaim LookupAspNetRoleClaimById(int id)
    {
      return this.LookupById<AspNetRoleClaim>(id);
    }
    
    /// <summary>
    /// Get AspNetRoleClaim by primary key.
    /// </summary>
    public virtual async Task<AspNetRoleClaim> LookupAspNetRoleClaimByIdAsync(int id)
    {
      return await this.LookupByIdAsync<AspNetRoleClaim>(id);
    }
    
    /// <summary>
    /// Delete AspNetRoleClaim by primary key.
    /// </summary>
    public virtual AspNetRoleClaim DeleteAspNetRoleClaimById(int id)
    {
      return this.DeleteById<AspNetRoleClaim>(id);
    }
    
    /// <summary>
    /// Delete AspNetRoleClaim by primary key.
    /// </summary>
    public virtual async Task<AspNetRoleClaim> DeleteAspNetRoleClaimByIdAsync(int id)
    {
      return await this.DeleteByIdAsync<AspNetRoleClaim>(id);
    }
    
    /// <summary>
    /// Save a new AspNetRoleClaim instance.
    /// </summary>
    public virtual AspNetRoleClaim SaveAspNetRoleClaim(AspNetRoleClaim aspNetRoleClaim)
    {
      return this.Save<AspNetRoleClaim>(aspNetRoleClaim);
    }
    
    /// <summary>
    /// Save a new AspNetRoleClaim instance.
    /// </summary>
    public virtual async Task<AspNetRoleClaim> SaveAspNetRoleClaimAsync(AspNetRoleClaim aspNetRoleClaim)
    {
      return await this.SaveAsync<AspNetRoleClaim>(aspNetRoleClaim);
    }
    
    /// <summary>
    /// Update an existing AspNetRoleClaim instance.
    /// </summary>
    public virtual AspNetRoleClaim UpdateAspNetRoleClaim(AspNetRoleClaim aspNetRoleClaim)
    {
      return this.Update<AspNetRoleClaim>(aspNetRoleClaim);
    }
    
    /// <summary>
    /// Update an existing AspNetRoleClaim instance.
    /// </summary>
    public virtual async Task<AspNetRoleClaim> UpdateAspNetRoleClaimAsync(AspNetRoleClaim aspNetRoleClaim)
    {
      return await this.UpdateAsync<AspNetRoleClaim>(aspNetRoleClaim);
    }
    
    /// <summary>
    /// Save or update an existing AspNetRoleClaim instance.
    /// </summary>
    public virtual AspNetRoleClaim SaveOrUpdateAspNetRoleClaim(AspNetRoleClaim aspNetRoleClaim)
    {
      return this.SaveOrUpdate<AspNetRoleClaim>(aspNetRoleClaim);
    }
    
    /// <summary>
    /// Save or update an existing AspNetRoleClaim instance.
    /// </summary>
    public virtual async Task<AspNetRoleClaim> SaveOrUpdateAspNetRoleClaimAsync(AspNetRoleClaim aspNetRoleClaim)
    {
      return await this.SaveOrUpdateAsync<AspNetRoleClaim>(aspNetRoleClaim);
    }

    
    
    /// <summary>
    /// Get AspNetUserClaim by primary key.
    /// </summary>
    public virtual AspNetUserClaim LookupAspNetUserClaimById(int id)
    {
      return this.LookupById<AspNetUserClaim>(id);
    }
    
    /// <summary>
    /// Get AspNetUserClaim by primary key.
    /// </summary>
    public virtual async Task<AspNetUserClaim> LookupAspNetUserClaimByIdAsync(int id)
    {
      return await this.LookupByIdAsync<AspNetUserClaim>(id);
    }
    
    /// <summary>
    /// Delete AspNetUserClaim by primary key.
    /// </summary>
    public virtual AspNetUserClaim DeleteAspNetUserClaimById(int id)
    {
      return this.DeleteById<AspNetUserClaim>(id);
    }
    
    /// <summary>
    /// Delete AspNetUserClaim by primary key.
    /// </summary>
    public virtual async Task<AspNetUserClaim> DeleteAspNetUserClaimByIdAsync(int id)
    {
      return await this.DeleteByIdAsync<AspNetUserClaim>(id);
    }
    
    /// <summary>
    /// Save a new AspNetUserClaim instance.
    /// </summary>
    public virtual AspNetUserClaim SaveAspNetUserClaim(AspNetUserClaim aspNetUserClaim)
    {
      return this.Save<AspNetUserClaim>(aspNetUserClaim);
    }
    
    /// <summary>
    /// Save a new AspNetUserClaim instance.
    /// </summary>
    public virtual async Task<AspNetUserClaim> SaveAspNetUserClaimAsync(AspNetUserClaim aspNetUserClaim)
    {
      return await this.SaveAsync<AspNetUserClaim>(aspNetUserClaim);
    }
    
    /// <summary>
    /// Update an existing AspNetUserClaim instance.
    /// </summary>
    public virtual AspNetUserClaim UpdateAspNetUserClaim(AspNetUserClaim aspNetUserClaim)
    {
      return this.Update<AspNetUserClaim>(aspNetUserClaim);
    }
    
    /// <summary>
    /// Update an existing AspNetUserClaim instance.
    /// </summary>
    public virtual async Task<AspNetUserClaim> UpdateAspNetUserClaimAsync(AspNetUserClaim aspNetUserClaim)
    {
      return await this.UpdateAsync<AspNetUserClaim>(aspNetUserClaim);
    }
    
    /// <summary>
    /// Save or update an existing AspNetUserClaim instance.
    /// </summary>
    public virtual AspNetUserClaim SaveOrUpdateAspNetUserClaim(AspNetUserClaim aspNetUserClaim)
    {
      return this.SaveOrUpdate<AspNetUserClaim>(aspNetUserClaim);
    }
    
    /// <summary>
    /// Save or update an existing AspNetUserClaim instance.
    /// </summary>
    public virtual async Task<AspNetUserClaim> SaveOrUpdateAspNetUserClaimAsync(AspNetUserClaim aspNetUserClaim)
    {
      return await this.SaveOrUpdateAsync<AspNetUserClaim>(aspNetUserClaim);
    }

    
    
    /// <summary>
    /// Get AspNetUserLogin by primary key.
    /// </summary>
    public virtual AspNetUserLogin LookupAspNetUserLoginById(int id)
    {
      return this.LookupById<AspNetUserLogin>(id);
    }
    
    /// <summary>
    /// Get AspNetUserLogin by primary key.
    /// </summary>
    public virtual async Task<AspNetUserLogin> LookupAspNetUserLoginByIdAsync(int id)
    {
      return await this.LookupByIdAsync<AspNetUserLogin>(id);
    }
    
    /// <summary>
    /// Delete AspNetUserLogin by primary key.
    /// </summary>
    public virtual AspNetUserLogin DeleteAspNetUserLoginById(int id)
    {
      return this.DeleteById<AspNetUserLogin>(id);
    }
    
    /// <summary>
    /// Delete AspNetUserLogin by primary key.
    /// </summary>
    public virtual async Task<AspNetUserLogin> DeleteAspNetUserLoginByIdAsync(int id)
    {
      return await this.DeleteByIdAsync<AspNetUserLogin>(id);
    }
    
    /// <summary>
    /// Save a new AspNetUserLogin instance.
    /// </summary>
    public virtual AspNetUserLogin SaveAspNetUserLogin(AspNetUserLogin aspNetUserLogin)
    {
      return this.Save<AspNetUserLogin>(aspNetUserLogin);
    }
    
    /// <summary>
    /// Save a new AspNetUserLogin instance.
    /// </summary>
    public virtual async Task<AspNetUserLogin> SaveAspNetUserLoginAsync(AspNetUserLogin aspNetUserLogin)
    {
      return await this.SaveAsync<AspNetUserLogin>(aspNetUserLogin);
    }
    
    /// <summary>
    /// Update an existing AspNetUserLogin instance.
    /// </summary>
    public virtual AspNetUserLogin UpdateAspNetUserLogin(AspNetUserLogin aspNetUserLogin)
    {
      return this.Update<AspNetUserLogin>(aspNetUserLogin);
    }
    
    /// <summary>
    /// Update an existing AspNetUserLogin instance.
    /// </summary>
    public virtual async Task<AspNetUserLogin> UpdateAspNetUserLoginAsync(AspNetUserLogin aspNetUserLogin)
    {
      return await this.UpdateAsync<AspNetUserLogin>(aspNetUserLogin);
    }
    
    /// <summary>
    /// Save or update an existing AspNetUserLogin instance.
    /// </summary>
    public virtual AspNetUserLogin SaveOrUpdateAspNetUserLogin(AspNetUserLogin aspNetUserLogin)
    {
      return this.SaveOrUpdate<AspNetUserLogin>(aspNetUserLogin);
    }
    
    /// <summary>
    /// Save or update an existing AspNetUserLogin instance.
    /// </summary>
    public virtual async Task<AspNetUserLogin> SaveOrUpdateAspNetUserLoginAsync(AspNetUserLogin aspNetUserLogin)
    {
      return await this.SaveOrUpdateAsync<AspNetUserLogin>(aspNetUserLogin);
    }

    
    
    /// <summary>
    /// Get AspNetUserToken by primary key.
    /// </summary>
    public virtual AspNetUserToken LookupAspNetUserTokenById(int id)
    {
      return this.LookupById<AspNetUserToken>(id);
    }
    
    /// <summary>
    /// Get AspNetUserToken by primary key.
    /// </summary>
    public virtual async Task<AspNetUserToken> LookupAspNetUserTokenByIdAsync(int id)
    {
      return await this.LookupByIdAsync<AspNetUserToken>(id);
    }
    
    /// <summary>
    /// Delete AspNetUserToken by primary key.
    /// </summary>
    public virtual AspNetUserToken DeleteAspNetUserTokenById(int id)
    {
      return this.DeleteById<AspNetUserToken>(id);
    }
    
    /// <summary>
    /// Delete AspNetUserToken by primary key.
    /// </summary>
    public virtual async Task<AspNetUserToken> DeleteAspNetUserTokenByIdAsync(int id)
    {
      return await this.DeleteByIdAsync<AspNetUserToken>(id);
    }
    
    /// <summary>
    /// Save a new AspNetUserToken instance.
    /// </summary>
    public virtual AspNetUserToken SaveAspNetUserToken(AspNetUserToken aspNetUserToken)
    {
      return this.Save<AspNetUserToken>(aspNetUserToken);
    }
    
    /// <summary>
    /// Save a new AspNetUserToken instance.
    /// </summary>
    public virtual async Task<AspNetUserToken> SaveAspNetUserTokenAsync(AspNetUserToken aspNetUserToken)
    {
      return await this.SaveAsync<AspNetUserToken>(aspNetUserToken);
    }
    
    /// <summary>
    /// Update an existing AspNetUserToken instance.
    /// </summary>
    public virtual AspNetUserToken UpdateAspNetUserToken(AspNetUserToken aspNetUserToken)
    {
      return this.Update<AspNetUserToken>(aspNetUserToken);
    }
    
    /// <summary>
    /// Update an existing AspNetUserToken instance.
    /// </summary>
    public virtual async Task<AspNetUserToken> UpdateAspNetUserTokenAsync(AspNetUserToken aspNetUserToken)
    {
      return await this.UpdateAsync<AspNetUserToken>(aspNetUserToken);
    }
    
    /// <summary>
    /// Save or update an existing AspNetUserToken instance.
    /// </summary>
    public virtual AspNetUserToken SaveOrUpdateAspNetUserToken(AspNetUserToken aspNetUserToken)
    {
      return this.SaveOrUpdate<AspNetUserToken>(aspNetUserToken);
    }
    
    /// <summary>
    /// Save or update an existing AspNetUserToken instance.
    /// </summary>
    public virtual async Task<AspNetUserToken> SaveOrUpdateAspNetUserTokenAsync(AspNetUserToken aspNetUserToken)
    {
      return await this.SaveOrUpdateAsync<AspNetUserToken>(aspNetUserToken);
    }

    
  }
}