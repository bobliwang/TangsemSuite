--SELECT  t.TABLE_CATALOG AS [Catalog] ,
--        t.TABLE_NAME AS [TableName] ,
--        c.COLUMN_NAME AS [ColumnName] ,
--        c.IS_NULLABLE AS [Nullable] ,
--        c.DATA_TYPE AS [DataType] ,
--        *
--FROM    INFORMATION_SCHEMA.Tables t
--        JOIN INFORMATION_SCHEMA.Columns C ON t.TABLE_NAME = c.TABLE_NAME
--WHERE   t.TABLE_NAME NOT LIKE 'sys%'
--        AND t.TABLE_NAME <> 'dtproperties'
--        AND t.TABLE_SCHEMA <> 'INFORMATION_SCHEMA'
--ORDER BY t.TABLE_CATALOG ,
--        c.TABLE_NAME ,
--        c.ORDINAL_POSITION
        

--SELECT  *
--FROM    INFORMATION_SCHEMA.KEY_COLUMN_USAGE
--SELECT  *
--FROM    INFORMATION_SCHEMA.TABLE_CONSTRAINTS

--SELECT  *
--FROM    INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
--SELECT  *
--FROM    INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS

-- Foreign Key Metadata 'Pairs!!!'
SELECT  col.CONSTRAINT_NAME [RefName],
        col.TABLE_NAME [FkTable] ,
        col.COLUMN_NAME [FkColumn] ,
        pk.TABLE_NAME [PkTable] ,
        pk.COLUMN_NAME [PkColumn]
FROM    INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE col
        JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS ref ON col.CONSTRAINT_NAME = ref.CONSTRAINT_NAME
        JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE pk ON pk.CONSTRAINT_NAME = ref.UNIQUE_CONSTRAINT_NAME
        
-- Primary Key and Unique Key Metadata
SELECT  colUsage.TABLE_NAME ,
        colUsage.COLUMN_NAME ,
        colUsage.CONSTRAINT_NAME ,
        tblCons.CONSTRAINT_TYPE ,
        col.DATA_TYPE ,
        CAST(CASE WHEN col.IS_NULLABLE = 'NO' THEN 0
                  ELSE 1
             END AS BIT) Nullable
FROM    INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE colUsage
        JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tblCons ON colUsage.CONSTRAINT_NAME = tblCons.CONSTRAINT_NAME
        JOIN INFORMATION_SCHEMA.COLUMNS col ON col.COLUMN_NAME = colUsage.COLUMN_NAME
                                               AND col.TABLE_NAME = colUsage.TABLE_NAME
WHERE   CONSTRAINT_TYPE IN ( 'PRIMARY KEY', 'UNIQUE' )
ORDER BY tblCons.CONSTRAINT_TYPE ,
        colUsage.TABLE_NAME ,
        colUsage.CONSTRAINT_NAME


-- Identity Columns
SELECT  col.TABLE_NAME ,
        col.COLUMN_NAME ,
        col.DATA_TYPE
FROM    INFORMATION_SCHEMA.COLUMNS col
WHERE   TABLE_SCHEMA = 'dbo'
        AND COLUMNPROPERTY(OBJECT_ID(TABLE_NAME), COLUMN_NAME, 'IsIdentity') = 1
        AND col.TABLE_NAME NOT IN ( 'sysdiagrams' )
ORDER BY TABLE_NAME

-- Columns Metadata
SELECT  col.TABLE_NAME ,
        col.COLUMN_NAME ,
        col.DATA_TYPE ,
        col.COLUMN_DEFAULT ,
        CAST(CASE WHEN col.IS_NULLABLE = 'NO' THEN 0
                  ELSE 1
             END AS BIT) Nullable ,
        CASE WHEN COLUMNPROPERTY(OBJECT_ID(TABLE_NAME), COLUMN_NAME,
                                 'IsIdentity') = 1 THEN 1
             ELSE 0
        END AS IsIdentity
        
        , sysCol.is_identity
        , sysCol.system_type_id
        , col.*
FROM    INFORMATION_SCHEMA.COLUMNS col
JOIN sys.columns sysCol ON col.COLUMN_NAME = sysCol.name
JOIN sys.objects sysObj ON sysCol.object_id = sysObj.object_id AND col.TABLE_NAME = sysObj.name
ORDER BY col.TABLE_NAME, col.ORDINAL_POSITION




SELECT o.name, c.name, * FROM sys.columns c JOIN sys.objects o ON c.object_id = o.object_id
SELECT * FROM sys.all_objects