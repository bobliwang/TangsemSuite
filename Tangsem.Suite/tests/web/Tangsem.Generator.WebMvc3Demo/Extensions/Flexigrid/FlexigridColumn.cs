﻿using System.Web.Helpers;

namespace Tangsem.Generator.WebMvc3Demo.Extensions.Flexigrid
{
  public class FlexigridColumn : WebGridColumn
  {
    public FlexigridColumn(WebGridColumn prototype, int headerWidth)
    {
      this.HeaderWidth = headerWidth;

      this.Format = prototype.Format;
      this.CanSort = prototype.CanSort;
      this.ColumnName = prototype.ColumnName;
      this.Header = prototype.Header;
      this.Style = prototype.Style;
    }

    public int HeaderWidth { get; set; }
  }
}