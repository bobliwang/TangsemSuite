using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

using NHibernate;
using NHibernate.Linq;

using Tangsem.Identity.Domain.Entities;
using Tangsem.NHibernate.Domain;

namespace Tangsem.Identity.Stores
{
  public class RoleStore<TRole>
    : IQueryableRoleStore<TRole>,
      IRoleClaimStore<TRole> where TRole : AspNetRole
  {
    public RepositoryBase Repository { get; set; }

    public ISession Context => this.Repository.CurrentSession;

    public RoleStore(RepositoryBase repository)
    {
      this.Repository = repository;
    }

    public IQueryable<TRole> Roles => this.Context.Query<TRole>();

    public void Dispose()
    {
    }

    public async Task<IdentityResult> CreateAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
    {
      if (role == null)
      {
        throw new ArgumentNullException(nameof(role));
      }

      await this.Context.SaveAsync(role, cancellationToken);
      await this.Context.FlushAsync(cancellationToken);

      return IdentityResult.Success;
    }

    public async Task<IdentityResult> UpdateAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
    {
      if (role == null)
      {
        throw new ArgumentNullException(nameof(role));
      }

      await this.Context.UpdateAsync(role, cancellationToken);
      await this.Context.FlushAsync(cancellationToken);

      return IdentityResult.Success;
    }

    public async Task<IdentityResult> DeleteAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
    {
      role.Active = false;
      await this.Context.UpdateAsync(role, cancellationToken);
      await this.Context.FlushAsync(cancellationToken);

      return IdentityResult.Success;
    }

    public Task<string> GetRoleIdAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
    {
      return Task.FromResult(role.Id.ToString());
    }

    public Task<string> GetRoleNameAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
    {
      return Task.FromResult(role.Name);
    }

    public async Task SetRoleNameAsync(TRole role, string roleName, CancellationToken cancellationToken = default(CancellationToken))
    {
      role.Name = roleName;
      await this.UpdateAsync(role, cancellationToken);
    }

    public Task<string> GetNormalizedRoleNameAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
    {
      return Task.FromResult(role.Name);
    }

    public async Task SetNormalizedRoleNameAsync(TRole role, string normalizedName, CancellationToken cancellationToken = default(CancellationToken))
    {
      role.Name = normalizedName;
      await this.UpdateAsync(role, cancellationToken);
    }

    public async Task<TRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
    {
      var role = await this.Context.Query<TRole>()
                           .FirstOrDefaultAsync(x => x.Id == int.Parse(roleId) && x.Active, cancellationToken);

      return role;
    }

    /// <summary>
    /// Finds the role who has the specified normalized name as an asynchronous operation.
    /// </summary>
    /// <param name="normalizedRoleName">The normalized role name to look for.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>A <see cref="T:System.Threading.Tasks.Task`1" /> that result of the look up.</returns>
    public async Task<TRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken = default(CancellationToken))
    {
      var role = await this.Context.Query<TRole>()
                     .FirstOrDefaultAsync(x => x.Name == normalizedRoleName && x.Active, cancellationToken);

      return role;
    }

    /// <summary>
    ///  Gets a list of <see cref="T:System.Security.Claims.Claim" />s to be belonging to the specified <paramref name="role" /> as an asynchronous operation.
    /// </summary>
    /// <param name="role">The role whose claims to retrieve.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>
    /// A <see cref="T:System.Threading.Tasks.Task`1" /> that represents the result of the asynchronous query, a list of <see cref="T:System.Security.Claims.Claim" />s.
    /// </returns>
    public Task<IList<Claim>> GetClaimsAsync(TRole role, CancellationToken cancellationToken = default(CancellationToken))
    {
      IList<Claim> claims = role.AspNetRoleClaims
                                .Where(x => x.Active)
                                .Select(x => new Claim(x.ClaimType, x.ClaimValue))
                                .ToList();

      return Task.FromResult(claims);
    }

    /// <summary>
    /// Add a new claim to a role as an asynchronous operation.
    /// </summary>
    /// <param name="role">The role to add a claim to.</param>
    /// <param name="claim">The <see cref="T:System.Security.Claims.Claim" /> to add.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task AddClaimAsync(TRole role, Claim claim, CancellationToken cancellationToken = default(CancellationToken))
    {
      var roleClaim  = new AspNetRoleClaim { AspNetRole = role, ClaimType = claim.Type, ClaimValue = claim.Value };

      await this.Context.SaveAsync(roleClaim, cancellationToken);
      role.AddToAspNetRoleClaims(roleClaim);
      await this.Context.FlushAsync(cancellationToken);
    }

    /// <summary>
    /// Remove a claim from a role as an asynchronous operation.
    /// </summary>
    /// <param name="role">The role to remove the claim from.</param>
    /// <param name="claim">The <see cref="T:System.Security.Claims.Claim" /> to remove.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task RemoveClaimAsync(TRole role, Claim claim, CancellationToken cancellationToken = new CancellationToken())
    {
      foreach (var rc in role.AspNetRoleClaims)
      {
        if (rc.ClaimType == claim.Type && rc.ClaimValue == claim.Value)
        {
          rc.Active = false;
        }
      }

      await this.Context.FlushAsync(cancellationToken);
    }
  }
}