using AutoMapper;

namespace GeneratorTest.Common.Domain.Mappings.AutoMapper
{

	public class GeneratorTestRepositoryAutoMapperConfiguration
	{
    
		public MapperConfiguration Configure()
		{
			var config = new MapperConfiguration(cfg => {
			
	
				cfg.AddProfile<ProductMappingProfile>();
	
				cfg.AddProfile<OrderMappingProfile>();
	
				cfg.AddProfile<PosMappingProfile>();
				});

			return config;
		}



	}
}