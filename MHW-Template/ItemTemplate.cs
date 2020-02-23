﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace MHW_Template
{
    using Microsoft.CSharp;
    using System.Text.RegularExpressions;
    using MHW_Template.Models;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class ItemTemplate : ItemTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System.ComponentModel;\r\nusing MHW_Editor.Assets;\r\nusing MHW_Editor.Models;\r" +
                    "\nusing MHW_Template;\r\nusing MHW_Template.Models;\r\n\r\nnamespace ");
            
            #line 17 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_namespace));
            
            #line default
            #line hidden
            this.Write(" {\r\n    public partial class ");
            
            #line 18 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(className));
            
            #line default
            #line hidden
            this.Write(" {\r\n        public const uint StructSize = ");
            
            #line 19 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(structData.size));
            
            #line default
            #line hidden
            this.Write(";\r\n        public const ulong InitialOffset = ");
            
            #line 20 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(structData.offsetInitial));
            
            #line default
            #line hidden
            this.Write(";\r\n        public const long EntryCountOffset = ");
            
            #line 21 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(structData.entryCountOffset));
            
            #line default
            #line hidden
            this.Write(";\r\n        public const string EncryptionKey = ");
            
            #line 22 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(structData.encryptionKey == null ? "null" : $"\"{structData.encryptionKey}\""));
            
            #line default
            #line hidden
            this.Write(";\r\n        public override string UniqueId => $\"");
            
            #line 23 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(structData.uniqueIdFormula));
            
            #line default
            #line hidden
            this.Write("\";\r\n");
            
            #line 24 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"

    var compiler = new CSharpCodeProvider();
    var sortIndex = 50;

    foreach (var entry in structData.entries) {
        var accessLevel = entry.accessLevel;
        var name = Regex.Replace(entry.displayName, @"[^\w\d]+", "_");
        var typeString = compiler.GetTypeOutput(entry.type);
        string returnString;
        var setCast = "";
        var getCast = "";

        // Don't need now, but uncomment in the future if we need to override a generated property.
        if (accessLevel != "private") {
            accessLevel += " virtual";
        }

        if (entry.enumReturn == null) {
            returnString = typeString;
        } else {
            returnString = compiler.GetTypeOutput(entry.enumReturn);
            getCast = $"({returnString}) ";
            setCast = $"({typeString}) ";
        }

            
            #line default
            #line hidden
            this.Write("\r\n        public const string ");
            
            #line 50 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(name));
            
            #line default
            #line hidden
            this.Write("_displayName = \"");
            
            #line 50 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entry.displayName));
            
            #line default
            #line hidden
            this.Write("\";\r\n        public const int ");
            
            #line 51 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(name));
            
            #line default
            #line hidden
            this.Write("_sortIndex = ");
            
            #line 51 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sortIndex));
            
            #line default
            #line hidden
            this.Write(";\r\n        [SortOrder(");
            
            #line 52 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(name));
            
            #line default
            #line hidden
            this.Write("_sortIndex)]\r\n        [DisplayName(");
            
            #line 53 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(name));
            
            #line default
            #line hidden
            this.Write("_displayName)]\r\n");
            
            #line 54 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"

        if (entry.dataSourceType != null) {

            
            #line default
            #line hidden
            this.Write("        [DataSource(DataSourceType.");
            
            #line 57 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entry.dataSourceType));
            
            #line default
            #line hidden
            this.Write(")]\r\n");
            
            #line 58 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"

        } // End dataSource check.

            
            #line default
            #line hidden
            this.Write("        ");
            
            #line 61 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(accessLevel));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 61 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(returnString));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 61 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(name));
            
            #line default
            #line hidden
            this.Write(" {");
            
            #line 61 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
 // Property definition. 
            
            #line default
            #line hidden
            this.Write("\r\n            get => ");
            
            #line 63 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(getCast));
            
            #line default
            #line hidden
            this.Write("GetData<");
            
            #line 63 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(typeString));
            
            #line default
            #line hidden
            this.Write(">(");
            
            #line 63 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entry.offset));
            
            #line default
            #line hidden
            this.Write(");");
            
            #line 63 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
 // Getter. 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 65 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"

        if (!entry.readOnly) {

            
            #line default
            #line hidden
            this.Write("            set {");
            
            #line 68 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
 // Setter. 
            
            #line default
            #line hidden
            this.Write("\r\n                if (");
            
            #line 70 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(getCast));
            
            #line default
            #line hidden
            this.Write("GetData<");
            
            #line 70 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(typeString));
            
            #line default
            #line hidden
            this.Write(">(");
            
            #line 70 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entry.offset));
            
            #line default
            #line hidden
            this.Write(") == ");
            
            #line 70 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entry.valueString));
            
            #line default
            #line hidden
            this.Write(") return;");
            
            #line 70 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
 // Do nothing if the value is the same. 
            
            #line default
            #line hidden
            this.Write("\r\n                SetData(");
            
            #line 72 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entry.offset));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 72 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(setCast));
            
            #line default
            #line hidden
            
            #line 72 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entry.valueString));
            
            #line default
            #line hidden
            this.Write(", nameof(");
            
            #line 72 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(name));
            
            #line default
            #line hidden
            this.Write("));\r\n                OnPropertyChanged(nameof(Raw_Data));\r\n                OnProp" +
                    "ertyChanged(nameof(");
            
            #line 74 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(name));
            
            #line default
            #line hidden
            this.Write("));\r\n");
            
            #line 75 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"

            if (entry.dataSourceType != null) {

            
            #line default
            #line hidden
            this.Write("                OnPropertyChanged(nameof(");
            
            #line 78 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(name));
            
            #line default
            #line hidden
            this.Write("_button));\r\n");
            
            #line 79 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"

            } // End extra OnPropertyChanged/dataSourceType check.

            if (entry.extraOnPropertyChanged != null) {
                foreach (var propertyToChange in entry.extraOnPropertyChanged) {
                    var propertyToChangeName = Regex.Replace(propertyToChange, @"[^\w\d]+", "_");

            
            #line default
            #line hidden
            this.Write("                OnPropertyChanged(nameof(");
            
            #line 86 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(propertyToChangeName));
            
            #line default
            #line hidden
            this.Write("));\r\n");
            
            #line 87 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"

                }
            } // End extra OnPropertyChanged/extraOnPropertyChanged check.

            
            #line default
            #line hidden
            this.Write("            }\r\n");
            
            #line 92 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"

        } // End readOnly check.

            
            #line default
            #line hidden
            this.Write("        }");
            
            #line 95 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
 // End property block. 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 97 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"

        if (entry.dataSourceType != null) {
            string dataSourceLookup;

            switch (entry.dataSourceType) {
                case DataSourceType.Items:
                    dataSourceLookup = "DataHelper.itemData[MainWindow.locale]";
                    break;
                case DataSourceType.Skills:
                    dataSourceLookup = "DataHelper.skillData[MainWindow.locale]";
                    break;
                case DataSourceType.SkillDat:
                    dataSourceLookup = "MainWindow.skillDatLookup";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            
            #line default
            #line hidden
            this.Write("\r\n        [SortOrder(");
            
            #line 116 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(name));
            
            #line default
            #line hidden
            this.Write("_sortIndex)]\r\n        [DisplayName(");
            
            #line 117 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(name));
            
            #line default
            #line hidden
            this.Write("_displayName)]\r\n        [CustomSorter(typeof(");
            
            #line 118 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entry.dataSourceCustomSorter));
            
            #line default
            #line hidden
            this.Write("))]\r\n        public string ");
            
            #line 119 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(name));
            
            #line default
            #line hidden
            this.Write("_button => ");
            
            #line 119 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(dataSourceLookup));
            
            #line default
            #line hidden
            this.Write(".TryGet((ushort) ");
            
            #line 119 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(name));
            
            #line default
            #line hidden
            this.Write(", IdNamePair.Unknown((ushort) ");
            
            #line 119 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(name));
            
            #line default
            #line hidden
            this.Write(")).ToString();\r\n");
            
            #line 120 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"

        } // End data source / button generation check.

        sortIndex += 50;
    } // End loop.

            
            #line default
            #line hidden
            this.Write("\r\n        public const int lastSortIndex = ");
            
            #line 127 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sortIndex));
            
            #line default
            #line hidden
            this.Write(";\r\n    }");
            
            #line 128 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
 // End class. 
            
            #line default
            #line hidden
            this.Write("\r\n}");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"

private string @__namespaceField;

/// <summary>
/// Access the _namespace parameter of the template.
/// </summary>
private string _namespace
{
    get
    {
        return this.@__namespaceField;
    }
}

private string _classNameField;

/// <summary>
/// Access the className parameter of the template.
/// </summary>
private string className
{
    get
    {
        return this._classNameField;
    }
}

private global::MHW_Template.MhwStructData _structDataField;

/// <summary>
/// Access the structData parameter of the template.
/// </summary>
private global::MHW_Template.MhwStructData structData
{
    get
    {
        return this._structDataField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool _namespaceValueAcquired = false;
if (this.Session.ContainsKey("_namespace"))
{
    this.@__namespaceField = ((string)(this.Session["_namespace"]));
    _namespaceValueAcquired = true;
}
if ((_namespaceValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("_namespace");
    if ((data != null))
    {
        this.@__namespaceField = ((string)(data));
    }
}
bool classNameValueAcquired = false;
if (this.Session.ContainsKey("className"))
{
    this._classNameField = ((string)(this.Session["className"]));
    classNameValueAcquired = true;
}
if ((classNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("className");
    if ((data != null))
    {
        this._classNameField = ((string)(data));
    }
}
bool structDataValueAcquired = false;
if (this.Session.ContainsKey("structData"))
{
    this._structDataField = ((global::MHW_Template.MhwStructData)(this.Session["structData"]));
    structDataValueAcquired = true;
}
if ((structDataValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("structData");
    if ((data != null))
    {
        this._structDataField = ((global::MHW_Template.MhwStructData)(data));
    }
}


    }
}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public class ItemTemplateBase
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
