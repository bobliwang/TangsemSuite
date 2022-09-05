using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json.Linq;
using Sample.Core.Domain.Entities;
using Sample.Core.Domain.Repositories;
using Sample.Host.Filters;
using Sample.Host.Services;

using Tangsem.Common.Extensions;
using Tangsem.Identity.Domain.Entities;

namespace Sample.Host.Controllers
{
  public class AuthCallbacksController : Controller
  {
    public readonly ISampleHostRepository repo;

    private readonly SignInManager<AspNetUser> signInManager;

    private readonly UserManager<AspNetUser> userManager;

    private readonly ShopeeService shopeeService;

    public AuthCallbacksController(ISampleHostRepository repo, SignInManager<AspNetUser> signInManager, UserManager<AspNetUser> userManager, ShopeeService shopeeService)
    {
      this.repo = repo;
      this.signInManager = signInManager;
      this.userManager = userManager;
      this.shopeeService = shopeeService;
    }

    [Authorize]
    [HttpGet("api/callbacks/shopee")]
    [Transaction]
    public async Task<IActionResult> ShopeeCallback([FromQuery(Name = "shop_id")]string shopId)
    {
      // original shopee auth url needs to have token generated from: https://www.xorbin.com/tools/sha256-hash-calculator

      var user = await this.userManager.GetUserAsync(this.Request.HttpContext.User);

      var shop = this.repo.ShopeeShops.FirstOrDefault(x => x.ShopId == shopId);

      ShopeeShopUser shopUser;
      if (shop == null)
      {
        shop = new ShopeeShop { ShopId = shopId };
        this.repo.Save(shop);
        shopUser = new ShopeeShopUser { AspNetUserId = user.Id, ShopeeShop = shop, LastLoginTime = DateTime.UtcNow };
        this.repo.Save(shopUser);
      }
      else
      {
        shopUser = shop.ShopeeShopUsers.FirstOrDefault(x => x.AspNetUserId == user.Id);

        if (shopUser == null)
        {
          shopUser = new ShopeeShopUser { AspNetUserId = user.Id, ShopeeShop = shop, LastLoginTime = DateTime.UtcNow };
          this.repo.Save(shopUser);
        }
        else
        {
          shopUser.LastLoginTime = DateTime.UtcNow;
        }
      }

      string[] results = await Task.WhenAll(
                      this.shopeeService.GetShopInfoAsync(shopId),
                      this.shopeeService.GetItemsAsync(shopId));

      var shopeePullHistory = new ShopeeItemPullHistory { RawResponse = results[1], ShopeeShopUser = shopUser };
      this.repo.SaveShopeeItemPullHistory(shopeePullHistory);
      this.repo.Flush();

      // select * from ShopeeItemPullHistory where RowVersion = 0x00000000000007D6

      return this.Ok(new
                       {
                         rowVersion = shopeePullHistory.RowVersion.ToRowVersionString(),
                         shopInfo = JObject.Parse(results[0]),
                         items = JObject.Parse(results[1])
                       });
    }
  }
}