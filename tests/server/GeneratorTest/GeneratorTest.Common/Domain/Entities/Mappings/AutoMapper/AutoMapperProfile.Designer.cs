using AutoMapper;
using GeneratorTest.Common.Domain.Repositories;

namespace GeneratorTest.Common.Domain.Mappings.AutoMapper
{

    public interface IRepoProvider
    {
      IGeneratorTestRepository Get();
    }

	public class TestRepositoryAutoMapperConfiguration
	{
    
		public MapperConfiguration Configure(IRepoProvider repoProvider)
		{
			var config = new MapperConfiguration(cfg => {
			
	
				cfg.AddProfile(new OrderMappingProfile(repoProvider));
	
				cfg.AddProfile(new CustomerMappingProfile(repoProvider));
	
				cfg.AddProfile(new StoreMappingProfile(repoProvider));
	
				cfg.AddProfile(new ProductMappingProfile(repoProvider));
	
				cfg.AddProfile(new PosMappingProfile(repoProvider));
				});

			return config;
		}



	}
}