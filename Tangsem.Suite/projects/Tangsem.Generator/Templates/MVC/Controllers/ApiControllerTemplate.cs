﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Tangsem.Generator.Templates.MVC.Controllers
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using Tangsem.Common.Extensions;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class ApiControllerTemplate : ApiControllerTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(" \r\n\r\n");
            
            #line 9 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"

	var tableMetadata = this.TableMetadata;

            
            #line default
            #line hidden
            this.Write("\r\npublic partial class ");
            
            #line 13 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("ApiController : Controller\r\n{\r\n\tprivate I");
            
            #line 15 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.RepositoryName));
            
            #line default
            #line hidden
            this.Write(" _repository = null;\r\n\r\n\tprivate IMapper _mapper = null;\r\n\r\n\tpublic ");
            
            #line 19 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("ApiController(I");
            
            #line 19 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.RepositoryName));
            
            #line default
            #line hidden
            this.Write(" repository, IMapper mapper)\r\n\t{\r\n\t\t_repository = repository;\r\n\t\t_mapper = mapper" +
                    ";\r\n\t}\r\n\r\n\t[HttpGet(\"_api/repo/");
            
            #line 25 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("\")]\r\n\tpublic IActionResult Get");
            
            #line 26 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("List(");
            
            #line 26 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("SearchModel model) {\r\n\r\n\t\tvar dataList = _repo.");
            
            #line 28 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName.Pluralize()));
            
            #line default
            #line hidden
            this.Write(".ToList();\r\n\r\n\t\treturn this.OK(dataList);\r\n\t}\r\n     \r\n\t[HttpGet(\"_api/repo/");
            
            #line 33 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("/{id}\")]\r\n\tpublic IActionResult Get");
            
            #line 34 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("ById(int id) {\r\n\t\tvar entity = _repo.Lookup");
            
            #line 35 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("ById(id);\r\n\r\n\t\treturn this.OK(entity);\r\n\t}\r\n\r\n\t[HttpPost(\"_api/repo/");
            
            #line 40 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("/{id}\")]\r\n\t[TransactionFilter]\r\n\tpublic IActionResult Update");
            
            #line 42 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("(int id, [FromBody] ");
            
            #line 42 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("DTO model) {\r\n\t\tvar entity = _repo.Lookup");
            
            #line 43 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("ById(id);\r\n\r\n\t\tif (entity == null)\r\n\t\t{\r\n\t\t\treturn this.NotFound($\"");
            
            #line 47 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write(" is not found by id {id}\");\r\n\t\t}\r\n\r\n\t\t_mapper.Map(model, entity);\r\n\t\t_repo.Update" +
                    "");
            
            #line 51 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("(entity);\r\n\r\n\t\treturn this.OK();\r\n\t}\r\n     \r\n\t[HttpPost(\"_api/repo/");
            
            #line 56 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("\")]\r\n\t[TransactionFilter]\r\n\tpublic IActionResult Create");
            
            #line 58 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("([FromBody] ");
            
            #line 58 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("DTO model) {\r\n\t\tvar entity = new ");
            
            #line 59 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("();\r\n\r\n\t\t_mapper.Map(model, entity);\r\n\t\t_repo.Save");
            
            #line 62 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("(entity);\r\n\r\n\t\treturn this.OK();\r\n\t}\r\n\r\n\t[HttpPost(\"_api/repo/");
            
            #line 67 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("/{id}/delete\")]\r\n\t[TransactionFilter]\r\n\tpublic IActionResult Delete");
            
            #line 69 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("(int id, bool isHardDelete) {\r\n\t\tvar entity = _repo.Lookup");
            
            #line 70 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("ById(id);\r\n\r\n\t\tif (entity == null)\r\n\t\t{\r\n\t\t\treturn this.NotFound($\"");
            
            #line 74 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write(" is not found by id {id}\");\r\n\t\t}\r\n\r\n\t\tif (isHardDelete) {\r\n\t\t\t_repo.Delete");
            
            #line 78 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("ById(id);\t\t\t\r\n\t\t}\r\n\t\telse\r\n\t\t{\r\n\t\t\tentity.Active = false;\r\n\t\t\t_repo.Update");
            
            #line 83 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("(entity);\r\n\t\t}\r\n\r\n\t\treturn this.OK();\r\n\t}\r\n\r\n\tprotected IQueryable<");
            
            #line 89 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("> FilterBySearchParams(IQueryable");
            
            #line 89 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write(" qry, ");
            
            #line 89 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(tableMetadata.EntityName));
            
            #line default
            #line hidden
            this.Write("SearchModel filterModel)\r\n\t{\r\n\t\tvar filteredQry = qry; \r\n\t\t\r\n\t\t");
            
            #line 93 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
 foreach (var col in tableMetadata.Columns) { 
            
            #line default
            #line hidden
            this.Write("\r\n\t\tif (filterModel.");
            
            #line 95 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write(" != null)\r\n\t\t{\r\n\t\t");
            
            #line 97 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
 if (col.ClrType == typeof(string)) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\r\n\t\t\tfilteredQry = filteredQry.Where(x => x.");
            
            #line 99 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write(".Contains(filterModel.");
            
            #line 99 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write("));\r\n\t\t");
            
            #line 100 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\r\n\t\t\tfilteredQry = filteredQry.Where(x => x.");
            
            #line 102 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write(" == filterModel.");
            
            #line 102 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(col.PropertyName));
            
            #line default
            #line hidden
            this.Write(");\r\n\t\t");
            
            #line 103 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t}\r\n\t\t");
            
            #line 106 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\MVC\Controllers\ApiControllerTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\t\treturn filteredQry;\r\n\t}\r\n}");
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
    public class ApiControllerTemplateBase
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
