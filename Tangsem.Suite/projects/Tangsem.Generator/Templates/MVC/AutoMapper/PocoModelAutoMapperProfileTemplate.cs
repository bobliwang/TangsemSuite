﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Tangsem.Generator.Templates.MVC.AutoMapper
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class PocoModelAutoMapperProfileTemplate : Tangsem.Common.T4.T4TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\nusing AutoMapper;\r\nusing ");
            
            #line 8 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.EntityNamespace));
            
            #line default
            #line hidden
            this.Write(";\r\nusing ");
            
            #line 9 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.DTONamespace));
            
            #line default
            #line hidden
            this.Write(";\r\n\r\nnamespace ");
            
            #line 11 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.DomainNamespace));
            
            #line default
            #line hidden
            this.Write(".Mappings.AutoMapper\r\n{\r\n  public partial class ");
            
            #line 13 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.TableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("MappingProfile : Profile\r\n  {\r\n    private readonly IRepoProvider repoProvider;\r\n" +
                    "\r\n    public ");
            
            #line 17 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.TableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("MappingProfile (IRepoProvider repoProvider)\r\n    {\r\n      this.repoProvider = rep" +
                    "oProvider;\r\n\r\n      // Entity to DTO\r\n      var mappingToDto = this.CreateMap<");
            
            #line 22 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.TableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 22 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.TableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write(@"DTO>();
      this.SetupMappingToDto(mappingToDto);
          
      // DTO to Entity
      // Using mappingToDto.ReverseMap(); will cause issues: https://github.com/AutoMapper/AutoMapper/issues/1764
      // MapFrom/ResolveUsing no longer support null assignment
      //  - It has something to do with ReverseMap() and resolving the same property in the first mapping.
      //  - If I split the logic into two different CreateMap declarations, it works correctly.
      var mappingEntity = this.CreateMap<");
            
            #line 30 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.TableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("DTO, ");
            
            #line 30 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.TableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write(">();\r\n      this.SetupMappingToEntity(mappingEntity);\r\n    }\r\n\r\n    public virtua" +
                    "l void SetupMappingToEntity(IMappingExpression<");
            
            #line 34 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.TableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("DTO, ");
            
            #line 34 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.TableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("> mappingEntity)\r\n    {\r\n      mappingEntity.ForMember(x => x.");
            
            #line 36 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.TableMetadata.PrimaryKeyPropertyName));
            
            #line default
            #line hidden
            this.Write(", opts => opts.Condition(s => s.");
            
            #line 36 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.TableMetadata.PrimaryKeyPropertyName));
            
            #line default
            #line hidden
            this.Write(" != default(");
            
            #line 36 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.TableMetadata.PrimaryKeyClrType));
            
            #line default
            #line hidden
            this.Write(")));\r\n\r\n");
            
            #line 38 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
 if( this.TableMetadata.IsAuditableEntity) { 
            
            #line default
            #line hidden
            this.Write(@"      // ignore auditing columns
      mappingEntity.ForMember(x => x.CreatedById, opts => opts.Ignore());
      mappingEntity.ForMember(x => x.ModifiedById, opts => opts.Ignore());
      mappingEntity.ForMember(x => x.CreatedTime, opts => opts.Ignore());
      mappingEntity.ForMember(x => x.ModifiedTime, opts => opts.Ignore());
");
            
            #line 44 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 46 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
 foreach(var outgingRef in this.TableMetadata.OutgoingReferences) { 
            
            #line default
            #line hidden
            this.Write("      mappingEntity.ForMember(x => x.");
            
            #line 47 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgingRef.ParentPropertyName));
            
            #line default
            #line hidden
            this.Write(", map => map.MapFrom((s, t) =>\r\n      {\r\n");
            
            #line 49 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
 if (outgingRef.ColumnPairs[0].ChildColumnMetadata.Nullable) { 
            
            #line default
            #line hidden
            this.Write("\r\n        if (s.");
            
            #line 51 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgingRef.ColumnPairs[0].ChildColumnMetadata.PropertyName));
            
            #line default
            #line hidden
            this.Write(" == null)\r\n        {\r\n            return null;\r\n        }\r\n\r\n");
            
            #line 56 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n        if (t.");
            
            #line 58 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgingRef.ParentPropertyName));
            
            #line default
            #line hidden
            this.Write(" != null && s.");
            
            #line 58 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgingRef.ColumnPairs[0].ChildColumnMetadata.PropertyName));
            
            #line default
            #line hidden
            this.Write(" == t.");
            
            #line 58 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgingRef.ParentPropertyName));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 58 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgingRef.ColumnPairs[0].ParentColumnMetadata.PropertyName));
            
            #line default
            #line hidden
            this.Write(")\r\n        {\r\n            // same id value, use source.\r\n            return t.");
            
            #line 61 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgingRef.ParentPropertyName));
            
            #line default
            #line hidden
            this.Write(";\r\n        }\r\n\r\n        var repo = this.repoProvider.Get();\r\n");
            
            #line 65 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
 if (outgingRef.ColumnPairs[0].ChildColumnMetadata.Nullable) { 
            
            #line default
            #line hidden
            this.Write("        return repo.Lookup");
            
            #line 66 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgingRef.ParentTableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("By");
            
            #line 66 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgingRef.ParentTableMetadata.PrimaryKeyPropertyName));
            
            #line default
            #line hidden
            this.Write("(s.");
            
            #line 66 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgingRef.ColumnPairs[0].ChildColumnMetadata.PropertyName));
            
            #line default
            #line hidden
            this.Write(".Value);\r\n");
            
            #line 67 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("        return repo.Lookup");
            
            #line 68 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgingRef.ParentTableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("By");
            
            #line 68 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgingRef.ParentTableMetadata.PrimaryKeyPropertyName));
            
            #line default
            #line hidden
            this.Write("(s.");
            
            #line 68 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgingRef.ColumnPairs[0].ChildColumnMetadata.PropertyName));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 69 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("      }));\r\n");
            
            #line 71 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write(" \r\n    }\r\n\r\n    public virtual void SetupMappingToDto(IMappingExpression<");
            
            #line 74 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.TableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 74 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.TableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("DTO> mappingToDto)\r\n    {\r\n");
            
            #line 76 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
 foreach(var outgingRef in this.TableMetadata.OutgoingReferences) { 
            
            #line default
            #line hidden
            this.Write("      mappingToDto.ForMember(x => x.");
            
            #line 77 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgingRef.ColumnPairs[0].ChildColumnMetadata.PropertyName));
            
            #line default
            #line hidden
            this.Write(", map => map.MapFrom((s, t) => ");
            
            #line 77 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
 if (outgingRef.ColumnPairs[0].ChildColumnMetadata.Nullable) { 
            
            #line default
            #line hidden
            this.Write("s.");
            
            #line 77 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgingRef.ParentPropertyName));
            
            #line default
            #line hidden
            this.Write("?.");
            
            #line 77 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgingRef.ParentTableMetadata.PrimaryKeyPropertyName));
            
            #line default
            #line hidden
            
            #line 77 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("s.");
            
            #line 77 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgingRef.ParentPropertyName));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 77 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgingRef.ParentTableMetadata.PrimaryKeyPropertyName));
            
            #line default
            #line hidden
            
            #line 77 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("));\r\n");
            
            #line 78 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("      this.SetupMappingToDtoExtra(mappingToDto);\r\n    }\r\n\r\n    partial void Setup" +
                    "MappingToDtoExtra(IMappingExpression<");
            
            #line 82 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.TableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 82 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\AutoMapper\PocoModelAutoMapperProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.TableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("DTO> mappingToDto);\r\n  }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
