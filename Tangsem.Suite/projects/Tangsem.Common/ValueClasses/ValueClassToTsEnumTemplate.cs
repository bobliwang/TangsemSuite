﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Tangsem.Common.ValueClasses
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Common\ValueClasses\ValueClassToTsEnumTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class ValueClassToTsEnumTemplate : Tangsem.Common.T4.T4TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n/**\r\n * ValueClass ");
            
            #line 8 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Common\ValueClasses\ValueClassToTsEnumTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.Type.FullName));
            
            #line default
            #line hidden
            this.Write(" to enum\r\n */\r\nexport enum ");
            
            #line 10 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Common\ValueClasses\ValueClassToTsEnumTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.TsEnumName));
            
            #line default
            #line hidden
            this.Write(" {\r\n\r\n  ");
            
            #line 12 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Common\ValueClasses\ValueClassToTsEnumTemplate.tt"
 foreach(var item in this.Values) { 
            
            #line default
            #line hidden
            this.Write("  ");
            
            #line 13 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Common\ValueClasses\ValueClassToTsEnumTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.ToTsEnumValueDef()));
            
            #line default
            #line hidden
            this.Write("\r\n  ");
            
            #line 14 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Common\ValueClasses\ValueClassToTsEnumTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
