using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Tangsem.Generator.NHibernateTest.Domain.Entities.DTOs
{
	public partial class CountryDTO
	{	
		/// <summary>
		/// The default constructor for CountryDTO class.
		/// </summary>
		public CountryDTO()
		{
		}


		/// <summary>
		/// Property Id mapping to Country.Id
		/// </summary>
		public virtual int Id { get; set; }
		
		/// <summary>
		/// Property Name mapping to Country.Name
		/// </summary>
		public virtual string Name { get; set; }
		
		/// <summary>
		/// Property CountryCode mapping to Country.CountryCode
		/// </summary>
		public virtual string CountryCode { get; set; }
		
		/// <summary>
		/// Property Continent mapping to Country.Continent
		/// </summary>
		public virtual string Continent { get; set; }
		
	}
}