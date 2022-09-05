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
	public partial class OrderApiController : OrderApiControllerBase
	{	
		public OrderApiController(IGeneratorTestRepository repository, IMapper mapper): base(repository, mapper) {
		}

		[HttpGet("_api/repo/Order")]
    [Produces("application/json", Type = typeof(SearchResultModel<OrderDTO>))]
    [AutoGenApiClient]
		public override IActionResult GetOrderList(OrderSearchParams filterModel) {
            return base.GetOrderList(filterModel);
		}
     
		[HttpGet("_api/repo/Order/{id}")]
    [Produces("application/json", Type = typeof(OrderDTO))]
    [AutoGenApiClient]
		public override IActionResult GetOrderById(int id) {
			return base.GetOrderById(id);
		}

		[HttpPost("_api/repo/Order/{id}")]
    [Produces("application/json", Type = typeof(object))]
    [AutoGenApiClient]
    [TransactionFilter]
		public override IActionResult UpdateOrder(int id, [FromBody] OrderDTO model) {
		    return base.UpdateOrder(id, model);
		}
     
		[HttpPost("_api/repo/Order")]
		[Produces("application/json", Type = typeof(object))]
    [AutoGenApiClient]
    [TransactionFilter]
		public override IActionResult CreateOrder([FromBody] OrderDTO model) {
			return base.CreateOrder(model);
		}

		[HttpPost("_api/repo/Order/{id}/delete")]		
    [Produces("application/json", Type = typeof(object))]
    [AutoGenApiClient]
    [TransactionFilter]
		public override IActionResult DeleteOrder(int id, bool isHardDelete) {
      return base.DeleteOrder(id, isHardDelete);
		}

		public override IQueryable<Order> FilterBySearchParams(IQueryable<Order> qry, OrderSearchParams filterModel) {
      return base.FilterBySearchParams(qry, filterModel);
		}
	}

}