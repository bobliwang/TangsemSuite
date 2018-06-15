using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace NHTest.Common.Domain.Entities.DTOs
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
		/// Property OrderTotal mapping to Order.OrderTotal
		/// </summary>
		public virtual decimal OrderTotal { get; set; }
		

	}
}