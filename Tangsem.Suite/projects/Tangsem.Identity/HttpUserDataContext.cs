using System;
using System.Security.Claims;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using Tangsem.Data.Domain;
using Tangsem.Identity.Domain.Entities;

namespace Tangsem.Identity
{
  public class HttpUserDataContext<TUser> : IDataContext where TUser: AspNetUser
  {
    private IHttpContextAccessor httpContextAccessor;
    
    public HttpUserDataContext(IHttpContextAccessor httpContextAccessor)
    {
      this.httpContextAccessor = httpContextAccessor;
      this.UserIdClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
    }

    public void SetHttpContextAccessor(IHttpContextAccessor httpContextAccessor)
    {
      this.httpContextAccessor = httpContextAccessor;
    }

    public string UserIdClaimType { get; set; }
    
    public int CurrentUserId
    {
      get
      {
        const int naUserId = -1;

        var httpContextUser = this.httpContextAccessor?.HttpContext?.User;

        if (httpContextUser == null)
        {
          return naUserId;
        }

        var userIdString = httpContextUser.FindFirstValue(this.UserIdClaimType);

        if (int.TryParse(userIdString, out int userId))
        {
          return userId;
        }

        return naUserId;
      }
    }
  }
}