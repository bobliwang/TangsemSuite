﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Tangsem.Generator.Templates.Angular
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using Tangsem.Common.Extensions;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class NgEditorComponentHtml : Tangsem.Common.T4.T4TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n<div class=\"editor-ctn\">\r\n\r\n");
            
            #line 10 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
 foreach(var col in this.TableMetadata.Columns) {
	var inputType = getInputType(col.CSharpTypeAsString);

            
            #line default
            #line hidden
            this.Write("\r\n    <!-- ");
            
            #line 14 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 14 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(inputType));
            
            #line default
            #line hidden
            this.Write(" - ");
            
            #line 14 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.ColumnSize));
            
            #line default
            #line hidden
            this.Write(" -->\r\n    <div class=\"editor-row\">\r\n    ");
            
            #line 16 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
 if (!col.IsOutgoingRefKey) { 
            
            #line default
            #line hidden
            this.Write("        ");
            
            #line 17 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
 if (inputType == "text" || inputType == "number") { 
            
            #line default
            #line hidden
            this.Write("\r\n        <mat-form-field>\r\n            ");
            
            #line 20 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
 if (inputType == "number" || (col.ColumnSize >= 0 && col.ColumnSize < 50) ) { 
            
            #line default
            #line hidden
            this.Write("\r\n\t        <input type=\"");
            
            #line 22 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(inputType));
            
            #line default
            #line hidden
            this.Write("\" matInput #");
            
            #line 22 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write("=\"ngModel\" ");
            
            #line 22 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.IsPrimaryKey ? "readonly" : ""));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t        [(ngModel)]=\"model.");
            
            #line 23 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write("\" placeholder=\"");
            
            #line 23 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write("\"\r\n                ");
            
            #line 24 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.ColumnSize > 0 ? ("maxlength=\"" + col.ColumnSize + "\"") : ""));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 24 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.Nullable || col.IsPrimaryKey ? "" : "required"));
            
            #line default
            #line hidden
            this.Write(" />\r\n\r\n            ");
            
            #line 26 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("            <textarea matInput #");
            
            #line 27 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write("=\"ngModel\" ");
            
            #line 27 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.ColumnSize > 0 ? ("maxlength=\"" + col.ColumnSize + "\"") : ""));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 27 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.IsPrimaryKey ? "readonly" : ""));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t        [(ngModel)]=\"model.");
            
            #line 28 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write("\" placeholder=\"");
            
            #line 28 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write("\" ");
            
            #line 28 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.Nullable|| col.IsPrimaryKey ? "" : "required"));
            
            #line default
            #line hidden
            this.Write("></textarea>\r\n            ");
            
            #line 29 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
 }
            
            #line default
            #line hidden
            this.Write("\r\n        </mat-form-field>\r\n        ");
            
            #line 32 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
 } else if (inputType == "checkbox") { 
            
            #line default
            #line hidden
            this.Write("\t        <mat-checkbox [(ngModel)]=\"model.");
            
            #line 33 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write("\" #");
            
            #line 33 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write("=\"ngModel\">");
            
            #line 33 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write("</mat-checkbox>\r\n        ");
            
            #line 34 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
 } else if (inputType == "datepicker") { 
            
            #line default
            #line hidden
            this.Write("        <mat-form-field>\r\n\t        <input matInput [matDatepicker]=\"picker");
            
            #line 36 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write("\" placeholder=\"Choose ");
            
            #line 36 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write("\" #");
            
            #line 36 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write("=\"ngModel\"\r\n                [(ngModel)]=\"model.");
            
            #line 37 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write("\" ");
            
            #line 37 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.Nullable ? "" : "required"));
            
            #line default
            #line hidden
            this.Write(">\r\n\t          <mat-datepicker-toggle matSuffix [for]=\"picker");
            
            #line 38 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write("\"></mat-datepicker-toggle>\r\n\t          <mat-datepicker #picker");
            
            #line 39 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write("></mat-datepicker>\r\n        </mat-form-field>\r\n        ");
            
            #line 41 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n    ");
            
            #line 43 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
 } else {
        var outgoingRef = col.OutgoingReference;
     
            
            #line default
            #line hidden
            this.Write("\r\n        <mat-form-field>\r\n            <mat-select placeholder=\"Select ");
            
            #line 48 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgoingRef.ParentPropertyName));
            
            #line default
            #line hidden
            this.Write("\" #");
            
            #line 48 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write("=\"ngModel\"\r\n                [(ngModel)]=\"model.");
            
            #line 49 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgoingRef.ColumnPairs[0].ChildColumnMetadata.PropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write("\" ");
            
            #line 49 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgoingRef.ColumnPairs[0].ChildColumnMetadata.Nullable ? "" : "required"));
            
            #line default
            #line hidden
            this.Write(">\r\n                <mat-option value=\"\"></mat-option>\r\n                <mat-optio" +
                    "n *ngFor=\"let opt of ");
            
            #line 51 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgoingRef.ParentPropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write("Options\" [value]=\"opt.");
            
            #line 51 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgoingRef.ColumnPairs[0].ParentColumnMetadata.PropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write("\">\r\n                    {{opt.");
            
            #line 52 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outgoingRef.ParentTableMetadata.Columns[1].PropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write("}}\r\n                </mat-option>\r\n            </mat-select>\r\n        </mat-form-" +
                    "field>\r\n\r\n    ");
            
            #line 57 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n        <!-- Validation HERE -->\r\n        <div *ngIf=\"");
            
            #line 60 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write(".invalid && (");
            
            #line 60 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write(".dirty || ");
            
            #line 60 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write(".touched)\"\r\n            class=\"alert alert-danger\">\r\n\r\n            <div *ngIf=\"");
            
            #line 63 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write(".errors.required\">\r\n                ");
            
            #line 64 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write(" is required.\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n");
            
            #line 69 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\r\n\t<div class=\"actions-bar\" *ngIf=\"!isDialog && !hideActionBar\">\r\n\t\t<button mat" +
                    "-button (click)=\"save()\">\r\n\t\t\tSave\r\n\t\t</button>\r\n\r\n\t\t<button mat-button (click)=" +
                    "\"cancel()\">\r\n\t\t\tCancel\r\n\t\t</button>\r\n\t</div>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 86 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgEditorComponentHtml.tt"

	string getInputType(string clrTypeAsString) {
		switch(clrTypeAsString) {
			case "int":
			case "decimal":
			case "float":
			case "double":
			case "int?":
			case "decimal?":
			case "float?":
			case "double?":
				return "number";
			case "bool":
			case "bool?":
				return "checkbox";
			case "DateTime":
			case "DateTime?":
				return "datepicker";
			default:
				return "text";
		}
	}

        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
}
