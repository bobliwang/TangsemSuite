﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tangsem.Generator.Templates.Entities
{
    using System;
    using System.Collections.Generic;
    
    #line 4 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    using System.Text;
    
    #line 5 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
    using Tangsem.Generator.Metadata;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
    using Tangsem.Generator.Settings;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
    using Tangsem.Generator.Templates;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public partial class Poco_NHibernate_Fluent_Designer : SingleTableMetadataTemplate
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");


WriteLiteral("\t\t\t  \r\n");





WriteLiteral("\r\nusing System;\r\nusing System.Collections;\r\nusing System.Collections.Generic;\r\nus" +
"ing System.Text;\r\nusing System.Linq;\r\n\r\nusing FluentNHibernate.Mapping;\r\n\r\nnames" +
"pace ");


            
            #line 17 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
      Write(Configuration.MappingNamespace);

            
            #line default
            #line hidden
WriteLiteral("\r\n{\r\n\t/// <summary>\r\n\t/// The mapping configuration for ");


            
            #line 20 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                               Write(TableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(".\r\n\t/// </summary>\r\n\tpublic partial class ");


            
            #line 22 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                  Write(TableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral("Map : ClassMap<");


            
            #line 22 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                            Write(TableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(">\r\n\t{\r\n\t\t/// <summary>\r\n\t\t/// The constructor.\r\n\t\t/// </summary>\r\n\t\tpublic ");


            
            #line 27 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
     Write(TableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral("Map()\r\n\t\t{\r\n\t\t\tthis.Table(\"");


            
            #line 29 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
           Write(TableMetadata.Name);

            
            #line default
            #line hidden
WriteLiteral("\");\r\n\t\t\t\r\n");


            
            #line 31 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
 			if(TableMetadata.IsView)
			{
            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\tthis.ReadOnly();\r\n\t\t\t");


            
            #line 34 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
          }

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t// primary key mapping\r\n\t\t\tthis.MapId();\r\n\t\t\t\r\n\t\t\t// basic columns mapping\r\n" +
"\t\t\tthis.MapBasicColumns();\r\n\t\t\t\r\n");


            
            #line 42 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
       if (Configuration.GenRelationship) {
            
            #line default
            #line hidden
WriteLiteral("\r\n      // outgoing references mapping\r\n\t\t\tthis.MapOutgoingReferences();\r\n\t\t\t\r\n\t\t" +
"\t// incoming references mapping\r\n      this.MapIncomingReferences();\r\n      ");


            
            #line 48 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
             }

            
            #line default
            #line hidden
WriteLiteral("\t\t}\r\n\t\t\r\n\t\t/// <summary>\r\n\t\t/// Map the Primary Key.\r\n\t\t/// </summary>\r\n\t\tprivate" +
" void MapId()\r\n\t\t{\r\n");


            
            #line 56 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
 			if (TableMetadata.PrimaryKeys.Any(x => x.IsAutoIncrement))
			{
            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\tthis.Id(x => x.");


            
            #line 58 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
              Write(TableMetadata.PrimaryKeys[0].PropertyName);

            
            #line default
            #line hidden
WriteLiteral(")\r\n\t\t\t\t.Column(\"");


            
            #line 59 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
         Write(TableMetadata.PrimaryKeys[0].ColumnName);

            
            #line default
            #line hidden
WriteLiteral("\")\r\n\t\t\t\t.GeneratedBy\r\n\t\t\t\t.Native();\r\n\t\t\t");


            
            #line 62 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
          }
			else if (TableMetadata.PrimaryKeys.Count == 1)
      {
            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\tthis.Id(x => x.");


            
            #line 65 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
              Write(TableMetadata.PrimaryKeys[0].PropertyName);

            
            #line default
            #line hidden
WriteLiteral(")\r\n\t\t\t    .Column(\"");


            
            #line 66 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
            Write(TableMetadata.PrimaryKeys[0].ColumnName);

            
            #line default
            #line hidden
WriteLiteral("\");\t\r\n\t\t\t");


            
            #line 67 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
          }
      else if (TableMetadata.PrimaryKeys.Count == 0)
      {
            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\tthis.Id(x => x.");


            
            #line 70 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
              Write(TableMetadata.Columns[0].PropertyName);

            
            #line default
            #line hidden
WriteLiteral(")\r\n\t\t\t    .Column(\"");


            
            #line 71 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
            Write(TableMetadata.Columns[0].ColumnName);

            
            #line default
            #line hidden
WriteLiteral("\");\t\r\n\t\t\t");


            
            #line 72 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
          }
      else
      {

            
            #line default
            #line hidden
WriteLiteral("        ");

WriteLiteral("this.CompositeId()");

WriteLiteral("\r\n");


            
            #line 76 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
        foreach (var col in this.TableMetadata.PrimaryKeys)
        {

            
            #line default
            #line hidden
WriteLiteral("          ");

WriteLiteral(".KeyProperty(x => x.");


            
            #line 78 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                Write(col.PropertyName);

            
            #line default
            #line hidden
WriteLiteral(", \"");


            
            #line 78 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                      Write(col.ColumnName);

            
            #line default
            #line hidden
WriteLiteral("\")");

WriteLiteral("\r\n");


            
            #line 79 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
        }
            
            #line default
            #line hidden
WriteLiteral(";");

WriteLiteral("\r\n");


            
            #line 80 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
      }

            
            #line default
            #line hidden
WriteLiteral("\t\t  \r\n\t\t}\r\n\t\t\r\n\t\t/// <summary>\r\n\t\t/// Map the Basic Columns.\r\n\t\t/// </summary>\r\n\t" +
"\tprivate void MapBasicColumns()\r\n\t\t{\r\n");


            
            #line 89 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
 			foreach (var col in @TableMetadata.Columns.Where(c => (!c.IsOutgoingRefKey || !Configuration.GenRelationship ) && !c.IsPrimaryKey))
			{
            
            #line default
            #line hidden
WriteLiteral("\r\n       // ");


            
            #line 91 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
      Write(col.ColumnName);

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t   this.Map(x => x.");


            
            #line 92 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                 Write(col.PropertyName);

            
            #line default
            #line hidden
WriteLiteral(").Column(\"");


            
            #line 92 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                              Write(col.ColumnName);

            
            #line default
            #line hidden
WriteLiteral("\")\r\n");


            
            #line 93 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
 			   if (col.ClrType == typeof(string)) {
            
            #line default
            #line hidden
WriteLiteral(" ");

WriteLiteral(".Length(");


            
            #line 93 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                      Write(col.ColumnSize > 0 ? col.ColumnSize.ToString() : "int.MaxValue");

            
            #line default
            #line hidden
WriteLiteral(")");

WriteLiteral(" ");


            
            #line 93 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                                                                                                     }

            
            #line default
            #line hidden

            
            #line 94 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
 			   if (!col.Nullable) {
            
            #line default
            #line hidden
WriteLiteral(" ");

WriteLiteral(".Not.Nullable()");


            
            #line 94 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                        }

            
            #line default
            #line hidden

            
            #line 95 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
          if (col.ReadOnly){
            
            #line default
            #line hidden
WriteLiteral(" ");

WriteLiteral(".ReadOnly()");


            
            #line 95 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                     }
            
            #line default
            #line hidden
WriteLiteral(";\r\n\r\n\t\t\t ");


            
            #line 97 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
           }

            
            #line default
            #line hidden
WriteLiteral("\t\t}\r\n\r\n");


            
            #line 100 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
     if (Configuration.GenRelationship) {
            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\r\n    /// <summary>\r\n\t\t/// Map the Outgoing References.\r\n\t\t/// </summary>\r\n\t\t" +
"private void MapOutgoingReferences()\r\n\t\t{\r\n");


            
            #line 107 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
 			foreach (var reference in this.TableMetadata.OutgoingReferences)
			{
            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\tthis.References<");


            
            #line 109 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
               Write(reference.ParentTableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(">(x => x.");


            
            #line 109 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                                   Write(reference.ParentPropertyName);

            
            #line default
            #line hidden
WriteLiteral(")\r\n                .Fetch.Join()\r\n                .Column(\"");


            
            #line 111 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                     Write(reference.ColumnPairs[0].ChildColumnMetadata.ColumnName);

            
            #line default
            #line hidden

            
            #line 111 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                                                   WriteLiteral("\")");

            
            #line default
            #line hidden
            
            #line 111 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                                                      if (reference.ColumnPairs[0].ChildColumnMetadata.Nullable){
            
            #line default
            #line hidden
WriteLiteral(";");


            
            #line 111 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                                                                                                                               }else{
            
            #line default
            #line hidden
WriteLiteral(".Not.Nullable();");


            
            #line 111 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                                                                                                                                                                  }

            
            #line default
            #line hidden
WriteLiteral("\t\t\t");


            
            #line 112 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
          }

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t}\r\n\t\t\r\n\t\t/// <summary>\r\n\t\t/// Map the Incoming References.\r\n\t\t/// </summary>\r" +
"\n\t\tprivate void MapIncomingReferences()\r\n\t\t{\r\n");


            
            #line 121 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
 			foreach (var reference in this.TableMetadata.IncomingReferences)
			{
            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\tthis.HasMany<");


            
            #line 123 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
            Write(reference.ChildTableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(">(x => x.");


            
            #line 123 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
                                                               Write(reference.ChildListPropertyName);

            
            #line default
            #line hidden
WriteLiteral(")\r\n\t\t\t\t.KeyColumn(\"");


            
            #line 124 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
            Write(reference.ColumnPairs[0].ChildColumnMetadata.ColumnName);

            
            #line default
            #line hidden
WriteLiteral("\")\r\n                .Inverse()\r\n                .LazyLoad()\r\n                .AsB" +
"ag();\r\n\t\t\t");


            
            #line 128 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
          }

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t}\r\n    ");


            
            #line 131 "..\..\Templates\Entities\Poco.NHibernate.Fluent.Designer.cshtml"
           }

            
            #line default
            #line hidden
WriteLiteral("\t}\r\n}");


        }
    }
}
#pragma warning restore 1591
