using System;
using System.Collections.Generic;
using System.Linq;
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

    public void Bind<T>(WebPageBase webPage, IQueryable<T> dataSource) where T : class
    {
      this.WebGrid.Bind(webPage, dataSource);
    }

    public FlexigridColumn FlexigridColumn(string columnName = null, string header = null, Func<dynamic, object> format = null, string style = null, bool canSort = true, int headerWidth = 100)
    {
      var columnPrototype = this.WebGrid.Column(columnName, header, format, style, canSort);
      var flexigridColumn = new FlexigridColumn(columnPrototype, headerWidth);

      return flexigridColumn;
    }

    public IHtmlString GetFlexigridHtml(FlexigridHtmlOptions flexigridHtmlOptions)
    {
      var gen = new FlexigridHtmlGenerator { FlexigridHtmlOptions = flexigridHtmlOptions, FlexigridWrapper = this };

      return new HtmlString(gen.TransformText());
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
      IEnumerable<FlexigridSearchItem> searchItems = null)
    {
      var options = new FlexigridHtmlOptions { FlexiWidth = flexiWidth, FlexiHeight = flexiHeight, Title = title, TableStyle = tableStyle, HeaderStyle = headerStyle, FooterStyle = footerStyle, RowStyle = rowStyle, AlternatingRowStyle = alternatingRowStyle, SelectedRowStyle = selectedRowStyle, Caption = caption, DisplayHeader = displayHeader, FillEmptyRows = fillEmptyRows, EmptyRowCellValue = emptyRowCellValue, Columns = columns, Exclusions = exclusions, Mode = mode, FirstText = firstText, PreviousText = previousText, NextText = nextText, LastText = lastText, NumericLinksCount = numericLinksCount, HtmlAttributes = htmlAttributes, FooterFormat = footerFormat, SearchItems = searchItems };

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
  }
}