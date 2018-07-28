using Tangsem.Data;


namespace GeneratorTest.Common.Domain.ViewModels.SearchParams
{

	public partial class OrderSearchParams: SearchParamsBase
	{    
	
	
		public int? Id { get; set; }

	
	
		public string CustomerName { get; set; }

	
	
		public int? ProductId { get; set; }

	
	
		public System.Guid? CustomerId { get; set; }

	
	
		public decimal? OrderTotal { get; set; }

	
	
		public int? CreatedById { get; set; }

	
	
		public int? ModifiedById { get; set; }

	
	
		public System.DateTime? CreatedTime { get; set; }

	
	
		public System.DateTime? ModifiedTime { get; set; }

	
	
		public bool? Active { get; set; }

	
	}
}