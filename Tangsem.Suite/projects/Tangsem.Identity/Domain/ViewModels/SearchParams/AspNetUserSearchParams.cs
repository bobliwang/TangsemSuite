using Tangsem.Data;


namespace Tangsem.Identity.Domain.ViewModels.SearchParams
{

	public class AspNetUserSearchParams: SearchParamsBase
	{    
	
	
		public int? Id { get; set; }

	
	
		public string UserName { get; set; }

	
	
		public string Email { get; set; }

	
	
		public bool? EmailConfirmed { get; set; }

	
	
		public string PasswordHash { get; set; }

	
	
		public string PhoneNumber { get; set; }

	
	
		public bool? PhoneNumberConfirmed { get; set; }

	
	
		public bool? TwoFactorEnabled { get; set; }

	
	
		public System.DateTime? LockoutEnd { get; set; }

	
	
		public bool? LockoutEnabled { get; set; }

	
	
		public int? AccessFailedCount { get; set; }

	
	
		public string SecurityStamp { get; set; }

	
	
		public string ConcurrencyStamp { get; set; }

	
	
		public System.DateTime? CreatedTime { get; set; }

	
	
		public System.DateTime? ModifiedTime { get; set; }

	
	
		public int? CreatedById { get; set; }

	
	
		public int? ModifiedById { get; set; }

	
	
		public bool? Active { get; set; }

	
	
		public string AuthenticatorKey { get; set; }

	
	
		public string NormalizedUserName { get; set; }

	
	
		public string NormalizedEmail { get; set; }

	
	}
}