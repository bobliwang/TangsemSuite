﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Tangsem.Generator.Templates.MVC.Controllers
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using Tangsem.Common.Extensions;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class ApiControllerBaseTemplate : ApiControllerBaseTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n");
            
            #line 8 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"

	var tableMetadata = this.TableMetadata;

            
            #line default
            #line hidden
            this.Write("\r\nusing System.Linq;\r\nusing Microsoft.AspNetCore.Mvc;\r\nusing AutoMapper;\r\nusing ");
            
            #line 15 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.RepositoryNamespace));
            
            #line default
            #line hidden
            this.Write(";\r\nusing ");
            
            #line 16 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.EntityNamespace));
            
            #line default
            #line hidden
            this.Write(";\r\nusing ");
            
            #line 17 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.DTONamespace));
            
            #line default
            #line hidden
            this.Write(";\r\nusing ");
            
            #line 18 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.DomainNamespace));
            
            #line default
            #line hidden
            this.Write(".ViewModels.SearchParams;\r\n\r\nusing Tangsem.Data;\r\nusing Tangsem.NHibernate.Extens" +
                    "tions;\r\nusing ");
            
            #line 22 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.RootProjectName));
            
            #line default
            #line hidden
            this.Write(".Host.Filters;\r\n\r\nnamespace ");
            
            #line 24 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.RootProjectName));
            
            #line default
            #line hidden
            this.Write(".Host.Controllers.Base\r\n{\r\n\tpublic partial class ");
            
            #line 26 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("ApiControllerBase : Controller\r\n\t{\r\n\t\tprotected readonly I");
            
            #line 28 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.RepositoryName));
            
            #line default
            #line hidden
            this.Write(" _repository = null;\r\n\r\n\t\tprotected readonly IMapper _mapper = null;\r\n\r\n\t\tpublic " +
                    "");
            
            #line 32 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("ApiControllerBase(I");
            
            #line 32 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.RepositoryName));
            
            #line default
            #line hidden
            this.Write(" repository, IMapper mapper)\r\n\t\t{\r\n\t\t\t_repository = repository;\r\n\t\t\t_mapper = map" +
                    "per;\r\n\t\t}\r\n\r\n\t\tpublic virtual IActionResult Get");
            
            #line 38 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("List(");
            
            #line 38 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("SearchParams filterModel) {\r\n\r\n\t\t\tvar filteredQry = this.FilterBySearchParams(_re" +
                    "pository.");
            
            #line 40 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName.Pluralize()));
            
            #line default
            #line hidden
            this.Write(", filterModel);\r\n\t\t\tvar searchResult = new SearchResultModel<");
            
            #line 41 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write(@"DTO>
			{
				PageIndex = filterModel.PageIndex ?? 0,
				PageSize = filterModel.PageSize ?? int.MaxValue,
				RowsCount = filteredQry.Count(),
				PagedData = filteredQry.SortBy(filterModel)
                                       .SkipAndTake(filterModel)
                                       .ToList()
                                       .Select(x => _mapper.Map<");
            
            #line 49 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("DTO>(x))\r\n                                       .ToList(),\r\n\t\t\t};\r\n\r\n\t\t\treturn t" +
                    "his.Ok(searchResult);\r\n\t\t}\r\n     \r\n\t\tpublic virtual IActionResult Get");
            
            #line 56 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("By");
            
            #line 56 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.PrimaryKeyPropertyName));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 56 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.PrimaryKeyCSharpTypeAsString));
            
            #line default
            #line hidden
            this.Write(" id) {\r\n\t\t\tvar ");
            
            #line 57 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName.Lf()));
            
            #line default
            #line hidden
            this.Write(" = _repository.Lookup");
            
            #line 57 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("By");
            
            #line 57 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.PrimaryKeyPropertyName));
            
            #line default
            #line hidden
            this.Write("(id);\r\n            if (");
            
            #line 58 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName.Lf()));
            
            #line default
            #line hidden
            this.Write(" == null)\r\n\t\t\t{\r\n\t\t\t\treturn this.NotFound($\"");
            
            #line 60 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write(" is not found by id {id}\");\r\n\t\t\t}\r\n\r\n            var ");
            
            #line 63 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName.Lf()));
            
            #line default
            #line hidden
            this.Write("Dto = _mapper.Map<");
            
            #line 63 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("DTO>(");
            
            #line 63 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName.Lf()));
            
            #line default
            #line hidden
            this.Write(");\r\n\r\n\t\t\treturn this.Ok(");
            
            #line 65 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName.Lf()));
            
            #line default
            #line hidden
            this.Write("Dto);\r\n\t\t}\r\n\r\n\t\tpublic virtual IActionResult Update");
            
            #line 68 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 68 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.PrimaryKeyCSharpTypeAsString));
            
            #line default
            #line hidden
            this.Write(" id, [FromBody] ");
            
            #line 68 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("DTO model) {\r\n\t\t\tvar entity = _repository.Lookup");
            
            #line 69 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("By");
            
            #line 69 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.PrimaryKeyPropertyName));
            
            #line default
            #line hidden
            this.Write("(id);\r\n\r\n\t\t\tif (entity == null)\r\n\t\t\t{\r\n\t\t\t\treturn this.NotFound($\"");
            
            #line 73 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write(" is not found by id {id}\");\r\n\t\t\t}\r\n\r\n\t\t\t_mapper.Map(model, entity);\r\n\t\t\t_reposito" +
                    "ry.Update");
            
            #line 77 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("(entity);\r\n\r\n\t\t\treturn this.Ok();\r\n\t\t}\r\n     \r\n\t\tpublic virtual IActionResult Cre" +
                    "ate");
            
            #line 82 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("([FromBody] ");
            
            #line 82 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("DTO model) {\r\n\t\t\tvar entity = new ");
            
            #line 83 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("();\r\n\r\n\t\t\t_mapper.Map(model, entity);\r\n\t\t\t_repository.Save");
            
            #line 86 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("(entity);\r\n\r\n\t\t\treturn this.Ok();\r\n\t\t}\r\n\r\n\t\tpublic virtual IActionResult Delete");
            
            #line 91 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 91 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.PrimaryKeyCSharpTypeAsString));
            
            #line default
            #line hidden
            this.Write(" id, bool isHardDelete) {\r\n\t\t\tvar entity = _repository.Lookup");
            
            #line 92 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("By");
            
            #line 92 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.PrimaryKeyPropertyName));
            
            #line default
            #line hidden
            this.Write("(id);\r\n\r\n\t\t\tif (entity == null)\r\n\t\t\t{\r\n\t\t\t\treturn this.NotFound($\"");
            
            #line 96 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write(" is not found by id {id}\");\r\n\t\t\t}\r\n\r\n\t\t\tif (isHardDelete) {\r\n\t\t\t\t_repository.Dele" +
                    "te");
            
            #line 100 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("By");
            
            #line 100 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.PrimaryKeyPropertyName));
            
            #line default
            #line hidden
            this.Write("(id);\t\t\t\r\n\t\t\t}\r\n\t\t\telse\r\n\t\t\t{\r\n\t\t\t\tentity.Active = false;\r\n\t\t\t\t_repository.Update" +
                    "");
            
            #line 105 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("(entity);\r\n\t\t\t}\r\n\r\n\t\t\treturn this.Ok();\r\n\t\t}\r\n\r\n\t\tpublic virtual IQueryable<");
            
            #line 111 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("> FilterBySearchParams(IQueryable<");
            
            #line 111 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("> qry, ");
            
            #line 111 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("SearchParams filterModel)\r\n\t\t{\r\n\t\t\tvar filteredQry = qry; \r\n\t\t\r\n\t\t\t");
            
            #line 115 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
 foreach (var col in tableMetadata.Columns) { 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\tif (filterModel.");
            
            #line 117 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write(" != null)\r\n\t\t\t{\r\n\t\t\t");
            
            #line 119 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
 if (col.OutgoingReference == null) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t");
            
            #line 120 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
 if (col.ClrType == typeof(string)) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t");
            
            #line 121 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
 if (col.IsJsonType) { 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\tfilteredQry = filteredQry.Where(x => x.");
            
            #line 123 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write(".ToJsonString().Contains(filterModel.");
            
            #line 123 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write("));\r\n\t\t\t\t\t");
            
            #line 124 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\tfilteredQry = filteredQry.Where(x => x.");
            
            #line 126 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write(".Contains(filterModel.");
            
            #line 126 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write("));\r\n\t\t\t\t\t");
            
            #line 127 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\r\n\t\t\t\t");
            
            #line 129 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\r\n\t\t\t\tfilteredQry = filteredQry.Where(x => x.");
            
            #line 131 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write(" == filterModel.");
            
            #line 131 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write(");\r\n\t\t\t\t");
            
            #line 132 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 133 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t// OutgoingReference\r\n\t\t\t\tfilteredQry = filteredQry.Where(x => x.");
            
            #line 135 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.OutgoingReference.ParentPropertyName));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 135 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.OutgoingReference.ParentTableMetadata.PrimaryKeyPropertyName));
            
            #line default
            #line hidden
            this.Write(" == filterModel.");
            
            #line 135 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write(");\r\n\t\t\t");
            
            #line 136 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t}\r\n\t\t\t");
            
            #line 139 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerBaseTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\treturn filteredQry;\r\n\t\t}\r\n\t}\r\n\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class ApiControllerBaseTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
