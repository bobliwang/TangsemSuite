using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Tangsem.Generator.NHibernateTest.Domain.Entities.DTOs
{
	public partial class CategoryDTO
	{	
		/// <summary>
		/// The default constructor for CategoryDTO class.
		/// </summary>
		public CategoryDTO()
		{
		}


		/// <summary>
		/// Property Id mapping to Category.Id
		/// </summary>
		public virtual int Id { get; set; }
		
		/// <summary>
		/// Property Name mapping to Category.Name
		/// </summary>
		public virtual string Name { get; set; }
		
		/// <summary>
		/// Property ShortDescription mapping to Category.ShortDescription
		/// </summary>
		public virtual string ShortDescription { get; set; }
		
		/// <summary>
		/// Property Description mapping to Category.Description
		/// </summary>
		public virtual string Description { get; set; }
		
		/// <summary>
		/// Property ParentId mapping to Category.ParentId
		/// </summary>
		public virtual int? ParentId { get; set; }
		
		/// <summary>
		/// Property KeyWords mapping to Category.KeyWords
		/// </summary>
		public virtual string KeyWords { get; set; }
		
		/// <summary>
		/// Property CreatedById mapping to Category.CreatedById
		/// </summary>
		public virtual int? CreatedById { get; set; }
		
		/// <summary>
		/// Property ModifiedById mapping to Category.ModifiedById
		/// </summary>
		public virtual int? ModifiedById { get; set; }
		
		/// <summary>
		/// Property CreatedTime mapping to Category.CreatedTime
		/// </summary>
		public virtual System.DateTime? CreatedTime { get; set; }
		
		/// <summary>
		/// Property ModifiedTime mapping to Category.ModifiedTime
		/// </summary>
		public virtual System.DateTime? ModifiedTime { get; set; }
		
		/// <summary>
		/// Property Active mapping to Category.Active
		/// </summary>
		public virtual bool? Active { get; set; }
		
	}
}