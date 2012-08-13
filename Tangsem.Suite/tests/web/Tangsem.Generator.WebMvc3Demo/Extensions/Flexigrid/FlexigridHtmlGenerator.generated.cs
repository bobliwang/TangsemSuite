﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.530
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tangsem.Generator.WebMvc3Demo.Extensions.Flexigrid
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    #line 3 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    using Tangsem.Common.Extensions;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    using Tangsem.Generator.WebMvc3Demo.Extensions.Flexigrid;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.4.1.0")]
    public partial class FlexigridHtmlGenerator : RazorGenerator.Templating.RazorTemplateBase
    {
#line hidden

        #line 6 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"

  public FlexigridWrapper FlexigridWrapper { get; set; }
  public FlexigridHtmlOptions FlexigridHtmlOptions { get; set; }

        #line default
        #line hidden

        public override void Execute()
        {


WriteLiteral("\r\n\r\n");



WriteLiteral("\r\n");


WriteLiteral("\r\n\r\n");


            
            #line 11 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
  
  var grid = this.FlexigridWrapper.WebGrid;

  var options = this.FlexigridHtmlOptions;

  var tableId = ((object)options.HtmlAttributes).GetPropertyValue("id") as string;

  if (tableId == null)
  {
    throw new Exception("TableId is required in HtmlAttributes!");
  }

  var containerId = this.FlexigridWrapper.ContainerId;
  var request = this.FlexigridWrapper.WebPageBase.Request;


            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 27 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
Write(grid.GetHtml(
    options.TableStyle,
    options.HeaderStyle,
    options.FooterStyle,
    options.RowStyle,
    options.AlternatingRowStyle,
    options.SelectedRowStyle,
    options.Caption,
    options.DisplayHeader,
    options.FillEmptyRows,
    options.EmptyRowCellValue,
    options.Columns,
    options.Exclusions,
    options.Mode,
    options.FirstText,
    options.PreviousText,
    options.NextText,
    options.LastText,
    options.NumericLinksCount,
    options.HtmlAttributes));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n<script language=\"javascript\" type=\"text/javascript\">\r\n  $(function () {\r\n");


            
            #line 51 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
      
      var i = 0;
      foreach (var col in options.Columns)
      {
            
            #line default
            #line hidden
WriteLiteral("\r\n        $(\'#");


            
            #line 55 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
        Write(tableId);

            
            #line default
            #line hidden
WriteLiteral(" th:nth-child(");


            
            #line 55 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                Write(++i);

            
            #line default
            #line hidden
WriteLiteral(")\').attr(\'width\', ");


            
            #line 55 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                        Write(col.HeaderWidth);

            
            #line default
            #line hidden
WriteLiteral(");\r\n        $(\'#");


            
            #line 56 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
        Write(tableId);

            
            #line default
            #line hidden
WriteLiteral(" th:nth-child(");


            
            #line 56 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                Write(i);

            
            #line default
            #line hidden
WriteLiteral(")\').attr(\'align\', \'");


            
            #line 56 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                       Write(col.Align.ToString().ToLower());

            
            #line default
            #line hidden
WriteLiteral("\');\r\n        $(\'#");


            
            #line 57 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
        Write(tableId);

            
            #line default
            #line hidden
WriteLiteral(" th:nth-child(");


            
            #line 57 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                Write(i);

            
            #line default
            #line hidden
WriteLiteral(")\').attr(\'valign\', \'");


            
            #line 57 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                        Write(col.VAlign.ToString().ToLower());

            
            #line default
            #line hidden
WriteLiteral("\');\r\n      ");


            
            #line 58 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
             }

      var columns = options.Columns.ToList();
      var sortedColumn = columns.FirstOrDefault(x => x.ColumnName == this.FlexigridWrapper.SortBy);
      var colIndex = 0;
      if (sortedColumn != null)
      {
        colIndex = columns.IndexOf(sortedColumn) + 1;

            
            #line default
            #line hidden
WriteLiteral("        ");

WriteLiteral("$(\'#");


            
            #line 66 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
              Write(tableId);

            
            #line default
            #line hidden
WriteLiteral(" th:nth-child(");


            
            #line 66 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                      Write(colIndex);

            
            #line default
            #line hidden
WriteLiteral(")\').addClass(\'sorted\')");

WriteLiteral("\r\n");


            
            #line 67 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
      }
    

            
            #line default
            #line hidden
WriteLiteral("    \r\n    \r\n    $(\'#");


            
            #line 71 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(tableId);

            
            #line default
            #line hidden
WriteLiteral(" th\').css(\'background-color\', \'transparent\');\r\n    $(\'#");


            
            #line 72 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(tableId);

            
            #line default
            #line hidden
WriteLiteral(" th\').css(\'color\', \'#000\');    \r\n    $(\'#");


            
            #line 73 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(tableId);

            
            #line default
            #line hidden
WriteLiteral(" th a\').css(\'color\', \'#000\');    \r\n    $(\'#");


            
            #line 74 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(tableId);

            
            #line default
            #line hidden
WriteLiteral(" th a\').css(\'text-decoration\', \'none\');\r\n    ");



WriteLiteral("\r\n    $(\'#");


            
            #line 76 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(tableId);

            
            #line default
            #line hidden
WriteLiteral(" tfoot\').remove();\r\n    \r\n");


            
            #line 78 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
      var searchSettings = options.FlexigridSearchSettings;

            
            #line default
            #line hidden
WriteLiteral("    $(\'#");


            
            #line 79 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(tableId);

            
            #line default
            #line hidden
WriteLiteral("\').flexigrid({\r\n      width:     ");


            
            #line 80 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
             Write(options.FlexiWidth);

            
            #line default
            #line hidden
WriteLiteral(",\r\n      height:    ");


            
            #line 81 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
             Write(options.FlexiHeight);

            
            #line default
            #line hidden
WriteLiteral(",\r\n      title:    \'");


            
            #line 82 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
             Write(options.Title);

            
            #line default
            #line hidden
WriteLiteral("\',\r\n      usepager: true,\r\n      useRp: false,\r\n      total: ");


            
            #line 85 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
         Write(grid.TotalRowCount);

            
            #line default
            #line hidden
WriteLiteral(",\r\n      rp: ");


            
            #line 86 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
      Write(grid.RowsPerPage);

            
            #line default
            #line hidden
WriteLiteral(",\r\n      page: ");


            
            #line 87 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
        Write(grid.PageIndex);

            
            #line default
            #line hidden
WriteLiteral("\r\n      ");


            
            #line 88 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
  Write(options.IsUsingSearchSettings ? "," + searchSettings.SearchItemsJson : string.Empty);

            
            #line default
            #line hidden


WriteLiteral("\r\n    });\r\n    \r\n    var ths = $(\'#");


            
            #line 91 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
              Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .hDivBox th\');\r\n    ths.each(function(idx) {\r\n      var self = $(this);\r\n      s" +
"elf.find(\'div\').click(\r\n        function(){\r\n          $.pjax({url: self.find(\'a" +
"\').attr(\'href\'), container:\'#");


            
            #line 96 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                            Write(containerId);

            
            #line default
            #line hidden
WriteLiteral("\'});\r\n          return false;// prevent the link to issue another query.\r\n       " +
" }\r\n      );\r\n    });\r\n    \r\n");


            
            #line 102 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
      
      if (sortedColumn != null)
      {
        var sortDir = this.FlexigridWrapper.SortDir;
        var sortDirClass = "DESC".Equals(sortDir, StringComparison.CurrentCultureIgnoreCase) ? "sdesc" : "sasc";


            
            #line default
            #line hidden
WriteLiteral("        ");

WriteLiteral("\r\n          var sortedDiv = $(\'#");


            
            #line 109 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                          Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .hDivBox th:nth-child(");


            
            #line 109 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                               Write(colIndex);

            
            #line default
            #line hidden
WriteLiteral(") div\');\r\n          sortedDiv.addClass(\'");


            
            #line 110 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                          Write(sortDirClass);

            
            #line default
            #line hidden
WriteLiteral("\');\r\n        ");

WriteLiteral("  \r\n");


            
            #line 112 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
      }

      var pageUrlTemplate = this.FlexigridWrapper.FirstPageUrl;
    

            
            #line default
            #line hidden
WriteLiteral("    \r\n    $(\'#");


            
            #line 117 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .pcontrol input\').val(");


            
            #line 117 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                         Write(grid.PageIndex + 1);

            
            #line default
            #line hidden
WriteLiteral(");\r\n    $(\'#");


            
            #line 118 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .pcontrol span\').html(\'");


            
            #line 118 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                          Write(grid.PageCount);

            
            #line default
            #line hidden
WriteLiteral("\');\r\n    $(\'#");


            
            #line 119 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .pPageStat\').html(\'Displaying ");


            
            #line 119 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                 Write(grid.PageIndex * grid.RowsPerPage + 1);

            
            #line default
            #line hidden
WriteLiteral(" to ");


            
            #line 119 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                                                             Write(Math.Min((grid.PageIndex+1) * grid.RowsPerPage, grid.TotalRowCount));

            
            #line default
            #line hidden
WriteLiteral(" of ");


            
            #line 119 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                                                                                                                                       Write(grid.TotalRowCount);

            
            #line default
            #line hidden
WriteLiteral(" items.\');\r\n    \r\n    ");



WriteLiteral("\r\n    var goPage = function() {\r\n      var template = \'");


            
            #line 123 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                  Write(pageUrlTemplate);

            
            #line default
            #line hidden
WriteLiteral("\';\r\n      var url = template.replace(\'");


            
            #line 124 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                              Write(grid.PageFieldName);

            
            #line default
            #line hidden
WriteLiteral("=1\', \'");


            
            #line 124 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                         Write(grid.PageFieldName);

            
            #line default
            #line hidden
WriteLiteral("=\' + $(\'.pcontrol input\').val());\r\n      $.pjax( {url: url, container: \'#");


            
            #line 125 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                  Write(containerId);

            
            #line default
            #line hidden
WriteLiteral("\' });\r\n    };\r\n    \r\n    $(\'#");


            
            #line 128 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .pcontrol input\').change(goPage);\r\n    $(\'#");


            
            #line 129 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .pcontrol input\').keyup(goPage);\r\n    $(\'#");


            
            #line 130 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .pReload\').click(goPage);\r\n    \r\n    ");



WriteLiteral("\r\n    $(\'#");


            
            #line 133 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(@" .pcontrol input').keypress(function (evt) {
      var e = window.event || evt; // for trans-browser compatibility  
      var charCode = e.which || e.keyCode;  
      if ((charCode > 47 && charCode < 58) || charCode == 8){
        return true;
      }  
      return false;
    });
    
    $('#");


            
            #line 142 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .pFirst\').click(function(){$.pjax({url:\'");


            
            #line 142 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                           Write(this.FlexigridWrapper.FirstPageUrl);

            
            #line default
            #line hidden
WriteLiteral("\', container:\'#");


            
            #line 142 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                                                                               Write(containerId);

            
            #line default
            #line hidden
WriteLiteral("\'});});\r\n    $(\'#");


            
            #line 143 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .pLast\').click(function(){$.pjax({url:\'");


            
            #line 143 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                          Write(this.FlexigridWrapper.LastPageUrl);

            
            #line default
            #line hidden
WriteLiteral("\', container:\'#");


            
            #line 143 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                                                                             Write(containerId);

            
            #line default
            #line hidden
WriteLiteral("\'});});\r\n    $(\'#");


            
            #line 144 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .pPrev\').click(function(){$.pjax({url:\'");


            
            #line 144 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                          Write(this.FlexigridWrapper.PrevPageUrl);

            
            #line default
            #line hidden
WriteLiteral("\', container:\'#");


            
            #line 144 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                                                                             Write(containerId);

            
            #line default
            #line hidden
WriteLiteral("\'});});\r\n    $(\'#");


            
            #line 145 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .pNext\').click(function(){$.pjax({url:\'");


            
            #line 145 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                          Write(this.FlexigridWrapper.NextPageUrl);

            
            #line default
            #line hidden
WriteLiteral("\', container:\'#");


            
            #line 145 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                                                                             Write(containerId);

            
            #line default
            #line hidden
WriteLiteral("\'});});\r\n    \r\n    ");



WriteLiteral("\r\n");


            
            #line 148 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
     if (options.IsUsingSearchSettings)
    {

            
            #line default
            #line hidden
WriteLiteral("    ");

WriteLiteral("\r\n      var searchBox = $(\'#");


            
            #line 151 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                      Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" input[name=\"q\"]\');\r\n      var qtypeSel = $(\'#");


            
            #line 152 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                     Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(@" select[name=""qtype""]');
      if (searchBox.length > 0) {
        searchBox.keypress(function(evt){
          var e = window.event || evt; // for trans-browser compatibility  
          var charCode = e.which || e.keyCode;
          if (charCode == 13) {
            ");



WriteLiteral("\r\n            $.pjax({url:\'");


            
            #line 159 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                     Write(options.FlexigridSearchSettings.Url);

            
            #line default
            #line hidden
WriteLiteral("\', container:\'#");


            
            #line 159 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                                          Write(containerId);

            
            #line default
            #line hidden
WriteLiteral("\', data: {\'");


            
            #line 159 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                                                                   Write(searchSettings.SearchFieldParamName);

            
            #line default
            #line hidden
WriteLiteral("\': qtypeSel.val(), \'");


            
            #line 159 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                                                                                                                             Write(searchSettings.SearchValueParamName);

            
            #line default
            #line hidden
WriteLiteral("\': searchBox.val()}});\r\n          }\r\n        });  \r\n      }\r\n    ");

WriteLiteral("\r\n");


            
            #line 164 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
      var currentQ = request[searchSettings.SearchValueParamName];
      var currentQtype = request[searchSettings.SearchFieldParamName];
      if (string.IsNullOrEmpty(currentQtype))
      {
        var defaultSearchItem = searchSettings.SearchItems.LastOrDefault(x => x.IsDefault);
        if (defaultSearchItem != null)
        {
          currentQtype = defaultSearchItem.Name;
        }
      }

      if (!string.IsNullOrEmpty(currentQ))
      {
            
            #line default
            #line hidden
WriteLiteral("\r\n        searchBox.val(\'");


            
            #line 177 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                   Write(currentQ);

            
            #line default
            #line hidden
WriteLiteral("\');\r\n      ");


            
            #line 178 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
             }

      if (!string.IsNullOrEmpty(currentQtype))
      {
            
            #line default
            #line hidden
WriteLiteral("\r\n        qtypeSel.val(\'");


            
            #line 182 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                  Write(currentQtype);

            
            #line default
            #line hidden
WriteLiteral("\');\r\n      ");


            
            #line 183 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
             }
    }

            
            #line default
            #line hidden
WriteLiteral("    \r\n");


            
            #line 186 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
     if (options.FooterFormat != null)
    {
      var newFooter = string.Format("<tfoot><tr><td colspan=\"{0}\">{1}</td></tr></tfoot>"
        , options.Columns.Count()
        , Convert.ToString(options.FooterFormat(null)));

      newFooter = newFooter.Replace("'", "\\'").Replace(Environment.NewLine, "");


            
            #line default
            #line hidden
WriteLiteral("      ");

WriteLiteral("\r\n      $(\'#");


            
            #line 195 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
      Write(tableId);

            
            #line default
            #line hidden
WriteLiteral("\').append(\'\" + ");


            
            #line 195 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                               Write(newFooter);

            
            #line default
            #line hidden
WriteLiteral(" + \"\');\r\n      ");

WriteLiteral("\r\n");


            
            #line 197 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("  });\r\n</script>");


        }
    }
}
#pragma warning restore 1591
