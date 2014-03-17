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
    {
      return new SqlConnection(this.ConnectionString);
    }

    public override ITypeMapper CreateTypeMapper()
    {
      return new SqlServer2008TypeMapper();
    }

    public override string ReferencesSql
    {
      get
      {
        return
          @"
                SELECT
                     col.CONSTRAINT_NAME [ReferenceName],
                     col.TABLE_NAME [ChildTable],
                     col.COLUMN_NAME [ChildColumn],
                     pk.TABLE_NAME [ParentTable],
                     pk.COLUMN_NAME [ParentColumn]
                FROM 
                     INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE col
                     JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS ref ON col.CONSTRAINT_NAME = ref.CONSTRAINT_NAME
                     JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE pk ON pk.CONSTRAINT_NAME = ref.UNIQUE_CONSTRAINT_NAME
                WHERE
                     col.TABLE_NAME = @TableName OR pk.TABLE_NAME = @TableName OR @TableName IS NULL";
      }
    }

    public override string KeysSql
    {
      get
      {
        return @"
                SELECT
                      [Table] = colUsage.TABLE_NAME,
                      [Column] = colUsage.COLUMN_NAME ,
                      [KeyName] = colUsage.CONSTRAINT_NAME ,
                      [KeyTypeName] = tblCons.CONSTRAINT_TYPE ,
                      [KeyType] = CASE WHEN tblCons.CONSTRAINT_TYPE = 'PRIMARY KEY' THEN 1 ELSE 2 END ,
                      [ColumnDataType] = col.DATA_TYPE ,
                      [Nullable] = CAST( CASE WHEN col.IS_NULLABLE = 'NO' THEN 0
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
                WHERE CONSTRAINT_TYPE IN ( 'PRIMARY KEY', 'UNIQUE' )
                  AND colUsage.TABLE_NAME NOT IN ('sysdiagrams')
                  AND (colUsage.TABLE_NAME = @TableName OR @TableName IS NULL)
                ORDER BY tblCons.CONSTRAINT_TYPE, colUsage.TABLE_NAME, colUsage.CONSTRAINT_NAME";
      }
    }

    public override string ColumnsSql
    {
      get
      {
        return
		  @"
              WITH PrimaryKeys
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
              FROM INFORMATION_SCHEMA.COLUMNS AS col
			  LEFT JOIN PrimaryKeys pk ON pk.TABLE_NAME = col.TABLE_NAME AND pk.COLUMN_NAME = col.COLUMN_NAME              
              WHERE (@TableName IS NULL OR col.TABLE_NAME = @TableName)
              ORDER BY col.TABLE_NAME, col.ORDINAL_POSITION";
      }
    }


    public override string TablesSql
    {
      get
      {
        return @"SELECT
                  [Table] = TABLE_NAME
                  , [IsView] = CAST( CASE WHEN TABLE_TYPE = 'VIEW' THEN 1 ELSE 0 END AS BIT)  
                  FROM INFORMATION_SCHEMA.TABLES";
      }
    }
  }
}