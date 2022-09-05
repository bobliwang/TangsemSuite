using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
  /// <summary>
  /// Implements IUserStore using NHibernate where TUser is the entity type of the user being stored
  /// </summary>
  /// <typeparam name="TUser"/>
  public class UserStore<TUser> :
    IUserStore<TUser>
    , IUserLoginStore<TUser>
    , IUserClaimStore<TUser>
    , IUserRoleStore<TUser>
    , IUserPasswordStore<TUser>
    , IUserSecurityStampStore<TUser>
    , IQueryableUserStore<TUser>
    , IUserLockoutStore<TUser>
    , IUserEmailStore<TUser>
    , IUserPhoneNumberStore<TUser>
    , IUserTwoFactorStore<TUser>
    , IUserAuthenticationTokenStore<TUser>
    , IUserAuthenticatorKeyStore<TUser>
    , IUserTwoFactorRecoveryCodeStore<TUser>
    where TUser : AspNetUser
  {
    private readonly string InternalLoginProvider = nameof(InternalLoginProvider);
    private readonly string RecoveryCodeTokenName = nameof(RecoveryCodeTokenName);

    public RepositoryBase Repository { get; set; }

    public ISession Context => this.Repository.CurrentSession;

    public UserStore(RepositoryBase repository)
    {
      this.Repository = repository;
    }

    public IQueryable<TUser> Users => this.Context.Query<TUser>();

    public void Dispose()
    {
    }

    /// <summary>
    /// Adds an external <see cref="T:Microsoft.AspNetCore.Identity.UserLoginInfo" /> to the specified <paramref name="user" />.
    /// </summary>
    /// <param name="user">The user to add the login to.</param>
    /// <param name="login">The external <see cref="T:Microsoft.AspNetCore.Identity.UserLoginInfo" /> to add to the specified <paramref name="user" />.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.</returns>
    public async Task AddLoginAsync(TUser user, UserLoginInfo login, CancellationToken cancellationToken = default(CancellationToken))
    {
      var userLogin = new AspNetUserLogin { ProviderKey = login.ProviderKey, LoginProvider = login.LoginProvider };
      user.AddToAspNetUserLogins(userLogin);

      await this.Context.SaveAsync(userLogin, cancellationToken);
      await this.Context.SaveOrUpdateAsync(user, cancellationToken);
      await this.Context.FlushAsync(cancellationToken);
    }

    /// <summary>
    /// Attempts to remove the provided login information from the specified <paramref name="user" />.
    /// and returns a flag indicating whether the removal succeed or not.
    /// </summary>
    /// <param name="user">The user to remove the login information from.</param>
    /// <param name="loginProvider">The login provide whose information should be removed.</param>
    /// <param name="providerKey">The key given by the external login provider for the specified user.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.</returns>
    public async Task RemoveLoginAsync(TUser user, string loginProvider, string providerKey, CancellationToken cancellationToken = default(CancellationToken))
    {
      var info = user.AspNetUserLogins.SingleOrDefault(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey);
      if (info != null)
      {
        user.AspNetUserLogins.Remove(info);
        info.AspNetUser = null;

        await this.Context.FlushAsync(cancellationToken);
      }
    }

    /// <summary>
    /// Retrieves the associated logins for the specified <param ref="user" />.
    /// </summary>
    /// <param name="user">The user whose associated logins to retrieve.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>
    /// The <see cref="T:System.Threading.Tasks.Task" /> for the asynchronous operation, containing a list of <see cref="T:Microsoft.AspNetCore.Identity.UserLoginInfo" /> for the specified <paramref name="user" />, if any.
    /// </returns>
    public Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      if (user == null)
      {
        throw new ArgumentNullException(nameof(user));
      }

      IList<UserLoginInfo> result = user.AspNetUserLogins.Select(x => new UserLoginInfo(x.LoginProvider, x.ProviderKey, x.LoginProvider)).ToList();

      return Task.FromResult(result);
    }

    /// <summary>
    /// Retrieves the user associated with the specified login provider and login provider key.
    /// </summary>
    /// <param name="loginProvider">The login provider who provided the <paramref name="providerKey" />.</param>
    /// <param name="providerKey">The key provided by the <paramref name="loginProvider" /> to identify a user.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>
    /// The <see cref="T:System.Threading.Tasks.Task" /> for the asynchronous operation, containing the user, if any which matched the specified login provider and key.
    /// </returns>
    public async Task<TUser> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken = default(CancellationToken))
    {
      var login = await this.Context.Query<AspNetUserLogin>()
                            .FirstOrDefaultAsync(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey, cancellationToken);

      return login?.AspNetUser as TUser;
    }

    /// <summary>
    /// Gets the user identifier for the specified <paramref name="user" />.
    /// </summary>
    /// <param name="user">The user whose identifier should be retrieved.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the identifier for the specified <paramref name="user" />.</returns>
    public Task<string> GetUserIdAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
      => Task.FromResult(user.Id.ToString());

    /// <summary>
    /// Gets the user name for the specified <paramref name="user" />.
    /// </summary>
    /// <param name="user">The user whose name should be retrieved.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the name for the specified <paramref name="user" />.</returns>
    public Task<string> GetUserNameAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
      => Task.FromResult(user.UserName);

    /// <summary>
    /// Sets the given <paramref name="userName" /> for the specified <paramref name="user" />.
    /// </summary>
    /// <param name="user">The user whose name should be set.</param>
    /// <param name="userName">The user name to set.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.</returns>
    public async Task SetUserNameAsync(TUser user, string userName, CancellationToken cancellationToken = default(CancellationToken))
    {
      user.UserName = userName;
      await this.Context.FlushAsync(cancellationToken);
    }

    /// <summary>
    /// Gets the normalized user name for the specified <paramref name="user" />.
    /// </summary>
    /// <param name="user">The user whose normalized name should be retrieved.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the normalized user name for the specified <paramref name="user" />.</returns>
    public Task<string> GetNormalizedUserNameAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
      => Task.FromResult(user.NormalizedUserName);

    /// <summary>
    /// Sets the given normalized name for the specified <paramref name="user" />.
    /// </summary>
    /// <param name="user">The user whose name should be set.</param>
    /// <param name="normalizedName">The normalized name to set.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.</returns>
    public async Task SetNormalizedUserNameAsync(TUser user, string normalizedName, CancellationToken cancellationToken = default(CancellationToken))
    {
      user.NormalizedUserName = normalizedName;
      await this.Context.FlushAsync(cancellationToken);
    }

    /// <summary>
    /// Creates the specified <paramref name="user" /> in the user store.
    /// </summary>
    /// <param name="user">The user to create.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNetCore.Identity.IdentityResult" /> of the creation operation.</returns>
    public async Task<IdentityResult> CreateAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      if (user == null)
      {
        throw new ArgumentNullException(nameof(user));
      }

      await this.Context.SaveAsync(user, cancellationToken);
      var appUser = new ApplicationUser { AspNetUser = user };
      await this.Context.SaveAsync(appUser, cancellationToken);
      await this.Context.FlushAsync(cancellationToken);

      return IdentityResult.Success;
    }

    /// <summary>
    /// Updates the specified <paramref name="user" /> in the user store.
    /// </summary>
    /// <param name="user">The user to update.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNetCore.Identity.IdentityResult" /> of the update operation.</returns>
    public async Task<IdentityResult> UpdateAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      if (user == null)
      {
        throw new ArgumentNullException(nameof(user));
      }

      await this.Context.UpdateAsync(user, cancellationToken);
      await this.Context.FlushAsync(cancellationToken);

      return IdentityResult.Success;
    }

    /// <summary>
    /// Deletes the specified <paramref name="user" /> from the user store.
    /// </summary>
    /// <param name="user">The user to delete.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNetCore.Identity.IdentityResult" /> of the update operation.</returns>
    public async Task<IdentityResult> DeleteAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      user.Active = false;
      await this.Context.FlushAsync(cancellationToken);

      return IdentityResult.Success;
    }

    /// <summary>
    /// Finds and returns a user, if any, who has the specified <paramref name="userId" />.
    /// </summary>
    /// <param name="userId">The user ID to search for.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>
    /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the user matching the specified <paramref name="userId" /> if it exists.
    /// </returns>
    public Task<TUser> FindByIdAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
      => this.GetUserAggregateAsync(u => u.Id == int.Parse(userId));

    /// <summary>
    /// Finds and returns a user, if any, who has the specified normalized user name.
    /// </summary>
    /// <param name="normalizedUserName">The normalized user name to search for.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>
    /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the user matching the specified <paramref name="normalizedUserName" /> if it exists.
    /// </returns>
    public Task<TUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = default(CancellationToken))
      => this.GetUserAggregateAsync(u => u.NormalizedUserName == normalizedUserName);

    /// <summary>
    /// Gets a list of <see cref="T:System.Security.Claims.Claim" />s to be belonging to the specified <paramref name="user" /> as an asynchronous operation.
    /// </summary>
    /// <param name="user">The role whose claims to retrieve.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>
    /// A <see cref="T:System.Threading.Tasks.Task`1" /> that represents the result of the asynchronous query, a list of <see cref="T:System.Security.Claims.Claim" />s.
    /// </returns>
    public Task<IList<Claim>> GetClaimsAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      IList<Claim> claims = user.AspNetUserClaims
                                .Where(x => x.Active)
                                .Select(x => new Claim(x.ClaimType, x.ClaimValue))
                                .ToList();

      var roleClaims = user.AspNetUserRoles
        .Where(x => x.Active)
        .Select(x => x.AspNetRole)
        .Where(x => x.Active)
        .SelectMany(x => x.AspNetRoleClaims)
        .ToList()
        .Where(x => x.Active)
        .Select(x => new Claim(x.ClaimType, x.ClaimValue));

      claims = claims.Concat(roleClaims).ToList();

      return Task.FromResult(claims);
    }

    /// <summary>Add claims to a user as an asynchronous operation.</summary>
    /// <param name="user">The user to add the claim to.</param>
    /// <param name="claims">The collection of <see cref="T:System.Security.Claims.Claim" />s to add.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task AddClaimsAsync(TUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken = default(CancellationToken))
    {
      foreach (var claim in claims)
      {
        var userClaim = new AspNetUserClaim { AspNetUser = user, ClaimType = claim.Type, ClaimValue = claim.Value };

        await this.Context.SaveAsync(userClaim, cancellationToken);
        user.AddToAspNetUserClaims(userClaim);
      }

      await this.Context.FlushAsync(cancellationToken);
    }

    /// <summary>
    /// Replaces the given <paramref name="claim" /> on the specified <paramref name="user" /> with the <paramref name="newClaim" />
    /// </summary>
    /// <param name="user">The user to replace the claim on.</param>
    /// <param name="claim">The claim to replace.</param>
    /// <param name="newClaim">The new claim to replace the existing <paramref name="claim" /> with.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task ReplaceClaimAsync(TUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken = default(CancellationToken))
    {
      await this.RemoveClaimsAsync(user, new [] { claim }, cancellationToken);
      await this.AddClaimsAsync(user, new[] { newClaim }, cancellationToken);
    }

    /// <summary>
    /// Removes the specified <paramref name="claims" /> from the given <paramref name="user" />.
    /// </summary>
    /// <param name="user">The user to remove the specified <paramref name="claims" /> from.</param>
    /// <param name="claims">A collection of <see cref="T:System.Security.Claims.Claim" />s to remove.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task RemoveClaimsAsync(TUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken = default(CancellationToken))
    {
      foreach (var claim in claims)
      {
        foreach (var uc in user.AspNetUserClaims)
        {
          if (uc.ClaimType == claim.Type && uc.ClaimValue == claim.Value)
          {
            uc.Active = false;
          }
        }
      }

      await this.Context.FlushAsync(cancellationToken);
    }

    /// <summary>
    /// Returns a list of users who contain the specified <see cref="T:System.Security.Claims.Claim" />.
    /// </summary>
    /// <param name="claim">The claim to look for.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>
    /// A <see cref="T:System.Threading.Tasks.Task`1" /> that represents the result of the asynchronous query, a list of <typeparamref name="TUser" /> who
    /// contain the specified claim.
    /// </returns>
    public async Task<IList<TUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken = default(CancellationToken))
    {
      var users = await this.Context.Query<TUser>()
                            .Where(x => x.AspNetUserClaims.Any(c => c.ClaimType == claim.Type && c.ClaimValue == claim.Value))
                            .ToListAsync(cancellationToken);

      return users;
    }

    /// <summary>
    /// Add the specified <paramref name="user" /> to the named role.
    /// </summary>
    /// <param name="user">The user to add to the named role.</param>
    /// <param name="roleName">The name of the role to add the user to.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.</returns>
    public async Task AddToRoleAsync(TUser user, string roleName, CancellationToken cancellationToken = default(CancellationToken))
    {
      var identityRole = await this.Context.Query<AspNetRole>()
                            .SingleOrDefaultAsync(x => x.Name == roleName, cancellationToken);

      if (identityRole == null)
      {
        throw new NullReferenceException($"{nameof(identityRole)} is not found!");
      }

      var userRole = new AspNetUserRole { AspNetRole = identityRole, AspNetUser = user };
      await this.Context.SaveAsync(userRole, cancellationToken);
      user.AddToAspNetUserRoles(userRole);
      await this.Context.FlushAsync(cancellationToken);
    }

    /// <summary>
    /// Remove the specified <paramref name="user" /> from the named role.
    /// </summary>
    /// <param name="user">The user to remove the named role from.</param>
    /// <param name="roleName">The name of the role to remove.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.</returns>
    public Task RemoveFromRoleAsync(TUser user, string roleName, CancellationToken cancellationToken = default(CancellationToken))
    {
      var userRole = user.AspNetUserRoles.FirstOrDefault(ur => ur.AspNetRole.Name == roleName);

      if (userRole != null)
      {
        userRole.Active = false;
      }
      return Task.CompletedTask;
    }

    /// <summary>
    /// Gets a list of role names the specified <paramref name="user" /> belongs to.
    /// </summary>
    /// <param name="user">The user whose role names to retrieve.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing a list of role names.</returns>
    public Task<IList<string>> GetRolesAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      IList<string> roleNames = user.AspNetUserRoles
                                    .Where(x => x.Active && x.AspNetRole.Active)
                                    .Select(x => x.AspNetRole.Name)
                                    .ToList();

      return Task.FromResult(roleNames);
    }

    /// <summary>
    /// Returns a flag indicating whether the specified <paramref name="user" /> is a member of the given named role.
    /// </summary>
    /// <param name="user">The user whose role membership should be checked.</param>
    /// <param name="roleName">The name of the role to be checked.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>
    /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing a flag indicating whether the specified <paramref name="user" /> is
    /// a member of the named role.
    /// </returns>
    public Task<bool> IsInRoleAsync(TUser user, string roleName, CancellationToken cancellationToken = default(CancellationToken))
    {
      var result = user.AspNetUserRoles.Any(r => r.Active && r.AspNetRole.Active && r.AspNetRole.Name.Equals(roleName));
      return Task.FromResult(result);
    }

    /// <summary>
    /// Returns a list of Users who are members of the named role.
    /// </summary>
    /// <param name="roleName">The name of the role whose membership should be returned.</param>
    /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> used to propagate notifications that the operation should be canceled.</param>
    /// <returns>
    /// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing a list of users who are in the named role.
    /// </returns>
    public async Task<IList<TUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken = default(CancellationToken))
    {
      IList<TUser> users = await this.Context.Query<TUser>()
                                .Where(x => x.AspNetUserRoles.Any(y => y.AspNetRole.Name == roleName))
                                .ToListAsync(cancellationToken);

      return users;
    }

    public async Task SetPasswordHashAsync(TUser user, string passwordHash, CancellationToken cancellationToken = default(CancellationToken))
    {
      user.PasswordHash = passwordHash;
      await this.Context.FlushAsync(cancellationToken);
    }

    public Task<string> GetPasswordHashAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      return Task.FromResult(user.PasswordHash);
    }

    public Task<bool> HasPasswordAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      return Task.FromResult(user.PasswordHash != null);
    }

    public async Task SetSecurityStampAsync(TUser user, string stamp, CancellationToken cancellationToken = default(CancellationToken))
    {
      user.SecurityStamp = stamp;
      await this.Context.FlushAsync(cancellationToken);
    }

    public Task<string> GetSecurityStampAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      return Task.FromResult(user.SecurityStamp);
    }

    public Task<DateTimeOffset?> GetLockoutEndDateAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      DateTimeOffset? dateTimeOffset = user.LockoutEnd.HasValue
                             ? new DateTimeOffset(DateTime.SpecifyKind(user.LockoutEnd.Value, DateTimeKind.Utc))
                             : (DateTimeOffset?)null;

      return Task.FromResult(dateTimeOffset);
    }

    public async Task SetLockoutEndDateAsync(TUser user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken = default(CancellationToken))
    {
      var utcDateTime = lockoutEnd?.UtcDateTime;
      user.LockoutEnd = utcDateTime;
      await this.Context.FlushAsync(cancellationToken);
    }

    public async Task<int> IncrementAccessFailedCountAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      user.AccessFailedCount++;
      await this.Context.FlushAsync(cancellationToken);

      return user.AccessFailedCount;
    }

    public async Task ResetAccessFailedCountAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      user.AccessFailedCount = 0;
      await this.Context.FlushAsync(cancellationToken);
    }

    public Task<int> GetAccessFailedCountAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      return Task.FromResult(user.AccessFailedCount);
    }

    public Task<bool> GetLockoutEnabledAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      return Task.FromResult(user.LockoutEnabled);
    }

    public async Task SetLockoutEnabledAsync(TUser user, bool enabled, CancellationToken cancellationToken = default(CancellationToken))
    {
      user.LockoutEnabled = enabled;
      await this.Context.FlushAsync(cancellationToken);
    }

    public async Task SetEmailAsync(TUser user, string email, CancellationToken cancellationToken = default(CancellationToken))
    {
      user.Email = email;
      await this.Context.FlushAsync(cancellationToken);
    }

    public Task<string> GetEmailAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      return Task.FromResult(user.Email);
    }

    public Task<bool> GetEmailConfirmedAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      return Task.FromResult(user.EmailConfirmed);
    }

    public async Task SetEmailConfirmedAsync(TUser user, bool confirmed, CancellationToken cancellationToken = default(CancellationToken))
    {
      user.EmailConfirmed = confirmed;
      await this.Context.FlushAsync(cancellationToken);
    }

    public Task<TUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = default(CancellationToken))
    {
      return this.GetUserAggregateAsync(u => u.Email == normalizedEmail);
    }

    public Task<string> GetNormalizedEmailAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      return Task.FromResult(user.NormalizedEmail);
    }

    public async Task SetNormalizedEmailAsync(TUser user, string normalizedEmail, CancellationToken cancellationToken = default(CancellationToken))
    {
      user.NormalizedEmail = normalizedEmail;
      await this.Context.FlushAsync(cancellationToken);
    }

    public async Task SetPhoneNumberAsync(TUser user, string phoneNumber, CancellationToken cancellationToken = default(CancellationToken))
    {
      user.PhoneNumber = phoneNumber;
      await this.Context.FlushAsync(cancellationToken);
    }

    public Task<string> GetPhoneNumberAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      return Task.FromResult(user.PhoneNumber);
    }

    public Task<bool> GetPhoneNumberConfirmedAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      return Task.FromResult(user.PhoneNumberConfirmed);
    }

    public async Task SetPhoneNumberConfirmedAsync(TUser user, bool confirmed, CancellationToken cancellationToken = default(CancellationToken))
    {
      user.PhoneNumberConfirmed = confirmed;
      await this.Context.FlushAsync(cancellationToken);
    }

    public async Task SetTwoFactorEnabledAsync(TUser user, bool enabled, CancellationToken cancellationToken = default(CancellationToken))
    {
      user.TwoFactorEnabled = enabled;
      await this.Context.FlushAsync(cancellationToken);
    }

    public Task<bool> GetTwoFactorEnabledAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      return Task.FromResult(user.TwoFactorEnabled);
    }
    
    private Task<TUser> GetUserAggregateAsync(Expression<Func<TUser, bool>> filter)
    {
      // no cartesian product, batch call.
      // Don't know if it's really needed: should we eager load or let lazy loading do its stuff?
      var query = this.Context.Query<TUser>().Where(x => x.Active).Where(filter);
      query.Fetch(p => p.AspNetUserRoles).ToFuture();
      query.Fetch(p => p.AspNetUserClaims).ToFuture();
      query.Fetch(p => p.AspNetUserLogins).ToFuture();

      var user = query.ToFuture().FirstOrDefault();

      return Task.FromResult(user);
    }

    public async Task SetTokenAsync(TUser user, string loginProvider, string name, string value, CancellationToken cancellationToken = default(CancellationToken))
    {
      var userToken = user.AspNetUserTokens.FirstOrDefault(x => x.LoginProvider == loginProvider && x.Name == name);

      if (userToken == null)
      {
        userToken = new AspNetUserToken { AspNetUser = user, Name = name, LoginProvider = loginProvider };
        this.Repository.Save(userToken);
      }

      userToken.Value = value;
      userToken.Active = true;

      await this.Context.FlushAsync(cancellationToken);
    }

    public async Task RemoveTokenAsync(TUser user, string loginProvider, string name, CancellationToken cancellationToken = default(CancellationToken))
    {
      var userToken = user.AspNetUserTokens.FirstOrDefault(x => x.Active && x.LoginProvider == loginProvider && x.Name == name);

      if (userToken != null)
      {
        userToken.Active = false;
      }

      await this.Context.FlushAsync(cancellationToken);
    }

    public Task<string> GetTokenAsync(TUser user, string loginProvider, string name, CancellationToken cancellationToken = default(CancellationToken))
    {
      var userToken = user.AspNetUserTokens.FirstOrDefault(x => x.Active && x.LoginProvider == loginProvider && x.Name == name);
      
      return Task.FromResult(userToken?.Value);
    }

    public async Task SetAuthenticatorKeyAsync(TUser user, string key, CancellationToken cancellationToken = default(CancellationToken))
    {
      user.AuthenticatorKey = key;
      await this.Context.FlushAsync(cancellationToken);
    }

    public Task<string> GetAuthenticatorKeyAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      return Task.FromResult(user.AuthenticatorKey);
    }

    public Task ReplaceCodesAsync(TUser user, IEnumerable<string> recoveryCodes, CancellationToken cancellationToken = default(CancellationToken))
    {
      var mergedCodes = string.Join(";", recoveryCodes);
      return this.SetTokenAsync(user, this.InternalLoginProvider, this.RecoveryCodeTokenName, mergedCodes, cancellationToken);
    }

    public async Task<bool> RedeemCodeAsync(TUser user, string code, CancellationToken cancellationToken = default(CancellationToken))
    {
      if (user == null)
      {
        throw new ArgumentNullException(nameof(user));
      }
      if (code == null)
      {
        throw new ArgumentNullException(nameof(code));
      }

      var mergedCodes = await this.GetTokenAsync(user, this.InternalLoginProvider, this.RecoveryCodeTokenName, cancellationToken) ?? string.Empty;
      var splitCodes = mergedCodes.Split(';');
      if (splitCodes.Contains(code))
      {
        var updatedCodes = new List<string>(splitCodes.Where(s => s != code));
        await this.ReplaceCodesAsync(user, updatedCodes, cancellationToken);

        return true;
      }

      return false;
    }

    public async Task<int> CountCodesAsync(TUser user, CancellationToken cancellationToken = default(CancellationToken))
    {
      if (user == null)
      {
        throw new ArgumentNullException(nameof(user));
      }

      var mergedCodes = await this.GetTokenAsync(user, this.InternalLoginProvider, this.RecoveryCodeTokenName, cancellationToken) ?? string.Empty;
      if (mergedCodes.Length > 0)
      {
        return mergedCodes.Split(';').Length;
      }

      return 0;
    }

  }
}