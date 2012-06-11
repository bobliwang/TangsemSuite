using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Tangsem.Common.DataAccess
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class PropertyColumnAttribute : Attribute
	{
		public PropertyColumnAttribute()
		{
		}

		public PropertyColumnAttribute(string columnName)
		{
			this.ColumnName = columnName;
		}

		public string ColumnName { get; set; }

		public PropertyInfo PropertyInfo { get; set; }
	}
}
