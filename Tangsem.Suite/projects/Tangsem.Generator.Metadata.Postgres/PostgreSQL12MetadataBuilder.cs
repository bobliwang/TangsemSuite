using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Npgsql;

using Tangsem.Generator.Metadata.Builder;
using Tangsem.Generator.Metadata.TypeMapping;

namespace Tangsem.Generator.Metadata.Postgres
{
  public class PostgreSQL12MetadataBuilder : MetadataBuilder
  {
    public PostgreSQL12MetadataBuilder(string connectionString)
      : base(connectionString)
    {
    }

    public override DbConnection GetDbConnection() => new NpgsqlConnection(this.ConnectionString);

    public override ITypeMapper CreateTypeMapper() => new PostgreSQL12TypeMapper();

    public override string ColumnsSql =>
      @"
WITH
PrimaryKeys as (SELECT pk.TABLE_NAME ,
                            c.COLUMN_NAME
                     FROM information_schema.table_constraints pk
                     INNER JOIN information_schema.key_column_usage c
                           ON c.TABLE_NAME = pk.TABLE_NAME
                           AND c.constraint_name = pk.constraint_name
                     WHERE constraint_type = 'PRIMARY KEY')
SELECT
    col.TABLE_NAME        AS ""Table""
   , col.COLUMN_NAME      AS ""Column""
   , CAST(
		   CASE WHEN col.IS_NULLABLE = 'YES' THEN 1
       ELSE 0 END AS BIT) AS ""Nullable""
   , col.DATA_TYPE        AS ""DataType""
   , COALESCE (col.CHARACTER_MAXIMUM_LENGTH, 0)
                          AS ""ColumnSize""
   , CAST((CASE WHEN col.is_identity = 'YES' THEN 1 ELSE 0 END) AS BIT) AS ""IsAutoIncrement""
   , CAST((CASE WHEN col.is_generated = 'NEVER' THEN 0 ELSE 1 END) AS BIT)
                          AS ""IsComputed""
   , CAST((CASE WHEN pk.TABLE_NAME IS NULL Then 0 ELSE 1 END) AS BIT)
                          AS ""IsPrimaryKey""
   , col.COLUMN_DEFAULT   AS ""DefaultValueExpr""
   , (
	    SELECT pg_catalog.col_description(c.oid, col.ordinal_position::int)
	    FROM pg_catalog.pg_class c
	    WHERE c.oid = (SELECT ('""' || col.table_name || '""')::regclass::oid)
		    AND c.relname = col.table_name) AS ""Description""
FROM INFORMATION_SCHEMA.COLUMNS AS col
INNER JOIN INFORMATION_SCHEMA.TABLES AS tbl ON col.TABLE_NAME = tbl.TABLE_NAME
LEFT JOIN PrimaryKeys pk ON pk.TABLE_NAME = col.TABLE_NAME AND pk.COLUMN_NAME = col.COLUMN_NAME
WHERE tbl.TABLE_SCHEMA = 'public' AND (col.TABLE_NAME = @TableName OR @TableName IS NULL)
ORDER BY col.TABLE_NAME, col.ORDINAL_POSITION
";

    public override string KeysSql =>
      @"SELECT
         colUsage.TABLE_NAME      AS ""Table"",
         colUsage.COLUMN_NAME     AS ""Column"",
         colUsage.CONSTRAINT_NAME AS ""KeyName"",
         tblCons.CONSTRAINT_TYPE  AS ""KeyTypeName"",
         CASE WHEN tblCons.CONSTRAINT_TYPE = 'PRIMARY KEY' THEN 1
          ELSE 2
         END                      AS ""KeyType"",
         col.DATA_TYPE AS ColumnDataType,
         CAST( CASE
                WHEN col.IS_NULLABLE = 'NO' THEN 0
                  ELSE 1
                END AS BIT)       AS ""Nullable""
        FROM  
              INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE colUsage
              JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tblCons
                  ON colUsage.CONSTRAINT_NAME = tblCons.CONSTRAINT_NAME
              JOIN INFORMATION_SCHEMA.COLUMNS col
                  ON col.COLUMN_NAME = colUsage.COLUMN_NAME
                    AND col.TABLE_NAME = colUsage.TABLE_NAME
        WHERE CONSTRAINT_TYPE IN ( 'PRIMARY KEY', 'UNIQUE' )
          AND (colUsage.TABLE_NAME = @TableName OR @TableName IS NULL)
        ORDER BY tblCons.CONSTRAINT_TYPE, colUsage.TABLE_NAME, colUsage.CONSTRAINT_NAME";

    public override string IndicesSql => string.Empty;

    public override string ReferencesSql =>
      @"-- https://stackoverflow.com/questions/1152260/postgres-sql-to-list-table-foreign-keys
        SELECT
            tc.table_schema, 
            tc.constraint_name AS ""ReferenceName"", 
            tc.table_name      AS ""ChildTable"", 
            kcu.column_name    AS ""ChildColumn"", 
            ccu.table_schema   AS ""foreign_table_schema"",
            ccu.table_name     AS ""ParentTable"",
            ccu.column_name    AS ""ParentColumn"",
            tc.constraint_name AS ""RawComment""
        FROM 
            information_schema.table_constraints AS tc 
            JOIN information_schema.key_column_usage AS kcu
              ON tc.constraint_name = kcu.constraint_name
              AND tc.table_schema = kcu.table_schema
            JOIN information_schema.constraint_column_usage AS ccu
              ON ccu.constraint_name = tc.constraint_name
              AND ccu.table_schema = tc.table_schema
        WHERE tc.constraint_type = 'FOREIGN KEY'
              AND (tc.TABLE_NAME = @TableName OR ccu.TABLE_NAME = @TableName OR @TableName IS NULL)";

    public override string TablesSql =>
      @"
        SELECT
          TABLE_NAME as ""Table""
        , CAST(
            CASE WHEN TABLE_TYPE = 'VIEW' THEN 1 ELSE 0 END
            AS BIT) as ""IsView""
        , TABLE_SCHEMA as ""Schema""
        FROM INFORMATION_SCHEMA.TABLES
        WHERE TABLE_SCHEMA = 'public'";
  }
}
