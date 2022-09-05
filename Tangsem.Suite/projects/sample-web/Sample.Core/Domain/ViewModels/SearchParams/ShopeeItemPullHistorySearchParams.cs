using Tangsem.Data;


namespace Sample.Core.Domain.ViewModels.SearchParams
{

	public class ShopeeItemPullHistorySearchParams: SearchParamsBase
	{    
	
	
		public int? Id { get; set; }

	
	
		public int? ShopeeShopUserId { get; set; }

	
	
		public string RawResponse { get; set; }

	
	
		public System.DateTime? CreatedTime { get; set; }

	
	
		public System.DateTime? ModifiedTime { get; set; }

	
	
		public int? CreatedById { get; set; }

	
	
		public int? ModifiedById { get; set; }

	
	
		public bool? Active { get; set; }

	
	
		public byte[] RowVersion { get; set; }

	
	}
}