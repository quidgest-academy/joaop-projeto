USE [W_GnBD]

-- begin of full-text index script
IF ((SELECT fulltextserviceproperty('isfulltextinstalled')) = 1)
BEGIN

-- enable fulltext on database (if already enable sp_fulltext_database will do nothing)
IF ((SELECT DATABASEPROPERTYEX(db_name(), 'IsFulltextEnabled')) = 0)
BEGIN
	EXEC sp_fulltext_database 'enable'
END

-- drop auxiliary tables if they exist
IF OBJECT_ID('tempdb..#tblExists') IS NOT NULL
BEGIN
	DROP TABLE #tblExists
END
IF OBJECT_ID('tempdb..#tblToExist') IS NOT NULL
BEGIN
	DROP TABLE #tblToExist
END

-- create the catalog for full-text search
IF NOT EXISTS(SELECT * FROM sys.fulltext_catalogs WHERE name = 'AJFCatalog')
BEGIN
	CREATE FULLTEXT CATALOG [AJFCatalog] WITH ACCENT_SENSITIVITY = OFF AS DEFAULT
END

-- create all necessary full-text indexes

-- find all existing full-text indexed columns
SELECT a.name COLLATE SQL_Latin1_General_CP1_CI_AI AS tblName, c.name COLLATE SQL_Latin1_General_CP1_CI_AI AS clnName
INTO #tblExists
FROM sys.objects a
INNER JOIN sys.fulltext_index_columns b ON a.object_id = b.object_id 
INNER JOIN sys.all_columns c ON b.column_id = c.column_id AND c.object_id = a.object_id

-- list all necessary full-text index columns
CREATE TABLE #tblToExist
(
	tblName VARCHAR(25) COLLATE SQL_Latin1_General_CP1_CI_AI,
	clnName VARCHAR(30) COLLATE SQL_Latin1_General_CP1_CI_AI,
	typeClnName VARCHAR(30) COLLATE SQL_Latin1_General_CP1_CI_AI
) 

-- delete all unecessary full-text index columns
DECLARE @tblName NVARCHAR(25)
DECLARE @clnName NVARCHAR(30)
DECLARE @typeClnName NVARCHAR(30)
DECLARE tableIndexApagar CURSOR STATIC FOR
	SELECT #tblExists.tblName, #tblExists.clnName
	FROM #tblExists
	LEFT JOIN #tblToExist ON #tblExists.clnName = #tblToExist.clnName AND #tblExists.tblName = #tblToExist.tblName
	WHERE #tblToExist.tblName IS NULL
OPEN tableIndexApagar
FETCH NEXT FROM tableIndexApagar INTO @tblName, @clnName
WHILE @@fetch_status = 0
BEGIN
	EXEC ('ALTER FULLTEXT INDEX ON ' + @tblName + ' DROP (' + @clnName + ')');
	FETCH NEXT FROM tableIndexApagar INTO @tblName, @clnName
END
CLOSE tableIndexApagar
DEALLOCATE tableIndexApagar

-- add missing full-text index columns
DECLARE tableIndexCriar CURSOR STATIC FOR
	SELECT #tblToExist.tblName, #tblToExist.clnName, #tblToExist.typeClnName
	FROM #tblExists
	RIGHT JOIN #tblToExist ON #tblExists.clnName = #tblToExist.clnName AND #tblExists.tblName = #tblToExist.tblName
	WHERE #tblExists.tblName IS NULL
OPEN tableIndexCriar
FETCH NEXT FROM tableIndexCriar INTO @tblName, @clnName, @typeClnName
WHILE @@fetch_status = 0
BEGIN
	IF (@typeClnName IS NULL)
	BEGIN
		EXEC ('ALTER FULLTEXT INDEX ON ' + @tblName + ' ADD (' + @clnName + ')');
	END
	ELSE
	BEGIN
		EXEC ('ALTER FULLTEXT INDEX ON ' + @tblName + ' ADD (' + @clnName + ' TYPE COLUMN ' + @typeClnName + ')');
	END
	FETCH NEXT FROM tableIndexCriar INTO @tblName, @clnName, @typeClnName
END
CLOSE tableIndexCriar
DEALLOCATE tableIndexCriar

-- delete all full-text indexes that have no indexed column
DECLARE tableIndexApagar CURSOR STATIC FOR
	SELECT sobj.name
	FROM sys.objects sobj
	JOIN sys.fulltext_indexes sftsidx ON sobj.object_id = sftsidx.object_id
	LEFT JOIN sys.fulltext_index_columns sftsidxcol ON sftsidx.object_id = sftsidxcol.object_id
	WHERE sftsidxcol.column_id IS NULL
OPEN tableIndexApagar
FETCH NEXT FROM tableIndexApagar INTO @tblName
WHILE @@fetch_status = 0
BEGIN
	EXEC ('DROP FULLTEXT INDEX ON ' + @tblName);
	FETCH NEXT FROM tableIndexApagar INTO @tblName
END
CLOSE tableIndexApagar
DEALLOCATE tableIndexApagar


END -- endif

GO

-- end of full-text index script
