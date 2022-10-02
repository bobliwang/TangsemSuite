using System;
using System.Collections.Generic;

using Tangsem.Generator.Metadata;
using Tangsem.Generator.Settings;

namespace Tangsem.Generator.Templates.StoredProc
{
  using System.Data;
  using System.Data.SqlClient;
  using System.Linq;

  public partial class StoredProc: IMultipleTableMetadataTemplate
  {
    public StoredProc(GeneratorConfiguration configuration, List<TableMetadata> tableMetadatas)
    {
      this.Configuration = configuration;
      this.TableMetadatas = tableMetadatas;
    }

    public string GetPathToSave(GeneratorConfiguration genConfig)
    {
      return this.Configuration.IRepositoriesDirPath + "/" + this.Configuration.OrmType.AsNamespacePart() + "/" + this.Configuration.RepositoryName + "StoredProcs.Designer.cs";
    }

    public GeneratorConfiguration Configuration { get; set; }

    public List<TableMetadata> TableMetadatas { get; set; }

    public bool HasParams(IGrouping<string, DataRow> group)
    {
      return !group.Any(x => x.IsNull("ParameterName"));
    }

    public bool HasInputParams(IGrouping<string, DataRow> group)
    {
      return !group.Any(x => x.IsNull("ParameterName") && !1.Equals(x["IsOutPutParameter"]));
    }

    public string getParamNames(IGrouping<string, DataRow> group)
    {
      return string.Join(", ", group.Select(x => getCsharpType(x) + " " + getParamName(x)));
    }

    public string getInputParamNames(IGrouping<string, DataRow> group)
    {
      return string.Join(", ", group.Where(x => !true.Equals(x["IsOutPutParameter"])).Select(x => getCsharpType(x) + " " + getParamName(x)));
    }

    public string getParamName(DataRow row)
    {
      var name = (row["ParameterName"] as String).Substring(1);
      name = name.Substring(0, 1).ToLower() + name.Substring(1);

      return name;
    }

    public string getDbParamName(DataRow row)
    {
      var name = (row["ParameterName"] as String).Substring(1);
      return name;
    }

    public string getCsharpType(DataRow dr)
    {
      var dbType = dr["ParameterDataType"] as string;

      switch (dbType)
      {
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

    public string getNhNullableType(DataRow dr)
    {

      var dbType = dr["ParameterDataType"] as string;

      switch (dbType)
      {
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

    public DataTable getDataTable(string dbConnecitonString)
    {
      var dt = new DataTable();

      using (var conn = new SqlConnection(dbConnecitonString))
      {
        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText = """
SELECT SCHEMA_NAME(SCHEMA_ID) AS [Schema]
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
	 -- SO.OBJECT_ID IN ( SELECT OBJECT_ID
   --                   FROM sys.objects
   --                   WHERE TYPE IN ( 'P', 'FN', 'F', 'IT' )
   --	)
   -- AND
			(SO.[name] LIKE 'p_%' OR SO.[name] LIKE 'fn_%')
            AND SO.[type_desc] IN('SQL_STORED_PROCEDURE', 'SQL_INLINE_TABLE_VALUED_FUNCTION')
            AND SO.[Name] NOT LIKE '%csgen%'
			AND SO.[Name] <> 'fn_diagramobjects'
    ORDER BY [Schema]
          , SO.name
          , P.parameter_id
""";
        var dr = cmd.ExecuteReader();

        dt.Load(dr);
      }

      return dt;
    }
  }
}