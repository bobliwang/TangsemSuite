using Antlr.Runtime.Misc;
using AutoMapper;
using GeneratorTest.Common.Domain.Entities;
using GeneratorTest.Common.Domain.Entities.DTOs;
using GeneratorTest.Common.Domain.Repositories;

namespace GeneratorTest.Common.Domain.Mappings.AutoMapper
{

	public partial class OrderMappingProfile : Profile
	{
		public OrderMappingProfile ()
		{
			IMappingExpression<Order, OrderDTO> mappingToDto = this.CreateMap<Order, OrderDTO>();
      this.SetupMappingToDto(mappingToDto);
		  
		  IMappingExpression<OrderDTO, Order> mappingEntity = mappingToDto.ReverseMap();
      this.SetupMappingToEntity(mappingEntity);
		}

	  public virtual void SetupMappingToEntity(IMappingExpression<OrderDTO, Order> mappingEntity)
	  {
      // ignore auditing columns
	    mappingEntity.ForMember(x => x.CreatedById, opts => opts.Ignore());
	    mappingEntity.ForMember(x => x.ModifiedById, opts => opts.Ignore());
	    mappingEntity.ForMember(x => x.CreatedTime, opts => opts.Ignore());
	    mappingEntity.ForMember(x => x.ModifiedTime, opts => opts.Ignore());

      mappingEntity.ForMember(x => x.Active, opts => opts.Condition(s => s.Active != null));
    }

	  public virtual void SetupMappingToDto(IMappingExpression<Order, OrderDTO> mappingToDto)
	  {
	    mappingToDto.ForMember(x => x.ProductId, opts => opts.MapFrom(s => s.Product != null ? (int?)s.Product.Id : null));
    }
  }
  
  public class EntityConverter<T> : ITypeConverter<int, T> where T : class
  {
    private readonly IGeneratorTestRepository _repository;

    public EntityConverter(IGeneratorTestRepository repository)
    {
      _repository = repository;
    }

    public T Convert(int source, T destination, ResolutionContext context)
    {
      return _repository.LookupById<T>(source);
    }
  }
}