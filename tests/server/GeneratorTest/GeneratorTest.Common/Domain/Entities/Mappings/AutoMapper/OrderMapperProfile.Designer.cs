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
            // Using mappingToDto.ReverseMap(); will cause issues: https://github.com/AutoMapper/AutoMapper/issues/1764
            // MapFrom/ResolveUsing no longer support null assignment
            //  - It has something to do with ReverseMap() and resolving the same property in the first mapping.
            //  - If I split the logic into two different CreateMap declarations, it works correctly.
		    var mappingEntity = this.CreateMap<OrderDTO, Order>();
            this.SetupMappingToEntity(mappingEntity);
		}

        public virtual void SetupMappingToEntity(IMappingExpression<OrderDTO, Order> mappingEntity)
	    {
            mappingEntity.ForMember(x => x.Id, opts => opts.Condition(s => s.Id != default(System.Int32)));

            
            // ignore auditing columns
	        mappingEntity.ForMember(x => x.CreatedById, opts => opts.Ignore());
	        mappingEntity.ForMember(x => x.ModifiedById, opts => opts.Ignore());
	        mappingEntity.ForMember(x => x.CreatedTime, opts => opts.Ignore());
	        mappingEntity.ForMember(x => x.ModifiedTime, opts => opts.Ignore());

            mappingEntity.ForMember(x => x.Active, opts => opts.Condition(s => s.Active != null));

                        
            
            
            mappingEntity.ForMember(x => x.Customer, opts => opts.ResolveUsing((s, t) =>
	        {
                
	            if (s.CustomerId == null)
	            {
	                return null;
	            }

                
	            if (t.Customer != null && s.CustomerId == t.Customer.CustomerId)
	            {
                    // same id value, use source.
	                return t.Customer;
	            }

	            var repo = this.repoProvider.Get();

                
	            return repo.LookupCustomerByCustomerId(s.CustomerId.Value);
                	        }));

            
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

            	        mappingToDto.ForMember(x => x.CustomerId, opts => opts.ResolveUsing((s, t) =>
	        {
                	            return s.Customer?.CustomerId;
                	        }));
            	        mappingToDto.ForMember(x => x.ProductId, opts => opts.ResolveUsing((s, t) =>
	        {
                	            return s.Product?.Id;
                	        }));
                    }
	}
}