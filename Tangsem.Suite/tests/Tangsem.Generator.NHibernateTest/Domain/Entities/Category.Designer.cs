using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Common.Entities;

namespace Tangsem.Generator.NHibernateTest.Domain.Entities
{
	public partial class Category : IAuditableEntity
	{

		/// <summary>
		/// The property name 'Id'. It matches the property to column 'Id'.
		/// </summary>
		public static readonly string Prop_Id = "Id";
		
		/// <summary>
		/// The lamda expression for Id.
		/// </summary>
		public static readonly Expression<Func<Category, object>> Expr_Id = x => x.Id;
		
		/// <summary>
		/// The property name 'Name'. It matches the property to column 'Name'.
		/// </summary>
		public static readonly string Prop_Name = "Name";
		
		/// <summary>
		/// The lamda expression for Name.
		/// </summary>
		public static readonly Expression<Func<Category, object>> Expr_Name = x => x.Name;
		
		/// <summary>
		/// The property name 'ShortDescription'. It matches the property to column 'ShortDescription'.
		/// </summary>
		public static readonly string Prop_ShortDescription = "ShortDescription";
		
		/// <summary>
		/// The lamda expression for ShortDescription.
		/// </summary>
		public static readonly Expression<Func<Category, object>> Expr_ShortDescription = x => x.ShortDescription;
		
		/// <summary>
		/// The property name 'Description'. It matches the property to column 'Description'.
		/// </summary>
		public static readonly string Prop_Description = "Description";
		
		/// <summary>
		/// The lamda expression for Description.
		/// </summary>
		public static readonly Expression<Func<Category, object>> Expr_Description = x => x.Description;
		
		/// <summary>
		/// The property name 'ParentId'. It matches the property to column 'ParentId'.
		/// </summary>
		public static readonly string Prop_ParentId = "ParentId";
		
		/// <summary>
		/// The lamda expression for ParentId.
		/// </summary>
		public static readonly Expression<Func<Category, object>> Expr_ParentId = x => x.ParentId;
		
		/// <summary>
		/// The property name 'KeyWords'. It matches the property to column 'KeyWords'.
		/// </summary>
		public static readonly string Prop_KeyWords = "KeyWords";
		
		/// <summary>
		/// The lamda expression for KeyWords.
		/// </summary>
		public static readonly Expression<Func<Category, object>> Expr_KeyWords = x => x.KeyWords;
		
		/// <summary>
		/// The property name 'CreatedById'. It matches the property to column 'CreatedById'.
		/// </summary>
		public static readonly string Prop_CreatedById = "CreatedById";
		
		/// <summary>
		/// The lamda expression for CreatedById.
		/// </summary>
		public static readonly Expression<Func<Category, object>> Expr_CreatedById = x => x.CreatedById;
		
		/// <summary>
		/// The property name 'ModifiedById'. It matches the property to column 'ModifiedById'.
		/// </summary>
		public static readonly string Prop_ModifiedById = "ModifiedById";
		
		/// <summary>
		/// The lamda expression for ModifiedById.
		/// </summary>
		public static readonly Expression<Func<Category, object>> Expr_ModifiedById = x => x.ModifiedById;
		
		/// <summary>
		/// The property name 'CreatedTime'. It matches the property to column 'CreatedTime'.
		/// </summary>
		public static readonly string Prop_CreatedTime = "CreatedTime";
		
		/// <summary>
		/// The lamda expression for CreatedTime.
		/// </summary>
		public static readonly Expression<Func<Category, object>> Expr_CreatedTime = x => x.CreatedTime;
		
		/// <summary>
		/// The property name 'ModifiedTime'. It matches the property to column 'ModifiedTime'.
		/// </summary>
		public static readonly string Prop_ModifiedTime = "ModifiedTime";
		
		/// <summary>
		/// The lamda expression for ModifiedTime.
		/// </summary>
		public static readonly Expression<Func<Category, object>> Expr_ModifiedTime = x => x.ModifiedTime;
		
		/// <summary>
		/// The property name 'Active'. It matches the property to column 'Active'.
		/// </summary>
		public static readonly string Prop_Active = "Active";
		
		/// <summary>
		/// The lamda expression for Active.
		/// </summary>
		public static readonly Expression<Func<Category, object>> Expr_Active = x => x.Active;
				
		
		
		
		/// <summary>
		/// The default constructor for Category class.
		/// </summary>
		public Category()
		{

		}


		#region "Basic Columns"


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
				
		#endregion
		
		#region "Outgoing References"
		
		
		#endregion
		
		#region "Incoming References"
		

		#endregion
		

	}
}