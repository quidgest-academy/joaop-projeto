use [W_GnBD]
declare @TblName sysname
DECLARE tableName CURSOR STATIC FOR
SELECT name FROM master.dbo.sysdatabases 
WHERE (upper(name) LIKE upper('AJFQuidTemp%')) OR (upper(name) LIKE upper('QuidTemp%'))
OPEN tableName
FETCH NEXT FROM tableName INTO @TblName
WHILE @@fetch_status = 0
BEGIN
--Esta condição serve para verificar se a BD que se pretende apagar está em uso, indo ao "active monitor"
	if not exists(SELECT top 1 dbid FROM MASTER..SysProcesses where DB_NAME(dbid) = @TblName)
		EXEC ( N'DROP DATABASE [' + @TblName+N']')
	FETCH NEXT FROM tableName INTO @TblName
END
CLOSE tableName
DEALLOCATE tableName
GO
