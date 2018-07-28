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
	public partial class OrderApiControllerBase : Controller
	{
		protected readonly IGeneratorTestRepository _repository = null;

		protected readonly IMapper _mapper = null;

		public OrderApiControllerBase(IGeneratorTestRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public virtual IActionResult GetOrderList(OrderSearchParams filterModel) {

			var filteredQry = this.FilterBySearchParams(_repository.Orders, filterModel);
			var searchResult = new SearchResultModel<OrderDTO>
			{
				PageIndex = filterModel.PageIndex ?? 0,
				PageSize = filterModel.PageSize ?? int.MaxValue,
				RowsCount = filteredQry.Count(),
				PagedData = filteredQry.SortBy(filterModel)
                                       .SkipAndTake(filterModel)
                                       .ToList()
                                       .Select(x => _mapper.Map<OrderDTO>(x))
                                       .ToList(),
			};

			return this.Ok(searchResult);
		}
     
		public virtual IActionResult GetOrderById(int id) {
			var order = _repository.LookupOrderById(id);
            if (order == null)
			{
				return this.NotFound($"Order is not found by id {id}");
			}

            var orderDto = _mapper.Map<OrderDTO>(order);

			return this.Ok(orderDto);
		}

		public virtual IActionResult UpdateOrder(int id, [FromBody] OrderDTO model) {
			var entity = _repository.LookupOrderById(id);

			if (entity == null)
			{
				return this.NotFound($"Order is not found by id {id}");
			}

			_mapper.Map(model, entity);
			_repository.UpdateOrder(entity);

			return this.Ok();
		}
     
		public virtual IActionResult CreateOrder([FromBody] OrderDTO model) {
			var entity = new Order();

			_mapper.Map(model, entity);
			_repository.SaveOrder(entity);

			return this.Ok();
		}

		public virtual IActionResult DeleteOrder(int id, bool isHardDelete) {
			var entity = _repository.LookupOrderById(id);

			if (entity == null)
			{
				return this.NotFound($"Order is not found by id {id}");
			}

			if (isHardDelete) {
				_repository.DeleteOrderById(id);			
			}
			else
			{
				entity.Active = false;
				_repository.UpdateOrder(entity);
			}

			return this.Ok();
		}

		public virtual IQueryable<Order> FilterBySearchParams(IQueryable<Order> qry, OrderSearchParams filterModel)
		{
			var filteredQry = qry; 
		
			
			if (filterModel.Id != null)
			{
										
				filteredQry = filteredQry.Where(x => x.Id == filterModel.Id);
							
			}
			
			if (filterModel.CustomerName != null)
			{
												
				filteredQry = filteredQry.Where(x => x.CustomerName.Contains(filterModel.CustomerName));
										
							
			}
			
			if (filterModel.ProductId != null)
			{
							// OutgoingReference
				filteredQry = filteredQry.Where(x => x.Product.Id == filterModel.ProductId);
			
			}
			
			if (filterModel.CustomerId != null)
			{
							// OutgoingReference
				filteredQry = filteredQry.Where(x => x.Customer.CustomerId == filterModel.CustomerId);
			
			}
			
			if (filterModel.OrderTotal != null)
			{
										
				filteredQry = filteredQry.Where(x => x.OrderTotal == filterModel.OrderTotal);
							
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