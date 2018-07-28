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
using GeneratorTest.Host.Controllers.Base;

namespace GeneratorTest.Host.Controllers
{
	public partial class ProductApiController : ProductApiControllerBase
	{	
		public ProductApiController(IGeneratorTestRepository repository, IMapper mapper): base(repository, mapper) {
		}

		[HttpGet("_api/repo/Product")]
		public override IActionResult GetProductList(ProductSearchParams filterModel) {
            return base.GetProductList(filterModel);
		}
     
		[HttpGet("_api/repo/Product/{id}")]
		public override IActionResult GetProductById(int id) {
			return base.GetProductById(id);
		}

		[HttpPost("_api/repo/Product/{id}")]
		[TransactionFilter]
		public override IActionResult UpdateProduct(int id, [FromBody] ProductDTO model) {
		    return base.UpdateProduct(id, model);
		}
     
		[HttpPost("_api/repo/Product")]
		[TransactionFilter]
		public override IActionResult CreateProduct([FromBody] ProductDTO model) {
			return base.CreateProduct(model);
		}

		[HttpPost("_api/repo/Product/{id}/delete")]
		[TransactionFilter]
		public override IActionResult DeleteProduct(int id, bool isHardDelete) {
            return base.DeleteProduct(id, isHardDelete);
		}

		public override IQueryable<Product> FilterBySearchParams(IQueryable<Product> qry, ProductSearchParams filterModel) {
            return base.FilterBySearchParams(qry, filterModel);
		}
	}

}