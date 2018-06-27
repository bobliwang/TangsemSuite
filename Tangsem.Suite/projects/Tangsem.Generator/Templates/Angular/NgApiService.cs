﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
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
    using Tangsem.Generator.Templates;
    using Tangsem.Generator.Settings;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class NgApiService : NgApiServiceBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n");
            this.Write("\r\nimport { Injectable } from \'@angular/core\';\r\nimport { HttpClient, HttpParams } " +
                    "from \'@angular/common/http\';\r\nimport { Observable } from \'rxjs/Observable\';\r\nimp" +
                    "ort * as models from \'../models/models\';\r\n\r\n@Injectable()\r\nexport class ");
            
            #line 17 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.RepositoryName));
            
            #line default
            #line hidden
            this.Write(@"ApiService {

	private _apiBaseUrl = '';

    constructor(protected httpClient: HttpClient) {
    }

	public setApiBaseUrl(val: string) {
		this._apiBaseUrl = val;
	}

	public url(path: string) {
		return `${this._apiBaseUrl}/${path}`;
	}	


");
            
            #line 33 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
 foreach (var tableMetadata in this.TableMetadatas) { 
            
            #line default
            #line hidden
            this.Write("\r\n     \r\n     public get");
            
            #line 36 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("List(filterModel: models.");
            
            #line 36 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("SearchParams): Observable<models.SearchResultModel<models.");
            
            #line 36 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.TsModelName));
            
            #line default
            #line hidden
            this.Write(">> {\r\n\t\tconst searchParams = this.populate");
            
            #line 37 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("SearchParams(filterModel);\r\n\r\n        return this.httpClient.get<models.SearchRes" +
                    "ultModel<models.");
            
            #line 39 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.TsModelName));
            
            #line default
            #line hidden
            this.Write(">>(this.url(`_api/repo/");
            
            #line 39 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("`), { params: searchParams });\r\n     }\r\n     \r\n     public get");
            
            #line 42 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("ById(id: number | string): Observable<models.");
            
            #line 42 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.TsModelName));
            
            #line default
            #line hidden
            this.Write("> {\r\n        return this.httpClient.get<models.");
            
            #line 43 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.TsModelName));
            
            #line default
            #line hidden
            this.Write(">(this.url(`_api/repo/");
            
            #line 43 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("/${id}`));\r\n     }\r\n     \r\n     public update");
            
            #line 46 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("(id: number | string, model: models.");
            
            #line 46 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.TsModelName));
            
            #line default
            #line hidden
            this.Write("): Observable<any> {\r\n        return this.httpClient.post<any>(this.url(`_api/rep" +
                    "o/");
            
            #line 47 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("/${id}`), model);\r\n     }\r\n     \r\n     public create");
            
            #line 50 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("(model: models.");
            
            #line 50 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.TsModelName));
            
            #line default
            #line hidden
            this.Write("): Observable<models.");
            
            #line 50 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.TsModelName));
            
            #line default
            #line hidden
            this.Write("> {\r\n        return this.httpClient.post<any>(this.url(`_api/repo/");
            
            #line 51 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("`), model);\r\n     }\r\n\r\n\t public delete");
            
            #line 54 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("(id: number | string): Observable<any> {\r\n        return this.httpClient.post<any" +
                    ">(this.url(`_api/repo/");
            
            #line 55 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("/${id}/delete`), {});\r\n     }\r\n\r\n\t protected populate");
            
            #line 58 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("SearchParams(filterModel: models.");
            
            #line 58 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write(@"SearchParams): HttpParams {
		

		let params = new HttpParams();

		if (filterModel) {
			params = params.set('sortFieldName', filterModel.sortFieldName)
						   .set('direction', filterModel.direction)
						   .set('pageIndex', filterModel.pageIndex.toString())
						   .set('pageSize', filterModel.pageSize.toString());

			");
            
            #line 69 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
 foreach (var col in tableMetadata.Columns) { 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\tif (filterModel.");
            
            #line 71 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write(")\r\n\t\t\t{\r\n\t\t\t\tparams = params.set(\'");
            
            #line 73 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write("\', filterModel.");
            
            #line 73 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName.Lf()));
            
            #line default
            #line hidden
            this.Write(".toString());\r\n\r\n\t\t\t}\r\n\t\t\t");
            
            #line 76 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t}\r\n\r\n\t\treturn params;\r\n\t }\r\n\r\n\r\n ");
            
            #line 84 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\Angular\NgApiService.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class NgApiServiceBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
