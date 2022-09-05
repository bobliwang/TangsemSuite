using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tangsem.Generator.Metadata.RawInfos
{
  public class RawInfoCache
  {
    public RawInfoCache()
    {
      this.RawColumns = new List<RawColumn>();
      this.RawReferences = new List<RawReference>();
      this.RawKeys = new List<RawKey>();
      this.RawTables = new List<RawTable>();
      this.RawIndices = new List<RawIndex>();
    }

    public List<RawColumn> RawColumns { get; private set; }

    public List<RawReference> RawReferences { get; private set; }

    public List<RawKey> RawKeys { get; private set; }

    public List<RawTable> RawTables { get; private set; }

    public List<RawIndex> RawIndices { get; private set; }

    public void Clear()
    {
      this.RawColumns.Clear();
      this.RawReferences.Clear();
      this.RawKeys.Clear();
      this.RawTables.Clear();
      this.RawIndices.Clear();
    }
  }
}
