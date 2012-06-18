using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities
{
	public partial class Country
	{

		/// <summary>
		/// The property name 'Id'. It matches the property to column 'Id'.
		/// </summary>
		public static readonly string Prop_Id = "Id";
		
		/// <summary>
		/// The lamda expression for Id.
		/// </summary>
		public static readonly Expression<Func<Country, object>> Expr_Id = x => x.Id;
		
		/// <summary>
		/// The property name 'Name'. It matches the property to column 'Name'.
		/// </summary>
		public static readonly string Prop_Name = "Name";
		
		/// <summary>
		/// The lamda expression for Name.
		/// </summary>
		public static readonly Expression<Func<Country, object>> Expr_Name = x => x.Name;
		
		/// <summary>
		/// The property name 'CountryCode'. It matches the property to column 'CountryCode'.
		/// </summary>
		public static readonly string Prop_CountryCode = "CountryCode";
		
		/// <summary>
		/// The lamda expression for CountryCode.
		/// </summary>
		public static readonly Expression<Func<Country, object>> Expr_CountryCode = x => x.CountryCode;
		
		/// <summary>
		/// The property name 'Continent'. It matches the property to column 'Continent'.
		/// </summary>
		public static readonly string Prop_Continent = "Continent";
		
		/// <summary>
		/// The lamda expression for Continent.
		/// </summary>
		public static readonly Expression<Func<Country, object>> Expr_Continent = x => x.Continent;
				
		
		
		
		/// <summary>
		/// The default constructor for Country class.
		/// </summary>
		public Country()
		{

			this.States = new List<State>();
			
		}


		#region "Basic Columns"


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
				
		#endregion
		
		#region "Outgoing References"
		
		
		#endregion
		
		#region "Incoming References"
		

		/// <summary>
		/// Field for the child list of Ref: FK_State_Country.
		/// </summary>
		public virtual IList<State> States { get; set; }
		
		/// <summary>
		/// Add State entity to States.
		/// </summary>
		/// <param name="state">
		///	The State entity.
		/// </param>
		public virtual void AddToStates(State state)
		{
			state.Country = this;
			this.States.Add(state);
		}
		
		#endregion
		

	}
}