using System;
using System.Data;
using System.Data.Common;

using Newtonsoft.Json;

using NHibernate;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace Tangsem.NHibernate.UserTypes
{
	public class JsonType<T> : IUserType where T : class
	{
		public Type ReturnedType => typeof(T);

		public object Assemble(object cached, object owner)
		{
			return cached;
		}

		public object DeepCopy(object value)
		{
			if (!(value is T source))
			{
				return null;
			}
				
			return this.Deserialise(this.Serialise(source));
		}

		public object Disassemble(object value)
		{
			return value;
		}

		public new bool Equals(object x, object y)
		{
			var left = x as T;
			var right = y as T;

			if (left == null && right == null)
			{
				return true;
			}

			if (left == null || right == null)
			{
				return false;
			}
				
			return Serialise(left).Equals(Serialise(right));
		}

		public int GetHashCode(object x)
		{
			return x == null ? 0.GetHashCode() : x.GetHashCode();
		}

		public bool IsMutable => false;

		public object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
		{
			var json = NHibernateUtil.String.NullSafeGet(rs, names[0], session) as string;
			return this.Deserialise(json);
		}

		public void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
		{
			var jsonText = this.Serialise(value as T);
			NHibernateUtil.String.NullSafeSet(cmd, jsonText, index, session);
		}

		public object Replace(object original, object target, object owner)
		{
			return original;
		}

		public SqlType[] SqlTypes => new SqlType[] { SqlTypeFactory.GetString(8000) };

		public T Deserialise(string jsonString)
		{
			if (string.IsNullOrWhiteSpace(jsonString))
			{
				return null;
			}
				
			return JsonConvert.DeserializeObject<T>(jsonString);
		}

		public string Serialise(T obj)
		{
			if (obj == null)
			{
				return null;
			}

			return JsonConvert.SerializeObject(obj);
		}
	}
}