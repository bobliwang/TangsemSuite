using System;
using System.Collections.Generic;
using System.Text;

namespace Tangsem.Common.T4
{
  [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
  public class T4TemplateBase
  {
    #region Fields
    private global::System.Text.StringBuilder generationEnvironmentField;
    private List<CompilerError> errorsField;
    private global::System.Collections.Generic.List<int> indentLengthsField;
    private string currentIndentField = "";
    private bool endsWithNewline;
    private global::System.Collections.Generic.IDictionary<string, object> sessionField;
    #endregion
    #region Properties

    public virtual string TransformText()
    {
      return string.Empty;
    }

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
    public List<CompilerError> Errors
    {
      get
      {
        if ((this.errorsField == null))
        {
          this.errorsField = new List<CompilerError>();
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
    public string CurrentIndent => this.currentIndentField;

    /// <summary>
    /// Current transformation session
    /// </summary>
    public virtual IDictionary<string, object> Session
    {
      get => this.sessionField;
      set => this.sessionField = value;
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
      var error = new CompilerError { ErrorText = message };
      this.Errors.Add(error);
    }
    /// <summary>
    /// Raise a warning
    /// </summary>
    public void Warning(string message)
    {
      this.Errors.Add(new CompilerError { ErrorText = message, IsWarning = true });
    }
    /// <summary>
    /// Increase the indent
    /// </summary>
    public void PushIndent(string indent)
    {
      if ((indent == null))
      {
        throw new ArgumentNullException(nameof(indent));
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
      private System.IFormatProvider formatProviderField = global::System.Globalization.CultureInfo.InvariantCulture;
      /// <summary>
      /// Gets or sets format provider to be used by ToStringWithCulture method.
      /// </summary>
      public System.IFormatProvider FormatProvider
      {
        get
        {
          return this.formatProviderField;
        }
        set
        {
          if ((value != null))
          {
            this.formatProviderField = value;
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
          ////throw new global::System.ArgumentNullException("objectToConvert");

          return string.Empty;
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

  public class CompilerError
  {//
    // Summary:
    //     Gets or sets the line number where the source of the error occurs.
    //
    // Returns:
    //     The line number of the source file where the compiler encountered the error.
    public int Line { get; set; }
    //
    // Summary:
    //     Gets or sets the column number where the source of the error occurs.
    //
    // Returns:
    //     The column number of the source file where the compiler encountered the error.
    public int Column { get; set; }
    //
    // Summary:
    //     Gets or sets the error number.
    //
    // Returns:
    //     The error number as a string.
    public string ErrorNumber { get; set; }
    //
    // Summary:
    //     Gets or sets the text of the error message.
    //
    // Returns:
    //     The text of the error message.
    public string ErrorText { get; set; }
    //
    // Summary:
    //     Gets or sets a value that indicates whether the error is a warning.
    //
    // Returns:
    //     true if the error is a warning; otherwise, false.
    public bool IsWarning { get; set; }
    //
    // Summary:
    //     Gets or sets the file name of the source file that contains the code which caused
    //     the error.
    //
    // Returns:
    //     The file name of the source file that contains the code which caused the error.
    public string FileName { get; set; }

  }
}
