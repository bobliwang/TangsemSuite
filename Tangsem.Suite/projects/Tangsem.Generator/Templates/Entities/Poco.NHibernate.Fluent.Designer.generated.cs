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

namespace Tangsem.Generator.Templates.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    #line 3 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
    using Tangsem.Generator.Metadata;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
    using Tangsem.Generator.Settings;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.3.2.0")]
    public partial class Poco_NHibernate_Fluent_Designer : RazorGenerator.Templating.RazorTemplateBase
    {
#line hidden

        #line 6 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"


	/// <summary>
	/// The table metadata.
	/// </summary>
	public TableMetadata TableMetadata { get; set; }

	/// <summary>
	/// The generator configuration instance.
	/// </summary>
	public GeneratorConfiguration Configuration { get; set; }


        #line default
        #line hidden

        public override void Execute()
        {


WriteLiteral("\r\n\r\n");



WriteLiteral("\r\n");


WriteLiteral("\r\n\r\nusing System;\r\nusing System.Collections;\r\nusing System.Collections.Generic;\r\n" +
"using System.Text;\r\nusing System.Linq;\r\n\r\nnamespace ");


            
            #line 26 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
      Write(Configuration.EntityNamespace);

            
            #line default
            #line hidden
WriteLiteral(".Fluent.Mappings\r\n{\r\n\t/// <summary>\r\n\t/// The mapping configuration for ");


            
            #line 29 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                               Write(TableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(".\r\n\t/// </summary>\r\n\tpublic class ");


            
            #line 31 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
          Write(TableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral("Map : ClassMap<");


            
            #line 31 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                    Write(TableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(">\r\n\t{\r\n\t\t/// <summary>\r\n\t\t/// The constructor.\r\n\t\t/// </summary>\r\n\t\tpublic ");


            
            #line 36 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
     Write(TableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(@"Map()
		{
			// primary key mapping
			this.MapId();
			
			// basic columns mapping
			this.MapBasicColumns();
			
			// outgoing references mapping
			this.MapOutgoingReferences();
			
			// incoming references mapping
			this.MapIncomingReferences();
		}
		
		/// <summary>
		/// Map the Primary Key.
		/// </summary>
		private void MapId()
		{
			this.Id(x => x.");


            
            #line 56 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
              Write(TableMetadata.PrimaryKeys[0].PropertyName);

            
            #line default
            #line hidden
WriteLiteral(")\r\n\t\t\t\t.GeneratedBy\r\n\t\t\t\t.Native();\r\n\t\t}\r\n\t\t\r\n\t\t/// <summary>\r\n\t\t/// Map the Basi" +
"c Columns.\r\n\t\t/// </summary>\r\n\t\tprivate void MapBasicColumns()\r\n\t\t{\r\n");


            
            #line 66 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
 			foreach (var col in @TableMetadata.Columns.Where(c => !c.IsOutgoingRefKey && !c.IsPrimaryKey))
			{
            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\tthis.Map(x => x.");


            
            #line 68 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
               Write(col.PropertyName);

            
            #line default
            #line hidden
WriteLiteral(")\r\n                .TheColumnNameIs(\"");


            
            #line 69 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                              Write(col.ColumnName);

            
            #line default
            #line hidden

            
            #line 69 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                   WriteLiteral("\")");

            
            #line default
            #line hidden
            
            #line 69 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                      if (col.Nullable) {
            
            #line default
            #line hidden
WriteLiteral(";");


            
            #line 69 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                                                       }else{
            
            #line default
            #line hidden
WriteLiteral(".CanNotBeNull();");


            
            #line 69 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                                                                                          }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t");


            
            #line 70 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
          }

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t}\r\n\t\t\r\n\t\t/// <summary>\r\n\t\t/// Map the Outgoing References.\r\n\t\t/// </summary>\r" +
"\n\t\tprivate void MapOutgoingReferences()\r\n\t\t{\r\n");


            
            #line 79 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
 			foreach (var reference in this.TableMetadata.OutgoingReferences)
			{
            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\tthis.References<");


            
            #line 81 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
               Write(reference.ParentTableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(">(x => x.");


            
            #line 81 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                                   Write(reference.ParentPropertyName);

            
            #line default
            #line hidden
WriteLiteral(")\r\n                .TheColumnNameIs(\"");


            
            #line 82 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                              Write(reference.ColumnPairs[0].ChildColumnMetadata.ColumnName);

            
            #line default
            #line hidden

            
            #line 82 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                                                            WriteLiteral("\")");

            
            #line default
            #line hidden
            
            #line 82 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                                                               if (reference.ColumnPairs[0].ChildColumnMetadata.Nullable){
            
            #line default
            #line hidden
WriteLiteral(";");


            
            #line 82 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                                                                                                                                        }else{
            
            #line default
            #line hidden
WriteLiteral(".CanNotBeNull();");


            
            #line 82 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                                                                                                                                                                           }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t");


            
            #line 83 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
          }

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t}\r\n\t\t\r\n\t\t/// <summary>\r\n\t\t/// Map the Incoming References.\r\n\t\t/// </summary>\r" +
"\n\t\tprivate void MapIncomingReferences()\r\n\t\t{\r\n");


            
            #line 92 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
 			foreach (var reference in this.TableMetadata.IncomingReferences)
			{
            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\tthis.HasMany<");


            
            #line 94 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
            Write(reference.ChildTableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(">(x => x.");


            
            #line 94 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                               Write(reference.ChildListPropertyName);

            
            #line default
            #line hidden
WriteLiteral(")\r\n                .IsInverse()\r\n                .AsBag();\r\n\t\t\t");


            
            #line 97 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
          }

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t}\r\n\t}\r\n}");


        }
    }
}
#pragma warning restore 1591
