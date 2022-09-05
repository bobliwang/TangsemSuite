using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sample.Core.Domain.Entities;
using Sample.Core.Domain.Repositories;
using Sample.Host.Filters;
using Sample.Host.Models.Shopee;
using Sample.Host.Services;

using Tangsem.Common.Extensions;
using Tangsem.Identity.Domain.Entities;

namespace Sample.Host.Controllers
{
  public class ShopeeController : ControllerBase
  {
    private readonly ShopeeService shopeeService;

    public readonly ISampleHostRepository repo;

    private readonly UserManager<AspNetUser> userManager;

    private readonly IQuickBooksService quickBooksService;

    public ShopeeController(ShopeeService shopeeService, ISampleHostRepository repo, UserManager<AspNetUser> userManager, IQuickBooksService quickBooksService)
    {
      this.shopeeService = shopeeService;
      this.repo = repo;
      this.userManager = userManager;
      this.quickBooksService = quickBooksService;
    }

    [HttpGet("api/shopee/items")]
    [Authorize]
    [Transaction]
    public async Task<IActionResult> GetShopeeItems()
    {
      var user = await this.userManager.GetUserAsync(this.Request.HttpContext.User);
      var shopUser = this.repo.ShopeeShopUsers.FirstOrDefault(x => x.AspNetUserId == user.Id && x.Active);

      if (shopUser == null)
      {
        return this.NotFound("No Linked Shop");
      }

      var responseText = await this.shopeeService.GetItemsAsync(shopUser.ShopeeShop.ShopId);

      var shopeePullHistory = new ShopeeItemPullHistory { RawResponse = responseText, ShopeeShopUser = shopUser };
      this.repo.SaveShopeeItemPullHistory(shopeePullHistory);
      this.repo.Flush();

      // select * from ShopeeItemPullHistory where RowVersion = 0x00000000000007D6

      return this.Ok(JObject.Parse(responseText));
    }

    [HttpGet("api/shopee/item/{itemId}")]
    [Authorize]
    [Transaction]
    public async Task<IActionResult> GetShopeeItemDetails(int itemId)
    {
      var user = await this.userManager.GetUserAsync(this.Request.HttpContext.User);
      var shopUser = this.repo.ShopeeShopUsers.FirstOrDefault(x => x.AspNetUserId == user.Id && x.Active);

      if (shopUser == null)
      {
        return this.NotFound("No Linked Shop");
      }

      var responseText = await this.shopeeService.GetItemAsync(shopUser.ShopeeShop.ShopId, itemId);

      var shopeePullHistory = new ShopeeItemPullHistory { RawResponse = responseText, ShopeeShopUser = shopUser };
      this.repo.SaveShopeeItemPullHistory(shopeePullHistory);
      this.repo.Flush();

      // select * from ShopeeItemPullHistory where RowVersion = 0x00000000000007D6

      return this.Ok(JObject.Parse(responseText));
    }

    [HttpPut("api/shopee/item/{itemId}")]
    [Authorize]
    public async Task<IActionResult> PushItemToQBO(int itemId, [FromBody]dynamic item) {
      
      Console.WriteLine($">>>>>>>. itemId: {itemId}, {JsonConvert.SerializeObject(item)}");
      var qboPayload = new QboItem();

      qboPayload.Name = $"shopee_{itemId}";
      qboPayload.Sku = $"{item.name}";
      qboPayload.Type = "Inventory";
      qboPayload.Description = $"{item.description}";
      qboPayload.TrackQtyOnHand = true;
      qboPayload.QtyOnHand = 100;
      qboPayload.InvStartDate = DateTime.UtcNow.Date.ToString("yyyy-MM-dd");

      qboPayload.IncomeAccountRef = new AssetAccountRef {
        Value = 79.ToString(),
        Name = "Sales of PRoduct Income"
      };

      qboPayload.ExpenseAccountRef = new AssetAccountRef {
        Value = 80.ToString(),
        Name = "Cost of Goods Sold"
      };

      qboPayload.AssetAccountRef = new AssetAccountRef {
        Value = 81.ToString(),
        Name = "Inventory Asset"
      };

      var responseText = await this.quickBooksService.PostAsync("/item?operation=update", JsonConvert.SerializeObject(qboPayload));
      
      return this.Ok(JObject.Parse(responseText));
    }
  }
}