using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Common.Entities;

namespace Tangsem.Generator.NHibernateTest.Domain.Entities
{
	public partial class State : IAuditableEntity
	{

		/// <summary>
		/// The property name 'Id'. It matches the property to column 'Id'.
		/// </summary>
		public static readonly string Prop_Id = "Id";
		
		/// <summary>
		/// The lamda expression for Id.
		/// </summary>
		public static readonly Expression<Func<State, object>> Expr_Id = x => x.Id;
		
		/// <summary>
		/// The property name 'Name'. It matches the property to column 'Name'.
		/// </summary>
		public static readonly string Prop_Name = "Name";
		
		/// <summary>
		/// The lamda expression for Name.
		/// </summary>
		public static readonly Expression<Func<State, object>> Expr_Name = x => x.Name;
		
		/// <summary>
		/// The property name 'CreatedById'. It matches the property to column 'CreatedById'.
		/// </summary>
		public static readonly string Prop_CreatedById = "CreatedById";
		
		/// <summary>
		/// The lamda expression for CreatedById.
		/// </summary>
		public static readonly Expression<Func<State, object>> Expr_CreatedById = x => x.CreatedById;
		
		/// <summary>
		/// The property name 'ModifiedById'. It matches the property to column 'ModifiedById'.
		/// </summary>
		public static readonly string Prop_ModifiedById = "ModifiedById";
		
		/// <summary>
		/// The lamda expression for ModifiedById.
		/// </summary>
		public static readonly Expression<Func<State, object>> Expr_ModifiedById = x => x.ModifiedById;
		
		/// <summary>
		/// The property name 'CreatedTime'. It matches the property to column 'CreatedTime'.
		/// </summary>
		public static readonly string Prop_CreatedTime = "CreatedTime";
		
		/// <summary>
		/// The lamda expression for CreatedTime.
		/// </summary>
		public static readonly Expression<Func<State, object>> Expr_CreatedTime = x => x.CreatedTime;
		
		/// <summary>
		/// The property name 'ModifiedTime'. It matches the property to column 'ModifiedTime'.
		/// </summary>
		public static readonly string Prop_ModifiedTime = "ModifiedTime";
		
		/// <summary>
		/// The lamda expression for ModifiedTime.
		/// </summary>
		public static readonly Expression<Func<State, object>> Expr_ModifiedTime = x => x.ModifiedTime;
		
		/// <summary>
		/// The property name 'Active'. It matches the property to column 'Active'.
		/// </summary>
		public static readonly string Prop_Active = "Active";
		
		/// <summary>
		/// The lamda expression for Active.
		/// </summary>
		public static readonly Expression<Func<State, object>> Expr_Active = x => x.Active;
				
		

		/// <summary>
		/// The property name 'Country'. It is for the reference 'FK_State_Country'.
		/// </summary>
		public static readonly string Prop_Country  = "Country";

		/// <summary>
		/// The lamda expression for Country.
		/// </summary>
		public static readonly Expression<Func<State, object>> Expr_Country = x => x.Country;
				
		
		/// <summary>
		/// The default constructor for State class.
		/// </summary>
		public State()
		{

		}


		#region "Basic Columns"


		/// <summary>
		/// Property Id mapping to State.Id
		/// </summary>
		public virtual int Id { get; set; }
		
		/// <summary>
		/// Property Name mapping to State.Name
		/// </summary>
		public virtual string Name { get; set; }
		
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
				
		#endregion
		
		#region "Outgoing References"
		

		/// <summary>
		/// Gets or sets reference to Country. ReferenceName: FK_State_Country.
		/// </summary>
		public virtual Country Country { get; set; }
				
		#endregion
		
		#region "Incoming References"
		

		#endregion
		

	}
}