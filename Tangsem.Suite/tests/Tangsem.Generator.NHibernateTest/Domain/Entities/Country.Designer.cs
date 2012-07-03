using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Common.Entities;

namespace Tangsem.Generator.NHibernateTest.Domain.Entities
{
	public partial class Country : IAuditableEntity
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
		/// The property name 'CreatedById'. It matches the property to column 'CreatedById'.
		/// </summary>
		public static readonly string Prop_CreatedById = "CreatedById";
		
		/// <summary>
		/// The lamda expression for CreatedById.
		/// </summary>
		public static readonly Expression<Func<Country, object>> Expr_CreatedById = x => x.CreatedById;
		
		/// <summary>
		/// The property name 'ModifiedById'. It matches the property to column 'ModifiedById'.
		/// </summary>
		public static readonly string Prop_ModifiedById = "ModifiedById";
		
		/// <summary>
		/// The lamda expression for ModifiedById.
		/// </summary>
		public static readonly Expression<Func<Country, object>> Expr_ModifiedById = x => x.ModifiedById;
		
		/// <summary>
		/// The property name 'CreatedTime'. It matches the property to column 'CreatedTime'.
		/// </summary>
		public static readonly string Prop_CreatedTime = "CreatedTime";
		
		/// <summary>
		/// The lamda expression for CreatedTime.
		/// </summary>
		public static readonly Expression<Func<Country, object>> Expr_CreatedTime = x => x.CreatedTime;
		
		/// <summary>
		/// The property name 'ModifiedTime'. It matches the property to column 'ModifiedTime'.
		/// </summary>
		public static readonly string Prop_ModifiedTime = "ModifiedTime";
		
		/// <summary>
		/// The lamda expression for ModifiedTime.
		/// </summary>
		public static readonly Expression<Func<Country, object>> Expr_ModifiedTime = x => x.ModifiedTime;
		
		/// <summary>
		/// The property name 'Active'. It matches the property to column 'Active'.
		/// </summary>
		public static readonly string Prop_Active = "Active";
		
		/// <summary>
		/// The lamda expression for Active.
		/// </summary>
		public static readonly Expression<Func<Country, object>> Expr_Active = x => x.Active;
				
		
		
		
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
		
		/// <summary>
		/// Property CreatedById mapping to Country.CreatedById
		/// </summary>
		public virtual int? CreatedById { get; set; }
		
		/// <summary>
		/// Property ModifiedById mapping to Country.ModifiedById
		/// </summary>
		public virtual int? ModifiedById { get; set; }
		
		/// <summary>
		/// Property CreatedTime mapping to Country.CreatedTime
		/// </summary>
		public virtual System.DateTime? CreatedTime { get; set; }
		
		/// <summary>
		/// Property ModifiedTime mapping to Country.ModifiedTime
		/// </summary>
		public virtual System.DateTime? ModifiedTime { get; set; }
		
		/// <summary>
		/// Property Active mapping to Country.Active
		/// </summary>
		public virtual bool? Active { get; set; }
				
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