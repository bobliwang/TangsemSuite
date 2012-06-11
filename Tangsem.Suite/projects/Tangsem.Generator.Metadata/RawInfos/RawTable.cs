using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tangsem.Common.DataAccess;

namespace Tangsem.Generator.Metadata.RawInfos
{
  public class RawTable
  {
    [PropertyColumn("Table")]
    public string Table { get; set; }

    [PropertyColumn("IsView")]
    public bool IsView { get; set; }
  }
}
