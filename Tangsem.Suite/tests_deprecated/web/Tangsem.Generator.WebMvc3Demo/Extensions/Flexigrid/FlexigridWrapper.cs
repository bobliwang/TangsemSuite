using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.WebPages;
using Tangsem.Web.Mvc.Extensions;
using Tangsem.Common.Extensions;

namespace Tangsem.Generator.WebMvc3Demo.Extensions.Flexigrid
{
  public class FlexigridWrapper
  {
    public FlexigridWrapper(string containerId, IEnumerable<dynamic> source = null, IEnumerable<string> columnNames = null, string defaultSort = null, int rowsPerPage = 10, bool canPage = true, bool canSort = true, string ajaxUpdateContainerId = null, string ajaxUpdateCallback = null, string fieldNamePrefix = null, string pageFieldName = null, string selectionFieldName = null, string sortFieldName = null, string sortDirectionFieldName = null)
    {
      this.ContainerId = containerId;
      this.WebGrid = new WebGrid(source, columnNames, defaultSort, rowsPerPage, canPage, canSort, ajaxUpdateContainerId, ajaxUpdateCallback, fieldNamePrefix, pageFieldName, selectionFieldName, sortFieldName, sortDirectionFieldName);
    }

    public FlexigridWrapper(string containerId, WebGrid webGrid)
    {
      this.ContainerId = containerId;
      this.WebGrid = webGrid;
    }

    public string ContainerId { get; private set; }

    public WebGrid WebGrid { get; private set; }

    public WebPageBase WebPageBase { get; private set; }

    public void Bind<T>(WebPageBase webPage, IQueryable<T> dataSource) where T : class
    {
      this.WebGrid.Bind(webPage, dataSource);
      this.WebPageBase = webPage;
    }

    public FlexigridColumn FlexigridColumn(string columnName = null, string header = null, Func<dynamic, object> format = null, string style = null, bool canSort = true, int headerWidth = 100, Align align = Align.Left, VAlign valign = VAlign.Middle)
    {
      var columnPrototype = this.WebGrid.Column(columnName, header, format, style, canSort);
      var flexigridColumn = new FlexigridColumn(columnPrototype, headerWidth, align, valign);

      return flexigridColumn;
    }

    public FlexigridColumn FlexigridColumn<T>(string columnName = null, string header = null, Func<T, object> format = null, string style = null, bool canSort = true, int headerWidth = 100, Align align = Align.Left, VAlign valign = VAlign.Middle) where T : class
    {
      Func<dynamic, object> dynFmt = x => "Format not specified";

      if (format != null)
      {
        dynFmt = x =>
        {
          var t = x as T;

          if (t == null)
          {
            var d = x as DynamicObject;
            if (d != null)
            {
              try
              {
                var val = d.GetPropertyValue("Value");
                t = val as T;
              }
              catch (Exception e)
              {
                return "Conversion Error.(" + e.Message + ")";
              }
            }
          }

          if (t != null)
          {
            return format(t);
          }

          return "Conversion Error.";
        };
      }

      return this.FlexigridColumn(columnName, header, dynFmt, style, canSort, headerWidth, align, valign);
    }

    public FlexigridColumn FlexigridColumn<T>(Expression<Func<T, object>> columnNameExpression, string header = null, Func<T, object> format = null, string style = null, bool canSort = true, int headerWidth = 100, Align align = Align.Left, VAlign valign = VAlign.Middle) where T : class
    {
      var columnName = columnNameExpression.GetPropertyInfo().Name;

      return this.FlexigridColumn(columnName, header, format, style, canSort, headerWidth, align, valign);
    }

    public IHtmlString GetFlexigridHtml(FlexigridHtmlOptions flexigridHtmlOptions)
    {
      var gen = new FlexigridHtmlGenerator { FlexigridHtmlOptions = flexigridHtmlOptions, FlexigridWrapper = this };

      return new HtmlString(gen.TransformText().Trim());
    }

    public FlexigridSearchSettings SearchSettings(string url, IEnumerable<FlexigridSearchItem> searchItems = null, string searchFieldParamName = "qtype", string searchValueParamName = "q")
    {
      return new FlexigridSearchSettings(url, searchItems, searchFieldParamName, searchValueParamName);
    }

    public FlexigridSearchItem SearchItem(string display, string name, bool isDefault = false)
    {
      return new FlexigridSearchItem { Display = display, Name = name, IsDefault = isDefault };
    }

    public IEnumerable<FlexigridSearchItem> SearchItems(params FlexigridSearchItem[] searchItems)
    {
      return searchItems;
    }

    public FlexigridSearchItem SearchItem<T>(string display, Expression<Func<T, object>> expression, bool isDefault = false)
    {
      return new FlexigridSearchItem { Display = display, Name = expression.GetPropertyInfo().Name, IsDefault = isDefault };
    }

    public IHtmlString GetFlexigridHtml(
      int flexiWidth,
      int flexiHeight,
      string title = null,
      string tableStyle = null,
      string headerStyle = null,
      string footerStyle = null,
      string rowStyle = null,
      string alternatingRowStyle = null,
      string selectedRowStyle = null,
      string caption = null,
      bool displayHeader = true,
      bool fillEmptyRows = false,
      string emptyRowCellValue = null,
      IEnumerable<FlexigridColumn> columns = null,
      IEnumerable<string> exclusions = null,
      WebGridPagerModes mode = WebGridPagerModes.Numeric | WebGridPagerModes.NextPrevious,
      string firstText = null,
      string previousText = null,
      string nextText = null,
      string lastText = null,
      int numericLinksCount = 5,
      dynamic htmlAttributes = null,
      Func<dynamic, object> footerFormat = null,
      FlexigridSearchSettings flexigridSearchSettings = null)
    {
      var options = new FlexigridHtmlOptions { FlexiWidth = flexiWidth, FlexiHeight = flexiHeight, Title = title, TableStyle = tableStyle, HeaderStyle = headerStyle, FooterStyle = footerStyle, RowStyle = rowStyle, AlternatingRowStyle = alternatingRowStyle, SelectedRowStyle = selectedRowStyle, Caption = caption, DisplayHeader = displayHeader, FillEmptyRows = fillEmptyRows, EmptyRowCellValue = emptyRowCellValue, Columns = columns, Exclusions = exclusions, Mode = mode, FirstText = firstText, PreviousText = previousText, NextText = nextText, LastText = lastText, NumericLinksCount = numericLinksCount, HtmlAttributes = htmlAttributes, FooterFormat = footerFormat, FlexigridSearchSettings = flexigridSearchSettings };

      return this.GetFlexigridHtml(options);
    }

    public string GetPageUrl(int pageIndex)
    {
      return this.WebGrid.GetPageUrl(pageIndex);
    }

    public string GetSortUrl(string column)
    {
      return this.WebGrid.GetSortUrl(column);
    }

    public IEnumerable<FlexigridColumn> Columns(params FlexigridColumn[] columns)
    {
      if (columns == null || !columns.Any())
      {
        throw new Exception("FlexigridWrapper.Columns method doesn't accept null or empty 'columns' parameter.");
      }

      return columns;
    }

    public int FirstPageIndex
    {
      get
      {
        return 0;
      }
    }

    public int LastPageIndex
    {
      get
      {
        return this.WebGrid.PageCount - 1 >= 0 ? this.WebGrid.PageCount - 1 : 0;
      }
    }

    public int PrevPageIndex
    {
      get
      {
        return this.WebGrid.PageIndex - 1 >= 0 ? this.WebGrid.PageIndex - 1 : 0;
      }
    }

    public int NextPageIndex
    {
      get
      {
        return this.WebGrid.PageIndex + 1 < this.WebGrid.PageCount ? this.WebGrid.PageIndex + 1 : this.WebGrid.PageIndex;
      }
    }

    public string FirstPageUrl
    {
      get
      {
        if (this.WebGrid.PageCount == 0)
        {
          return "#";
        }

        return this.WebGrid.GetPageUrl(this.FirstPageIndex);
      }
    }

    public string LastPageUrl
    {
      get
      {
        if (this.WebGrid.PageCount == 0)
        {
          return "#";
        }

        return this.WebGrid.GetPageUrl(this.LastPageIndex);
      }
    }

    public string PrevPageUrl
    {
      get
      {
        if (this.WebGrid.PageCount == 0)
        {
          return "#";
        }

        return this.WebGrid.GetPageUrl(this.PrevPageIndex);
      }
    }

    public string NextPageUrl
    {
      get
      {
        if (this.WebGrid.PageCount == 0)
        {
          return "#";
        }

        return this.WebGrid.GetPageUrl(this.NextPageIndex);
      }
    }

    public string SortBy
    {
      get
      {
        return this.WebPageBase.Request[this.WebGrid.SortFieldName];
      }
    }

    public string SortDir
    {
      get
      {
        return this.WebPageBase.Request[this.WebGrid.SortDirectionFieldName];
      }
    }
  }
}