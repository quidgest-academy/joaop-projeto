use [W_GnBD]
if exists(select * from sysobjects where type = 'P' and name = 'CriarTabelaTmp')
	DROP PROCEDURE CriarTabelaTmp
EXEC('CREATE PROCEDURE CriarTabelaTmp
	@NomeTabela NVARCHAR(300),
	@PK NVARCHAR(300),
	@PKtype nvarchar(1)
	,@PKsize int = 0
	,@NewTable bit = NULL OUTPUT
	AS
	declare @sql nvarchar(4000);
	declare @current_pk nvarchar(300);
	declare @current_constraint nvarchar(300);
	declare @newpk bit = 0;
	declare @seqname nvarchar(50) = ''SEQ_'' + @NomeTabela + ''_'' + @PK;
	declare @nextpk bigint;

	declare @pk_data nvarchar(50) = case
		when @PKtype = ''G'' then ''uniqueidentifier ROWGUIDCOL''
		when @PKtype = ''I'' and @PKsize<3 then ''TINYINT''
		when @PKtype = ''I'' and @PKsize>=3 and @PKsize<5 then ''SMALLINT''
		when @PKtype = ''I'' and @PKsize>=5 and @PKsize<10 then ''INT''
		when @PKtype = ''I'' and @PKsize>=10 then ''BIGINT''
		else ''NVARCHAR(''+cast(@PKsize as varchar)+'')'' end;

	set nocount on
	SET @NewTable = ~cast(coalesce(object_id(@NomeTabela, ''U''), 0) as bit);

	if @NewTable = 1
	begin
		--create table
		SET @sql = ''CREATE TABLE ['' + @NomeTabela + ''] ('' + @PK + '' '' + @pk_data + '' NOT NULL ''
			+ '', CONSTRAINT ['' + @NomeTabela + ''_'' + @PK + ''] PRIMARY KEY CLUSTERED ('' + @PK + ''));'';
		EXEC (@sql);
	end
	else
	begin
		-- table already exists, look for the primary key field

		-- if it already exists check if the primary key constraint is already created
		select TOP 1 @current_pk = kc.column_name, @current_constraint = tc.constraint_name
		from information_schema.key_column_usage kc
		inner join information_schema.table_constraints tc on kc.constraint_name = tc.constraint_name
		where kc.table_name = @NomeTabela and tc.constraint_type = ''PRIMARY KEY'';

		-- If there was already a primary key on a different field the constraint needs to be removed first
		if @current_pk is null
		begin
			set @newpk = 1;
		end
		else if @current_pk IS NOT NULL AND @current_pk != @pk
		begin
			--guids have to be marked as rowguidcol, but there can be only one per table
			--this can still fail if there is a filestream field on the table
			if @PKtype = ''G''
				EXEC (''ALTER TABLE [''+@NomeTabela+''] ALTER COLUMN '' + @current_pk + '' DROP ROWGUIDCOL'');
			EXEC (''ALTER TABLE [''+@NomeTabela+''] DROP CONSTRAINT '' + @current_constraint);
			set @newpk = 1;
		end;

		-- if the column doesn''t exist then add it
		if NOT EXISTS(SELECT 1 FROM information_schema.columns WHERE columns.table_name = @NomeTabela AND column_name = @pk)
		begin
			EXEC (''ALTER TABLE [''+@NomeTabela+''] ADD '' + @PK + '' '' + @pk_data + '' NOT NULL;'');
			set @newpk = 1;
		end;

		-- TODO: check if the field needs size or type changes
		--exec dbo.AlterarCamposTmp(@NomeTabela, @pk, @pk_data, @pk_data, @PKsize, 1)

	   --add the constraint to the new column
       if (@newpk = 1)
			EXEC (''ALTER TABLE [''+@NomeTabela+''] ADD CONSTRAINT ['' + @NomeTabela + ''_'' + @PK + ''] PRIMARY KEY CLUSTERED ('' + @PK + '');'');
	end;

	-- if the primary key requires a sequence then ensure its created and set to the next available number
	if @PKtype != ''G'' 
	begin
		SET @sql = ''SELECT @nextpk = cast(MAX(''+@pk+'') as bigint)+1 FROM ''+@NomeTabela;
		EXEC sp_executesql @sql, N''@nextpk bigint output'', @nextpk = @nextpk OUTPUT;

		if object_id(@seqname, ''SO'') IS NULL
		begin
			SET @sql = ''CREATE SEQUENCE '' + @seqname
			+ '' as '' + (case when @PKtype = ''C'' then N''bigint'' else @pk_data end)
			+ '' START WITH ''+ cast(coalesce(@nextpk, 1) as varchar) +'' INCREMENT BY 1 CACHE 10;'';
			EXEC (@sql);
		end
		else
		begin
			SET @sql = ''ALTER SEQUENCE '' + @seqname
			+ '' RESTART WITH ''+ cast(coalesce(@nextpk, 1) as varchar)
			EXEC (@sql);
		end
	end

	-- check if the default function needs to be set in the pk
	if not exists (select 1 from sys.default_constraints dc where parent_object_id = object_id(@NomeTabela, ''U'') and name = ''DF_''+ @NomeTabela + ''_'' + @PK)
	begin
		SET @sql = ''ALTER TABLE [''+@NomeTabela+''] ADD CONSTRAINT DF_''+ @NomeTabela + ''_'' + @PK + '' DEFAULT '';
		if @PKtype = ''G''
			SET @sql = @sql + ''(newid()) FOR ['' + @PK + '']'';
		else if @PKtype = ''I''
			SET @sql = @sql + ''(NEXT VALUE FOR '' + @seqname +'') FOR ['' + @PK + '']'';
		else if @PKtype = ''C''
			SET @sql = @sql + ''(RIGHT(SPACE(''+cast(@PKsize as nvarchar)+'') + cast((NEXT VALUE FOR '' + @seqname +'') as varchar), ''+cast(@PKsize as nvarchar)+'')) FOR ['' + @PK + '']'';
		EXEC (@sql)
	end;
')

	
if exists(select * from sysobjects where type = 'P' and name = 'ApagarTodosIndicesTmp')
	DROP PROCEDURE ApagarTodosIndicesTmp
EXEC ('CREATE PROCEDURE ApagarTodosIndicesTmp
	@NomeTabela NVARCHAR(300), @sistema NVARCHAR(10), @pkName NVARCHAR(150) = ''''
	AS
	set nocount on
	DECLARE @sql NVARCHAR(MAX);
	DECLARE @Hasfilestream bit;
	SET @Hasfilestream = 0;
	SET @NomeTabela = UPPER(@NomeTabela);
	SET @sistema = UPPER(@sistema);
	
	-- ir buscar o nome actual da chave primária
	declare @pkNameNow nvarchar(150)
	set @pkNameNow = ''''
	if (@pkName != '''')
		SELECT @pkNameNow = COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + ''.'' + CONSTRAINT_NAME), ''IsPrimaryKey'') = 1 AND TABLE_NAME = @NomeTabela AND TABLE_SCHEMA = ''dbo''
	
	if (@Hasfilestream = 0)
	begin
		if (@pkName = '''' OR (@pkName != '''' AND UPPER(@pkNameNow) != UPPER(@pkName))) -- só apagar a chave primária se mudar de nome ou caso seja obrigado
		begin
	-- Drop primary keys
				SET @sql = N'''';
				SELECT @sql = @sql + N''ALTER TABLE ''
				  + QUOTENAME(OBJECT_SCHEMA_NAME([parent_object_id]))
				  + ''.'' + QUOTENAME(OBJECT_NAME([parent_object_id])) 
				  + '' DROP CONSTRAINT '' + QUOTENAME(name) + ''; ''
				FROM sys.key_constraints 
				WHERE [type] = ''PK''
					AND OBJECTPROPERTY([parent_object_id], ''IsMsShipped'') = 0 
					AND UPPER(OBJECT_NAME([parent_object_id])) = @NomeTabela;

				EXEC sp_executesql @sql;
		end
	end
	
	-- Non-clustered indexes
	SET @sql = N'''';
	SELECT @sql = @sql + N''DROP INDEX ''
	  + QUOTENAME(name) + '' ON ''
	  + QUOTENAME(OBJECT_SCHEMA_NAME([object_id]))
	  + ''.'' + QUOTENAME(OBJECT_NAME([object_id])) + ''; ''
	FROM sys.indexes 
	WHERE index_id > 0
		AND OBJECTPROPERTY([object_id], ''IsMsShipped'') = 0 
		AND UPPER(OBJECT_NAME([object_id])) = @NomeTabela -- só objectos da tabela do parametro
		AND [type] != 1 --só objectos que não sejam chave primária
		AND (name LIKE (@NomeTabela + ''%'') OR name LIKE (@sistema + ''%'')); --só objectos que tenham como prefixo o nome da tabela ou o nome do sistema

	EXEC sp_executesql @sql;')
	
if exists(select * from sysobjects where type = 'P' and name = 'AlinharCmpDireitaTmp')
	DROP PROCEDURE AlinharCmpDireitaTmp
EXEC ('CREATE PROCEDURE AlinharCmpDireitaTmp
	@NomeTabela NVARCHAR(300),
	@name VARCHAR(300),
	@length VARCHAR(25),
	@location VARCHAR(25),
	@type VARCHAR(25)
	AS
	set nocount on
	if (@location = ''FF_DIREITA'' and @type in (''dbText'', ''dbMemo''))
	begin
		EXEC (''UPDATE ['' + @NomeTabela + ''] SET '' + @name + ''= space('' + @length + '' - len(LTRIM('' + @name + '')))+LTRIM('' + @name + '') WHERE LEN('' + @name + '')< replace('' + @length + '','''' '''', '''''''') AND LEN('' + @name + '')>0'')
		EXEC (''UPDATE ['' + @NomeTabela + ''] SET '' + @name + ''='''''''' where '' + @name + '' is null'')
	end')

if exists(select * from sysobjects where type = 'P' and name = 'AlterarCamposTmp')
	DROP PROCEDURE AlterarCamposTmp
EXEC ('CREATE PROCEDURE AlterarCamposTmp
	@NomeTabela NVARCHAR(300),
	@nameCampo VARCHAR(300),
	@tipoDados VARCHAR(25),
	@typeSQL VARCHAR(300),
	@length VARCHAR(25),
	@isKey bit = 0
	AS
	set nocount on
	--verificar se o tipo de dados são diferentes dos inseridos
	BEGIN TRY
		DECLARE @tipo varchar(50);
		DECLARE @len varchar(25);
		DECLARE @exist bit = 0;
		DECLARE @computed bit = 0;
		DECLARE @checksize bit = 0;
		DECLARE @defvalue nvarchar(max) = '''';

		-- check if the field exists and get its schema
		select TOP 1 @tipo = t.name, @exist = 1, @computed = c.iscomputed, 
			@len = CASE 
				WHEN t.name IN (''nvarchar'', ''nchar'') THEN convert(varchar, CASE WHEN  c.length = -1 THEN 8000 ELSE c.length/2 END)
				WHEN t.name IN (''varchar'', ''char'') THEN convert(varchar, CASE WHEN c.length = -1 THEN 8000 ELSE c.length END)
				WHEN t.name IN (''decimal'') THEN (CAST(c.prec AS VARCHAR) +  '','' + CAST(c.scale AS VARCHAR))
				ELSE convert(varchar, c.length) END
			from sys.syscolumns c 
			inner join sys.sysobjects o on o.id = c.id
			inner join sys.systypes t on t.xusertype = c.xusertype
			where o.name = @NomeTabela and c.name = @nameCampo;
			
		-- only some types need to check their size qualifier (most its the data type itself that changes)
		if(@tipo in (''nvarchar'', ''nchar'', ''varchar'', ''char'', ''decimal'', ''datetime2'')) SET @checksize = 1;

		--if the columns is a computed column, then we should delete it first
		if(@computed = 1)
			EXEC (''ALTER TABLE ['' + @NomeTabela + ''] DROP COLUMN "'' + @nameCampo + ''" '')

		--add the column if it doesn''t exist in the table
		if (@exist = 0 OR @computed = 1)
		begin
			if (@tipoDados in (''float'',''real'',''decimal'',''tinyint'',''smallint'',''int'',''bigint'') AND @isKey = 0)
				set @defvalue = '' DEFAULT 0 WITH VALUES'';
			EXEC(''ALTER TABLE ['' + @NomeTabela + ''] ADD "'' + @nameCampo + ''" '' + @typeSQL + @defvalue);
		end
		--modify the column if it already exists in the table
		else
		begin
			DECLARE @sql nvarchar(max);
			
			--check if the data type or its properties are different from the requested ones
			if (@tipo != lower(replace(@tipoDados,'' '','''')) OR (@checksize = 1 AND @len != replace(@length,'' '', '''')))
			begin
				--there can be default contraints that need to be dropped before we can alter the column type
				EXEC dbo.DropConstraintsTmp @NomeTabela, @nameCampo;

				--alter the column type in the table
				set @sql = ''ALTER TABLE ['' + @NomeTabela + ''] ALTER COLUMN "'' + @nameCampo + ''" '' + @typeSQL;
				EXEC sp_executesql @sql;

				--after we alter the field type we need to recreate the contraints
				if (@tipoDados in (''float'',''real'',''decimal'',''tinyint'',''smallint'',''int'',''bigint'')  AND @isKey = 0)
				begin
					set @sql = ''ALTER TABLE ['' + @NomeTabela + ''] ADD DEFAULT 0 FOR "''+ @nameCampo +''"''
					EXEC sp_executesql @sql;
				end
			end
		end	END TRY
	BEGIN CATCH
		declare @erro as nvarchar (4000)
		set @erro = ''Error while changing the column '' + @nameCampo + '' on table '' + @NomeTabela + '': '' + CHAR(13) + ERROR_MESSAGE()
		RAISERROR (@erro, 16, -1)
	END CATCH')

if exists(select * from sysobjects where type = 'FN' and name = 'ConcatenarGroupByTmp')
	DROP Function ConcatenarGroupByTmp;
if exists(select * from sysobjects where type = 'P' and name = 'CheckIdxTmp')
	DROP PROCEDURE CheckIdxTmp;
IF TYPE_ID(N'IndexCheckType') IS NOT NULL
	DROP TYPE IndexCheckType;
EXEC ('CREATE TYPE IndexCheckType AS TABLE 
(idxName varchar(1000), columnName varchar(1000), uniqueIdx int, ordem int, include int, pk int);')

EXEC ('create function dbo.ConcatenarGroupByTmp(@tabela IndexCheckType READONLY, @indexName varchar(1000), @include int)
returns varchar(5000)
as
begin
	--juntar todas as opções de um determinado grupo na mesma row separados por '',''
	declare @out varchar(5000)
	select	@out = coalesce(@out + '',['' + convert(varchar(1000),columnName) + '']'', ''['' + convert(varchar(1000),columnName) + '']'')
	from	@tabela
	where	idxName = @indexName and include = @include
	return @out
end')

EXEC ('CREATE PROCEDURE CheckIdxTmp
@tabela IndexCheckType READONLY,
@tableName nvarchar(128),
@idxPKName nvarchar(250),
@sistema nvarchar(10)
AS
set nocount on
DECLARE @sql as nvarchar(max);
--SELECIONAR TODOS OS INDICES QUE ESTÃO CRIADOS
DECLARE @tblOriginal TABLE (idxName varchar(1000), columnName varchar(1000), uniqueIdx int, ordem int, include int, pk int)
insert @tblOriginal
	SELECT i.name, c.name, indexproperty(o.[object_id], i.name, ''IsUnique''), ik.key_ordinal, ik.is_included_column, i.is_primary_key 
	FROM sys.objects o
	JOIN sys.indexes i ON i.[object_id] = o.[object_id]
	JOIN sys.index_columns ik ON ik.[object_id] = i.[object_id] AND ik.index_id = i.index_id
	JOIN sys.columns c ON c.[object_id] = ik.[object_id] AND c.column_id = ik.column_id
	WHERE indexproperty(o.[object_id], i.name, ''IsStatistics'') = 0 AND indexproperty(o.[object_id], i.name, ''IsHypothetical'') = 0 
	AND o.name = @tableName AND (i.name like @sistema + ''%'')

--QUERY QUE INDICA TODOS OS INDICES QUE ESTÃO DIFERENTES E TÊM DE SER APAGADOS
DECLARE @apagarIdx TABLE (idxName varchar(1000), columnName varchar(1000), uniqueIdx int, ordem int, include int, pk int)
insert @apagarIdx
SELECT t.*
       FROM @tabela as t 
	   INNER JOIN @tblOriginal as ix ON (t.idxName = ix.idxName)
	   LEFT JOIN @tblOriginal as o
             ON (t.idxName = o.idxName 
          AND t.columnName = o.columnName
					AND t.uniqueIdx = o.uniqueIdx
					AND t.ordem = o.ordem
					AND t.include = o.include)
       WHERE o.idxName IS NULL AND t.idxName != @idxPKName
insert @apagarIdx
SELECT o.*
       FROM @tblOriginal as o LEFT JOIN @tabela as t
             ON (o.idxName = t.idxName
          AND o.columnName = t.columnName
					AND o.uniqueIdx = t.uniqueIdx
					AND o.ordem = t.ordem
					AND o.include = t.include)
       WHERE t.idxName IS NULL AND t.idxName != @idxPKName
      
if(exists (select idxName from @apagarIdx))
begin
  SET @sql = N'''';
 SELECT @sql = @sql + CAST(
             CASE 
                  WHEN pk = 1 THEN ''ALTER TABLE '' + @tableName + '' DROP CONSTRAINT '' + idxName + ''; ''
				  ELSE ''DROP INDEX '' + idxName + '' ON '' + @tableName + ''; ''
             END AS nvarchar(max))
 FROM (select distinct idxName, pk from @apagarIdx) as tbl

 EXEC sp_executesql @sql;
end

  --QUERY QUE INDICA TODOS OS INDICES QUE ESTÃO DIFERENTES E TÊM DE SER CRIADOS
  DECLARE @dummyRdxTmp as IndexCheckType;
  insert into @dummyRdxTmp (idxName, columnName, uniqueIdx, ordem, include)
  select idxName, columnName, uniqueIdx, ordem, include from @tabela as t where idxName not in (
        select isnull(i.name COLLATE SQL_Latin1_General_CP1_CI_AI,'''') FROM sys.objects o JOIN sys.indexes i ON i.[object_id] = o.[object_id] where  
        indexproperty(o.[object_id], i.name, ''IsStatistics'') = 0
        AND indexproperty(o.[object_id], i.name, ''IsHypothetical'') = 0
        and o.name = @tableName)
    AND t.idxName != @idxPKName

SET @sql = N'''';
SELECT @sql = @sql +  CAST(
             CASE 
                  WHEN idxName = @idxPKName THEN ''ALTER TABLE '' + @tableName + '' ADD CONSTRAINT '' + idxName + '' PRIMARY KEY ('' + columnName + ''); ''
				  WHEN (includeName is null or len(rtrim(includeName)) = 0) THEN (''CREATE '' + CASE WHEN uniqueIdx = 1 THEN ''UNIQUE '' ELSE '''' END + ''INDEX '' + idxName + '' ON '' + @tableName + '' ('' + columnName + ''); '')
				  ELSE ''CREATE '' + CASE WHEN uniqueIdx = 1 THEN ''UNIQUE '' ELSE '''' END + ''INDEX '' + idxName + '' ON '' + @tableName + '' ('' + columnName + '') INCLUDE ('' + includeName + ''); ''
             END AS nvarchar(max))
FROM (select distinct idxName, dbo.ConcatenarGroupByTmp(@dummyRdxTmp, idxName, 0) as columnName, uniqueIdx, dbo.ConcatenarGroupByTmp(@dummyRdxTmp, idxName, 1) as includeName from @dummyRdxTmp) AS tbl

EXEC sp_executesql @sql;')
GO
if exists(select * from sysobjects where type = 'P' and name = 'DropColumnsTmp')
	DROP PROCEDURE DropColumnsTmp
IF TYPE_ID(N'DropColumnType') IS NOT NULL
	DROP TYPE DropColumnType;
EXEC ('CREATE TYPE DropColumnType AS TABLE (name VARCHAR(300));')
EXEC ('CREATE PROCEDURE DropColumnsTmp
@tabela DropColumnType READONLY,
@tableName nvarchar(128)
AS
set nocount on
declare @result nvarchar(MAX)
select @result = COALESCE(@result + '','', '''') + ''['' + TblToRemove.name + '']'' 
from (
	select Col.name
	from sysobjects as Tbl inner join syscolumns as Col on Tbl.id = Col.id 
	where Tbl.name = @tableName and Col.name COLLATE SQL_Latin1_General_CP1_CI_AI not in (select name from @tabela)) as TblToRemove

if (@result != '''')
BEGIN
	declare @constraints nvarchar(MAX)

	SELECT @constraints = COALESCE(@constraints + '','', '''') + ''['' + obj_Constraint.NAME + '']''
        FROM   sys.objects obj_table 
        JOIN sys.objects obj_Constraint ON obj_table.object_id = obj_Constraint.parent_object_id 
        JOIN sys.default_constraints constraints ON constraints.object_id = obj_Constraint.object_id -- changed from sysconstraints because when number of columns is bigger than smallint, the view produces an error
        JOIN sys.columns columns ON columns.object_id = obj_table.object_id AND columns.column_id = constraints.parent_column_id
    WHERE obj_table.NAME=@tableName AND columns.NAME COLLATE SQL_Latin1_General_CP1_CI_AI not in (select name from @tabela)

	if (@constraints != '''')
		EXEC(''ALTER TABLE ['' + @tableName + ''] DROP CONSTRAINT '' + @constraints);

	/* If it detects indexes associated with the columns to be removed, it removes them */
	declare @indexes nvarchar(MAX)
	select @indexes = COALESCE(@indexes + char(10), '''') + ''Drop INDEX ['' +  sysindex.name + ''] On '' +@tableName
	From sys.indexes As SysIndex
		Inner Join sys.index_columns As SysIndexCol On SysIndex.object_id = SysIndexCol.object_id And SysIndex.index_id = SysIndexCol.index_id 
		Inner Join sys.columns As SysCols On SysIndexCol.column_id = SysCols.column_id And SysIndexCol.object_id = SysCols.object_id 
	Where 
		type <> 0 
		And SysIndex.object_id in (Select systbl.object_id from sys.tables as systbl Where SysTbl.name = @tableName)
		and  SysCols.name COLLATE SQL_Latin1_General_CP1_CI_AI not in (select name from @tabela)
	
	if (@indexes != '''')
		EXEC(@indexes);

	EXEC (''ALTER TABLE ['' + @tableName + ''] DROP COLUMN '' + @result);
END');
GO
if exists(select * from sysobjects where type = 'P' and name = 'DropConstraintsTmp')
	DROP PROCEDURE DropConstraintsTmp
EXEC ('CREATE PROCEDURE DropConstraintsTmp
@tableName nvarchar(128),
@columnName nvarchar(128)
AS
BEGIN
	set nocount on
	declare @constraints nvarchar(MAX)
	SELECT @constraints = COALESCE(@constraints + '','', '''') + ''['' + obj_Constraint.NAME + '']''
    FROM   sys.objects obj_table 
        JOIN sys.objects obj_Constraint ON obj_table.object_id = obj_Constraint.parent_object_id 
        JOIN sys.default_constraints constraints ON constraints.object_id = obj_Constraint.object_id -- changed from sysconstraints because when number of columns is bigger than smallint, the view produces an error
        JOIN sys.columns columns ON columns.object_id = obj_table.object_id AND columns.column_id = constraints.parent_column_id
    WHERE obj_table.NAME=@tableName AND columns.NAME COLLATE SQL_Latin1_General_CP1_CI_AI = @columnName
	if (@constraints != '''')
		EXEC(''ALTER TABLE ['' + @tableName + ''] DROP CONSTRAINT '' + @constraints);
END');
GO
if exists(select * from sysobjects where type = 'P' and name = 'BackupComputedColumns')
	DROP PROCEDURE BackupComputedColumns
EXEC ('CREATE PROCEDURE BackupComputedColumns
AS
BEGIN
	IF OBJECT_ID(''tempdb.dbo.##save_computed_definitions'', ''U'') IS NOT NULL
		drop table ##save_computed_definitions;

	SELECT t.[Name] as table_name, cc.[name] as column_name, cc.[definition]
	into ##save_computed_definitions
	FROM sys.computed_columns cc
	INNER JOIN sysobjects t ON cc.object_id = t.id AND t.xtype = ''U'';

	DECLARE @sqlDrop nvarchar(max) = N'''';
	DECLARE @sqlAdd nvarchar(max) = N'''';

	SELECT @sqlDrop = @sqlDrop + N''ALTER TABLE '' + QUOTENAME(table_name)
		+ '' DROP COLUMN '' + QUOTENAME(column_name) + ''; ''
	FROM ##save_computed_definitions;

	EXEC sp_executesql @sqlDrop;

	SELECT @sqlAdd = @sqlAdd + N''ALTER TABLE '' + QUOTENAME(table_name)
		+ '' ADD '' + QUOTENAME(column_name) 
		+ '' AS ''''''''; ''
	FROM ##save_computed_definitions;

	EXEC sp_executesql @sqlAdd;
END');
GO
if exists(select * from sysobjects where type = 'P' and name = 'RestoreComputedColumns')
	DROP PROCEDURE RestoreComputedColumns
EXEC ('CREATE PROCEDURE RestoreComputedColumns
AS
BEGIN
	DECLARE @sqlDrop nvarchar(max) = N'''';
	DECLARE @sqlAdd nvarchar(max) = N'''';

	SELECT @sqlDrop = @sqlDrop + N''ALTER TABLE '' + QUOTENAME(table_name)
		+ '' DROP COLUMN '' + QUOTENAME(column_name) + ''; ''
	FROM ##save_computed_definitions;

	EXEC sp_executesql @sqlDrop;

	SELECT @sqlAdd = @sqlAdd + N''ALTER TABLE '' + QUOTENAME(table_name)
		+ '' ADD '' + QUOTENAME(column_name) 
		+ '' AS '' + [definition]
		+ ''; ''
	FROM ##save_computed_definitions;

	EXEC sp_executesql @sqlAdd;

	drop table ##save_computed_definitions;
END');
GO
if exists(select * from sysobjects where type = 'P' and name = 'estrutura_dinamica')
	DROP PROCEDURE estrutura_dinamica
EXEC ('create PROCEDURE estrutura_dinamica
as
begin
	DECLARE @nometabela VARCHAR(25)
	DECLARE @nomecampo VARCHAR(25)
	DECLARE @tipodados VARCHAR(15)
	DECLARE @tiposql VARCHAR(15)
	DECLARE @largura int
	DECLARE tableFields CURSOR STATIC FOR
	SELECT nometabela, nomecampo, tipodados, tiposql, largura from [AJFTABDINAMIC] where zzstate = 0
	OPEN tableFields
	FETCH NEXT FROM tableFields INTO @nometabela, @nomecampo, @tipodados, @tiposql, @largura
	WHILE @@fetch_status = 0
	BEGIN
		exec AlterarCamposTmp @nometabela, @nomecampo, @tipodados, @tiposql, @largura;
	FETCH NEXT FROM tableFields INTO @nometabela, @nomecampo, @tipodados, @tiposql, @largura
	END
	CLOSE tableFields
	DEALLOCATE tableFields
end');
GO
