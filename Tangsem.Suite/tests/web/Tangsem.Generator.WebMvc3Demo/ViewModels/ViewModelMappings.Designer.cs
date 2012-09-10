using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;

public static class ViewModelMappingsExt
{
  public static Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities.State ToState(this Tangsem.Generator.WebMvc3Demo.ViewModels.StateViewModel stateViewModel)
  {
    var entity = new Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities.State();
    
    stateViewModel.MapToState(entity);

    return entity;
  }

  public static void MapToState(this Tangsem.Generator.WebMvc3Demo.ViewModels.StateViewModel stateViewModel, Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities.State entity)
  { 
    entity.Id = stateViewModel.Id;
    entity.Name = stateViewModel.Name;
    entity.CreatedById = stateViewModel.CreatedById;
  }
}