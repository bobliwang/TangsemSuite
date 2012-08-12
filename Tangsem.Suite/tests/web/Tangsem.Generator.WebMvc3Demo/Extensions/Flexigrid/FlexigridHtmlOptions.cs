using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Tangsem.Generator.WebMvc3Demo.Extensions.Flexigrid
{
  public class FlexigridHtmlOptions
  {
    public FlexigridHtmlOptions()
    {
      NumericLinksCount = 5;
      Mode = WebGridPagerModes.Numeric | WebGridPagerModes.NextPrevious;
      DisplayHeader = true;
    }

    public int FlexiWidth { get; set; }

    public int FlexiHeight { get; set; }

    public string Title { get; set; }

    public string TableStyle { get; set; }

    public string HeaderStyle { get; set; }

    public string FooterStyle { get; set; }

    public string RowStyle { get; set; }

    public string AlternatingRowStyle { get; set; }

    public string SelectedRowStyle { get; set; }

    public string Caption { get; set; }

    public bool DisplayHeader { get; set; }

    public bool FillEmptyRows { get; set; }

    public string EmptyRowCellValue { get; set; }

    public IEnumerable<FlexigridColumn> Columns { get; set; }

    public IEnumerable<string> Exclusions { get; set; }

    public WebGridPagerModes Mode { get; set; }

    public string FirstText { get; set; }

    public string PreviousText { get; set; }

    public string NextText { get; set; }

    public string LastText { get; set; }

    public int NumericLinksCount { get; set; }

    public dynamic HtmlAttributes { get; set; }

    public Func<dynamic, object> FooterFormat { get; set; }

    public IEnumerable<FlexigridSearchItem> SearchItems { get; set; }
  }
}