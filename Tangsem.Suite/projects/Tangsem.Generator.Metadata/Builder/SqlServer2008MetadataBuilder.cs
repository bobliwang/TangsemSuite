using System;
using System.Data.Common;
using System.Data.SqlClient;

using Tangsem.Generator.Metadata.TypeMapping;

namespace Tangsem.Generator.Metadata.Builder
{
  public class SqlServer2008MetadataBuilder : MetadataBuilder
  {
    public SqlServer2008MetadataBuilder(string connectionString)
      : base(connectionString)
    {
    }

    public override DbConnection GetDbConnection()
      => new SqlConnection(this.ConnectionString);

    public override ITypeMapper CreateTypeMapper()
      => new SqlServer2008TypeMapper();

    /// <summary>
    /// Generates SQL to fetch FK (references) info.
    /// </summary>
    public override string ReferencesSql
      => @"
            SELECT
                 col.CONSTRAINT_NAME AS [ReferenceName],
                 col.TABLE_NAME      AS [ChildTable],
                 col.COLUMN_NAME     AS [ChildColumn],
                 pk.TABLE_NAME       AS [ParentTable],
                 pk.COLUMN_NAME      AS [ParentColumn],
                 meta.Value          AS [RawComment]
            FROM 
                 INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE col
                 JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS ref ON col.CONSTRAINT_NAME = ref.CONSTRAINT_NAME
                 JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE pk ON pk.CONSTRAINT_NAME = ref.UNIQUE_CONSTRAINT_NAME
                 OUTER APPLY (
						      SELECT
                              TOP 1 *
                              FROM
                              fn_listextendedproperty(NULL, 'schema', 'dbo', 'table', col.TABLE_NAME, 'CONSTRAINT', default)
                              WHERE col.CONSTRAINT_NAME collate SQL_Latin1_General_CP1_CI_AS
                                  = objname collate SQL_Latin1_General_CP1_CI_AS 
					       ) AS meta
                WHERE
                     col.TABLE_NAME = @TableName OR pk.TABLE_NAME = @TableName OR @TableName IS NULL";

    /// <summary>
    /// Generates SQL to fetch keys and index metadata.
    /// </summary>
    public override string KeysSql
      => @"
            SELECT
              [Table]          = colUsage.TABLE_NAME,
              [Column]         = colUsage.COLUMN_NAME ,
              [KeyName]        = colUsage.CONSTRAINT_NAME ,
              [KeyTypeName]    = tblCons.CONSTRAINT_TYPE ,
              [KeyType]        = CASE WHEN tblCons.CONSTRAINT_TYPE = 'PRIMARY KEY' THEN 1
                                  ELSE 2
                                 END ,
              [ColumnDataType] = col.DATA_TYPE ,
              [Nullable]       = CAST(
                                   CASE WHEN col.IS_NULLABLE = 'NO' THEN 0
                                    ELSE 1
                                   END
                                   AS BIT)
            FROM  
              INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE colUsage
              JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tblCons
                  ON colUsage.CONSTRAINT_NAME = tblCons.CONSTRAINT_NAME
              JOIN INFORMATION_SCHEMA.COLUMNS col
                  ON col.COLUMN_NAME = colUsage.COLUMN_NAME
                    AND col.TABLE_NAME = colUsage.TABLE_NAME
            WHERE CONSTRAINT_TYPE IN ('PRIMARY KEY', 'UNIQUE')
              AND colUsage.TABLE_NAME NOT IN ('sysdiagrams')
              AND (colUsage.TABLE_NAME = @TableName OR @TableName IS NULL)
            ORDER BY tblCons.CONSTRAINT_TYPE, colUsage.TABLE_NAME, colUsage.CONSTRAINT_NAME";

    public override string IndicesSql => @"WITH uniqueIdxQry as (
SELECT
     IndexName = ind.name,
     TableName = t.name,
	 ColumnId = ic.index_column_id,
     ColumnName = col.name,
     IndexId = ind.index_id     
     --ind.*,
     --ic.*,
     --col.* 
FROM 
     sys.indexes ind
INNER JOIN 
     sys.index_columns ic ON  ind.object_id = ic.object_id and ind.index_id = ic.index_id 
INNER JOIN 
     sys.columns col ON ic.object_id = col.object_id and ic.column_id = col.column_id 
INNER JOIN 
     sys.tables t ON ind.object_id = t.object_id

WHERE 
     ind.is_primary_key = 0 
     AND ind.is_unique = 1 
     --AND ind.is_unique_constraint = 0 
     --AND t.is_ms_shipped = 0 

	 AND t.name <> 'sysdiagrams'

)

SELECT * FROM uniqueIdxQry";

    /// <summary>
    /// Generates SQL to fetch column metadata.
    /// </summary>
    public override string ColumnsSql
      => @" WITH PrimaryKeys
            AS
            (
                   SELECT pk.TABLE_NAME ,
                          c.COLUMN_NAME
                   FROM information_schema.table_constraints pk
                   INNER JOIN information_schema.key_column_usage c
                         ON c.TABLE_NAME = pk.TABLE_NAME
                         AND c.constraint_name = pk.constraint_name
                   WHERE constraint_type = 'PRIMARY KEY'
            )
            SELECT  [Table] = col.TABLE_NAME
                   ,[Column] = col.COLUMN_NAME
                   ,[Nullable] = CAST(CASE WHEN col.IS_NULLABLE = 'YES' THEN 1 ELSE 0 END AS BIT)
                   ,[DataType] = col.DATA_TYPE
                   ,[ColumnSize] = ISNULL(col.CHARACTER_MAXIMUM_LENGTH, 0)
                   ,[IsAutoIncrement] = ISNULL(CAST(COLUMNPROPERTY(OBJECT_ID(col.TABLE_NAME), col.COLUMN_NAME,'IsIdentity') AS BIT), 0)
                   ,[IsComputed] = ISNULL(CAST(COLUMNPROPERTY(OBJECT_ID(col.TABLE_NAME), col.COLUMN_NAME, 'IsComputed') AS BIT), 0)
                   ,[IsPrimaryKey] = CAST((CASE WHEN pk.TABLE_NAME IS NULL Then 0 ELSE 1 END) AS BIT)
                   ,[DefaultValueExpr] = col.[COLUMN_DEFAULT]
                   ,[Description] = meta.value
            FROM INFORMATION_SCHEMA.COLUMNS AS col
            INNER JOIN INFORMATION_SCHEMA.TABLES AS tbl ON col.TABLE_NAME = tbl.TABLE_NAME
			      LEFT JOIN PrimaryKeys pk ON pk.TABLE_NAME = col.TABLE_NAME AND pk.COLUMN_NAME = col.COLUMN_NAME
            OUTER APPLY (
						  SELECT
                TOP 1 * FROM
                fn_listextendedproperty(NULL, 'schema', 'dbo', CASE WHEN tbl.TABLE_TYPE = 'BASE TABLE' THEN 'table' ELSE 'view' END, col.TABLE_NAME, 'column', col.COLUMN_NAME)
						    WHERE name = 'MS_Description'
					  ) AS meta
            WHERE (@TableName IS NULL OR col.TABLE_NAME = @TableName)
            ORDER BY col.TABLE_NAME, col.ORDINAL_POSITION";

    /// <summary>
    /// Gets the tables metadata.
    /// </summary>
    public override string TablesSql =>
      @"SELECT
          [Table] = TABLE_NAME
          , [IsView] = CAST( CASE WHEN TABLE_TYPE = 'VIEW' THEN 1 ELSE 0 END AS BIT)
          , [Schema] = TABLE_SCHEMA
          FROM INFORMATION_SCHEMA.TABLES";
  }
}