using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Tangsem.Generator.NHibernateTest.Domain.Entities
{
	public partial class State
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