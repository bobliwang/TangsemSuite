using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace GeneratorTest.Common.Domain.Entities.DTOs
{
	public partial class OrderDTO
	{	
		/// <summary>
		/// The default constructor for OrderDTO class.
		/// </summary>
		public OrderDTO()
		{
		}


		/// <summary>
		/// Property Id mapping to Order.Id
		/// </summary>
		public virtual int Id { get; set; }
		
		/// <summary>
		/// Property CustomerName mapping to Order.CustomerName
		/// </summary>
		public virtual string CustomerName { get; set; }
		
		/// <summary>
		/// Property ProductId mapping to Order.ProductId
		/// </summary>
		public virtual int? ProductId { get; set; }
		
		/// <summary>
		/// Property OrderTotal mapping to Order.OrderTotal
		/// </summary>
		public virtual decimal OrderTotal { get; set; }
		
		/// <summary>
		/// Property CreatedById mapping to Order.CreatedById
		/// </summary>
		public virtual int? CreatedById { get; set; }
		
		/// <summary>
		/// Property ModifiedById mapping to Order.ModifiedById
		/// </summary>
		public virtual int? ModifiedById { get; set; }
		
		/// <summary>
		/// Property CreatedTime mapping to Order.CreatedTime
		/// </summary>
		public virtual System.DateTime? CreatedTime { get; set; }
		
		/// <summary>
		/// Property ModifiedTime mapping to Order.ModifiedTime
		/// </summary>
		public virtual System.DateTime? ModifiedTime { get; set; }
		
		/// <summary>
		/// Property Active mapping to Order.Active
		/// </summary>
		public virtual bool? Active { get; set; }
		

	}
}