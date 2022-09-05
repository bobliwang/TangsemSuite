﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Tangsem.Generator.Templates.StoredProc
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    using Tangsem.Generator.Settings;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class StoredProc : Tangsem.Common.T4.T4TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n\r\n");
            this.Write("\r\n\r\n\r\n");
            this.Write(" \r\n");
            this.Write(" \r\n");
            this.Write(" \r\n");
            this.Write("\r\n\r\n");
            this.Write(" \r\n");
            this.Write("  \r\n");
            this.Write(" \r\n");
            this.Write("\r\n\r\nusing System;\r\nusing System.Data;\r\nusing System.Collections.Generic;\r\nusing S" +
                    "ystem.Linq;\r\nusing ");
            
            #line 36 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.RepositoryNamespace));
            
            #line default
            #line hidden
            this.Write(";\r\nusing Tangsem.NHibernate.StoredProc;\r\nusing NHibernate;\r\n\r\nnamespace ");
            
            #line 40 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.RepositoryNamespace));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 40 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.OrmType.AsNamespacePart()));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n  public static class StoredProcedureExtensions\r\n  {\r\n");
            
            #line 44 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"

  var dbConnecitonString = this.Configuration.ConnectionString;

  var dt = getDataTable(dbConnecitonString);
  
  var groups = dt.Rows.Cast<DataRow>().GroupBy(x => x["ProcedureName"] as string);

  foreach(var gp in groups){
            
            #line default
            #line hidden
            this.Write("\r\n    // --------- ");
            
            #line 53 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(gp.Key));
            
            #line default
            #line hidden
            this.Write(" ------------\r\n    public static ");
            
            #line 54 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(gp.Key));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 54 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(gp.Key));
            
            #line default
            #line hidden
            this.Write("(this ");
            
            #line 54 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Configuration.RepositoryName));
            
            #line default
            #line hidden
            this.Write(" repository");
            
            #line 54 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
 if(HasInputParams(gp)){
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 54 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(getInputParamNames(gp)));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 54 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
}
            
            #line default
            #line hidden
            this.Write(" )\r\n    {\r\n      var sp = new ");
            
            #line 56 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(gp.Key));
            
            #line default
            #line hidden
            this.Write("(repository.CurrentSession);\r\n\r\n");
            
            #line 58 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
 if (HasParams(gp)){
    foreach(var row in gp){
            
            #line default
            #line hidden
            this.Write("      sp.AddParameter(@\"");
            
            #line 60 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(getDbParamName(row)));
            
            #line default
            #line hidden
            this.Write("\",  ");
            
            #line 60 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(!true.Equals(row["IsOutPutParameter"]) ? getParamName(row) : "null"));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 60 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(getNhNullableType(row)));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 60 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(true.Equals(row["IsOutPutParameter"]) ? "ParameterDirection.Output" : "ParameterDirection.Input"));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 61 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
 }

} 
            
            #line default
            #line hidden
            this.Write("\r\n      return sp;\r\n    }\r\n");
            
            #line 67 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"

  }

            
            #line default
            #line hidden
            this.Write("\r\n\r\n\r\n  }\r\n\r\n\r\n");
            
            #line 76 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
  foreach(var gp in groups){
            
            #line default
            #line hidden
            this.Write("  public class ");
            
            #line 77 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(gp.Key));
            
            #line default
            #line hidden
            this.Write(" : NhSpExecutor\r\n  {\r\n\r\n    public ");
            
            #line 80 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(gp.Key));
            
            #line default
            #line hidden
            this.Write("(ISession session) : base(session, \"");
            
            #line 80 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(gp.Key));
            
            #line default
            #line hidden
            this.Write("\")\r\n    { \r\n    }\r\n\r\n    protected override void PostExecute(IDbCommand cmd)\r\n   " +
                    " {\r\n      base.PostExecute(cmd);\r\n\r\n      ");
            
            #line 88 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
 foreach(var row in gp.Where(x => true.Equals(x["IsOutPutParameter"]))){ 
            
            #line default
            #line hidden
            this.Write("\r\n      this.");
            
            #line 90 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(getDbParamName(row)));
            
            #line default
            #line hidden
            this.Write(" = _params.First(x => x.Name == \"");
            
            #line 90 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(getDbParamName(row)));
            
            #line default
            #line hidden
            this.Write("\").Value as ");
            
            #line 90 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(getCsharpType(row)));
            
            #line default
            #line hidden
            this.Write(";\r\n      ");
            
            #line 91 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n    }\r\n    \r\n    ");
            
            #line 95 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
 foreach(var row in gp.Where(x => true.Equals(x["IsOutPutParameter"]))){ 
            
            #line default
            #line hidden
            this.Write("\r\n    public ");
            
            #line 97 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(getCsharpType(row)));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 97 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(getDbParamName(row)));
            
            #line default
            #line hidden
            this.Write(" { get; private set; }\r\n\r\n    ");
            
            #line 99 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\r\n  }\r\n\r\n");
            
            #line 104 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"

  }

            
            #line default
            #line hidden
            this.Write("\r\n\r\n}\r\n\r\n");
            
            #line 111 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"

  var str = this.GenerationEnvironment.ToString().Trim();
  this.GenerationEnvironment.Clear();

            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 116 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(str));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 118 "C:\git-temp\tangsem.suite\Tangsem.Suite\projects\Tangsem.Generator\Templates\StoredProc\StoredProc.tt"

  public bool HasParams(IGrouping<string, DataRow> group){
    return !group.Any(x => x.IsNull("ParameterName"));
  }

  public bool HasInputParams(IGrouping<string, DataRow> group){
    return !group.Any(x => x.IsNull("ParameterName") && ! 1.Equals(x["IsOutPutParameter"]));
  }

  public string getParamNames(IGrouping<string, DataRow> group){
     return string.Join(", " , group.Select(x => getCsharpType(x) + " " + getParamName(x)));
  }

  public string getInputParamNames(IGrouping<string, DataRow> group){
     return string.Join(", " , group.Where(x => !true.Equals(x["IsOutPutParameter"])).Select(x => getCsharpType(x) + " " + getParamName(x)));
  }

  public string getParamName(DataRow row){
    var name = (row["ParameterName"] as String).Substring(1);
    name = name.Substring(0,1).ToLower() + name.Substring(1);

    return name;
  }

  public string getDbParamName(DataRow row){
    var name = (row["ParameterName"] as String).Substring(1);
    return name;
  }

  public string getCsharpType(DataRow dr)
  {
      var dbType = dr["ParameterDataType"] as string;

      switch(dbType){
        case "int": return "int?";
        case "smallint": return "short?";
        case "datetime": return "DateTime?";
        case "bit": return "bool?";        
        case "decimal": return "decimal?";
        case "nvarchar":
        case "varchar":
        case "nchar":
          return "string";

        case "binary":        
        case "image": return "byte[]";

        case "uniqueidentifier":
          return "Guid";
        default:
          return dbType + " Not Support";
      }
  }

  public string getNhNullableType(DataRow dr){

      var dbType = dr["ParameterDataType"] as string;

      switch(dbType){
        case "int": return "NHibernateUtil.Int32";
        case "smallint": return "NHibernateUtil.Int16";
        case "datetime": return "NHibernateUtil.DateTime";
        case "bit": return "NHibernateUtil.Boolean";        
        case "decimal": return "NHibernateUtil.Decimal";
        case "nvarchar":
        case "varchar":
        case "nchar":
          return "NHibernateUtil.String";
        
        case "binary":          
        case "image": return "NHibernateUtil.Binary";

        case "uniqueidentifier":
          return "NHibernateUtil.Guid";
        default:
          return dbType + " Not Support";
      }
  }


  
  public DataTable getDataTable(string dbConnecitonString){
  
    ////var dbConnecitonString = @"Data Source=(local);Initial Catalog=TEST2012_REOS;Integrated Security=True";
    ////var dbConnecitonString = @"Data Source=Airloom-Lee\R2;Initial Catalog=ArnottsMTA;User ID=sa;Password=sa";

    var dt = new DataTable();

      using(var conn = new SqlConnection(dbConnecitonString)){
        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText = @"SELECT  SCHEMA_NAME(SCHEMA_ID) AS [Schema]
          , SO.name AS [ProcedureName]
          , SO.Type_Desc AS [ObjectType (UDF/SP)]
          , P.parameter_id AS [ParameterID]
          , P.name AS [ParameterName]
          , TYPE_NAME(P.user_type_id) AS [ParameterDataType]
          , P.max_length AS [ParameterMaxBytes]
          , P.is_output AS [IsOutPutParameter]
          , P.[default_value] AS [DefaultValue]
          , p.[has_default_value] AS [HasDefaultValue]
          --, object_definition(P.OBJECT_ID)
    FROM    sys.objects AS SO
            LEFT JOIN sys.parameters AS P ON SO.OBJECT_ID = P.OBJECT_ID
            -- AND P.is_output = 0 
    WHERE   
			--SO.OBJECT_ID IN ( SELECT  OBJECT_ID
   --                           FROM    sys.objects
   --                           WHERE   TYPE IN ( 'P', 'FN', 'F', 'IT' )
			--			)
   --         AND
			(SO.[name] LIKE 'p_%' OR SO.[name] LIKE 'fn_%')
            AND SO.[type_desc] IN('SQL_STORED_PROCEDURE', 'SQL_INLINE_TABLE_VALUED_FUNCTION')
            AND SO.[Name] NOT LIKE '%csgen%'
			AND SO.[Name] <> 'fn_diagramobjects'
    ORDER BY [Schema]
          , SO.name
          , P.parameter_id";
    

        var dr = cmd.ExecuteReader();

        dt.Load(dr);
    }

    return dt;
  }


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
}
