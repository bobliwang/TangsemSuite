// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionUtil.cs" company="TangsemTechAu">
//   LiWang@TangsemTechAu
// </copyright>
// <summary>
//   The reflection util.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Collections;
using System.Collections.Generic;
using System.Linq;



namespace Tangsem.NHibernate
{
	/// <summary>
	/// The reflection util.
	/// </summary>
	public static class ReflectionUtil
	{
		
		/// <summary>
		/// The as list.
		/// </summary>
		/// <param name="enumerable">
		/// The enumerable.
		/// </param>
		/// <typeparam name="T">
		/// </typeparam>
		/// <returns>
		/// </returns>
		public static List<T> AsList<T>(this IEnumerable enumerable)
		{
			if (enumerable is List<T>)
			{
				return enumerable as List<T>;
			}

			return enumerable.OfType<T>().ToList();
		}

		/// <summary>
		/// The as list.
		/// </summary>
		/// <param name="enumerable">
		/// The enumerable.
		/// </param>
		/// <typeparam name="T">
		/// </typeparam>
		/// <returns>
		/// </returns>
		public static List<T> AsList<T>(this IEnumerable<T> enumerable)
		{
			if (enumerable is List<T>)
			{
				return enumerable as List<T>;
			}

			return enumerable.OfType<T>().ToList();
		}

		/// <summary>
		/// The copy properties.
		/// </summary>
		/// <param name="objFrom">
		/// The obj from.
		/// </param>
		/// <param name="objTo">
		/// The obj to.
		/// </param>
		/// <param name="propertyNames">
		/// The property names.
		/// </param>
		public static void CopyProperties(this object objFrom, object objTo, string[] propertyNames)
		{
			foreach (var propertyName in propertyNames)
			{
				objTo.SetPropertyValue(propertyName, objFrom.GetPropertyValue(propertyName));
			}
		}

		/// <summary>
		/// The get property value.
		/// </summary>
		/// <param name="obj">
		/// The obj.
		/// </param>
		/// <param name="propertyName">
		/// The property name.
		/// </param>
		/// <returns>
		/// The get property value.
		/// </returns>
		public static object GetPropertyValue(this object obj, string propertyName)
		{
			return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
		}

		/// <summary>
		/// The list property.
		/// </summary>
		/// <param name="list">
		/// The list.
		/// </param>
		/// <param name="propertyName">
		/// The property name.
		/// </param>
		/// <typeparam name="P">
		/// </typeparam>
		/// <typeparam name="O">
		/// </typeparam>
		/// <returns>
		/// </returns>
		public static List<P> ListProperty<P, O>(this IList<O> list, string propertyName)
		{
			return list.Select(obj => (P)obj.GetPropertyValue(propertyName)).ToList();
		}

		/// <summary>
		/// The set property value.
		/// </summary>
		/// <param name="obj">
		/// The obj.
		/// </param>
		/// <param name="propertyName">
		/// The property name.
		/// </param>
		/// <param name="value">
		/// The value.
		/// </param>
		public static void SetPropertyValue(this object obj, string propertyName, object value)
		{
			obj.GetType().GetProperty(propertyName).SetValue(obj, value, null);
		}

		
	}
}