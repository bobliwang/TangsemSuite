using AutoMapper;
using GeneratorTest.Common.Domain.Entities;
using GeneratorTest.Common.Domain.Entities.DTOs;

namespace GeneratorTest.Common.Domain.Mappings.AutoMapper
{

	public partial class PosMappingProfile : Profile
	{
	    private readonly IRepoProvider repoProvider;

		public PosMappingProfile (IRepoProvider repoProvider)
		{
            this.repoProvider = repoProvider;

            // Entity to DTO
            var mappingToDto = this.CreateMap<Pos, PosDTO>();
            this.SetupMappingToDto(mappingToDto);
		  
            // DTO to Entity
		    var mappingEntity = mappingToDto.ReverseMap();
            this.SetupMappingToEntity(mappingEntity);
		}

        public virtual void SetupMappingToEntity(IMappingExpression<PosDTO, Pos> mappingEntity)
	    {
            
            // ignore auditing columns
	        mappingEntity.ForMember(x => x.CreatedById, opts => opts.Ignore());
	        mappingEntity.ForMember(x => x.ModifiedById, opts => opts.Ignore());
	        mappingEntity.ForMember(x => x.CreatedTime, opts => opts.Ignore());
	        mappingEntity.ForMember(x => x.ModifiedTime, opts => opts.Ignore());

            mappingEntity.ForMember(x => x.Active, opts => opts.Condition(s => s.Active != null));

                        
            
            	    
        }

	    public virtual void SetupMappingToDto(IMappingExpression<Pos, PosDTO> mappingToDto)
	    {

                    }
	}
}