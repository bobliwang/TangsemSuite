using Tangsem.Common.DataAccess;

namespace Tangsem.Generator.Metadata.RawInfos
{
  public class RawKey
  {
    [PropertyColumn("Table")]
    public string Table { get; set; }

    [PropertyColumn("Column")]
    public string Column { get; set; }

    [PropertyColumn("KeyName")]
    public string KeyName { get; set; }

    [PropertyColumn("KeyTypeName")]
    public string KeyTypeName { get; set; }

    [PropertyColumn("KeyType")]
    public int KeyType { get; set; }
  }
}
