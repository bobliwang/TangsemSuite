﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tangsem.Generator.Templates.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    #line 4 "..\..\Templates\Entities\Poco.DTO.Designer.cshtml"
    using Tangsem.Generator.Metadata;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Templates\Entities\Poco.DTO.Designer.cshtml"
    using Tangsem.Generator.Settings;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Templates\Entities\Poco.DTO.Designer.cshtml"
    using Tangsem.Generator.Templates;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public partial class Poco_DTO_Designer : SingleTableMetadataTemplate
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");


WriteLiteral("\r\n");




WriteLiteral("\r\nusing System;\r\nusing System.Collections;\r\nusing System.Collections.Generic;\r\nus" +
"ing System.Text;\r\nusing System.Linq;\r\nusing System.Linq.Expressions;\r\n\r\nnamespac" +
"e ");


            
            #line 15 "..\..\Templates\Entities\Poco.DTO.Designer.cshtml"
      Write(Configuration.DTONamespace);

            
            #line default
            #line hidden
WriteLiteral("\r\n{\r\n\tpublic partial class ");


            
            #line 17 "..\..\Templates\Entities\Poco.DTO.Designer.cshtml"
                  Write(TableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral("DTO\r\n\t{\t\r\n\t\t/// <summary>\r\n\t\t/// The default constructor for ");


            
            #line 20 "..\..\Templates\Entities\Poco.DTO.Designer.cshtml"
                              Write(TableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral("DTO class.\r\n\t\t/// </summary>\r\n\t\tpublic ");


            
            #line 22 "..\..\Templates\Entities\Poco.DTO.Designer.cshtml"
     Write(TableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral("DTO()\r\n\t\t{\r\n\t\t}\r\n\r\n");


            
            #line 26 "..\..\Templates\Entities\Poco.DTO.Designer.cshtml"
 		foreach (var col in @TableMetadata.Columns)
		{
            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t/// <summary>\r\n\t\t/// Property ");


            
            #line 29 "..\..\Templates\Entities\Poco.DTO.Designer.cshtml"
          Write(col.PropertyName);

            
            #line default
            #line hidden
WriteLiteral(" mapping to ");


            
            #line 29 "..\..\Templates\Entities\Poco.DTO.Designer.cshtml"
                                        Write(TableMetadata.Name);

            
            #line default
            #line hidden
WriteLiteral(".");


            
            #line 29 "..\..\Templates\Entities\Poco.DTO.Designer.cshtml"
                                                              Write(col.ColumnName);

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t/// </summary>\r\n\t\tpublic virtual ");


            
            #line 31 "..\..\Templates\Entities\Poco.DTO.Designer.cshtml"
            Write(col.CSharpTypeAsString);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 31 "..\..\Templates\Entities\Poco.DTO.Designer.cshtml"
                                    Write(col.PropertyName);

            
            #line default
            #line hidden
WriteLiteral(" { get; set; }\r\n\t\t");


            
            #line 32 "..\..\Templates\Entities\Poco.DTO.Designer.cshtml"
         }

            
            #line default
            #line hidden
WriteLiteral("\r\n\t}\r\n}");


        }
    }
}
#pragma warning restore 1591
