using AutoMapper;
using GeneratorTest.Common.Domain.Entities;
using GeneratorTest.Common.Domain.Entities.DTOs;

namespace GeneratorTest.Common.Domain.Mappings.AutoMapper
{

	public partial class StoreMappingProfile : Profile
	{
	    private readonly IRepoProvider repoProvider;

		public StoreMappingProfile (IRepoProvider repoProvider)
		{
            this.repoProvider = repoProvider;

            // Entity to DTO
            var mappingToDto = this.CreateMap<Store, StoreDTO>();
            this.SetupMappingToDto(mappingToDto);
		  
            // DTO to Entity
		    var mappingEntity = mappingToDto.ReverseMap();
            this.SetupMappingToEntity(mappingEntity);
		}

        public virtual void SetupMappingToEntity(IMappingExpression<StoreDTO, Store> mappingEntity)
	    {
            
            // ignore auditing columns
	        mappingEntity.ForMember(x => x.CreatedById, opts => opts.Ignore());
	        mappingEntity.ForMember(x => x.ModifiedById, opts => opts.Ignore());
	        mappingEntity.ForMember(x => x.CreatedTime, opts => opts.Ignore());
	        mappingEntity.ForMember(x => x.ModifiedTime, opts => opts.Ignore());

            mappingEntity.ForMember(x => x.Active, opts => opts.Condition(s => s.Active != null));

                        
            
            	    
        }

	    public virtual void SetupMappingToDto(IMappingExpression<Store, StoreDTO> mappingToDto)
	    {

                    }
	}
}