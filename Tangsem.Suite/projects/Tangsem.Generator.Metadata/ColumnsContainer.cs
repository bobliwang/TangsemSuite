// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColumnsContainer.cs" company="TangsemTechAu">
//   LiWang@TangsemTechAu
// </copyright>
// <summary>
//   The columns container.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Tangsem.Generator.Metadata
{
	/// <summary>
	/// The columns container.
	/// </summary>
	public class ColumnsContainer
	{
		/// <summary>
		/// The _columns.
		/// </summary>
		private IDictionary<string, ColumnMetadata> _columns;

		/// <summary>
		/// Gets or sets Columns.
		/// </summary>
		public IList<ColumnMetadata> Columns
		{
			get
			{
				if (this._columns == null)
				{
					this._columns = new Dictionary<string, ColumnMetadata>();
				}

				return this._columns.Values.ToList();
			}

			set
			{
				if (this._columns == null)
				{
					this._columns = new Dictionary<string, ColumnMetadata>();
				}

				this._columns = value.ToDictionary(x => x.ColumnName);
			}
		}

		/// <summary>
		/// The this.
		/// </summary>
		/// <param name="columnName">
		/// The column name.
		/// </param>
		public ColumnMetadata this[string columnName]
		{
			get
			{
				return this.Columns.FirstOrDefault(col => col.ColumnName == columnName);
			}
		}
	}
}