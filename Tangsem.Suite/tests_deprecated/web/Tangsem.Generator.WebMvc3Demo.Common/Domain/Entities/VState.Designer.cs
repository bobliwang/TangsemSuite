using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Common.Entities;

namespace Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities
{
	public partial class VState : IAuditableEntity
	{

		/// <summary>
		/// The property name 'RowNum'. It matches the property to column 'RowNum'.
		/// </summary>
		public static readonly string Prop_RowNum = "RowNum";
		
		/// <summary>
		/// The lamda expression for RowNum.
		/// </summary>
		public static readonly Expression<Func<VState, object>> Expr_RowNum = x => x.RowNum;
		
		/// <summary>
		/// The property name 'Id'. It matches the property to column 'Id'.
		/// </summary>
		public static readonly string Prop_Id = "Id";
		
		/// <summary>
		/// The lamda expression for Id.
		/// </summary>
		public static readonly Expression<Func<VState, object>> Expr_Id = x => x.Id;
		
		/// <summary>
		/// The property name 'Name'. It matches the property to column 'Name'.
		/// </summary>
		public static readonly string Prop_Name = "Name";
		
		/// <summary>
		/// The lamda expression for Name.
		/// </summary>
		public static readonly Expression<Func<VState, object>> Expr_Name = x => x.Name;
		
		/// <summary>
		/// The property name 'CountryId'. It matches the property to column 'CountryId'.
		/// </summary>
		public static readonly string Prop_CountryId = "CountryId";
		
		/// <summary>
		/// The lamda expression for CountryId.
		/// </summary>
		public static readonly Expression<Func<VState, object>> Expr_CountryId = x => x.CountryId;
		
		/// <summary>
		/// The property name 'CreatedById'. It matches the property to column 'CreatedById'.
		/// </summary>
		public static readonly string Prop_CreatedById = "CreatedById";
		
		/// <summary>
		/// The lamda expression for CreatedById.
		/// </summary>
		public static readonly Expression<Func<VState, object>> Expr_CreatedById = x => x.CreatedById;
		
		/// <summary>
		/// The property name 'ModifiedById'. It matches the property to column 'ModifiedById'.
		/// </summary>
		public static readonly string Prop_ModifiedById = "ModifiedById";
		
		/// <summary>
		/// The lamda expression for ModifiedById.
		/// </summary>
		public static readonly Expression<Func<VState, object>> Expr_ModifiedById = x => x.ModifiedById;
		
		/// <summary>
		/// The property name 'CreatedTime'. It matches the property to column 'CreatedTime'.
		/// </summary>
		public static readonly string Prop_CreatedTime = "CreatedTime";
		
		/// <summary>
		/// The lamda expression for CreatedTime.
		/// </summary>
		public static readonly Expression<Func<VState, object>> Expr_CreatedTime = x => x.CreatedTime;
		
		/// <summary>
		/// The property name 'ModifiedTime'. It matches the property to column 'ModifiedTime'.
		/// </summary>
		public static readonly string Prop_ModifiedTime = "ModifiedTime";
		
		/// <summary>
		/// The lamda expression for ModifiedTime.
		/// </summary>
		public static readonly Expression<Func<VState, object>> Expr_ModifiedTime = x => x.ModifiedTime;
		
		/// <summary>
		/// The property name 'Active'. It matches the property to column 'Active'.
		/// </summary>
		public static readonly string Prop_Active = "Active";
		
		/// <summary>
		/// The lamda expression for Active.
		/// </summary>
		public static readonly Expression<Func<VState, object>> Expr_Active = x => x.Active;
		
		/// <summary>
		/// The property name 'CountryName'. It matches the property to column 'CountryName'.
		/// </summary>
		public static readonly string Prop_CountryName = "CountryName";
		
		/// <summary>
		/// The lamda expression for CountryName.
		/// </summary>
		public static readonly Expression<Func<VState, object>> Expr_CountryName = x => x.CountryName;
		
		/// <summary>
		/// The property name 'CountryCode'. It matches the property to column 'CountryCode'.
		/// </summary>
		public static readonly string Prop_CountryCode = "CountryCode";
		
		/// <summary>
		/// The lamda expression for CountryCode.
		/// </summary>
		public static readonly Expression<Func<VState, object>> Expr_CountryCode = x => x.CountryCode;
		
		/// <summary>
		/// The property name 'Continent'. It matches the property to column 'Continent'.
		/// </summary>
		public static readonly string Prop_Continent = "Continent";
		
		/// <summary>
		/// The lamda expression for Continent.
		/// </summary>
		public static readonly Expression<Func<VState, object>> Expr_Continent = x => x.Continent;
				
		
		
		
		/// <summary>
		/// The default constructor for VState class.
		/// </summary>
		public VState()
		{

		}


		#region "Basic Columns"


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
				
		#endregion
		
		#region "Outgoing References"
		
		
		#endregion
		
		#region "Incoming References"
		

		#endregion
		

	}
}