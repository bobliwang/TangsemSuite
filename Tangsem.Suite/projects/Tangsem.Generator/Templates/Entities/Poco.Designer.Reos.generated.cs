﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tangsem.Generator.Templates.Entities
{
    using System;
    using System.Collections.Generic;
    
    #line 4 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    using System.Text;
    
    #line 5 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
    using Common.Extensions;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
    using Tangsem.Generator.Metadata;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
    using Tangsem.Generator.Settings;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
    using Tangsem.Generator.Templates;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public partial class Poco_Designer_Reos : SingleTableMetadataTemplate
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");


WriteLiteral("\r\n");






WriteLiteral("\r\nusing System;\r\nusing System.Collections;\r\nusing System.Collections.Generic;\r\nus" +
"ing System.Text;\r\nusing System.Linq;\r\nusing System.Linq.Expressions;\r\n\r\nusing Ta" +
"ngsem.Common.Entities.Reos;\r\n\r\nnamespace ");


            
            #line 19 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
     Write(Configuration.EntityNamespace);

            
            #line default
            #line hidden
WriteLiteral("\r\n{\r\n  /// <summary>\r\n  /// This entity maps to \'");


            
            #line 22 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                       Write(TableMetadata.Name);

            
            #line default
            #line hidden
WriteLiteral("\'.\r\n  /// </summary>\r\n  public partial class ");


            
            #line 24 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                   Write(TableMetadata.EntityName);

            
            #line default
            #line hidden

            
            #line 24 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                                              Write(TableMetadata.PocoExtensionsForReos);

            
            #line default
            #line hidden
WriteLiteral("\r\n  { \r\n    /// <summary>\r\n    /// The default constructor for ");


            
            #line 27 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                                Write(TableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" class.\r\n    /// </summary>\r\n    public ");


            
            #line 29 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
       Write(TableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral("()\r\n    {\r\n");


            
            #line 31 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
       if (Configuration.GenRelationship)
      {
        foreach (var reference in this.TableMetadata.IncomingReferences)
        {
            
            #line default
            #line hidden
WriteLiteral("\r\n        this.");


            
            #line 35 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
         Write(reference.ChildListPropertyName);

            
            #line default
            #line hidden
WriteLiteral(" = new List<");


            
            #line 35 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                                                       Write(reference.ChildTableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(">();\r\n        ");


            
            #line 36 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
               }
      }

            
            #line default
            #line hidden
WriteLiteral("      \r\n");


            
            #line 39 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
       if (TableMetadata.IsReosAuditableEntity)
      {

            
            #line default
            #line hidden
WriteLiteral("        ");

WriteLiteral("\r\n        var now = DateTime.Now;\r\n        this.CreatedDate = now;\r\n        this." +
"ModifiedDate = now;\r\n        this.Active = true;\r\n        ");

WriteLiteral("\r\n");


            
            #line 47 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
      }

            
            #line default
            #line hidden
WriteLiteral("      \r\n");


            
            #line 49 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
       if (TableMetadata.IsReosReplicatedEntity)
      {

            
            #line default
            #line hidden
WriteLiteral("        ");

WriteLiteral("\r\n        this.Replicated = true;\r\n        this.Rowguid = Guid.NewGuid();\r\n      " +
"  ");

WriteLiteral("\r\n");


            
            #line 55 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
      }

            
            #line default
            #line hidden
WriteLiteral("      \r\n      this.Init();\r\n    }\r\n\r\n    partial void Init();\r\n\r\n    #region \"Bas" +
"ic Columns\"\r\n\r\n");


            
            #line 64 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
     foreach (var col in @TableMetadata.Columns.Where(c => !c.IsOutgoingRefKey || !Configuration.GenRelationship))
    {
            
            #line default
            #line hidden
WriteLiteral("\r\n    /// <summary>\r\n    /// Property ");


            
            #line 67 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
            Write(col.PropertyName);

            
            #line default
            #line hidden
WriteLiteral(" mapping to ");


            
            #line 67 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                                          Write(TableMetadata.Name);

            
            #line default
            #line hidden
WriteLiteral(".");


            
            #line 67 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                                                                Write(col.ColumnName);

            
            #line default
            #line hidden
WriteLiteral("\r\n    /// </summary>\r\n    public virtual ");


            
            #line 69 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
              Write(col.CSharpTypeAsString);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 69 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                                      Write(col.PropertyName);

            
            #line default
            #line hidden
WriteLiteral(" { get; set; }\r\n    ");


            
            #line 70 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
           }

            
            #line default
            #line hidden
WriteLiteral("    \r\n    #endregion\r\n    \r\n    #region \"Outgoing References\"\r\n");


            
            #line 75 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
     if (Configuration.GenRelationship)
    {
    foreach (var reference in @TableMetadata.OutgoingReferences)
    {
            
            #line default
            #line hidden
WriteLiteral("\r\n    /// <summary>\r\n    /// Gets or sets reference to ");


            
            #line 80 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                              Write(reference.ParentPropertyName);

            
            #line default
            #line hidden
WriteLiteral(". ReferenceName: ");


            
            #line 80 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                                                                              Write(reference.Name);

            
            #line default
            #line hidden
WriteLiteral(".\r\n    /// </summary>\r\n    public virtual ");


            
            #line 82 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
               Write(reference.ParentTableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 82 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                                                           Write(reference.ParentPropertyName);

            
            #line default
            #line hidden
WriteLiteral(" { get; set; }\r\n    ");


            
            #line 83 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
           }
    }

            
            #line default
            #line hidden
WriteLiteral("    #endregion\r\n    \r\n    #region \"Incoming References\"\r\n");


            
            #line 88 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
 if (Configuration.GenRelationship) { 
    foreach (var reference in this.TableMetadata.IncomingReferences)
    {
            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 91 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
       var childObjParamName = reference.ChildTableMetadata.EntityName.Substring(0, 1).ToLower() + reference.ChildTableMetadata.EntityName.Substring(1); 

            
            #line default
            #line hidden
WriteLiteral("    /// <summary>\r\n    /// Field for the child list of Ref: ");


            
            #line 93 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                                     Write(reference.Name);

            
            #line default
            #line hidden
WriteLiteral(".\r\n    /// </summary>\r\n    public virtual IList<");


            
            #line 95 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                     Write(reference.ChildTableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral("> ");


            
            #line 95 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                                                                 Write(reference.ChildListPropertyName);

            
            #line default
            #line hidden
WriteLiteral(" { get; set; }\r\n    \r\n    /// <summary>\r\n    /// Add ");


            
            #line 98 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
        Write(reference.ChildTableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" entity to ");


            
            #line 98 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                                                             Write(reference.ChildListPropertyName);

            
            #line default
            #line hidden
WriteLiteral(".\r\n    /// </summary>\r\n    /// <param name=\"");


            
            #line 100 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                 Write(childObjParamName);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n    ///\tThe ");


            
            #line 101 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
        Write(reference.ChildTableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" entity.\r\n    /// </param>\r\n    public virtual void AddTo");


            
            #line 103 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                         Write(reference.ChildListPropertyName);

            
            #line default
            #line hidden
WriteLiteral("(");


            
            #line 103 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                                                            Write(reference.ChildTableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 103 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                                                                                                       Write(childObjParamName);

            
            #line default
            #line hidden
WriteLiteral(")\r\n    {\r\n      ");


            
            #line 105 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
  Write(childObjParamName);

            
            #line default
            #line hidden
WriteLiteral(".");


            
            #line 105 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                       Write(reference.ParentPropertyName);

            
            #line default
            #line hidden
WriteLiteral(" = this;\r\n      this.");


            
            #line 106 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
       Write(reference.ChildListPropertyName);

            
            #line default
            #line hidden
WriteLiteral(".Add(");


            
            #line 106 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
                                              Write(childObjParamName);

            
            #line default
            #line hidden
WriteLiteral(");\r\n    }\r\n    ");


            
            #line 108 "..\..\Templates\Entities\Poco.Designer.Reos.cshtml"
           }
}

            
            #line default
            #line hidden
WriteLiteral("    #endregion\r\n    \r\n\r\n  }\r\n}");


        }
    }
}
#pragma warning restore 1591
