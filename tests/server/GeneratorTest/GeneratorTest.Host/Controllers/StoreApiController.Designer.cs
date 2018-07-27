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

namespace GeneratorTest.Host.Controllers
{
	public partial class StoreApiController : Controller
	{
		private IGeneratorTestRepository _repository = null;

		private IMapper _mapper = null;

		public StoreApiController(IGeneratorTestRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet("_api/repo/Store")]
		public IActionResult GetStoreList(StoreSearchParams filterModel) {

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
     
		[HttpGet("_api/repo/Store/{id}")]
		public IActionResult GetStoreById(int id) {
			var store = _repository.LookupStoreById(id);
            if (store == null)
			{
				return this.NotFound($"Store is not found by id {id}");
			}

            var storeDto = _mapper.Map<StoreDTO>(store);

			return this.Ok(storeDto);
		}

		[HttpPost("_api/repo/Store/{id}")]
		[TransactionFilter]
		public IActionResult UpdateStore(int id, [FromBody] StoreDTO model) {
			var entity = _repository.LookupStoreById(id);

			if (entity == null)
			{
				return this.NotFound($"Store is not found by id {id}");
			}

			_mapper.Map(model, entity);
			_repository.UpdateStore(entity);

			return this.Ok();
		}
     
		[HttpPost("_api/repo/Store")]
		[TransactionFilter]
		public IActionResult CreateStore([FromBody] StoreDTO model) {
			var entity = new Store();

			_mapper.Map(model, entity);
			_repository.SaveStore(entity);

			return this.Ok();
		}

		[HttpPost("_api/repo/Store/{id}/delete")]
		[TransactionFilter]
		public IActionResult DeleteStore(int id, bool isHardDelete) {
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

		protected IQueryable<Store> FilterBySearchParams(IQueryable<Store> qry, StoreSearchParams filterModel)
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