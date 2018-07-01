using System.Data;

namespace Tangsem.Data.StoredProc
{
  public class SpParam
  {
    public string Name { get; set; }
    public object Value { get; set; }
    public DbType DbType { get; set; }
    public ParameterDirection Direction { get; set; }
  }
}