using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangsem.Generator.Settings
{
  /// <summary>
  /// The EnumsGenConfiguration class.
  /// </summary>
  public class EnumsGenConfiguration
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="EnumsGenConfiguration"/> class.
    /// </summary>
    public EnumsGenConfiguration()
    {
      this.EnumConfigs = new List<EnumConfig>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EnumsGenConfiguration"/> class.
    /// </summary>
    /// <param name="connectionString">
    /// The connection string.
    /// </param>
    public EnumsGenConfiguration(string connectionString)
      : this()
    {
      this.ConnectionString = connectionString;
    }

    /// <summary>
    /// Gets or sets ConnectionString.
    /// </summary>
    public string ConnectionString { get; set; }

    /// <summary>
    /// Gets or sets EnumConfigs.
    /// </summary>
    public List<EnumConfig> EnumConfigs { get; set; }

    /// <summary>
    /// Gets or sets EnumsNamespace.
    /// </summary>
    public string EnumsNamespace { get; set; }
  }
}
