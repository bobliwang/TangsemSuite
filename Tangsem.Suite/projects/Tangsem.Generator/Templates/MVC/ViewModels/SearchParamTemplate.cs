﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Tangsem.Generator.Templates.MVC.ViewModels
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\ViewModels\SearchParamTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class SearchParamTemplate : Tangsem.Common.T4.T4TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\nusing Tangsem.Data;\r\n\r\n");
            
            #line 9 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\ViewModels\SearchParamTemplate.tt"

	var tableMetadata = this.TableMetadata;

            
            #line default
            #line hidden
            this.Write("\r\nnamespace ");
            
            #line 13 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\ViewModels\SearchParamTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.DomainNamespace));
            
            #line default
            #line hidden
            this.Write(".ViewModels.SearchParams\r\n{\r\n\r\n\tpublic partial class ");
            
            #line 16 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\ViewModels\SearchParamTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("SearchParams: SearchParamsBase\r\n\t{    \r\n\t");
            
            #line 18 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\ViewModels\SearchParamTemplate.tt"
 foreach (var col in tableMetadata.Columns) { 
            
            #line default
            #line hidden
            this.Write("\r\n\t\r\n\t\tpublic ");
            
            #line 21 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\ViewModels\SearchParamTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.NullableCSharpTypeAsString));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 21 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\ViewModels\SearchParamTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n\r\n\t");
            
            #line 23 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\ViewModels\SearchParamTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\t}\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
