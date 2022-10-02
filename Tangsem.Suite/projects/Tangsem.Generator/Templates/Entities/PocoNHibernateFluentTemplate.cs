﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Tangsem.Generator.Templates.Entities
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class PocoNHibernateFluentTemplate : Tangsem.Common.T4.T4TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\nusing System;\r\nusing System.Collections;\r\nusing System.Collections.Generic;\r\nus" +
                    "ing System.Text;\r\nusing System.Linq;\r\n\r\nusing FluentNHibernate.Mapping;\r\nusing F" +
                    "luentNHibernate.MappingModel;\r\n\r\nusing Tangsem.NHibernate.UserTypes;\r\n\r\n");
            
            #line 18 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.IncludeTangsemIdentity ? "using Tangsem.Identity.Domain.Entities;" : ""));
            
            #line default
            #line hidden
            this.Write("\r\nnamespace ");
            
            #line 19 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.MappingNamespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n  /// <summary>\r\n  /// The mapping configuration for ");
            
            #line 22 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write(".\r\n  /// </summary>\r\n  public partial class ");
            
            #line 24 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("Map : ClassMap<");
            
            #line 24 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write(">\r\n  {\r\n    /// <summary>\r\n    /// The default constructor.\r\n    /// </summary>\r\n" +
                    "    public ");
            
            #line 29 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("Map()\r\n      : this(new AttributeStore(), new MappingProviderStore())\r\n    {\r\n   " +
                    " }\r\n\r\n    /// <summary>\r\n    /// The constructor.\r\n    /// </summary>\r\n    publi" +
                    "c ");
            
            #line 37 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("Map(AttributeStore attributes, MappingProviderStore providers)\r\n      : base(attr" +
                    "ibutes, providers)\r\n    {\r\n      this.Providers = providers;\r\n\r\n");
            
            #line 42 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 if (TableMetadata.Schema != "dbo") { 
            
            #line default
            #line hidden
            this.Write("      this.Schema(\"");
            
            #line 43 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TableMetadata.Schema));
            
            #line default
            #line hidden
            this.Write("\");\r\n");
            
            #line 44 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n      this.Table(\"");
            
            #line 46 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TableNameInMapping(TableMetadata.Name)));
            
            #line default
            #line hidden
            this.Write("\");\r\n      \r\n");
            
            #line 48 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 if (TableMetadata.IsView) { 
            
            #line default
            #line hidden
            this.Write("      this.ReadOnly();\r\n");
            
            #line 50 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n      // primary key mapping\r\n      this.MapId();\r\n      \r\n      // basic colum" +
                    "ns mapping\r\n      this.MapBasicColumns();\r\n      \r\n");
            
            #line 58 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 if (Configuration.GenRelationship) { 
            
            #line default
            #line hidden
            this.Write("      // outgoing references mapping\r\n      this.MapOutgoingReferences();\r\n      " +
                    "\r\n      // incoming references mapping\r\n      this.MapIncomingReferences();\r\n");
            
            #line 64 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 66 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 if (Configuration.UpdateSqlForModifiedColumnsOnly) { 
            
            #line default
            #line hidden
            this.Write("      this.DynamicUpdate();\r\n");
            
            #line 68 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"
      this.CustomMappingConfig();
    }

    public MappingProviderStore Providers { get; private set; }

    partial void CustomMappingConfig();
    
    /// <summary>
    /// Map the Primary Key.
    /// </summary>
    protected virtual void MapId()
    {
      ");
            
            #line 82 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 if (TableMetadata.PrimaryKeys.Any(x => x.IsAutoIncrement)) { 
            
            #line default
            #line hidden
            this.Write("      \r\n      this.Id(x => x.");
            
            #line 84 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TableMetadata.PrimaryKeys[0].PropertyName));
            
            #line default
            #line hidden
            this.Write(")\r\n        .Column(\"");
            
            #line 85 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TableMetadata.PrimaryKeys[0].ColumnName));
            
            #line default
            #line hidden
            this.Write("\")\r\n        .GeneratedBy\r\n        .Native();\r\n      ");
            
            #line 88 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 } else if (TableMetadata.PrimaryKeys.Count == 1) {
            
            #line default
            #line hidden
            this.Write("      \r\n      this.Id(x => x.");
            
            #line 90 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TableMetadata.PrimaryKeys[0].PropertyName));
            
            #line default
            #line hidden
            this.Write(")\r\n          .Column(\"");
            
            #line 91 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TableMetadata.PrimaryKeys[0].ColumnName));
            
            #line default
            #line hidden
            this.Write("\")\r\n          .GeneratedBy.Assigned();\t\r\n      ");
            
            #line 93 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 } else if (TableMetadata.IsView) { 
            
            #line default
            #line hidden
            this.Write("\r\n      // VIEW\r\n      this.Id(x => x.");
            
            #line 96 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TableMetadata.Columns[0].PropertyName));
            
            #line default
            #line hidden
            this.Write(")\r\n          .Column(\"");
            
            #line 97 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TableMetadata.Columns[0].ColumnName));
            
            #line default
            #line hidden
            this.Write("\");\t\r\n      ");
            
            #line 98 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("\r\n      this.CompositeId()\r\n        ");
            
            #line 101 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 foreach (var col in this.TableMetadata.PrimaryKeys) { 
            
            #line default
            #line hidden
            this.Write("          .KeyProperty(x => x.");
            
            #line 102 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write(", \"");
            
            #line 102 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.ColumnName));
            
            #line default
            #line hidden
            this.Write("\")\r\n        ");
            
            #line 103 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 }
            
            #line default
            #line hidden
            this.Write(";\r\n      ");
            
            #line 104 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("      \r\n    }\r\n    \r\n    /// <summary>\r\n    /// Map the Basic Columns.\r\n    /// <" +
                    "/summary>\r\n    protected virtual void MapBasicColumns()\r\n    {\r\n      ");
            
            #line 113 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"

      var colIndex = 0;
      foreach (var col in TableMetadata.Columns.Where(c => (!c.IsOutgoingRefKey || !Configuration.GenRelationship ) && !c.IsPrimaryKey)) { 
            
            #line default
            #line hidden
            this.Write("         \r\n       // ");
            
            #line 117 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.ColumnName));
            
            #line default
            #line hidden
            this.Write("\r\n       ");
            
            #line 118 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"

          if (TableMetadata.IsView && colIndex == 0) {
            colIndex ++;
            continue;
          }
          
          if (col.IsRowVersion) { 
            
            #line default
            #line hidden
            this.Write("\r\n      this.Version(x => x.");
            
            #line 126 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write(").Generated.Always();\r\n       ");
            
            #line 127 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 } else if(col.ExtraColumnMeta == null || string.IsNullOrWhiteSpace(col.ExtraColumnMeta.JsonType)) { 
            
            #line default
            #line hidden
            this.Write("\r\n      this.Map(x => x.");
            
            #line 129 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write(").Column(\"");
            
            #line 129 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.ColumnName));
            
            #line default
            #line hidden
            this.Write("\")\r\n         ");
            
            #line 130 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 if (col.IsAutoIncrement) { 
            
            #line default
            #line hidden
            this.Write("         .Generated.Always()\r\n         ");
            
            #line 132 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 }
         if (col.ClrType == typeof(string) || col.ClrType == typeof(byte[])) { 
            
            #line default
            #line hidden
            this.Write("         .Length(");
            
            #line 134 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.ColumnSize > 0 ? col.ColumnSize.ToString() : "int.MaxValue"));
            
            #line default
            #line hidden
            this.Write(")\r\n         ");
            
            #line 135 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 }
         if (!col.Nullable) { 
            
            #line default
            #line hidden
            this.Write("         .Not.Nullable()\r\n         ");
            
            #line 138 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 }
         if (col.ReadOnly) { 
            
            #line default
            #line hidden
            this.Write(".ReadOnly()\r\n         ");
            
            #line 140 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write(";\r\n       ");
            
            #line 141 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 } else {
            
            #line default
            #line hidden
            this.Write("      this.Map(x => x.");
            
            #line 142 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write(").Column(\"");
            
            #line 142 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.ColumnName));
            
            #line default
            #line hidden
            this.Write("\").CustomType<JsonType<");
            
            #line 142 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.ExtraColumnMeta.JsonType));
            
            #line default
            #line hidden
            this.Write(">>()\r\n         ");
            
            #line 143 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
if (!col.Nullable) { 
            
            #line default
            #line hidden
            this.Write(".Not.Nullable() ");
            
            #line 143 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("         ");
            
            #line 144 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
if (col.ReadOnly){ 
            
            #line default
            #line hidden
            this.Write(".ReadOnly() ");
            
            #line 144 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write(";\r\n        ");
            
            #line 145 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
}
      }
            
            #line default
            #line hidden
            this.Write("\r\n    }\r\n\r\n    ");
            
            #line 150 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 if (Configuration.GenRelationship) { 
            
            #line default
            #line hidden
            this.Write("    \r\n    /// <summary>\r\n    /// Map the Outgoing References.\r\n    /// </summary>" +
                    "\r\n    protected virtual void MapOutgoingReferences()\r\n    {\r\n      ");
            
            #line 157 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 foreach (var reference in this.TableMetadata.OutgoingReferences) { 
            
            #line default
            #line hidden
            this.Write("      \r\n      this.References<");
            
            #line 159 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(reference.ParentTableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write(">(x => x.");
            
            #line 159 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(reference.ParentPropertyName));
            
            #line default
            #line hidden
            this.Write(")\r\n                .Fetch.Join().Column(\"");
            
            #line 160 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(reference.ColumnPairs[0].ChildColumnMetadata.ColumnName));
            
            #line default
            #line hidden
            this.Write("\")\r\n      ");
            
            #line 161 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 if (reference.ColumnPairs[0].ChildColumnMetadata.Nullable){ 
            
            #line default
            #line hidden
            this.Write(";");
            
            #line 161 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 }else{
            
            #line default
            #line hidden
            this.Write(".Not.Nullable();");
            
            #line 161 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 }
            
            #line default
            #line hidden
            this.Write("      ");
            
            #line 162 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n    }\r\n    \r\n    /// <summary>\r\n    /// Map the Incoming References.\r\n    /// <" +
                    "/summary>\r\n    protected virtual void MapIncomingReferences()\r\n    {\r\n      ");
            
            #line 171 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 foreach (var reference in this.TableMetadata.IncomingReferences) { 
            
            #line default
            #line hidden
            this.Write("      \r\n      this.HasMany<");
            
            #line 173 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(reference.ChildTableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write(">(x => x.");
            
            #line 173 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(reference.ChildListPropertyName));
            
            #line default
            #line hidden
            this.Write(")\r\n        .KeyColumn(\"");
            
            #line 174 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(reference.ColumnPairs[0].ChildColumnMetadata.ColumnName));
            
            #line default
            #line hidden
            this.Write("\")\r\n                .Inverse()\r\n                .LazyLoad()\r\n                .AsB" +
                    "ag();\r\n      ");
            
            #line 178 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n    }\r\n    ");
            
            #line 181 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Entities\PocoNHibernateFluentTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n  }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
