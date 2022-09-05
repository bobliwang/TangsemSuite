using Tangsem.Data;


namespace Tangsem.Identity.Domain.ViewModels.SearchParams
{

	public class AspNetUserTokenSearchParams: SearchParamsBase
	{    
	
	
		public int? Id { get; set; }

	
	
		public int? AspNetUserId { get; set; }

	
	
		public string LoginProvider { get; set; }

	
	
		public string Name { get; set; }

	
	
		public string Value { get; set; }

	
	
		public System.DateTime? CreatedTime { get; set; }

	
	
		public System.DateTime? ModifiedTime { get; set; }

	
	
		public int? CreatedById { get; set; }

	
	
		public int? ModifiedById { get; set; }

	
	
		public bool? Active { get; set; }

	
	}
}