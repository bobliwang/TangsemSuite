using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GeneratorTest.Common.Domain.Repositories;
using GeneratorTest.Common.Domain.Entities;
using GeneratorTest.Common.Domain.Entities.DTOs;
using GeneratorTest.Common.Domain.ViewModels.SearchParams;

using Tangsem.Data;
using Tangsem.NHibernate.Extenstions;
using GeneratorTest.Host.Filters;

namespace GeneratorTest.Host.Controllers.Base
{
	public partial class StoreApiControllerBase : Controller
	{
		protected readonly IGeneratorTestRepository _repository = null;

		protected readonly IMapper _mapper = null;

		public StoreApiControllerBase(IGeneratorTestRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public virtual IActionResult GetStoreList(StoreSearchParams filterModel) {

			var filteredQry = this.FilterBySearchParams(_repository.Stores, filterModel);
			var searchResult = new SearchResultModel<StoreDTO>
			{
				PageIndex = filterModel.PageIndex ?? 0,
				PageSize = filterModel.PageSize ?? int.MaxValue,
				RowsCount = filteredQry.Count(),
				PagedData = filteredQry.SortBy(filterModel)
                                       .SkipAndTake(filterModel)
                                       .ToList()
                                       .Select(x => _mapper.Map<StoreDTO>(x))
                                       .ToList(),
			};

			return this.Ok(searchResult);
		}
     
		public virtual IActionResult GetStoreById(int id) {
			var store = _repository.LookupStoreById(id);
            if (store == null)
			{
				return this.NotFound($"Store is not found by id {id}");
			}

            var storeDto = _mapper.Map<StoreDTO>(store);

			return this.Ok(storeDto);
		}

		public virtual IActionResult UpdateStore(int id, [FromBody] StoreDTO model) {
			var entity = _repository.LookupStoreById(id);

			if (entity == null)
			{
				return this.NotFound($"Store is not found by id {id}");
			}

			_mapper.Map(model, entity);
			_repository.UpdateStore(entity);

			return this.Ok();
		}
     
		public virtual IActionResult CreateStore([FromBody] StoreDTO model) {
			var entity = new Store();

			_mapper.Map(model, entity);
			_repository.SaveStore(entity);

			return this.Ok();
		}

		public virtual IActionResult DeleteStore(int id, bool isHardDelete) {
			var entity = _repository.LookupStoreById(id);

			if (entity == null)
			{
				return this.NotFound($"Store is not found by id {id}");
			}

			if (isHardDelete) {
				_repository.DeleteStoreById(id);			
			}
			else
			{
				entity.Active = false;
				_repository.UpdateStore(entity);
			}

			return this.Ok();
		}

		public virtual IQueryable<Store> FilterBySearchParams(IQueryable<Store> qry, StoreSearchParams filterModel)
		{
			var filteredQry = qry; 
		
			
			if (filterModel.Id != null)
			{
										
				filteredQry = filteredQry.Where(x => x.Id == filterModel.Id);
							
			}
			
			if (filterModel.StoreName != null)
			{
												
				filteredQry = filteredQry.Where(x => x.StoreName.Contains(filterModel.StoreName));
										
							
			}
			
			if (filterModel.StorePhoto != null)
			{
												
				filteredQry = filteredQry.Where(x => x.StorePhoto.Contains(filterModel.StorePhoto));
										
							
			}
			
			if (filterModel.CreatedById != null)
			{
										
				filteredQry = filteredQry.Where(x => x.CreatedById == filterModel.CreatedById);
							
			}
			
			if (filterModel.CreatedTime != null)
			{
										
				filteredQry = filteredQry.Where(x => x.CreatedTime == filterModel.CreatedTime);
							
			}
			
			if (filterModel.ModifiedById != null)
			{
										
				filteredQry = filteredQry.Where(x => x.ModifiedById == filterModel.ModifiedById);
							
			}
			
			if (filterModel.ModifiedTime != null)
			{
										
				filteredQry = filteredQry.Where(x => x.ModifiedTime == filterModel.ModifiedTime);
							
			}
			
			if (filterModel.Active != null)
			{
										
				filteredQry = filteredQry.Where(x => x.Active == filterModel.Active);
							
			}
			
			return filteredQry;
		}
	}

}