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

namespace Tangsem.Generator.Templates.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    #line 4 "..\..\Templates\Repositories\Repository.Designer.cshtml"
    using Tangsem.Common.Extensions;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Templates\Repositories\Repository.Designer.cshtml"
    using Tangsem.Generator.Templates;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.4.1.0")]
    public partial class Repository_Designer : MultipleTableMetadataTemplate
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");


WriteLiteral("        \r\n");



WriteLiteral("\r\nusing System;\r\nusing System.Collections;\r\nusing System.Collections.Generic;\r\nus" +
"ing System.Text;\r\nusing System.Linq;\r\nusing System.Linq.Expressions;\r\n\r\nusing Ta" +
"ngsem.Data.Domain;\r\nusing Tangsem.NHibernate.Domain;\r\n\r\nusing ");


            
            #line 17 "..\..\Templates\Repositories\Repository.Designer.cshtml"
  Write(Configuration.EntityNamespace);

            
            #line default
            #line hidden
WriteLiteral(";\r\n\r\nnamespace ");


            
            #line 19 "..\..\Templates\Repositories\Repository.Designer.cshtml"
      Write(Configuration.RepositoryNamespace);

            
            #line default
            #line hidden
WriteLiteral("\r\n{\r\n  /// <summary>\r\n  /// The ");


            
            #line 22 "..\..\Templates\Repositories\Repository.Designer.cshtml"
      Write(Configuration.RepositoryName);

            
            #line default
            #line hidden
WriteLiteral(" class.\r\n  /// </summary>\r\n  public partial class ");


            
            #line 24 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                   Write(Configuration.RepositoryName);

            
            #line default
            #line hidden
WriteLiteral(" : RepositoryBase, I");


            
            #line 24 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                                      Write(Configuration.RepositoryName);

            
            #line default
            #line hidden
WriteLiteral("\r\n  {\r\n");


            
            #line 26 "..\..\Templates\Repositories\Repository.Designer.cshtml"
     foreach (var tableMetadata in this.TableMetadatas)
    {
            
            #line default
            #line hidden
WriteLiteral("\r\n    \r\n    /// <summary>\r\n    /// The IQueryable for ");


            
            #line 30 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                       Write(tableMetadata.EntityName.Pluralize());

            
            #line default
            #line hidden
WriteLiteral(".\r\n    /// </summary>\r\n    public virtual IQueryable<");


            
            #line 32 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                          Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral("> ");


            
            #line 32 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                       Write(tableMetadata.EntityName.Pluralize());

            
            #line default
            #line hidden
WriteLiteral("\r\n    {\r\n      get\r\n      {\r\n        return this.GetEntities<");


            
            #line 36 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                            Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(">();\r\n      }\r\n    }\r\n\r\n    ");


            
            #line 40 "..\..\Templates\Repositories\Repository.Designer.cshtml"
           }

            
            #line default
            #line hidden
WriteLiteral("    \r\n    \r\n");


            
            #line 43 "..\..\Templates\Repositories\Repository.Designer.cshtml"
     foreach (var tableMetadata in this.TableMetadatas.Where(x => !x.IsView))
    {
            
            #line default
            #line hidden
WriteLiteral("\r\n    \r\n    /// <summary>\r\n    /// Get ");


            
            #line 47 "..\..\Templates\Repositories\Repository.Designer.cshtml"
        Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" by primary key.\r\n    /// </summary>\r\n    public virtual ");


            
            #line 49 "..\..\Templates\Repositories\Repository.Designer.cshtml"
               Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" Lookup");


            
            #line 49 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                 Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral("By");


            
            #line 49 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                                              Write(tableMetadata.PrimaryKeys[0].PropertyName);

            
            #line default
            #line hidden
WriteLiteral("(");


            
            #line 49 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                                                                                           Write(tableMetadata.PrimaryKeys[0].CSharpTypeAsString);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 49 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                                                                                                                                              Write(tableMetadata.PrimaryKeys[0].PropertyName.LowerFirst());

            
            #line default
            #line hidden
WriteLiteral(")\r\n    {\r\n      return this.LookupById<");


            
            #line 51 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                         Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(">(");


            
            #line 51 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                      Write(tableMetadata.PrimaryKeys[0].PropertyName.LowerFirst());

            
            #line default
            #line hidden
WriteLiteral(");\r\n    }\r\n    \r\n    /// <summary>\r\n    /// Delete ");


            
            #line 55 "..\..\Templates\Repositories\Repository.Designer.cshtml"
           Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" by primary key.\r\n    /// </summary>\r\n    public virtual ");


            
            #line 57 "..\..\Templates\Repositories\Repository.Designer.cshtml"
               Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" Delete");


            
            #line 57 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                 Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral("By");


            
            #line 57 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                                              Write(tableMetadata.PrimaryKeys[0].PropertyName);

            
            #line default
            #line hidden
WriteLiteral("(");


            
            #line 57 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                                                                                           Write(tableMetadata.PrimaryKeys[0].CSharpTypeAsString);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 57 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                                                                                                                                              Write(tableMetadata.PrimaryKeys[0].PropertyName.LowerFirst());

            
            #line default
            #line hidden
WriteLiteral(")\r\n    {\r\n      return this.DeleteById<");


            
            #line 59 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                         Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(">(");


            
            #line 59 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                      Write(tableMetadata.PrimaryKeys[0].PropertyName.LowerFirst());

            
            #line default
            #line hidden
WriteLiteral(");\r\n    }\r\n    \r\n    /// <summary>\r\n    /// Save a new ");


            
            #line 63 "..\..\Templates\Repositories\Repository.Designer.cshtml"
               Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" instance.\r\n    /// </summary>\r\n    public virtual ");


            
            #line 65 "..\..\Templates\Repositories\Repository.Designer.cshtml"
               Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" Save");


            
            #line 65 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                               Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral("(");


            
            #line 65 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                                           Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 65 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                                                                       Write(tableMetadata.EntityName.LowerFirst());

            
            #line default
            #line hidden
WriteLiteral(")\r\n    {\r\n      return this.Save<");


            
            #line 67 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                   Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(">(");


            
            #line 67 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                Write(tableMetadata.EntityName.LowerFirst());

            
            #line default
            #line hidden
WriteLiteral(");\r\n    }\r\n    \r\n    /// <summary>\r\n    /// Update an existing ");


            
            #line 71 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                       Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" instance.\r\n    /// </summary>\r\n    public virtual ");


            
            #line 73 "..\..\Templates\Repositories\Repository.Designer.cshtml"
               Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" Update");


            
            #line 73 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                 Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral("(");


            
            #line 73 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                                             Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 73 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                                                                         Write(tableMetadata.EntityName.LowerFirst());

            
            #line default
            #line hidden
WriteLiteral(")\r\n    {\r\n      return this.Update<");


            
            #line 75 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                     Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(">(");


            
            #line 75 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                  Write(tableMetadata.EntityName.LowerFirst());

            
            #line default
            #line hidden
WriteLiteral(");\r\n    }\r\n    \r\n    /// <summary>\r\n    /// Save or update an existing ");


            
            #line 79 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                               Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" instance.\r\n    /// </summary>\r\n    public virtual ");


            
            #line 81 "..\..\Templates\Repositories\Repository.Designer.cshtml"
               Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" SaveOrUpdate");


            
            #line 81 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                       Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral("(");


            
            #line 81 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                                                   Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 81 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                                                                               Write(tableMetadata.EntityName.LowerFirst());

            
            #line default
            #line hidden
WriteLiteral(")\r\n    {\r\n      return this.SaveOrUpdate<");


            
            #line 83 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                           Write(tableMetadata.EntityName);

            
            #line default
            #line hidden
WriteLiteral(">(");


            
            #line 83 "..\..\Templates\Repositories\Repository.Designer.cshtml"
                                                        Write(tableMetadata.EntityName.LowerFirst());

            
            #line default
            #line hidden
WriteLiteral(");\r\n    }\r\n\r\n    ");


            
            #line 86 "..\..\Templates\Repositories\Repository.Designer.cshtml"
           }

            
            #line default
            #line hidden
WriteLiteral("\r\n  }\r\n}\r\n");


            
            #line 90 "..\..\Templates\Repositories\Repository.Designer.cshtml"
  
  var plainEntities = this.TableMetadatas.Where(x => !x.IsAuditableEntity && !x.IsView).ToList();


            
            #line default
            #line hidden

            
            #line 93 "..\..\Templates\Repositories\Repository.Designer.cshtml"
 if(plainEntities.Any())
{
            
            #line default
            #line hidden
WriteLiteral("\r\n/*    \r\n  ");


WriteLiteral("@NOTE: The following entities are not IAuditableEntities:\r\n     \r\n");


            
            #line 98 "..\..\Templates\Repositories\Repository.Designer.cshtml"
   foreach(var entity in plainEntities)
  {
            
            #line default
            #line hidden
WriteLiteral("\r\n     \r\n  ------------------------------\r\n  -- ");


            
            #line 102 "..\..\Templates\Repositories\Repository.Designer.cshtml"
Write(entity.EntityName);

            
            #line default
            #line hidden
WriteLiteral("     ----\r\n  ------------------------------\r\n  ALTER TABLE ");


            
            #line 104 "..\..\Templates\Repositories\Repository.Designer.cshtml"
         Write(entity.Name);

            
            #line default
            #line hidden
WriteLiteral(" ADD CreatedById INT NULL\r\n  GO\r\n  ALTER TABLE ");


            
            #line 106 "..\..\Templates\Repositories\Repository.Designer.cshtml"
         Write(entity.Name);

            
            #line default
            #line hidden
WriteLiteral(" ADD ModifiedById INT NULL\r\n  GO\r\n  ALTER TABLE ");


            
            #line 108 "..\..\Templates\Repositories\Repository.Designer.cshtml"
         Write(entity.Name);

            
            #line default
            #line hidden
WriteLiteral(" ADD CreatedTime DATETIME NULL\r\n  GO\r\n  ALTER TABLE ");


            
            #line 110 "..\..\Templates\Repositories\Repository.Designer.cshtml"
         Write(entity.Name);

            
            #line default
            #line hidden
WriteLiteral(" ADD ModifiedTime DATETIME NULL\r\n  GO\r\n  ALTER TABLE ");


            
            #line 112 "..\..\Templates\Repositories\Repository.Designer.cshtml"
         Write(entity.Name);

            
            #line default
            #line hidden
WriteLiteral(" ADD Active BIT NULL\r\n  GO\r\n         \r\n       \r\n  ");


            
            #line 116 "..\..\Templates\Repositories\Repository.Designer.cshtml"
         }

            
            #line default
            #line hidden
WriteLiteral("*/\r\n");


            
            #line 118 "..\..\Templates\Repositories\Repository.Designer.cshtml"
       }

            
            #line default
            #line hidden
WriteLiteral("\r\n");


        }
    }
}
#pragma warning restore 1591
