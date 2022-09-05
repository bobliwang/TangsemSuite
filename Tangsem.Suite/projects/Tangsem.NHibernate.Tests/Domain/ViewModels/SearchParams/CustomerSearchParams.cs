using Tangsem.Data;


namespace Tangsem.NHibernate.Tests.Domain.ViewModels.SearchParams
{

	public class CustomerSearchParams: SearchParamsBase
	{    
	
	
		public System.Guid? CustomerId { get; set; }

	
	
		public string CustomerName { get; set; }

	
	
		public int? CreatedById { get; set; }

	
	
		public int? ModifiedById { get; set; }

	
	
		public System.DateTime? CreatedTime { get; set; }

	
	
		public System.DateTime? ModifiedTime { get; set; }

	
	
		public bool? Active { get; set; }

	
	
		public int? StoreId { get; set; }

	
	
		public byte[] RowVersion { get; set; }

	
	}
}