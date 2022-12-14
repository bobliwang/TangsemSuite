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
using GeneratorTest.Host.Infrastructure;

namespace GeneratorTest.Host.Controllers
{
	public partial class StoreApiController : StoreApiControllerBase
	{	
		public StoreApiController(IGeneratorTestRepository repository, IMapper mapper): base(repository, mapper) {
		}

		[HttpGet("_api/repo/Store")]
    [Produces("application/json", Type = typeof(SearchResultModel<StoreDTO>))]
    [AutoGenApiClient]
		public override IActionResult GetStoreList(StoreSearchParams filterModel) {
            return base.GetStoreList(filterModel);
		}
     
		[HttpGet("_api/repo/Store/{id}")]
    [Produces("application/json", Type = typeof(StoreDTO))]
    [AutoGenApiClient]
		public override IActionResult GetStoreById(int id) {
			return base.GetStoreById(id);
		}

		[HttpPost("_api/repo/Store/{id}")]
    [Produces("application/json", Type = typeof(object))]
    [AutoGenApiClient]
    [TransactionFilter]
		public override IActionResult UpdateStore(int id, [FromBody] StoreDTO model) {
		    return base.UpdateStore(id, model);
		}
     
		[HttpPost("_api/repo/Store")]
		[Produces("application/json", Type = typeof(object))]
    [AutoGenApiClient]
    [TransactionFilter]
		public override IActionResult CreateStore([FromBody] StoreDTO model) {
			return base.CreateStore(model);
		}

		[HttpPost("_api/repo/Store/{id}/delete")]		
    [Produces("application/json", Type = typeof(object))]
    [AutoGenApiClient]
    [TransactionFilter]
		public override IActionResult DeleteStore(int id, bool isHardDelete) {
      return base.DeleteStore(id, isHardDelete);
		}

		public override IQueryable<Store> FilterBySearchParams(IQueryable<Store> qry, StoreSearchParams filterModel) {
      return base.FilterBySearchParams(qry, filterModel);
		}
	}

}