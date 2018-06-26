using Tangsem.Data;


namespace GeneratorTest.Common.Domain.ViewModels.SearchParams
{

	public class PosSearchParams: SearchParamsBase
	{    
	
	
		public int? Id { get; set; }

	
	
		public string Name { get; set; }

	
	
		public int? CreatedById { get; set; }

	
	
		public int? ModifiedById { get; set; }

	
	
		public System.DateTime? CreatedTime { get; set; }

	
	
		public System.DateTime? ModifiedTime { get; set; }

	
	
		public bool? Active { get; set; }

	
	}
}