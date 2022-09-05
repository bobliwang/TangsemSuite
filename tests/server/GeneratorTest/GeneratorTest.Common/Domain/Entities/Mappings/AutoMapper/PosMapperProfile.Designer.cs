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
      // Using mappingToDto.ReverseMap(); will cause issues: https://github.com/AutoMapper/AutoMapper/issues/1764
      // MapFrom/ResolveUsing no longer support null assignment
      //  - It has something to do with ReverseMap() and resolving the same property in the first mapping.
      //  - If I split the logic into two different CreateMap declarations, it works correctly.
      var mappingEntity = this.CreateMap<PosDTO, Pos>();
      this.SetupMappingToEntity(mappingEntity);
    }

    public virtual void SetupMappingToEntity(IMappingExpression<PosDTO, Pos> mappingEntity)
    {
      mappingEntity.ForMember(x => x.Id, opts => opts.Condition(s => s.Id != default(System.Int32)));

      // ignore auditing columns
      mappingEntity.ForMember(x => x.CreatedById, opts => opts.Ignore());
      mappingEntity.ForMember(x => x.ModifiedById, opts => opts.Ignore());
      mappingEntity.ForMember(x => x.CreatedTime, opts => opts.Ignore());
      mappingEntity.ForMember(x => x.ModifiedTime, opts => opts.Ignore());

 
    }

    public virtual void SetupMappingToDto(IMappingExpression<Pos, PosDTO> mappingToDto)
    {
      this.SetupMappingToDtoExtra(mappingToDto);
    }

    partial void SetupMappingToDtoExtra(IMappingExpression<Pos, PosDTO> mappingToDto);
  }
}