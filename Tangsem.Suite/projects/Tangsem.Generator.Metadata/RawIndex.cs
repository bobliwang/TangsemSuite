using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tangsem.Common.DataAccess;

namespace Tangsem.Generator.Metadata
{
  public class RawIndex
  {
    [PropertyColumn("IndexName")]
    public string IndexName { get; set; }

    [PropertyColumn("TableName")]
    public string TableName { get; set; }

    [PropertyColumn("ColumnName")]
    public string ColumnName { get; set; }
  }
}
