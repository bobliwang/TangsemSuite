using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace GeneratorTest.Common.Domain.Entities.DTOs
{
	public partial class CustomerDTO
	{	
		/// <summary>
		/// The default constructor for CustomerDTO class.
		/// </summary>
		public CustomerDTO()
		{
		}


		/// <summary>
		/// Property CustomerId mapping to Customer.CustomerId
		/// </summary>
		public virtual System.Guid CustomerId { get; set; }
		
		/// <summary>
		/// Property CustomerName mapping to Customer.CustomerName
		/// </summary>
		public virtual string CustomerName { get; set; }
		
		/// <summary>
		/// Property StoreId mapping to Customer.StoreId
		/// </summary>
		public virtual int? StoreId { get; set; }
		
		/// <summary>
		/// Property CreatedById mapping to Customer.CreatedById
		/// </summary>
		public virtual int? CreatedById { get; set; }
		
		/// <summary>
		/// Property ModifiedById mapping to Customer.ModifiedById
		/// </summary>
		public virtual int? ModifiedById { get; set; }
		
		/// <summary>
		/// Property CreatedTime mapping to Customer.CreatedTime
		/// </summary>
		public virtual System.DateTime? CreatedTime { get; set; }
		
		/// <summary>
		/// Property ModifiedTime mapping to Customer.ModifiedTime
		/// </summary>
		public virtual System.DateTime? ModifiedTime { get; set; }
		
		/// <summary>
		/// Property Active mapping to Customer.Active
		/// </summary>
		public virtual bool? Active { get; set; }
		

	}
}