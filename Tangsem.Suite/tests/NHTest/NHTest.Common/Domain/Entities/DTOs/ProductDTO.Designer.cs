using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace NHTest.Common.Domain.Entities.DTOs
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
    /// Property SpecsJson mapping to Product.SpecsJson. JSON Object!
    /// </summary>
    public virtual NHTest.Common.Domain.ViewModels.ProductSpec[] SpecsJson { get; set; }
    
	}
}