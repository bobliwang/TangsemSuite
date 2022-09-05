using Tangsem.Data;


namespace Sample.Core.Domain.ViewModels.SearchParams
{

	public class ShopeeShopSearchParams: SearchParamsBase
	{    
	
	
		public int? Id { get; set; }

	
	
		public string ShopId { get; set; }

	
	
		public string ShopName { get; set; }

	
	
		public string Status { get; set; }

	
	
		public System.DateTime? CreatedTime { get; set; }

	
	
		public System.DateTime? ModifiedTime { get; set; }

	
	
		public int? CreatedById { get; set; }

	
	
		public int? ModifiedById { get; set; }

	
	
		public bool? Active { get; set; }

	
	}
}