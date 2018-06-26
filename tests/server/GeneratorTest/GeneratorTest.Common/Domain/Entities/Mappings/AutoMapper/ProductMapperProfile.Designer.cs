using AutoMapper;
using GeneratorTest.Common.Domain.Entities;
using GeneratorTest.Common.Domain.Entities.DTOs;

namespace GeneratorTest.Common.Domain.Mappings.AutoMapper
{

	public partial class ProductMappingProfile : Profile
	{
		public ProductMappingProfile ()
		{
			var mapping = this.CreateMap<Product, ProductDTO>();

		

			// TODO: To generate code that ignores auditable columns as createdById, modifiedById ...
			
				mapping.ForMember(x => x.CreatedById, opts => opts.Ignore()); 
				mapping.ForMember(x => x.ModifiedById, opts => opts.Ignore());
				mapping.ForMember(x => x.CreatedTime, opts => opts.Ignore());
				mapping.ForMember(x => x.ModifiedTime, opts => opts.Ignore());
				mapping.ForMember(x => x.Active, opts => opts.Ignore());

						mapping.ReverseMap();
		}
	}
}