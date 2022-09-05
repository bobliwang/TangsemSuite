using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using Tangsem.Identity.Stores;

namespace Tangsem.Identity
{
  public static class IdentityBuilderExtensions
  {
    public static IdentityBuilder AddHibernateStores(this IdentityBuilder builder)
    {
      AddStores(builder.Services, builder.UserType, builder.RoleType);

      return builder;
    }
    
    public static void AddStores(this IServiceCollection services, System.Type userType, System.Type roleType)
    {
      // register user store type
      var userStoreServiceType = typeof(IUserStore<>)
        .MakeGenericType(userType);
      var userStoreImplType = typeof(UserStore<>).MakeGenericType(userType);
      services.AddScoped(userStoreServiceType, userStoreImplType);

      // add role store type
      var roleStoreSvcType = typeof(IRoleStore<>).MakeGenericType(roleType);
      var roleStoreImplType = typeof(RoleStore<>).MakeGenericType(roleType);
      services.AddScoped(roleStoreSvcType, roleStoreImplType);
    }
  }
}