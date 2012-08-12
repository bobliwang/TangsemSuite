﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.431
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.3.2.0")]
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


            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 26 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
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
WriteLiteral("\r\n\r\n\r\n<script language=\"javascript\" type=\"text/javascript\">\r\n  $(function () {\r\n " +
"   \r\n");


            
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
WriteLiteral(");\r\n      ");


            
            #line 56 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
             }
    

            
            #line default
            #line hidden
WriteLiteral("    \r\n    $(\'#");


            
            #line 59 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(tableId);

            
            #line default
            #line hidden
WriteLiteral(" tfoot\').remove();\r\n    \r\n    ");



WriteLiteral("\r\n");


            
            #line 62 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
      
      var searchItemsStr = string.Empty;
      if( options.SearchItems != null && options.SearchItems.Any()){
        searchItemsStr += ", searchitems: [";
        searchItemsStr += string.Join(", ", options.SearchItems.Select(x => x.ToJson()));
        searchItemsStr += "]";
      }
    

            
            #line default
            #line hidden
WriteLiteral("\r\n    $(\'#");


            
            #line 71 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(tableId);

            
            #line default
            #line hidden
WriteLiteral("\').flexigrid({\r\n      width:     ");


            
            #line 72 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
             Write(options.FlexiWidth);

            
            #line default
            #line hidden
WriteLiteral(",\r\n      height:    ");


            
            #line 73 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
             Write(options.FlexiHeight);

            
            #line default
            #line hidden
WriteLiteral(",\r\n      title:    \'");


            
            #line 74 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
             Write(options.Title);

            
            #line default
            #line hidden
WriteLiteral("\',\r\n      usepager: true,\r\n      useRp: false,\r\n      total: ");


            
            #line 77 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
         Write(grid.TotalRowCount);

            
            #line default
            #line hidden
WriteLiteral(",\r\n      rp: ");


            
            #line 78 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
      Write(grid.RowsPerPage);

            
            #line default
            #line hidden
WriteLiteral(",\r\n      page: ");


            
            #line 79 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
        Write(grid.PageIndex);

            
            #line default
            #line hidden
WriteLiteral("\r\n      ");


            
            #line 80 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
  Write(searchItemsStr);

            
            #line default
            #line hidden
WriteLiteral("\r\n    });\r\n    \r\n");


            
            #line 83 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
      
      var pageUrlTemplate = this.FlexigridWrapper.FirstPageUrl;
    

            
            #line default
            #line hidden
WriteLiteral("\r\n    $(\'#");


            
            #line 87 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .pcontrol input\').val(");


            
            #line 87 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                         Write(grid.PageIndex + 1);

            
            #line default
            #line hidden
WriteLiteral(");\r\n    $(\'#");


            
            #line 88 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .pcontrol span\').html(\'");


            
            #line 88 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                          Write(grid.PageCount);

            
            #line default
            #line hidden
WriteLiteral("\');\r\n    $(\'#");


            
            #line 89 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .pPageStat\').html(\'Displaying ");


            
            #line 89 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                 Write(grid.PageIndex * grid.RowsPerPage + 1);

            
            #line default
            #line hidden
WriteLiteral(" to ");


            
            #line 89 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                                                             Write(Math.Min((grid.PageIndex+1) * grid.RowsPerPage, grid.TotalRowCount));

            
            #line default
            #line hidden
WriteLiteral(" of ");


            
            #line 89 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                                                                                                                                       Write(grid.TotalRowCount);

            
            #line default
            #line hidden
WriteLiteral(" items.\');\r\n    \r\n    var goPage = function() {\r\n      var template = \'");


            
            #line 92 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                  Write(pageUrlTemplate);

            
            #line default
            #line hidden
WriteLiteral("\';\r\n      var url = template.replace(\'");


            
            #line 93 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                              Write(grid.PageFieldName);

            
            #line default
            #line hidden
WriteLiteral("=1\', \'");


            
            #line 93 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                         Write(grid.PageFieldName);

            
            #line default
            #line hidden
WriteLiteral("=\' + $(\'.pcontrol input\').val());\r\n      $.pjax( {url: url, container: \'#");


            
            #line 94 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                  Write(containerId);

            
            #line default
            #line hidden
WriteLiteral("\' });\r\n    };\r\n    \r\n    $(\'#");


            
            #line 97 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .pcontrol input\').change(goPage);\r\n    $(\'#");


            
            #line 98 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .pcontrol input\').keyup(goPage);\r\n    $(\'#");


            
            #line 99 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .pReload\').click(goPage);\r\n    \r\n    ");



WriteLiteral("\r\n    $(\'#");


            
            #line 102 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
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


            
            #line 111 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .pFirst\').click(function(){$.pjax({url:\'");


            
            #line 111 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                           Write(this.FlexigridWrapper.FirstPageUrl);

            
            #line default
            #line hidden
WriteLiteral("\', container:\'#");


            
            #line 111 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                                                                               Write(containerId);

            
            #line default
            #line hidden
WriteLiteral("\'});});\r\n    $(\'#");


            
            #line 112 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .pLast\').click(function(){$.pjax({url:\'");


            
            #line 112 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                          Write(this.FlexigridWrapper.LastPageUrl);

            
            #line default
            #line hidden
WriteLiteral("\', container:\'#");


            
            #line 112 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                                                                             Write(containerId);

            
            #line default
            #line hidden
WriteLiteral("\'});});\r\n    $(\'#");


            
            #line 113 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .pPrev\').click(function(){$.pjax({url:\'");


            
            #line 113 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                          Write(this.FlexigridWrapper.PrevPageUrl);

            
            #line default
            #line hidden
WriteLiteral("\', container:\'#");


            
            #line 113 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                                                                             Write(containerId);

            
            #line default
            #line hidden
WriteLiteral("\'});});\r\n    $(\'#");


            
            #line 114 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(" .pNext\').click(function(){$.pjax({url:\'");


            
            #line 114 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                          Write(this.FlexigridWrapper.NextPageUrl);

            
            #line default
            #line hidden
WriteLiteral("\', container:\'#");


            
            #line 114 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                                                                                                             Write(containerId);

            
            #line default
            #line hidden
WriteLiteral("\'});});\r\n    \r\n    ");



WriteLiteral("\r\n    var searchBox = $(\'#");


            
            #line 117 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
                    Write(containerId);

            
            #line default
            #line hidden
WriteLiteral(@" input[name=""q""]');
    if (searchBox.length > 0) {
      searchBox.keypress(function(evt){
        var e = window.event || evt; // for trans-browser compatibility  
        var charCode = e.which || e.keyCode;  
        if (charCode == 13) {
          ");



WriteLiteral("\r\n          \r\n          alert(charCode);\r\n        }\r\n      });  \r\n    }\r\n    \r\n\r\n" +
"");


            
            #line 131 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
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


            
            #line 140 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
      Write(tableId);

            
            #line default
            #line hidden
WriteLiteral("\').append(\'\" + newFooter + \"\');\r\n      ");

WriteLiteral("\r\n");


            
            #line 142 "..\..\Extensions\Flexigrid\FlexigridHtmlGenerator.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("    \r\n  });\r\n</script>");


        }
    }
}
#pragma warning restore 1591
