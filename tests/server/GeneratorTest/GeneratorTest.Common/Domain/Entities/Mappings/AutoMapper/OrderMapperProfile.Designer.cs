using Antlr.Runtime.Misc;
using AutoMapper;
using GeneratorTest.Common.Domain.Entities;
using GeneratorTest.Common.Domain.Entities.DTOs;
using GeneratorTest.Common.Domain.Repositories;

namespace GeneratorTest.Common.Domain.Mappings.AutoMapper
{

	public partial class OrderMappingProfile : Profile
	{
	  private Func<IGeneratorTestRepository> _repoFunc;
    
		public OrderMappingProfile ()
		{
			IMappingExpression<Order, OrderDTO> mappingToDto = this.CreateMap<Order, OrderDTO>();
      this.SetupMappingToDto(mappingToDto);
		  
		  IMappingExpression<OrderDTO, Order> mappingEntity = mappingToDto.ReverseMap();
      this.SetupMappingToEntity(mappingEntity);
		}

	  public virtual void SetupMappingToEntity(IMappingExpression<OrderDTO, Order> mappingEntity)
	  {

	    mappingEntity.ForMember(x => x.Product, opts => opts.MapFrom(s => s.ProductId == null ? null : _repoFunc().LookupProductById(s.ProductId.Value) ));

	  }

	  public virtual void SetupMappingToDto(IMappingExpression<Order, OrderDTO> mappingToDto)
	  {
	    mappingToDto.ForMember(x => x.ProductId, opts => opts.MapFrom(s => s.Product != null ? (int?)s.Product.Id : null));

      
      // ignore auditing columns
      mappingToDto.ForMember(x => x.CreatedById, opts => opts.Ignore());
	    mappingToDto.ForMember(x => x.ModifiedById, opts => opts.Ignore());
	    mappingToDto.ForMember(x => x.CreatedTime, opts => opts.Ignore());
	    mappingToDto.ForMember(x => x.ModifiedTime, opts => opts.Ignore());
	    mappingToDto.ForMember(x => x.Active, opts => opts.Ignore());
    }
  }
}