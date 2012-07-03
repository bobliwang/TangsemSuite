using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Tangsem.Generator.NHibernateTest.Domain.Entities.DTOs
{
	public partial class StateDTO
	{	
		/// <summary>
		/// The default constructor for StateDTO class.
		/// </summary>
		public StateDTO()
		{
		}


		/// <summary>
		/// Property Id mapping to State.Id
		/// </summary>
		public virtual int Id { get; set; }
		
		/// <summary>
		/// Property Name mapping to State.Name
		/// </summary>
		public virtual string Name { get; set; }
		
		/// <summary>
		/// Property CountryId mapping to State.CountryId
		/// </summary>
		public virtual int? CountryId { get; set; }
		
		/// <summary>
		/// Property CreatedById mapping to State.CreatedById
		/// </summary>
		public virtual int? CreatedById { get; set; }
		
		/// <summary>
		/// Property ModifiedById mapping to State.ModifiedById
		/// </summary>
		public virtual int? ModifiedById { get; set; }
		
		/// <summary>
		/// Property CreatedTime mapping to State.CreatedTime
		/// </summary>
		public virtual System.DateTime? CreatedTime { get; set; }
		
		/// <summary>
		/// Property ModifiedTime mapping to State.ModifiedTime
		/// </summary>
		public virtual System.DateTime? ModifiedTime { get; set; }
		
		/// <summary>
		/// Property Active mapping to State.Active
		/// </summary>
		public virtual bool? Active { get; set; }
		
	}
}