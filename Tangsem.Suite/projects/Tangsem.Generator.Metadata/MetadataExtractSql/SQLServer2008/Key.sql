-- Primary Key and Unique Key Metadata
SELECT  [Table] = colUsage.TABLE_NAME,
        [Column] = colUsage.COLUMN_NAME ,
        [KeyName] = colUsage.CONSTRAINT_NAME ,
        [KeyTypeName] = tblCons.CONSTRAINT_TYPE ,
        [KeyType] = CASE WHEN tblCons.CONSTRAINT_TYPE = 'PRIMARY KEY' THEN 1 ELSE 2 END ,
        [ColumnDataType] = col.DATA_TYPE ,
        [Nullable] = CAST( CASE WHEN col.IS_NULLABLE = 'NO' THEN 0
						   ELSE 1
						   END
						   AS BIT)
FROM    INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE colUsage
        JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tblCons ON colUsage.CONSTRAINT_NAME = tblCons.CONSTRAINT_NAME
        JOIN INFORMATION_SCHEMA.COLUMNS col ON col.COLUMN_NAME = colUsage.COLUMN_NAME
                                               AND col.TABLE_NAME = colUsage.TABLE_NAME
WHERE   CONSTRAINT_TYPE IN ( 'PRIMARY KEY', 'UNIQUE' )
	AND colUsage.TABLE_NAME NOT IN ('sysdiagrams')
ORDER BY tblCons.CONSTRAINT_TYPE,
        colUsage.TABLE_NAME,
        colUsage.CONSTRAINT_NAME