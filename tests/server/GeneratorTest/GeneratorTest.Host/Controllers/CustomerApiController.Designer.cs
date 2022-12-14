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
	public partial class CustomerApiController : CustomerApiControllerBase
	{	
		public CustomerApiController(IGeneratorTestRepository repository, IMapper mapper): base(repository, mapper) {
		}

		[HttpGet("_api/repo/Customer")]
    [Produces("application/json", Type = typeof(SearchResultModel<CustomerDTO>))]
    [AutoGenApiClient]
		public override IActionResult GetCustomerList(CustomerSearchParams filterModel) {
            return base.GetCustomerList(filterModel);
		}
     
		[HttpGet("_api/repo/Customer/{id}")]
    [Produces("application/json", Type = typeof(CustomerDTO))]
    [AutoGenApiClient]
		public override IActionResult GetCustomerByCustomerId(System.Guid id) {
			return base.GetCustomerByCustomerId(id);
		}

		[HttpPost("_api/repo/Customer/{id}")]
    [Produces("application/json", Type = typeof(object))]
    [AutoGenApiClient]
    [TransactionFilter]
		public override IActionResult UpdateCustomer(System.Guid id, [FromBody] CustomerDTO model) {
		    return base.UpdateCustomer(id, model);
		}
     
		[HttpPost("_api/repo/Customer")]
		[Produces("application/json", Type = typeof(object))]
    [AutoGenApiClient]
    [TransactionFilter]
		public override IActionResult CreateCustomer([FromBody] CustomerDTO model) {
			return base.CreateCustomer(model);
		}

		[HttpPost("_api/repo/Customer/{id}/delete")]		
    [Produces("application/json", Type = typeof(object))]
    [AutoGenApiClient]
    [TransactionFilter]
		public override IActionResult DeleteCustomer(System.Guid id, bool isHardDelete) {
      return base.DeleteCustomer(id, isHardDelete);
		}

		public override IQueryable<Customer> FilterBySearchParams(IQueryable<Customer> qry, CustomerSearchParams filterModel) {
      return base.FilterBySearchParams(qry, filterModel);
		}
	}

}