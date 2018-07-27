using AutoMapper;
using GeneratorTest.Common.Domain.Entities;
using GeneratorTest.Common.Domain.Entities.DTOs;

namespace GeneratorTest.Common.Domain.Mappings.AutoMapper
{

	public partial class OrderMappingProfile : Profile
	{
	    private readonly IRepoProvider repoProvider;

		public OrderMappingProfile (IRepoProvider repoProvider)
		{
            this.repoProvider = repoProvider;

            // Entity to DTO
            var mappingToDto = this.CreateMap<Order, OrderDTO>();
            this.SetupMappingToDto(mappingToDto);
		  
            // DTO to Entity
		    var mappingEntity = mappingToDto.ReverseMap();
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

                        
            
            
            mappingEntity.ForMember(x => x.Product, opts => opts.ResolveUsing((s, t) =>
	        {
                
	            if (s.ProductId == null)
	            {
	                return null;
	            }

                
	            if (t.Product != null && s.ProductId == t.Product.Id)
	            {
                    // same id value, use source.
	                return t.Product;
	            }

	            var repo = this.repoProvider.Get();

                
	            return repo.LookupProductById(s.ProductId.Value);
                	        }));

            	    
        }

	    public virtual void SetupMappingToDto(IMappingExpression<Order, OrderDTO> mappingToDto)
	    {

            	        mappingToDto.ForMember(x => x.ProductId, opts => opts.ResolveUsing((s, t) =>
	        {
	            return s.Product?.Id;
	        }));
                    }
	}
}