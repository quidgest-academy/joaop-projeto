use [W_GnBD]

--converter o antigo schema de logins para o novo
--caso a tabela antiga de psw ainda exista então vamos migrar os dados e no fim apagamos/renomeamos a tabela
if exists(SELECT top 1 name FROM sysobjects where name = 'AJFPSW')
begin
	insert into UserLogin (CODPSW, NOME, PASSWORD, PSWTYPE, DATAPSW, CERTSN, ZZSTATE)
	select CODPSW, NOME, PASSWORD, 'QH', GETDATE(), CERTSN, ZZSTATE from AJFPSW;

--para codigos internos
	if (not exists(select id_objecto from Codigos_Sequenciais where id_objecto='UserAuthorization'))
		insert into Codigos_Sequenciais (id_objecto, proximo) values ('UserAuthorization', 1)

	declare @codtbl table (cod int);
	declare @bs int;
	declare @cod int;
	SELECT @bs = count(1) from AJFpsw;
	insert into @codtbl exec UpdateCod 'UserAuthorization', @bs;
	select @cod = cod from @codtbl;
BEGIN TRY	
	insert into UserAuthorization (CODUA, CODPSW, SISTEMA, MODULO, NIVEL, ZZSTATE)
	select STR(@cod - 1 + ROW_NUMBER() OVER (ORDER BY codpsw), 6), CODPSW, 'AJF', 'AJF', [AJF], 0 from AJFPSW;
END TRY
BEGIN CATCH
END CATCH;
	EXEC sp_rename 'AJFPSW', 'backupAJFPSW'
end
GO

--caso a tabela antiga de docums ainda exista então vamos migrar os dados e no fim apagamos/renomeamos a tabela
if exists(SELECT top 1 name FROM sysobjects where name = 'AJFDOCUMS')
begin
	INSERT INTO DOCUMS ([coddocums],[documid],[document],[docpath],[tabela],[campo],[chave],[form],[nome],[versao],[tamanho],[extensao],[opercria],[datacria],[opermuda],[datamuda],[ZZSTATE])
	SELECT [coddocums],[documid],[document],[docpath],[tabela],[campo],[chave],[form],[nome],[versao],[tamanho],[extensao],[opercria],[datacria],[opermuda],[datamuda],[ZZSTATE] FROM AJFDOCUMS
	EXEC sp_rename 'AJFDOCUMS', 'backupAJFDOCUMS'
end
GO

--caso a tabela antiga de hashcd ainda exista então vamos migrar os dados e no fim apagamos/renomeamos a tabela
if exists(SELECT top 1 name FROM sysobjects where name = 'AJFhashcd')
begin
	INSERT INTO hashcd ([tabela],[campos],[datacria],[ZZSTATE],[codhashcd])
	SELECT [tabela],[campos],[datacria],[ZZSTATE],[codhashcd] FROM AJFhashcd
	EXEC sp_rename 'AJFhashcd', 'backupAJFhashcd'
end
GO

if (object_id(N'[dbo].[FillHashcd]', 'P') is not null) drop procedure [dbo].[FillHashcd]
EXEC ('CREATE PROCEDURE dbo.FillHashcd
AS
BEGIN
  DECLARE @o_proximo int = 0
  DECLARE @_campos varchar(max) = '''', @_ccampos varchar(max) = ''''
  DECLARE @codHashcd bigint
END')
GO

EXEC dbo.FillHashcd
GO

if (object_id(N'[dbo].[UpdateUserSettingsFormat_0_1]', 'P') is not null) drop procedure [dbo].[UpdateUserSettingsFormat_0_1]
EXEC ('CREATE PROCEDURE dbo.UpdateUserSettingsFormat_0_1
AS
BEGIN
UPDATE AJFtblcfg SET CONFIG = 
REPLACE(
REPLACE(
REPLACE(
REPLACE(
REPLACE(
REPLACE(
REPLACE(
REPLACE(
REPLACE(
REPLACE(
REPLACE(
REPLACE(
REPLACE(
REPLACE(
REPLACE(
REPLACE(
REPLACE(
REPLACE(
REPLACE(
REPLACE(
REPLACE(
REPLACE(
CONFIG, 
''~'', ''|~|''), 
''"'', ''~"''), 
''\~"Name\~"'', ''"name"''), 
''\~"Active\~"'', ''"active"''), 
''\~"Conditions\~"'', ''"conditions"''), 
''\~"Field\~"'', ''"field"''), 
''\~"Operator\~"'', ''"operator"''), 
''\~"Values\~"'', ''"values"''), 
''\~"'', ''"''), 
''~"advancedFilters~"'', ''"advancedFilters"''), 
''~"columnFilters~"'', ''"columnFilters"''), 
''~"groupFilterValues~"'', ''"staticFilters"''), 
''~"activeFilter~"'', ''"activeFilter"''), 
''~"initialSortColumn~"'', ''"columnOrderBy"''), 
''~"perPage~"'', ''"rowsPerPage"''), 
''~"defaultSearchColumn~"'', ''"defaultSearchColumn"''), 
''~"columnOrder~"'', ''"columnConfiguration"''), 
''~"columnSizes~"'', ''"columnSizes"''), 
''~"hasTextWrap~"'', ''"lineBreak"''),
''\\'', ''\''),
''~"'', ''''),
''|~|'', ''~'') 
UPDATE AJFcfg SET usrsetv = 1
END')
GO

if (object_id(N'[dbo].[UpdateUserSettingsFormat_1_2]', 'P') is not null) drop procedure [dbo].[UpdateUserSettingsFormat_1_2]
EXEC ('CREATE PROCEDURE dbo.UpdateUserSettingsFormat_1_2
AS
BEGIN
UPDATE AJFtblcfg SET usrsetv = 1
UPDATE AJFcfg SET usrsetv = 2
END')
GO

DECLARE @usrsetv INT
SELECT @usrsetv = usrsetv FROM dbo.AJFcfg
IF @usrsetv = '0'
EXEC dbo.UpdateUserSettingsFormat_0_1
GO
DECLARE @usrsetv INT
SELECT @usrsetv = usrsetv FROM dbo.AJFcfg
IF @usrsetv = '1'
EXEC dbo.UpdateUserSettingsFormat_1_2
GO
