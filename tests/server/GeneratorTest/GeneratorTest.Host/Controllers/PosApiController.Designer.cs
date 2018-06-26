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
	public partial class PosApiController : Controller
	{
		private IGeneratorTestRepository _repository = null;

		private IMapper _mapper = null;

		public PosApiController(IGeneratorTestRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet("_api/repo/Pos")]
		public IActionResult GetPosList(PosSearchParams filterModel) {

			var filteredQry = this.FilterBySearchParams(_repository.Poses, filterModel);
			var searchResult = new SearchResultModel<Pos>
			{
				PageIndex = filterModel.PageIndex ?? 0,
				PageSize = filterModel.PageSize ?? int.MaxValue,
				RowsCount = filteredQry.Count(),
				PagedData = filteredQry.SortBy(filterModel).SkipAndTake(filterModel).ToList(),
			};

			return this.Ok(searchResult);
		}
     
		[HttpGet("_api/repo/Pos/{id}")]
		public IActionResult GetPosById(int id) {
			var entity = _repository.LookupPosById(id);

			return this.Ok(entity);
		}

		[HttpPost("_api/repo/Pos/{id}")]
		[TransactionFilter]
		public IActionResult UpdatePos(int id, [FromBody] PosDTO model) {
			var entity = _repository.LookupPosById(id);

			if (entity == null)
			{
				return this.NotFound($"Pos is not found by id {id}");
			}

			_mapper.Map(model, entity);
			_repository.UpdatePos(entity);

			return this.Ok();
		}
     
		[HttpPost("_api/repo/Pos")]
		[TransactionFilter]
		public IActionResult CreatePos([FromBody] PosDTO model) {
			var entity = new Pos();

			_mapper.Map(model, entity);
			_repository.SavePos(entity);

			return this.Ok();
		}

		[HttpPost("_api/repo/Pos/{id}/delete")]
		[TransactionFilter]
		public IActionResult DeletePos(int id, bool isHardDelete) {
			var entity = _repository.LookupPosById(id);

			if (entity == null)
			{
				return this.NotFound($"Pos is not found by id {id}");
			}

			if (isHardDelete) {
				_repository.DeletePosById(id);			
			}
			else
			{
				entity.Active = false;
				_repository.UpdatePos(entity);
			}

			return this.Ok();
		}

		protected IQueryable<Pos> FilterBySearchParams(IQueryable<Pos> qry, PosSearchParams filterModel)
		{
			var filteredQry = qry; 
		
			
			if (filterModel.Id != null)
			{
										
					filteredQry = filteredQry.Where(x => x.Id == filterModel.Id);
							
			}
			
			if (filterModel.Name != null)
			{
							
											filteredQry = filteredQry.Where(x => x.Name.Contains(filterModel.Name));
										
							
			}
			
			if (filterModel.CreatedById != null)
			{
										
					filteredQry = filteredQry.Where(x => x.CreatedById == filterModel.CreatedById);
							
			}
			
			if (filterModel.ModifiedById != null)
			{
										
					filteredQry = filteredQry.Where(x => x.ModifiedById == filterModel.ModifiedById);
							
			}
			
			if (filterModel.CreatedTime != null)
			{
										
					filteredQry = filteredQry.Where(x => x.CreatedTime == filterModel.CreatedTime);
							
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