using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities.DTOs
{
	public partial class VStateDTO
	{	
		/// <summary>
		/// The default constructor for VStateDTO class.
		/// </summary>
		public VStateDTO()
		{
		}


		/// <summary>
		/// Property RowNum mapping to v_State.RowNum
		/// </summary>
		public virtual long? RowNum { get; set; }
		
		/// <summary>
		/// Property Id mapping to v_State.Id
		/// </summary>
		public virtual int Id { get; set; }
		
		/// <summary>
		/// Property Name mapping to v_State.Name
		/// </summary>
		public virtual string Name { get; set; }
		
		/// <summary>
		/// Property CountryId mapping to v_State.CountryId
		/// </summary>
		public virtual int? CountryId { get; set; }
		
		/// <summary>
		/// Property CreatedById mapping to v_State.CreatedById
		/// </summary>
		public virtual int? CreatedById { get; set; }
		
		/// <summary>
		/// Property ModifiedById mapping to v_State.ModifiedById
		/// </summary>
		public virtual int? ModifiedById { get; set; }
		
		/// <summary>
		/// Property CreatedTime mapping to v_State.CreatedTime
		/// </summary>
		public virtual System.DateTime? CreatedTime { get; set; }
		
		/// <summary>
		/// Property ModifiedTime mapping to v_State.ModifiedTime
		/// </summary>
		public virtual System.DateTime? ModifiedTime { get; set; }
		
		/// <summary>
		/// Property Active mapping to v_State.Active
		/// </summary>
		public virtual bool? Active { get; set; }
		
		/// <summary>
		/// Property CountryName mapping to v_State.CountryName
		/// </summary>
		public virtual string CountryName { get; set; }
		
		/// <summary>
		/// Property CountryCode mapping to v_State.CountryCode
		/// </summary>
		public virtual string CountryCode { get; set; }
		
		/// <summary>
		/// Property Continent mapping to v_State.Continent
		/// </summary>
		public virtual string Continent { get; set; }
		
	}
}