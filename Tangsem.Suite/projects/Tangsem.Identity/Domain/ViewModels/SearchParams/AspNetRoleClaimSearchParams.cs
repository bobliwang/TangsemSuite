using Tangsem.Data;


namespace Tangsem.Identity.Domain.ViewModels.SearchParams
{

	public class AspNetRoleClaimSearchParams: SearchParamsBase
	{    
	
	
		public int? Id { get; set; }

	
	
		public int? AspNetRoleId { get; set; }

	
	
		public string ClaimType { get; set; }

	
	
		public string ClaimValue { get; set; }

	
	
		public System.DateTime? CreatedTime { get; set; }

	
	
		public System.DateTime? ModifiedTime { get; set; }

	
	
		public int? CreatedById { get; set; }

	
	
		public int? ModifiedById { get; set; }

	
	
		public bool? Active { get; set; }

	
	}
}