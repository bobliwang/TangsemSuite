using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;

namespace Tangsem.Generator.WebMvc3Demo.Extensions
{
  public static class WebGridExtensions
  {
    public static MyWebGridColumn MyColumn(this WebGrid grid, string columnName = null, string header = null, Func<dynamic, object> format = null, string style = null, bool canSort = true, int headerWidth = 100)
    {
      var column = grid.Column(columnName, header, format, style, canSort);
      var myColumn = new MyWebGridColumn(column, headerWidth);

      return myColumn;
    }

    public static IHtmlString MyGetHtml(this WebGrid grid, int flexiWidth, int flexiHeight, string title=null, string tableStyle = null, string headerStyle = null, string footerStyle = null, string rowStyle = null, string alternatingRowStyle = null, string selectedRowStyle = null, string caption = null, bool displayHeader = true, bool fillEmptyRows = false, string emptyRowCellValue = null, IEnumerable<WebGridColumn> columns = null, IEnumerable<string> exclusions = null, WebGridPagerModes mode = WebGridPagerModes.Numeric | WebGridPagerModes.NextPrevious, string firstText = null, string previousText = null, string nextText = null, string lastText = null, int numericLinksCount = 5, dynamic htmlAttributes = null,
                                        Func<dynamic, object> footerFormat = null)
    {
      var tableId = htmlAttributes.GetType().GetProperty("id").GetValue(htmlAttributes, null);
      var html = grid.GetHtml(
        tableStyle,
        headerStyle,
        footerStyle,
        rowStyle,
        alternatingRowStyle,
        selectedRowStyle,
        caption,
        displayHeader,
        fillEmptyRows,
        emptyRowCellValue,
        columns,
        exclusions,
        mode,
        firstText,
        previousText,
        nextText,
        lastText,
        numericLinksCount,
        htmlAttributes);



      var sb = new StringBuilder(html.ToString());
      sb.AppendLine("<script language=\"javascript\" type=\"text/javascript\">");
      sb.AppendLine("$(document).ready(function () {");

      var i = 0;
      foreach (var col in columns)
      {
        var myCol = col as MyWebGridColumn;
        if (myCol != null)
        {
          if (tableId != null)
          {

            var js = string.Format("$('#{0} th:nth-child({1})').attr(\"width\", {2});", tableId, (i+1), myCol.HeaderWidth);
            sb.AppendLine(js);
          }
        }
        i++;
      }
      if (tableId != null)
      {
        sb.AppendLine("$('#" + tableId + " tfoot').remove();");

        var sizeString = string.Format("width: {0}, height:{1}", flexiWidth, flexiHeight);
        var titleString = string.Format("title:'{0}' ", title);
        var usepagerString = string.Format("usepager: true, useRp: false, total: {0}, rp: {1}, page: {2}", grid.TotalRowCount, grid.RowsPerPage, grid.PageIndex);


        var attrs = string.Join(",", new[] { sizeString, titleString, usepagerString });
        sb.AppendLine("$('#" + tableId + "').flexigrid({" + attrs + "});");

        AttachePagerEvents(grid, sb);

        // render customized footer here.
        if (footerFormat != null)
        {
          var newFooter = string.Format("<tfoot><tr><td colspan=\"{0}\">{1}</td></tr></tfoot>"
            , columns.Count()
            , Convert.ToString(footerFormat(null)));

          newFooter = newFooter.Replace("'", "\\'").Replace(Environment.NewLine, "");

          sb.AppendLine("$('#" + tableId + "').append('" + newFooter + "');");
        }
        else
        {
          // render flexigrid footer.
          //var newFooter = footerFormat(null) as IHtmlString;

          //newFooter.ToHtmlString();
        }

      }


      sb.AppendLine("});");
      sb.AppendLine("</script>");

      return new HtmlString(sb.ToString());
    }

    private static void AttachePagerEvents(WebGrid grid, StringBuilder sb)
    {
      var firstPage = grid.GetPageUrl(0);
      var lastPage = grid.GetPageUrl(grid.PageCount - 1 >= 0 ? grid.PageCount - 1 : 0);
      var prevPage = grid.GetPageUrl(grid.PageIndex - 1 >= 0 ? grid.PageIndex - 1 : 0);
      var nextPage = grid.GetPageUrl(grid.PageIndex + 1 < grid.PageCount ? grid.PageIndex + 1 : grid.PageIndex);

      var template = firstPage;

      ////.Replace(grid.PageFieldName + "=1", );


      var first = string.Format("$('.pFirst').attr(\"onClick\", \"document.location.href = '{0}'\");", firstPage);
      var last = string.Format("$('.pLast').attr(\"onClick\", \"document.location.href = '{0}'\");", lastPage);
      var prev = string.Format("$('.pPrev').attr(\"onClick\", \"document.location.href = '{0}'\");", prevPage);
      var next = string.Format("$('.pNext').attr(\"onClick\", \"document.location.href = '{0}'\");", nextPage);

      sb.AppendLine(string.Format("$('.pcontrol input').val({0});", grid.PageIndex + 1));
      sb.AppendLine(string.Format("$('.pcontrol span').html('{0}');", grid.PageCount));
      sb.AppendLine(string.Format("$('.pPageStat').html('Displaying {0} to {1} of {2} items.');",
          grid.PageIndex * grid.RowsPerPage + 1,
          Math.Min((grid.PageIndex+1) * grid.RowsPerPage, grid.TotalRowCount),
          grid.TotalRowCount));

      sb.AppendLine(string.Format("var template = '{0}';", template));
      sb.AppendLine(@"$('.pcontrol input').change(function () { document.location.href = template.replace('" + grid.PageFieldName + "=1', '" + grid.PageFieldName + "=' + $(this).val()); })");
      sb.AppendLine(@"$('.pcontrol input').keyup(function (evt) { document.location.href = template.replace('" + grid.PageFieldName + "=1', '" + grid.PageFieldName + "=' + $(this).val()); })");

      // allow only digits.
      sb.AppendLine(@"$('.pcontrol input').keypress(function (evt) {
                    var e = window.event || evt; // for trans-browser compatibility  
                    var charCode = e.which || e.keyCode;  
                    if ((charCode > 47 && charCode < 58) || charCode == 8){
                      return true;
                    }  
                    return false;
                  })"
            );


      sb.AppendLine(first);
      sb.AppendLine(prev);
      sb.AppendLine(next);
      sb.AppendLine(last);


    }

    ////public static IHtmlString MyGetHtml(this WebGrid grid, string tableStyle = null, string headerStyle = null, string footerStyle = null, string rowStyle = null, string alternatingRowStyle = null, string selectedRowStyle = null, string caption = null, bool displayHeader = true, bool fillEmptyRows = false, string emptyRowCellValue = null, IEnumerable<WebGridColumn> columns = null, IEnumerable<string> exclusions = null, WebGridPagerModes mode = WebGridPagerModes.Numeric | WebGridPagerModes.NextPrevious, string firstText = null, string previousText = null, string nextText = null, string lastText = null, int numericLinksCount = 5, dynamic htmlAttributes = null)
    ////{
    ////  var tableId = htmlAttributes.GetType().GetProperty("id").GetValue(htmlAttributes, null);
    ////  var width = htmlAttributes.GetType().GetProperty("width").GetValue(htmlAttributes, null);
    ////  var height = htmlAttributes.GetType().GetProperty("height").GetValue(htmlAttributes, null);

    ////  var html = grid.GetHtml(
    ////    tableStyle,
    ////    headerStyle,
    ////    footerStyle,
    ////    rowStyle,
    ////    alternatingRowStyle,
    ////    selectedRowStyle,
    ////    caption,
    ////    displayHeader,
    ////    fillEmptyRows,
    ////    emptyRowCellValue,
    ////    columns,
    ////    exclusions,
    ////    mode,
    ////    firstText,
    ////    previousText,
    ////    nextText,
    ////    lastText,
    ////    numericLinksCount,
    ////    htmlAttributes);

    ////  var strBuilder = new StringBuilder(html.ToString());
    ////  strBuilder.AppendLine("<script language=\"javascript\" type=\"text/javascript\">");
    ////  strBuilder.AppendLine("$(document).ready(function () {");

    ////  var i = 0;
    ////  foreach (var col in columns)
    ////  {
    ////    var myCol = col as MyWebGridColumn;
    ////    if (myCol != null)
    ////    {
    ////      if (tableId != null)
    ////      {

    ////        var js = string.Format("$('#{0} th:nth-child({1})').attr(\"width\", {2});", tableId, (i+1), myCol.HeaderWidth);
    ////        strBuilder.AppendLine(js);
    ////      }
    ////    }
    ////    i++;
    ////  }
    ////  if (tableId != null)
    ////  {
    ////    var sizeString = string.Format("width: {0}, height:{1}", width, height);
    ////    var js = "$('#" + tableId + "').flexigrid({" + sizeString + "});";
    ////    strBuilder.AppendLine(js);
    ////  }

    ////  strBuilder.AppendLine("});");
    ////  strBuilder.AppendLine("</script>");

    ////  return new HtmlString(strBuilder.ToString());
    ////}
  }
}