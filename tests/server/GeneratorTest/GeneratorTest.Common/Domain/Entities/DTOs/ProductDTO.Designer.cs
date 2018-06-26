using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace GeneratorTest.Common.Domain.Entities.DTOs
{
	public partial class ProductDTO
	{	
		/// <summary>
		/// The default constructor for ProductDTO class.
		/// </summary>
		public ProductDTO()
		{
		}


		/// <summary>
		/// Property Id mapping to Product.Id
		/// </summary>
		public virtual int Id { get; set; }
		
		/// <summary>
		/// Property Name mapping to Product.Name
		/// </summary>
		public virtual string Name { get; set; }
		
		/// <summary>
		/// Property UnitPrice mapping to Product.UnitPrice
		/// </summary>
		public virtual decimal UnitPrice { get; set; }
		
		/// <summary>
		/// Property CreatedById mapping to Product.CreatedById
		/// </summary>
		public virtual int? CreatedById { get; set; }
		
		/// <summary>
		/// Property CreatedTime mapping to Product.CreatedTime
		/// </summary>
		public virtual System.DateTime? CreatedTime { get; set; }
		
		/// <summary>
		/// Property ModifiedById mapping to Product.ModifiedById
		/// </summary>
		public virtual int? ModifiedById { get; set; }
		
		/// <summary>
		/// Property ModifiedTime mapping to Product.ModifiedTime
		/// </summary>
		public virtual System.DateTime? ModifiedTime { get; set; }
		
		/// <summary>
		/// Property Active mapping to Product.Active
		/// </summary>
		public virtual bool? Active { get; set; }
		

    /// <summary>
    /// Property SpecsJson mapping to Product.SpecsJson. JSON Object!
    /// </summary>
    public virtual GeneratorTest.Common.Domain.ViewModels.ProductSpec[] SpecsJson { get; set; }
    
	}
}