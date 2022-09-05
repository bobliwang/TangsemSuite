using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Tangsem.Common.DataAccess;
using Tangsem.Common.Extensions;

namespace Tangsem.Generator.Settings;

using System.Threading;

public class EnumConfigScope : IDisposable
{
  private bool _disposed;

  public EnumConfigScope(Action<EnumConfig> defaultInitAction)
  {
    this.DefaultInitAction = defaultInitAction;

    ThreadLocal.Value = this;
  }

  public Action<EnumConfig> DefaultInitAction { get; }

  public static readonly ThreadLocal<EnumConfigScope> ThreadLocal = new ThreadLocal<EnumConfigScope>();

  public void Dispose()
  {
    if (!this._disposed)
    {
      ThreadLocal.Value = null;
      this._disposed = true;
    }
  }
}

public class EnumConfig
{
  /// <summary>
  /// The _gen flag none.
  /// </summary>
  private bool _genFlagNone;

  /// <summary>
  /// The _gen flag all.
  /// </summary>
  private bool _genFlagAll;

  /// <summary>
  /// Initializes a new instance of the <see cref="EnumConfig"/> class.
  /// </summary>
  public EnumConfig()
  {
    this.NameField = "Name";
    this.ValueField = "Value";
    this.GenComments = true;
    this.NeedLineBreak = true;
    this.SingularizeName = false;

    if (EnumConfigScope.ThreadLocal.Value != null)
    {
      EnumConfigScope.ThreadLocal.Value.DefaultInitAction?.Invoke(this);;
    }
  }

  /// <summary>
  /// Gets or sets a value indicating whether public access.
  /// </summary>
  public bool PublicAccess { get; set; }

  /// <summary>
  /// Gets or sets a value indicating whether it need a line break between the enums values.
  /// </summary>
  public bool NeedLineBreak { get; set; }

  /// <summary>
  /// Gets or sets a value indicating whether IsFlags.
  /// </summary>
  public bool IsFlags { get; set; }

  /// <summary>
  /// Gets or sets a value indicating whether IsFlags.
  /// </summary>
  public string FlagIndexName { get; set; }

  /// <summary>
  /// Gets or sets a value indicating whether GenComments.
  /// </summary>
  public bool GenComments { get; set; }

  /// <summary>
  /// Gets or sets OrderByState.
  /// </summary>
  public string LookupOrderBy { get; set; }

  /// <summary>
  /// Gets or sets EnumClassName.
  /// </summary>
  public string EnumClassName { get; set; }

  /// <summary>
  /// Gets or sets GenFlags.
  /// </summary>
  public bool GenFlags { get; set; }

  /// <summary>
  /// Gets or sets Attribute.
  /// </summary>
  public string Attribute { get; set; }

  /// <summary>
  /// Gets or sets SqlQry.
  /// </summary>
  public string SqlQry { get; set; }

  /// <summary>
  /// Gets or sets NameField.
  /// </summary>
  public string NameField { get; set; }

  /// <summary>
  /// Gets or sets ValueField.
  /// </summary>
  public string ValueField { get; set; }

  /// <summary>
  /// Gets or sets DescriptionField.
  /// </summary>
  public string DescriptionField { get; set; }

  /// <summary>
  /// Gets or sets a value indicating whether ForceCapFirst.
  /// </summary>
  public bool ForceCapFirst { get; set; }

  /// <summary>
  /// Gets or sets PrefixForNumericName.
  /// </summary>
  public string PrefixFoName { get; set; }

  /// <summary>
  /// Gets a value indicating whether IncludeDescription.
  /// </summary>
  public bool IncludeDescription => !string.IsNullOrEmpty(this.DescriptionField);

  /// <summary>
  /// Gets a value indicating whether IsLookup.
  /// </summary>
  public bool IsLookup => !string.IsNullOrEmpty(this.Attribute);

  /// <summary>
  /// Gets or sets the TS, true = 1.
  /// </summary>
  public int TS { get; set; }

  /// <summary>
  /// Gets or sets the ParentValueHasBit.
  /// </summary>
  public int? ParentValueHasBits { get; set; }

  /// <summary>
  /// Gets or sets a value indicating whether singularize name.
  /// </summary>
  public bool SingularizeName { get; set; }

  /// <summary>
  /// Gets or sets a value indicating whether shared code with client profile.
  /// </summary>
  public bool SharedCodeWithClientProfile { get; set; }

  /// <summary>
  /// Gets or sets a value indicating whether long enum.
  /// </summary>
  /// <remarks> If true, the base is long. </remarks>
  public bool LongEnum { get; set; }

  /// <summary>
  /// Gets or sets a value indicating whether gen flag none.
  /// </summary>
  public bool GenFlagNone
  {
    get => this._genFlagNone && this.IsFlags;
    set => this._genFlagNone = value;
  }

  /// <summary>
  /// Gets or sets a value indicating whether gen flag all.
  /// </summary>
  public bool GenFlagAll
  {
    get { return this._genFlagAll && this.IsFlags; }
    set { this._genFlagAll = value; }
  }

  /// <summary>
  /// Gets or sets the data table.
  /// </summary>
  public DataTable TempDataTable { get; set; }

  /// <summary>
  /// Gets or sets TempMaxNameLength.
  /// </summary>
  public int TempMaxNameLength { get; set; }

  /// <summary>
  /// The sql to run.
  /// </summary>
  /// <returns>
  /// The sql string.
  /// </returns>
  public string GetSql()
  {
    if (this.IsLookup)
    {
      var order = string.IsNullOrEmpty(this.LookupOrderBy) ?
             this.NameField
           : this.LookupOrderBy;

      return "SELECT * FROM [Lookup] WHERE [Attribute] = @Attribute AND [Active] = 1 ORDER BY [" + order + "]";
    }

    return this.SqlQry;
  }

  /// <summary>
  /// Returns the parameters.
  /// </summary>
  /// <returns>
  /// The parameters.
  /// </returns>
  public List<Parameter> GetParameters()
  {
    if (this.IsLookup)
    {
      return new List<Parameter> { new Parameter("Attribute", this.Attribute, DbType.String) };
    }

    return new List<Parameter> { };
  }

  /// <summary>
  /// The ParentMatchFlag.
  /// </summary>
  /// <param name="dr"> The data reader. </param>
  /// <returns> The enum name. </returns>
  public bool ParentMatchFlag(DataRow dr)
  {
    // if the ParentValueHasBits is null, just ignore this option by returning true value. 
    if (!this.ParentValueHasBits.HasValue)
      return true;

    if (int.TryParse(dr["ParentValue"]?.ToString(), out var parentValue))
    {
      return (parentValue & this.ParentValueHasBits) == this.ParentValueHasBits;
    }

    // default value if the ParentValueHasBits is not null.
    return false;
  }

  /// <summary>
  /// Get the enum name.
  /// </summary>
  /// <param name="dr"> The data reader. </param>
  /// <returns> The enum name. </returns>
  public string GetEnumName(DataRow dr)
  {
    var name = dr[this.NameField] + string.Empty;

    // remove the space by default.
    name = name.Replace(" ", string.Empty);

    if (this.ForceCapFirst)
    {
      name = name.UpperFirst();
    }

    if (this.SingularizeName)
      name = name.Singularize();

    if (!string.IsNullOrEmpty(this.PrefixFoName))
      name = string.Concat(this.PrefixFoName, name);

    return name.Replace(' ', '_');
  }

  /// <summary>
  /// The get base type.
  /// </summary>
  /// <returns> Returns the base type.. </returns>
  public string GetBaseType()
  {
    return this.LongEnum ? " : long" : string.Empty;
  }

  /// <summary>
  /// The get enum int type.
  /// </summary>
  /// <returns> Returns int or long. </returns>
  public string GetEnumIntType()
  {
    return this.LongEnum ? "long" : "int";
  }

  /// <summary>
  /// The get flag value comment.
  /// </summary>
  /// <param name="max"> The max length. </param>
  /// <param name="row"> The DataRow. </param>
  /// <returns> Returns Flag Value Comment. </returns>
  public string GetFlagValueComment(int max, DataRow row)
  {
    // 8 - 0x;
    if (this.IsFlags)
    {
      var longValue = 1 << Convert.ToInt32(row[this.ValueField]);
      var padding = string.Empty.PadLeft(max - this.GetEnumName(row).Length);
      ////return @"{2}// 0x{1} - {0}".FormatBy(longValue.ToString().PadLeft(4), longValue.ToString("X").PadLeft(4, '0'), padding);
      return @"{1} {0}".FormatBy(this.Comments(longValue), padding);
    }

    return string.Empty;
  }

  /// <summary>
  /// The get flag none literals.
  /// </summary>
  /// <param name="maxlenght"> The maxlenght. </param>
  /// <returns> The FlagNoneLiterals.  </returns>
  public string GetFlagNoneLiterals(int maxlenght)
  {
    var comments = this.Comments(0L);
    var padding = string.Empty;
    if (maxlenght > 4)
    {
      padding = string.Empty.PadLeft(maxlenght - 4);
    }

    return "NONE{1} =  0{0}, {2}".FormatBy(this.ValueIndicator(), padding, comments);
  }

  /// <summary>
  /// The get flag ALL literals.
  /// </summary>
  /// <param name="maxlenght"> The maxlenght. </param>
  /// <returns> The FlagNoneLiterals. </returns>
  public string GetFlagAllLiterals(int maxlenght)
  {
    var comments = this.Comments(-1L);
    var padding = string.Empty;
    if (maxlenght > 3)
    {
      padding = string.Empty.PadLeft(maxlenght - 3);
    }

    return "ALL{1} = -1{0}, {2}".FormatBy(this.ValueIndicator(), padding, comments);
  }

  /// <summary>
  /// The value indicator.
  /// </summary>
  /// <returns>Return ValueIndicator. </returns>
  public string ValueIndicator()
  {
    return this.LongEnum ? "L" : string.Empty;
  }

  /// <summary>
  /// The get flag literal.
  /// </summary>
  /// <param name="row"> The DataRow. </param>
  /// <returns> Return FlagLiteral. </returns>
  public string GetFlagLiteral(DataRow row)
  {
    return string.Format("1{0} << {1}.{2}", this.ValueIndicator(), this.FlagIndexName, this.GetEnumName(row));
  }

  /// <summary>
  /// The comments.
  /// </summary>
  /// <param name="longValue"> The long value. </param>
  /// <param name="padding"> The padding. </param>
  /// <returns> The Comments. </returns>
  private string Comments(long longValue, string padding = "")
  {
    var paddingLength = this.LongEnum ? 16 : 8;
    return @"{2}// 0x{1} - {0}".FormatBy(longValue.ToString().PadLeft(4), longValue.ToString("X").PadLeft(paddingLength, '0'), padding);
  }
}
