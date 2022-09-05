using System.Web.Helpers;

namespace Tangsem.Generator.WebMvc3Demo.Extensions.Flexigrid
{
  public class FlexigridColumn : WebGridColumn
  {
    public FlexigridColumn(WebGridColumn prototype, int headerWidth, Align align, VAlign valign)
    {
      this.HeaderWidth = headerWidth;

      this.Format = prototype.Format;
      this.CanSort = prototype.CanSort;
      this.ColumnName = prototype.ColumnName;
      this.Header = prototype.Header;
      this.Style = prototype.Style;

      this.Align = align;
      this.VAlign = valign;
    }

    public int HeaderWidth { get; set; }

    public Align Align { get; set; }

    public VAlign VAlign { get; set; }
  }

  public enum Align
  {
    Left = 0,
    Center = 1,
    Right = 2,
  }

  public enum VAlign
  {
    Top = 0,
    Middle = 1,
    Bottom = 2
  }
}