using AutoMapper;
using GeneratorTest.Common.Domain.Entities;
using GeneratorTest.Common.Domain.Entities.DTOs;

namespace GeneratorTest.Common.Domain.Mappings.AutoMapper
{

	public partial class CustomerMappingProfile : Profile
	{
	    private readonly IRepoProvider repoProvider;

		public CustomerMappingProfile (IRepoProvider repoProvider)
		{
            this.repoProvider = repoProvider;

            // Entity to DTO
            var mappingToDto = this.CreateMap<Customer, CustomerDTO>();
            this.SetupMappingToDto(mappingToDto);
		  
            // DTO to Entity
            // Using mappingToDto.ReverseMap(); will cause issues: https://github.com/AutoMapper/AutoMapper/issues/1764
            // MapFrom/ResolveUsing no longer support null assignment
            //  - It has something to do with ReverseMap() and resolving the same property in the first mapping.
            //  - If I split the logic into two different CreateMap declarations, it works correctly.
		    var mappingEntity = this.CreateMap<CustomerDTO, Customer>();
            this.SetupMappingToEntity(mappingEntity);
		}

        public virtual void SetupMappingToEntity(IMappingExpression<CustomerDTO, Customer> mappingEntity)
	    {
            mappingEntity.ForMember(x => x.CustomerId, opts => opts.Condition(s => s.CustomerId != default(System.Guid)));

            
            // ignore auditing columns
	        mappingEntity.ForMember(x => x.CreatedById, opts => opts.Ignore());
	        mappingEntity.ForMember(x => x.ModifiedById, opts => opts.Ignore());
	        mappingEntity.ForMember(x => x.CreatedTime, opts => opts.Ignore());
	        mappingEntity.ForMember(x => x.ModifiedTime, opts => opts.Ignore());

            mappingEntity.ForMember(x => x.Active, opts => opts.Condition(s => s.Active != null));

                        
            
            
            mappingEntity.ForMember(x => x.Store, opts => opts.ResolveUsing((s, t) =>
	        {
                
	            if (s.StoreId == null)
	            {
	                return null;
	            }

                
	            if (t.Store != null && s.StoreId == t.Store.Id)
	            {
                    // same id value, use source.
	                return t.Store;
	            }

	            var repo = this.repoProvider.Get();

                
	            return repo.LookupStoreById(s.StoreId.Value);
                	        }));

            	    
        }

	    public virtual void SetupMappingToDto(IMappingExpression<Customer, CustomerDTO> mappingToDto)
	    {

            	        mappingToDto.ForMember(x => x.StoreId, opts => opts.ResolveUsing((s, t) =>
	        {
                	            return s.Store?.Id;
                	        }));
                    }
	}
}