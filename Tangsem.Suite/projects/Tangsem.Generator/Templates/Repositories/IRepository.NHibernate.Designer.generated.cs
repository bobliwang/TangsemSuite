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

namespace Tangsem.Generator.Templates.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    #line 4 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
    using Tangsem.Common.Extensions;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
    using Tangsem.Generator.Templates;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.3.2.0")]
    public partial class IRepository_NHibernate_Designer : MultipleTableMetadataTemplate
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");


WriteLiteral("\t\t\t  \r\n");



WriteLiteral("\r\nusing System;\r\nusing System.Collections;\r\nusing System.Collections.Generic;\r\nus" +
"ing System.Text;\r\nusing System.Linq;\r\nusing System.Linq.Expressions;\r\n\r\nusing Ta" +
"ngsem.Data.Domain;\r\nusing Tangsem.NHibernate.Domain;\r\n\r\nusing ");


            
            #line 17 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
  Write(Configuration.EntityNamespace);

            
            #line default
            #line hidden
WriteLiteral(";\r\n\r\nnamespace ");


            
            #line 19 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
      Write(Configuration.RepositoryNamespace);

            
            #line default
            #line hidden
WriteLiteral("\r\n{\r\n\t/// <summary>\r\n\t/// The I");


            
            #line 22 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
      Write(Configuration.RepositoryName);

            
            #line default
            #line hidden
WriteLiteral(" interface.\r\n\t/// </summary>\r\n\tpublic partial interface I");


            
            #line 24 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                       Write(Configuration.RepositoryName);

            
            #line default
            #line hidden
WriteLiteral(" : IRepository\r\n\t{\r\n");


            
            #line 26 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
 		foreach (var tableMetadata in this.TableMetadatas)
		{
            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\r\n\t\t/// <summary>\r\n\t\t/// The IQueryable for ");


            
            #line 30 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                     Write(tableMetadata.EntityName.Pluralize());

            
            #line default
            #line hidden
WriteLiteral(".\r\n\t\t/// </summary>\r\n\t\tIQueryable<");


            
            #line 32 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
         Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral("> ");


            
            #line 32 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                                      Write(tableMetadata.EntityName.Pluralize());

            
            #line default
            #line hidden
WriteLiteral(" { get; }\r\n\r\n\t\t");


            
            #line 34 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
         }

            
            #line default
            #line hidden
WriteLiteral("\t\t\r\n\t\t\r\n");


            
            #line 37 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
 		foreach (var tableMetadata in this.TableMetadatas)
		{
            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\r\n\t\t/// <summary>\r\n\t\t/// Get ");


            
            #line 41 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
      Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" by primary key.\r\n\t\t/// </summary>\r\n\t\t");


            
            #line 43 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" Lookup");


            
            #line 43 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                                Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral("By");


            
            #line 43 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                                                             Write(tableMetadata.PrimaryKeys[0].PropertyName);

            
            #line default
            #line hidden
WriteLiteral("(");


            
            #line 43 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                                                                                                          Write(tableMetadata.PrimaryKeys[0].CSharpTypeAsString);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 43 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                                                                                                                                                             Write(tableMetadata.PrimaryKeys[0].PropertyName.LowerFirst());

            
            #line default
            #line hidden
WriteLiteral(");\r\n\t\t\r\n\t\t/// <summary>\r\n\t\t/// Delete ");


            
            #line 46 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
         Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" by primary key.\r\n\t\t/// </summary>\r\n\t\t");


            
            #line 48 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" Delete");


            
            #line 48 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                                Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral("By");


            
            #line 48 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                                                             Write(tableMetadata.PrimaryKeys[0].PropertyName);

            
            #line default
            #line hidden
WriteLiteral("(");


            
            #line 48 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                                                                                                          Write(tableMetadata.PrimaryKeys[0].CSharpTypeAsString);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 48 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                                                                                                                                                             Write(tableMetadata.PrimaryKeys[0].PropertyName.LowerFirst());

            
            #line default
            #line hidden
WriteLiteral(");\r\n\t\t\r\n\t\t/// <summary>\r\n\t\t/// Save a new ");


            
            #line 51 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
             Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" instance.\r\n\t\t/// </summary>\r\n\t\t");


            
            #line 53 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" Save");


            
            #line 53 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                              Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral("(");


            
            #line 53 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                                                          Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 53 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                                                                                      Write(tableMetadata.EntityName.LowerFirst());

            
            #line default
            #line hidden
WriteLiteral(");\r\n\t\t\r\n\t\t/// <summary>\r\n\t\t/// Update an existing ");


            
            #line 56 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                     Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" instance.\r\n\t\t/// </summary>\r\n\t\t");


            
            #line 58 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" Update");


            
            #line 58 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                                Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral("(");


            
            #line 58 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                                                            Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 58 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                                                                                        Write(tableMetadata.EntityName.LowerFirst());

            
            #line default
            #line hidden
WriteLiteral(");\r\n\t\t\r\n\t\t/// <summary>\r\n\t\t/// Save or update an existing ");


            
            #line 61 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                             Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" instance.\r\n\t\t/// </summary>\r\n\t\t");


            
            #line 63 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" SaveOrUpdate");


            
            #line 63 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                                      Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral("(");


            
            #line 63 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                                                                  Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 63 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
                                                                                              Write(tableMetadata.EntityName.LowerFirst());

            
            #line default
            #line hidden
WriteLiteral(");\r\n\r\n\t\t");


            
            #line 65 "..\..\Templates\Repositories\IRepository.NHibernate.Designer.cshtml"
         }

            
            #line default
            #line hidden
WriteLiteral("\r\n\t}\r\n}");


        }
    }
}
#pragma warning restore 1591
