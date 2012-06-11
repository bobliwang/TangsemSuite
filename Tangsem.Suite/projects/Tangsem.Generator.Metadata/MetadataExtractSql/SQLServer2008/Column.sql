--DECLARE @TableName NVARCHAR(500)
--SET @TableName = 'AnnualLeaveChange';
WITH    PrimaryKeys
      AS ( SELECT   pk.TABLE_NAME ,
                    c.COLUMN_NAME
           FROM     information_schema.table_constraints pk
                    INNER JOIN information_schema.key_column_usage c ON c.TABLE_NAME = pk.TABLE_NAME
                                                          AND c.constraint_name = pk.constraint_name
           WHERE    constraint_type = 'PRIMARY KEY'
         )
SELECT  [Table] = col.TABLE_NAME
        ,[Column] = col.COLUMN_NAME
        ,[Nullable] = CAST(CASE WHEN col.IS_NULLABLE = 'YES' THEN 1 ELSE 0 END AS BIT)
        ,[DataType] = col.DATA_TYPE
        ,[ColumnSize] = ISNULL(col.CHARACTER_MAXIMUM_LENGTH, 0)
        ,[IsAutoIncrement] = CAST(COLUMNPROPERTY(OBJECT_ID(col.TABLE_NAME), col.COLUMN_NAME,
                            'IsIdentity') AS BIT)
        ,[IsComputed] = CAST(COLUMNPROPERTY(OBJECT_ID(col.TABLE_NAME), col.COLUMN_NAME,
                            'IsComputed') AS BIT)
        ,[IsPrimaryKey] = CAST(PkCheck.IsPk AS BIT)
FROM    INFORMATION_SCHEMA.COLUMNS col
        CROSS APPLY ( SELECT    CASE WHEN EXISTS ( SELECT *
                                                   FROM   PrimaryKeys pk
                                                   WHERE  pk.TABLE_NAME = col.TABLE_NAME
                                                          AND pk.COLUMN_NAME = col.COLUMN_NAME )
                                     THEN 1
                                     ELSE 0
                                END AS IsPk
                    ) AS PkCheck
WHERE @TableName IS NULL OR col.TABLE_NAME = @TableName
ORDER BY col.TABLE_NAME ,
        col.ORDINAL_POSITION