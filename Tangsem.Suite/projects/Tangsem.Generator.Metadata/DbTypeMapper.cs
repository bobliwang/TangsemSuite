// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DbTypeMapper.cs" company="TangsemTechAu">
//   LiWang@TangsemTechAu
// </copyright>
// <summary>
//   The db type mapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Data;
using System.Linq;

namespace Tangsem.Generator.Metadata
{
	/// <summary>
	/// The db type mapper.
	/// </summary>
	public class DbTypeMapper
	{

		public DbType FromSqlServerTypeName(string typeName)
		{
			var dbType = Enum.GetValues(typeof(DbType)).Cast<DbType>().FirstOrDefault(x => x.ToString().ToLower() == typeName.ToLower());
			return dbType;
		}

		/// <summary>
		/// The from sql db type.
		/// </summary>
		/// <param name="sqlDbType">
		/// The sql db type.
		/// </param>
		/// <returns>
		/// </returns>
		/// <exception cref="Exception">
		/// </exception>
		public DbType FromSqlDbType(SqlDbType sqlDbType)
		{
			switch (sqlDbType)
			{
					// Summary:
					// System.Int64. A 64-bit signed integer.
				case SqlDbType.BigInt:
					return DbType.Int64;

					// Summary:
					// System.Array of type System.Byte. A fixed-length stream of binary data ranging
					// between 1 and 8,000 bytes.
				case SqlDbType.Binary:
					return DbType.Binary;

					// Summary:
					// System.Boolean. An unsigned numeric value that can be 0, 1, or null.
				case SqlDbType.Bit:
					return DbType.Boolean;

					// Summary:
					// System.String. A fixed-length stream of non-Unicode characters ranging between
					// 1 and 8,000 characters.
				case SqlDbType.Char:
					return DbType.AnsiStringFixedLength;

					// Summary:
					// System.DateTime. Date and time data ranging in value from January 1, 1753
					// to December 31, 9999 to an accuracy of 3.33 milliseconds.
				case SqlDbType.DateTime:
					return DbType.DateTime;

					// Summary:
					// System.Decimal. A fixed precision and scale numeric value between -10 38
					// -1 and 10 38 -1.
				case SqlDbType.Decimal:
					return DbType.Decimal;

					// Summary:
					// System.Double. A floating point number within the range of -1.79E +308 through
					// 1.79E +308.
				case SqlDbType.Float:
					return DbType.Single;

					// Summary:
					// System.Array of type System.Byte. A variable-length stream of binary data
					// ranging from 0 to 2 31 -1 (or 2,147,483,647) bytes.
				case SqlDbType.Image:
					return DbType.Binary;

					// Summary:
					// System.Int32. A 32-bit signed integer.
				case SqlDbType.Int:
					return DbType.Int32;

					// Summary:
					// System.Decimal. A currency value ranging from -2 63 (or -9,223,372,036,854,775,808)
					// to 2 63 -1 (or +9,223,372,036,854,775,807) with an accuracy to a ten-thousandth
					// of a currency unit.
				case SqlDbType.Money:
					return DbType.Currency;

					// Summary:
					// System.String. A fixed-length stream of Unicode characters ranging between
					// 1 and 4,000 characters.
				case SqlDbType.NChar:
					return DbType.StringFixedLength;

					// Summary:
					// System.String. A variable-length stream of Unicode data with a maximum length
					// of 2 30 - 1 (or 1,073,741,823) characters.
				case SqlDbType.NText:
					return DbType.String;

					// Summary:
					// System.String. A variable-length stream of Unicode characters ranging between
					// 1 and 4,000 characters. Implicit conversion fails if the string is greater
					// than 4,000 characters. Explicitly set the object when working with strings
					// longer than 4,000 characters.
				case SqlDbType.NVarChar:
					return DbType.String;

					// Summary:
					// System.Single. A floating point number within the range of -3.40E +38 through
					// 3.40E +38.
				case SqlDbType.Real:
					return DbType.Double;

					// Summary:
					// System.Guid. A globally unique identifier (or GUID).
				case SqlDbType.UniqueIdentifier:
					return DbType.Guid;

					// Summary:
					// System.DateTime. Date and time data ranging in value from January 1, 1900
					// to June 6, 2079 to an accuracy of one minute.
				case SqlDbType.SmallDateTime:
					return DbType.DateTime;

					// Summary:
					// System.Int16. A 16-bit signed integer.
				case SqlDbType.SmallInt:
					return DbType.Int16;

					// Summary:
					// System.Decimal. A currency value ranging from -214,748.3648 to +214,748.3647
					// with an accuracy to a ten-thousandth of a currency unit.
				case SqlDbType.SmallMoney:
					return DbType.Currency;

					// Summary:
					// System.String. A variable-length stream of non-Unicode data with a maximum
					// length of 2 31 -1 (or 2,147,483,647) characters.
				case SqlDbType.Text:
					return DbType.String;

					// Summary:
					// System.Array of type System.Byte. Automatically generated binary numbers,
					// which are guaranteed to be unique within a database. timestamp is used typically
					// as a mechanism for version-stamping table rows. The storage size is 8 bytes.
				case SqlDbType.Timestamp:
					return DbType.DateTime;

					// Summary:
					// System.Byte. An 8-bit unsigned integer.
				case SqlDbType.TinyInt:
					return DbType.SByte;

					// Summary:
					// System.Array of type System.Byte. A variable-length stream of binary data
					// ranging between 1 and 8,000 bytes. Implicit conversion fails if the byte
					// array is greater than 8,000 bytes. Explicitly set the object when working
					// with byte arrays larger than 8,000 bytes.
				case SqlDbType.VarBinary:
					return DbType.Binary;

					// Summary:
					// System.String. A variable-length stream of non-Unicode characters ranging
					// between 1 and 8,000 characters.
				case SqlDbType.VarChar:
					return DbType.AnsiString;

					// Summary:
					// System.Object. A special data type that can contain numeric, string, binary,
					// or date data as well as the SQL Server values Empty and Null, which is assumed
					// if no other type is declared.
				case SqlDbType.Variant:
					return DbType.Object;

					// Summary:
					// An XML value. Obtain the XML as a string using the System.Data.SqlClient.SqlDataReader.GetValue(System.Int32)
					// method or System.Data.SqlTypes.SqlXml.Value property, or as an System.Xml.XmlReader
					// by calling the System.Data.SqlTypes.SqlXml.CreateReader() method.
				case SqlDbType.Xml:
					return DbType.Xml;

					// Summary:
					// A SQL Server 2005 user-defined type (UDT).
				case SqlDbType.Udt:
					return DbType.Object;

					// Summary:
					// A special data type for specifying structured data contained in table-valued
					// parameters.
				case SqlDbType.Structured:
					return DbType.Object;

					// Summary:
					// Date data ranging in value from January 1,1 AD through December 31, 9999
					// AD.
				case SqlDbType.Date:
					return DbType.Date;

					// Summary:
					// Time data based on a 24-hour clock. Time value range is 00:00:00 through
					// 23:59:59.9999999 with an accuracy of 100 nanoseconds. Corresponds to a SQL
					// Server time value.
				case SqlDbType.Time:
					return DbType.Time;

					// Summary:
					// Date and time data. Date value range is from January 1,1 AD through December
					// 31, 9999 AD. Time value range is 00:00:00 through 23:59:59.9999999 with an
					// accuracy of 100 nanoseconds.
				case SqlDbType.DateTime2:
					return DbType.DateTime;

					// Summary:
					// Date and time data with time zone awareness. Date value range is from January
					// 1,1 AD through December 31, 9999 AD. Time value range is 00:00:00 through
					// 23:59:59.9999999 with an accuracy of 100 nanoseconds. Time zone value range
					// is -14:00 through +14:00.
				case SqlDbType.DateTimeOffset:
					return DbType.DateTimeOffset;
			}

			throw new Exception("Unrecognized SqlDbType:" + sqlDbType);
		}
	}
}