using Tangsem.Data;


namespace Sample.Core.Domain.ViewModels.SearchParams
{

	public class ShopeeShopUserSearchParams: SearchParamsBase
	{    
	
	
		public int? Id { get; set; }

	
	
		public int? ShopeeShopId { get; set; }

	
	
		public int? AspNetUserId { get; set; }

	
	
		public System.DateTime? LastLoginTime { get; set; }

	
	
		public System.DateTime? CreatedTime { get; set; }

	
	
		public System.DateTime? ModifiedTime { get; set; }

	
	
		public int? CreatedById { get; set; }

	
	
		public int? ModifiedById { get; set; }

	
	
		public bool? Active { get; set; }

	
	}
}