using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

using Tangsem.Data.Domain;

using Tangsem.Identity.Domain.Entities;

namespace Tangsem.Identity.Domain.Repositories
{
	/// <summary>
	/// The IIdentityRepository interface.
	/// </summary>
	public partial interface IIdentityRepository : IRepository
	{

		
		/// <summary>
		/// Maps to database table/view ApplicationUser. The IQueryable for ApplicationUsers.
		/// </summary>
		IQueryable<ApplicationUser> ApplicationUsers { get; }

		
		
		/// <summary>
		/// Maps to database table/view AspNetUser. The IQueryable for AspNetUsers.
		/// </summary>
		IQueryable<AspNetUser> AspNetUsers { get; }

		
		
		/// <summary>
		/// Maps to database table/view AspNetUserRole. The IQueryable for AspNetUserRoles.
		/// </summary>
		IQueryable<AspNetUserRole> AspNetUserRoles { get; }

		
		
		/// <summary>
		/// Maps to database table/view AspNetRole. The IQueryable for AspNetRoles.
		/// </summary>
		IQueryable<AspNetRole> AspNetRoles { get; }

		
		
		/// <summary>
		/// Maps to database table/view AspNetRoleClaim. The IQueryable for AspNetRoleClaims.
		/// </summary>
		IQueryable<AspNetRoleClaim> AspNetRoleClaims { get; }

		
		
		/// <summary>
		/// Maps to database table/view AspNetUserClaim. The IQueryable for AspNetUserClaims.
		/// </summary>
		IQueryable<AspNetUserClaim> AspNetUserClaims { get; }

		
		
		/// <summary>
		/// Maps to database table/view AspNetUserLogin. The IQueryable for AspNetUserLogins.
		/// </summary>
		IQueryable<AspNetUserLogin> AspNetUserLogins { get; }

		
		
		/// <summary>
		/// Maps to database table/view AspNetUserToken. The IQueryable for AspNetUserTokens.
		/// </summary>
		IQueryable<AspNetUserToken> AspNetUserTokens { get; }

				
		

		
		/// <summary>
		/// Get ApplicationUser by primary key.
		/// </summary>
		ApplicationUser LookupApplicationUserById(int id);

    /// <summary>
    /// Get ApplicationUser by primary key.
    /// </summary>
    System.Threading.Tasks.Task<ApplicationUser> LookupApplicationUserByIdAsync(int id);

		/// <summary>
		/// Delete ApplicationUser by primary key.
		/// </summary>
		ApplicationUser DeleteApplicationUserById(int id);
		
    /// <summary>
    /// Delete ApplicationUser by primary key.
    /// </summary>
    System.Threading.Tasks.Task<ApplicationUser> DeleteApplicationUserByIdAsync(int id);

    /// <summary>
		/// Save a new ApplicationUser instance.
		/// </summary>
    ApplicationUser SaveApplicationUser(ApplicationUser applicationUser);
    
    /// <summary>
    /// Save a new ApplicationUser instance.
    /// </summary>
    System.Threading.Tasks.Task<ApplicationUser> SaveApplicationUserAsync(ApplicationUser applicationUser);
		
		/// <summary>
		/// Update an existing ApplicationUser instance.
		/// </summary>
    ApplicationUser UpdateApplicationUser(ApplicationUser applicationUser);
		
    /// <summary>
    /// Update an existing ApplicationUser instance.
    /// </summary>
    System.Threading.Tasks.Task<ApplicationUser> UpdateApplicationUserAsync(ApplicationUser applicationUser);
		
		/// <summary>
		/// Save or update an existing ApplicationUser instance.
		/// </summary>
		ApplicationUser SaveOrUpdateApplicationUser(ApplicationUser applicationUser);

    /// <summary>
		/// Save or update an existing ApplicationUser instance.
		/// </summary>
    System.Threading.Tasks.Task<ApplicationUser> SaveOrUpdateApplicationUserAsync(ApplicationUser applicationUser);

		
		
		/// <summary>
		/// Get AspNetUser by primary key.
		/// </summary>
		AspNetUser LookupAspNetUserById(int id);

    /// <summary>
    /// Get AspNetUser by primary key.
    /// </summary>
    System.Threading.Tasks.Task<AspNetUser> LookupAspNetUserByIdAsync(int id);

		/// <summary>
		/// Delete AspNetUser by primary key.
		/// </summary>
		AspNetUser DeleteAspNetUserById(int id);
		
    /// <summary>
    /// Delete AspNetUser by primary key.
    /// </summary>
    System.Threading.Tasks.Task<AspNetUser> DeleteAspNetUserByIdAsync(int id);

    /// <summary>
		/// Save a new AspNetUser instance.
		/// </summary>
    AspNetUser SaveAspNetUser(AspNetUser aspNetUser);
    
    /// <summary>
    /// Save a new AspNetUser instance.
    /// </summary>
    System.Threading.Tasks.Task<AspNetUser> SaveAspNetUserAsync(AspNetUser aspNetUser);
		
		/// <summary>
		/// Update an existing AspNetUser instance.
		/// </summary>
    AspNetUser UpdateAspNetUser(AspNetUser aspNetUser);
		
    /// <summary>
    /// Update an existing AspNetUser instance.
    /// </summary>
    System.Threading.Tasks.Task<AspNetUser> UpdateAspNetUserAsync(AspNetUser aspNetUser);
		
		/// <summary>
		/// Save or update an existing AspNetUser instance.
		/// </summary>
		AspNetUser SaveOrUpdateAspNetUser(AspNetUser aspNetUser);

    /// <summary>
		/// Save or update an existing AspNetUser instance.
		/// </summary>
    System.Threading.Tasks.Task<AspNetUser> SaveOrUpdateAspNetUserAsync(AspNetUser aspNetUser);

		
		
		/// <summary>
		/// Get AspNetUserRole by primary key.
		/// </summary>
		AspNetUserRole LookupAspNetUserRoleById(int id);

    /// <summary>
    /// Get AspNetUserRole by primary key.
    /// </summary>
    System.Threading.Tasks.Task<AspNetUserRole> LookupAspNetUserRoleByIdAsync(int id);

		/// <summary>
		/// Delete AspNetUserRole by primary key.
		/// </summary>
		AspNetUserRole DeleteAspNetUserRoleById(int id);
		
    /// <summary>
    /// Delete AspNetUserRole by primary key.
    /// </summary>
    System.Threading.Tasks.Task<AspNetUserRole> DeleteAspNetUserRoleByIdAsync(int id);

    /// <summary>
		/// Save a new AspNetUserRole instance.
		/// </summary>
    AspNetUserRole SaveAspNetUserRole(AspNetUserRole aspNetUserRole);
    
    /// <summary>
    /// Save a new AspNetUserRole instance.
    /// </summary>
    System.Threading.Tasks.Task<AspNetUserRole> SaveAspNetUserRoleAsync(AspNetUserRole aspNetUserRole);
		
		/// <summary>
		/// Update an existing AspNetUserRole instance.
		/// </summary>
    AspNetUserRole UpdateAspNetUserRole(AspNetUserRole aspNetUserRole);
		
    /// <summary>
    /// Update an existing AspNetUserRole instance.
    /// </summary>
    System.Threading.Tasks.Task<AspNetUserRole> UpdateAspNetUserRoleAsync(AspNetUserRole aspNetUserRole);
		
		/// <summary>
		/// Save or update an existing AspNetUserRole instance.
		/// </summary>
		AspNetUserRole SaveOrUpdateAspNetUserRole(AspNetUserRole aspNetUserRole);

    /// <summary>
		/// Save or update an existing AspNetUserRole instance.
		/// </summary>
    System.Threading.Tasks.Task<AspNetUserRole> SaveOrUpdateAspNetUserRoleAsync(AspNetUserRole aspNetUserRole);

		
		
		/// <summary>
		/// Get AspNetRole by primary key.
		/// </summary>
		AspNetRole LookupAspNetRoleById(int id);

    /// <summary>
    /// Get AspNetRole by primary key.
    /// </summary>
    System.Threading.Tasks.Task<AspNetRole> LookupAspNetRoleByIdAsync(int id);

		/// <summary>
		/// Delete AspNetRole by primary key.
		/// </summary>
		AspNetRole DeleteAspNetRoleById(int id);
		
    /// <summary>
    /// Delete AspNetRole by primary key.
    /// </summary>
    System.Threading.Tasks.Task<AspNetRole> DeleteAspNetRoleByIdAsync(int id);

    /// <summary>
		/// Save a new AspNetRole instance.
		/// </summary>
    AspNetRole SaveAspNetRole(AspNetRole aspNetRole);
    
    /// <summary>
    /// Save a new AspNetRole instance.
    /// </summary>
    System.Threading.Tasks.Task<AspNetRole> SaveAspNetRoleAsync(AspNetRole aspNetRole);
		
		/// <summary>
		/// Update an existing AspNetRole instance.
		/// </summary>
    AspNetRole UpdateAspNetRole(AspNetRole aspNetRole);
		
    /// <summary>
    /// Update an existing AspNetRole instance.
    /// </summary>
    System.Threading.Tasks.Task<AspNetRole> UpdateAspNetRoleAsync(AspNetRole aspNetRole);
		
		/// <summary>
		/// Save or update an existing AspNetRole instance.
		/// </summary>
		AspNetRole SaveOrUpdateAspNetRole(AspNetRole aspNetRole);

    /// <summary>
		/// Save or update an existing AspNetRole instance.
		/// </summary>
    System.Threading.Tasks.Task<AspNetRole> SaveOrUpdateAspNetRoleAsync(AspNetRole aspNetRole);

		
		
		/// <summary>
		/// Get AspNetRoleClaim by primary key.
		/// </summary>
		AspNetRoleClaim LookupAspNetRoleClaimById(int id);

    /// <summary>
    /// Get AspNetRoleClaim by primary key.
    /// </summary>
    System.Threading.Tasks.Task<AspNetRoleClaim> LookupAspNetRoleClaimByIdAsync(int id);

		/// <summary>
		/// Delete AspNetRoleClaim by primary key.
		/// </summary>
		AspNetRoleClaim DeleteAspNetRoleClaimById(int id);
		
    /// <summary>
    /// Delete AspNetRoleClaim by primary key.
    /// </summary>
    System.Threading.Tasks.Task<AspNetRoleClaim> DeleteAspNetRoleClaimByIdAsync(int id);

    /// <summary>
		/// Save a new AspNetRoleClaim instance.
		/// </summary>
    AspNetRoleClaim SaveAspNetRoleClaim(AspNetRoleClaim aspNetRoleClaim);
    
    /// <summary>
    /// Save a new AspNetRoleClaim instance.
    /// </summary>
    System.Threading.Tasks.Task<AspNetRoleClaim> SaveAspNetRoleClaimAsync(AspNetRoleClaim aspNetRoleClaim);
		
		/// <summary>
		/// Update an existing AspNetRoleClaim instance.
		/// </summary>
    AspNetRoleClaim UpdateAspNetRoleClaim(AspNetRoleClaim aspNetRoleClaim);
		
    /// <summary>
    /// Update an existing AspNetRoleClaim instance.
    /// </summary>
    System.Threading.Tasks.Task<AspNetRoleClaim> UpdateAspNetRoleClaimAsync(AspNetRoleClaim aspNetRoleClaim);
		
		/// <summary>
		/// Save or update an existing AspNetRoleClaim instance.
		/// </summary>
		AspNetRoleClaim SaveOrUpdateAspNetRoleClaim(AspNetRoleClaim aspNetRoleClaim);

    /// <summary>
		/// Save or update an existing AspNetRoleClaim instance.
		/// </summary>
    System.Threading.Tasks.Task<AspNetRoleClaim> SaveOrUpdateAspNetRoleClaimAsync(AspNetRoleClaim aspNetRoleClaim);

		
		
		/// <summary>
		/// Get AspNetUserClaim by primary key.
		/// </summary>
		AspNetUserClaim LookupAspNetUserClaimById(int id);

    /// <summary>
    /// Get AspNetUserClaim by primary key.
    /// </summary>
    System.Threading.Tasks.Task<AspNetUserClaim> LookupAspNetUserClaimByIdAsync(int id);

		/// <summary>
		/// Delete AspNetUserClaim by primary key.
		/// </summary>
		AspNetUserClaim DeleteAspNetUserClaimById(int id);
		
    /// <summary>
    /// Delete AspNetUserClaim by primary key.
    /// </summary>
    System.Threading.Tasks.Task<AspNetUserClaim> DeleteAspNetUserClaimByIdAsync(int id);

    /// <summary>
		/// Save a new AspNetUserClaim instance.
		/// </summary>
    AspNetUserClaim SaveAspNetUserClaim(AspNetUserClaim aspNetUserClaim);
    
    /// <summary>
    /// Save a new AspNetUserClaim instance.
    /// </summary>
    System.Threading.Tasks.Task<AspNetUserClaim> SaveAspNetUserClaimAsync(AspNetUserClaim aspNetUserClaim);
		
		/// <summary>
		/// Update an existing AspNetUserClaim instance.
		/// </summary>
    AspNetUserClaim UpdateAspNetUserClaim(AspNetUserClaim aspNetUserClaim);
		
    /// <summary>
    /// Update an existing AspNetUserClaim instance.
    /// </summary>
    System.Threading.Tasks.Task<AspNetUserClaim> UpdateAspNetUserClaimAsync(AspNetUserClaim aspNetUserClaim);
		
		/// <summary>
		/// Save or update an existing AspNetUserClaim instance.
		/// </summary>
		AspNetUserClaim SaveOrUpdateAspNetUserClaim(AspNetUserClaim aspNetUserClaim);

    /// <summary>
		/// Save or update an existing AspNetUserClaim instance.
		/// </summary>
    System.Threading.Tasks.Task<AspNetUserClaim> SaveOrUpdateAspNetUserClaimAsync(AspNetUserClaim aspNetUserClaim);

		
		
		/// <summary>
		/// Get AspNetUserLogin by primary key.
		/// </summary>
		AspNetUserLogin LookupAspNetUserLoginById(int id);

    /// <summary>
    /// Get AspNetUserLogin by primary key.
    /// </summary>
    System.Threading.Tasks.Task<AspNetUserLogin> LookupAspNetUserLoginByIdAsync(int id);

		/// <summary>
		/// Delete AspNetUserLogin by primary key.
		/// </summary>
		AspNetUserLogin DeleteAspNetUserLoginById(int id);
		
    /// <summary>
    /// Delete AspNetUserLogin by primary key.
    /// </summary>
    System.Threading.Tasks.Task<AspNetUserLogin> DeleteAspNetUserLoginByIdAsync(int id);

    /// <summary>
		/// Save a new AspNetUserLogin instance.
		/// </summary>
    AspNetUserLogin SaveAspNetUserLogin(AspNetUserLogin aspNetUserLogin);
    
    /// <summary>
    /// Save a new AspNetUserLogin instance.
    /// </summary>
    System.Threading.Tasks.Task<AspNetUserLogin> SaveAspNetUserLoginAsync(AspNetUserLogin aspNetUserLogin);
		
		/// <summary>
		/// Update an existing AspNetUserLogin instance.
		/// </summary>
    AspNetUserLogin UpdateAspNetUserLogin(AspNetUserLogin aspNetUserLogin);
		
    /// <summary>
    /// Update an existing AspNetUserLogin instance.
    /// </summary>
    System.Threading.Tasks.Task<AspNetUserLogin> UpdateAspNetUserLoginAsync(AspNetUserLogin aspNetUserLogin);
		
		/// <summary>
		/// Save or update an existing AspNetUserLogin instance.
		/// </summary>
		AspNetUserLogin SaveOrUpdateAspNetUserLogin(AspNetUserLogin aspNetUserLogin);

    /// <summary>
		/// Save or update an existing AspNetUserLogin instance.
		/// </summary>
    System.Threading.Tasks.Task<AspNetUserLogin> SaveOrUpdateAspNetUserLoginAsync(AspNetUserLogin aspNetUserLogin);

		
		
		/// <summary>
		/// Get AspNetUserToken by primary key.
		/// </summary>
		AspNetUserToken LookupAspNetUserTokenById(int id);

    /// <summary>
    /// Get AspNetUserToken by primary key.
    /// </summary>
    System.Threading.Tasks.Task<AspNetUserToken> LookupAspNetUserTokenByIdAsync(int id);

		/// <summary>
		/// Delete AspNetUserToken by primary key.
		/// </summary>
		AspNetUserToken DeleteAspNetUserTokenById(int id);
		
    /// <summary>
    /// Delete AspNetUserToken by primary key.
    /// </summary>
    System.Threading.Tasks.Task<AspNetUserToken> DeleteAspNetUserTokenByIdAsync(int id);

    /// <summary>
		/// Save a new AspNetUserToken instance.
		/// </summary>
    AspNetUserToken SaveAspNetUserToken(AspNetUserToken aspNetUserToken);
    
    /// <summary>
    /// Save a new AspNetUserToken instance.
    /// </summary>
    System.Threading.Tasks.Task<AspNetUserToken> SaveAspNetUserTokenAsync(AspNetUserToken aspNetUserToken);
		
		/// <summary>
		/// Update an existing AspNetUserToken instance.
		/// </summary>
    AspNetUserToken UpdateAspNetUserToken(AspNetUserToken aspNetUserToken);
		
    /// <summary>
    /// Update an existing AspNetUserToken instance.
    /// </summary>
    System.Threading.Tasks.Task<AspNetUserToken> UpdateAspNetUserTokenAsync(AspNetUserToken aspNetUserToken);
		
		/// <summary>
		/// Save or update an existing AspNetUserToken instance.
		/// </summary>
		AspNetUserToken SaveOrUpdateAspNetUserToken(AspNetUserToken aspNetUserToken);

    /// <summary>
		/// Save or update an existing AspNetUserToken instance.
		/// </summary>
    System.Threading.Tasks.Task<AspNetUserToken> SaveOrUpdateAspNetUserTokenAsync(AspNetUserToken aspNetUserToken);

		
	}
}