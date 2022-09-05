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
	public partial class CustomerApiControllerBase : Controller
	{
		protected readonly IGeneratorTestRepository _repository = null;

		protected readonly IMapper _mapper = null;

		public CustomerApiControllerBase(IGeneratorTestRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public virtual IActionResult GetCustomerList(CustomerSearchParams filterModel) {

			var filteredQry = this.FilterBySearchParams(_repository.Customers, filterModel);
			var searchResult = new SearchResultModel<CustomerDTO>
			{
				PageIndex = filterModel.PageIndex ?? 0,
				PageSize = filterModel.PageSize ?? int.MaxValue,
				RowsCount = filteredQry.Count(),
				PagedData = filteredQry.SortBy(filterModel)
                                       .SkipAndTake(filterModel)
                                       .ToList()
                                       .Select(x => _mapper.Map<CustomerDTO>(x))
                                       .ToList(),
			};

			return this.Ok(searchResult);
		}
     
		public virtual IActionResult GetCustomerByCustomerId(System.Guid id) {
			var customer = _repository.LookupCustomerByCustomerId(id);
            if (customer == null)
			{
				return this.NotFound($"Customer is not found by id {id}");
			}

            var customerDto = _mapper.Map<CustomerDTO>(customer);

			return this.Ok(customerDto);
		}

		public virtual IActionResult UpdateCustomer(System.Guid id, [FromBody] CustomerDTO model) {
			var entity = _repository.LookupCustomerByCustomerId(id);

			if (entity == null)
			{
				return this.NotFound($"Customer is not found by id {id}");
			}

			_mapper.Map(model, entity);
			_repository.UpdateCustomer(entity);

			return this.Ok();
		}
     
		public virtual IActionResult CreateCustomer([FromBody] CustomerDTO model) {
			var entity = new Customer();

			_mapper.Map(model, entity);
			_repository.SaveCustomer(entity);

			return this.Ok();
		}

		public virtual IActionResult DeleteCustomer(System.Guid id, bool isHardDelete) {
			var entity = _repository.LookupCustomerByCustomerId(id);

			if (entity == null)
			{
				return this.NotFound($"Customer is not found by id {id}");
			}

			if (isHardDelete) {
				_repository.DeleteCustomerByCustomerId(id);			
			}
			else
			{
				entity.Active = false;
				_repository.UpdateCustomer(entity);
			}

			return this.Ok();
		}

		public virtual IQueryable<Customer> FilterBySearchParams(IQueryable<Customer> qry, CustomerSearchParams filterModel)
		{
			var filteredQry = qry; 
		
			
			if (filterModel.CustomerId != null)
			{
										
				filteredQry = filteredQry.Where(x => x.CustomerId == filterModel.CustomerId);
							
			}
			
			if (filterModel.CustomerName != null)
			{
												
				filteredQry = filteredQry.Where(x => x.CustomerName.Contains(filterModel.CustomerName));
										
							
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
			
			if (filterModel.StoreId != null)
			{
							// OutgoingReference
				filteredQry = filteredQry.Where(x => x.Store.Id == filterModel.StoreId);
			
			}
			
			return filteredQry;
		}
	}

}