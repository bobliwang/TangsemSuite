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
		
	}
}