using System;
using AutoMapper;
using GeneratorTest.Common.Domain.Repositories;
using Type = System.Type;

namespace GeneratorTest.Common.Domain.Mappings.AutoMapper
{
  public interface IRepoProvider
  {
    IGeneratorTestRepository Get();
  }

	public class GeneratorTestRepositoryAutoMapperConfiguration
	{
		public MapperConfiguration Configure(IRepoProvider repoProvider)
		{
			var config = new MapperConfiguration(cfg => {
			
	
				cfg.AddProfile<ProductMappingProfile>();
			  
        cfg.AddProfile(new OrderMappingProfile(repoProvider));
	
				cfg.AddProfile<PosMappingProfile>();

        //cfg.ConstructServicesUsing(resolverFunc);

			});

            

			return config;
		}



	}
}