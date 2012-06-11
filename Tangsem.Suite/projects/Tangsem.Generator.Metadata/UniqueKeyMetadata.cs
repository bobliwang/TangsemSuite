// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IndexMetadata.cs" company="TangsemTechAu">
//   LiWang@TangsemTechAu
// </copyright>
// <summary>
//   The index metadata.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;

namespace Tangsem.Generator.Metadata
{
	/// <summary>
	/// The index metadata.
	/// </summary>
	public class UniqueKeyMetadata : ColumnsContainer
	{
		/// <summary>
		/// Gets or sets Name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets a value indicating whether IsPrimaryKey.
		/// </summary>
		public bool IsPrimaryKey
		{
			get
			{
				return this.Columns.Any(col => col.IsPrimaryKey);
			}
		}
	}
}