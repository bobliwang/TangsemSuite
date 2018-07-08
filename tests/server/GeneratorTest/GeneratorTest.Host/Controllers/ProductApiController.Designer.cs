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
	public partial class ProductApiController : Controller
	{
		private IGeneratorTestRepository _repository = null;

		private IMapper _mapper = null;

		public ProductApiController(IGeneratorTestRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet("_api/repo/Product")]
		public IActionResult GetProductList(ProductSearchParams filterModel) {

			var filteredQry = this.FilterBySearchParams(_repository.Products, filterModel);
			var searchResult = new SearchResultModel<ProductDTO>
			{
				PageIndex = filterModel.PageIndex ?? 0,
				PageSize = filterModel.PageSize ?? int.MaxValue,
				RowsCount = filteredQry.Count(),
				PagedData = filteredQry.SortBy(filterModel)
                                       .SkipAndTake(filterModel)
                                       .ToList()
                                       .Select(x => _mapper.Map<ProductDTO>(x))
                                       .ToList(),
			};

			return this.Ok(searchResult);
		}
     
		[HttpGet("_api/repo/Product/{id}")]
		public IActionResult GetProductById(int id) {
			var product = _repository.LookupProductById(id);
            if (product == null)
			{
				return this.NotFound($"Product is not found by id {id}");
			}

            var productDto = _mapper.Map<ProductDTO>(product);

			return this.Ok(productDto);
		}

		[HttpPost("_api/repo/Product/{id}")]
		[TransactionFilter]
		public IActionResult UpdateProduct(int id, [FromBody] ProductDTO model) {
			var entity = _repository.LookupProductById(id);

			if (entity == null)
			{
				return this.NotFound($"Product is not found by id {id}");
			}

			_mapper.Map(model, entity);
			_repository.UpdateProduct(entity);

			return this.Ok();
		}
     
		[HttpPost("_api/repo/Product")]
		[TransactionFilter]
		public IActionResult CreateProduct([FromBody] ProductDTO model) {
			var entity = new Product();

			_mapper.Map(model, entity);
			_repository.SaveProduct(entity);

			return this.Ok();
		}

		[HttpPost("_api/repo/Product/{id}/delete")]
		[TransactionFilter]
		public IActionResult DeleteProduct(int id, bool isHardDelete) {
			var entity = _repository.LookupProductById(id);

			if (entity == null)
			{
				return this.NotFound($"Product is not found by id {id}");
			}

			if (isHardDelete) {
				_repository.DeleteProductById(id);			
			}
			else
			{
				entity.Active = false;
				_repository.UpdateProduct(entity);
			}

			return this.Ok();
		}

		protected IQueryable<Product> FilterBySearchParams(IQueryable<Product> qry, ProductSearchParams filterModel)
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
			
			if (filterModel.UnitPrice != null)
			{
										
					filteredQry = filteredQry.Where(x => x.UnitPrice == filterModel.UnitPrice);
							
			}
			
			if (filterModel.SpecsJson != null)
			{
							
											filteredQry = filteredQry.Where(x => x.SpecsJson.ToJsonString().Contains(filterModel.SpecsJson));
										
							
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