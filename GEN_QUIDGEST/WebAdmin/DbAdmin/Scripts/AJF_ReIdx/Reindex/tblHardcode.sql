



		
 
USE [W_GnBD]

if exists(SELECT top 1 name FROM sysobjects where name = 'Codigos_Int_Modulos')
	DROP TABLE Codigos_Int_Modulos
if exists(SELECT top 1 name FROM sysobjects where name = 'Codigos_Internos')
	DROP TABLE Codigos_Internos

if not exists(SELECT top 1 name FROM sysobjects where name = 'Codigos_Sequenciais')
	EXEC ('CREATE TABLE Codigos_Sequenciais ( [id_objecto] varchar(50) NOT NULL ) ');
exec AlterarCamposTmp 'Codigos_Sequenciais', 'id_objecto', 'varchar', 'VARCHAR(50) NOT NULL', 50
if not exists (select * from sysobjects where xtype = 'PK' and parent_obj = (select id from sysobjects where name = 'Codigos_Sequenciais'))
	ALTER TABLE Codigos_Sequenciais ADD CONSTRAINT CODIGOS_SEQUENCIAIS_PK PRIMARY KEY(id_objecto)
exec AlterarCamposTmp 'Codigos_Sequenciais', 'proximo', 'bigint', 'BIGINT', '10'
GO


exec CriarTabelaTmp 'AJFmem','codmem','I', 8
exec ApagarTodosIndicesTmp 'AJFmem','AJF','codmem'
exec AlterarCamposTmp 'AJFmem', 'codmem', 'int', 'INT NOT NULL', '8'
exec AlterarCamposTmp 'AJFmem', 'login', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'AJFmem', 'altura', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFmem', 'rotina', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'AJFmem', 'obs', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'AJFmem', 'hostid', 'varchar', 'VARCHAR(20)', '20'
exec AlterarCamposTmp 'AJFmem', 'clientid', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFmem', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO
exec CriarTabelaTmp 'AJFcfg','codcfg','I', 6
exec ApagarTodosIndicesTmp 'AJFcfg','AJF','codcfg'
exec AlterarCamposTmp 'AJFcfg', 'checkdat', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFcfg', 'versao', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFcfg', 'versindx', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFcfg', 'manutdat', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFcfg', 'upgrindx', 'int', 'INT', '5'
exec AlterarCamposTmp 'AJFcfg', 'usrsetv', 'int', 'INT', '5'
exec AlterarCamposTmp 'AJFcfg', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'AJFtblcfg','CODTBLCFG','I', 8
exec ApagarTodosIndicesTmp 'AJFtblcfg','AJF','CODTBLCFG'
exec AlterarCamposTmp 'AJFtblcfg', 'CODPSW', 'int', 'INT', '8'
exec AlterarCamposTmp 'AJFtblcfg', 'UUID', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFtblcfg', 'NAME', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFtblcfg', 'CONFIGID', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'AJFtblcfg', 'CONFIG', 'varchar', 'VARCHAR(MAX)', 'MAX'
exec AlterarCamposTmp 'AJFtblcfg', 'USRSETV', 'int', 'INT', '5'
exec AlterarCamposTmp 'AJFtblcfg', 'DATE', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFtblcfg', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'AJFtblcfgsel','CODTBLCFGSEL','I', 8
exec ApagarTodosIndicesTmp 'AJFtblcfgsel','AJF','CODTBLCFGSEL'
exec AlterarCamposTmp 'AJFtblcfgsel', 'CODPSW', 'int', 'INT', '8'
exec AlterarCamposTmp 'AJFtblcfgsel', 'UUID', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFtblcfgsel', 'CODTBLCFG', 'int', 'INT', '8'
exec AlterarCamposTmp 'AJFtblcfgsel', 'DATE', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFtblcfgsel', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'AJFlstusr','CODLSTUSR','I', 8
exec ApagarTodosIndicesTmp 'AJFlstusr','AJF','CODLSTUSR'
exec AlterarCamposTmp 'AJFlstusr', 'CODPSW', 'int', 'INT', '8'
exec AlterarCamposTmp 'AJFlstusr', 'DESCRIC', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFlstusr', 'IDLIST', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFlstusr', 'MODULO', 'varchar', 'VARCHAR(3)', '3'
exec AlterarCamposTmp 'AJFlstusr', 'SISTEMA', 'varchar', 'VARCHAR(3)', '3'
exec AlterarCamposTmp 'AJFlstusr', 'ORDERCOL', 'int', 'INT', '2'
exec AlterarCamposTmp 'AJFlstusr', 'ORDERTYPE', 'int', 'INT', '2'
exec AlterarCamposTmp 'AJFlstusr', 'DATA', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFlstusr', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'AJFlstcol','CODLSTCOL','I', 8
exec ApagarTodosIndicesTmp 'AJFlstcol','AJF','CODLSTCOL'
exec AlterarCamposTmp 'AJFlstcol', 'CODLSTUSR', 'int', 'INT', '8'
exec AlterarCamposTmp 'AJFlstcol', 'TABELA', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFlstcol', 'ALIAS', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'AJFlstcol', 'CAMPO', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFlstcol', 'VISIVEL', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFlstcol', 'POSICAO', 'int', 'INT', '2'
exec AlterarCamposTmp 'AJFlstcol', 'OPERACAO', 'int', 'INT', '2'
exec AlterarCamposTmp 'AJFlstcol', 'TIPO', 'int', 'INT', '2'
exec AlterarCamposTmp 'AJFlstcol', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'AJFlstren','CODLSTREN','I', 8
exec ApagarTodosIndicesTmp 'AJFlstren','AJF','CODLSTREN'
exec AlterarCamposTmp 'AJFlstren', 'CODLSTUSR', 'int', 'INT', '8'
exec AlterarCamposTmp 'AJFlstren', 'RENDERIZACAO', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFlstren', 'VISIVEL', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFlstren', 'POSICAO', 'int', 'INT', '2'
exec AlterarCamposTmp 'AJFlstren', 'OPERACAO', 'int', 'INT', '2'
exec AlterarCamposTmp 'AJFlstren', 'TIPO', 'int', 'INT', '2'
exec AlterarCamposTmp 'AJFlstren', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'AJFusrwid','CODUSRWID','I', 8
exec ApagarTodosIndicesTmp 'AJFusrwid','AJF','CODUSRWID'
exec AlterarCamposTmp 'AJFusrwid', 'CODLSTUSR', 'int', 'INT', '8'
exec AlterarCamposTmp 'AJFusrwid', 'WIDGET', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFusrwid', 'ROWKEY', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFusrwid', 'VISIBLE', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFusrwid', 'HPOSITION', 'int', 'INT', '2'
exec AlterarCamposTmp 'AJFusrwid', 'VPOSITION', 'int', 'INT', '2'
exec AlterarCamposTmp 'AJFusrwid', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'AJFusrcfg','codusrcfg','I', 6
exec ApagarTodosIndicesTmp 'AJFusrcfg','AJF','codusrcfg'
exec AlterarCamposTmp 'AJFusrcfg', 'modulo', 'varchar', 'VARCHAR(3)', '3'

exec AlterarCamposTmp 'AJFusrcfg', 'codpsw', 'int', 'INT', '8'
exec AlterarCamposTmp 'AJFusrcfg', 'tipo', 'varchar', 'VARCHAR(2)', '2'
exec AlterarCamposTmp 'AJFusrcfg', 'id', 'varchar', 'VARCHAR(15)', '15'
exec AlterarCamposTmp 'AJFusrcfg', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'AJFusrset','codusrset','I', 6
exec ApagarTodosIndicesTmp 'AJFusrset','AJF','codusrset'
exec AlterarCamposTmp 'AJFusrset', 'modulo', 'varchar', 'VARCHAR(3)', '3'
exec AlterarCamposTmp 'AJFusrset', 'codpsw', 'int', 'INT', '8'
exec AlterarCamposTmp 'AJFusrset', 'chave', 'varchar', 'VARCHAR(30)', '30'
exec AlterarCamposTmp 'AJFusrset', 'valor', 'varchar', 'VARCHAR(4000)', '4000'
exec AlterarCamposTmp 'AJFusrset', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'AJFwkfact','codwkfact','I',  6
exec ApagarTodosIndicesTmp 'AJFwkfact','AJF','codwkfact'
exec AlterarCamposTmp 'AJFwkfact', 'wfid', 'varchar', 'VARCHAR(6)', '6'
exec AlterarCamposTmp 'AJFwkfact', 'actid', 'int', 'INT', ''
exec AlterarCamposTmp 'AJFwkfact', 'tpactid', 'varchar', 'VARCHAR(6)', '6'
exec AlterarCamposTmp 'AJFwkfact', 'descrica', 'varchar', 'VARCHAR(40)', '40'
exec AlterarCamposTmp 'AJFwkfact', 'duracao', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFwkfact', 'perfil', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFwkfact', 'perfilu', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFwkfact', 'x', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFwkfact', 'y', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFwkfact', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'AJFwkfcon','codwkfcon','I', 6
exec ApagarTodosIndicesTmp 'AJFwkfcon','AJF','codwkfcon'
exec AlterarCamposTmp 'AJFwkfcon', 'wfid', 'varchar', 'VARCHAR(6)', '6'
exec AlterarCamposTmp 'AJFwkfcon', 'condid', 'int', 'INT', ''
exec AlterarCamposTmp 'AJFwkfcon', 'tpcondid', 'varchar', 'VARCHAR(6)', '6'
exec AlterarCamposTmp 'AJFwkfcon', 'descrica', 'varchar', 'VARCHAR(40)', '40'
exec AlterarCamposTmp 'AJFwkfcon', 'tiporegr', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFwkfcon', 'sinal', 'varchar', 'VARCHAR(6)', '6'
exec AlterarCamposTmp 'AJFwkfcon', 'x', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFwkfcon', 'y', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFwkfcon', 'valor', 'varchar', 'VARCHAR(30)', '30'
exec AlterarCamposTmp 'AJFwkfcon', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'AJFwkflig','codwkflig','I',6
exec ApagarTodosIndicesTmp 'AJFwkflig','AJF','codwkflig'
exec AlterarCamposTmp 'AJFwkflig', 'wfid', 'varchar', 'VARCHAR(6)', '6'
exec AlterarCamposTmp 'AJFwkflig', 'parentid', 'int', 'INT', '6'
exec AlterarCamposTmp 'AJFwkflig', 'childid', 'int', 'INT', '6'
exec AlterarCamposTmp 'AJFwkflig', 'ptoy', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFwkflig', 'ptox', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFwkflig', 'ptor', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFwkflig', 'tipo', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFwkflig', 'pfromx', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFwkflig', 'pfromy', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFwkflig', 'pfromr', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFwkflig', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'AJFwkflow','codwkflow','I', 6
exec ApagarTodosIndicesTmp 'AJFwkflow','AJF','codwkflow'
exec AlterarCamposTmp 'AJFwkflow', 'descrica', 'varchar', 'VARCHAR(40)', '40'
exec AlterarCamposTmp 'AJFwkflow', 'modulo', 'varchar', 'VARCHAR(3)', '3'
exec AlterarCamposTmp 'AJFwkflow', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'AJFnotifi','codnotifi','I', 6
exec ApagarTodosIndicesTmp 'AJFnotifi','AJF','codnotifi'
exec AlterarCamposTmp 'AJFnotifi', 'modulo', 'varchar', 'VARCHAR(3)', '3'
exec AlterarCamposTmp 'AJFnotifi', 'descrica', 'varchar', 'VARCHAR(120)', '120'
exec AlterarCamposTmp 'AJFnotifi', 'activid', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFnotifi', 'menuid', 'varchar', 'VARCHAR(15)', '15'
exec AlterarCamposTmp 'AJFnotifi', 'usernivl', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFnotifi', 'wfid', 'varchar', 'VARCHAR(6)', '6'
exec AlterarCamposTmp 'AJFnotifi', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'AJFprmfrm','codprmfrm','I',6
exec ApagarTodosIndicesTmp 'AJFprmfrm','AJF','codprmfrm'
exec AlterarCamposTmp 'AJFprmfrm', 'desform', 'varchar', 'VARCHAR(8)', '8'
exec AlterarCamposTmp 'AJFprmfrm', 'perfil', 'varchar', 'VARCHAR(2)', '2'
exec AlterarCamposTmp 'AJFprmfrm', 'autoriza', 'varchar', 'VARCHAR(1)', '1'
exec AlterarCamposTmp 'AJFprmfrm', 'sevalida', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFprmfrm', 'prfvalid', 'varchar', 'VARCHAR(2)', '2'
exec AlterarCamposTmp 'AJFprmfrm', 'prazodia', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFprmfrm', 'comprova', 'varchar', 'VARCHAR(30)', '30'
exec AlterarCamposTmp 'AJFprmfrm', 'prazohor', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFprmfrm', 'secompro', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFprmfrm', 'mensag1', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'AJFprmfrm', 'mensag2', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'AJFprmfrm', 'mensag3', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'AJFprmfrm', 'mensag4', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'AJFprmfrm', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'AJFscrcrd','codscrcrd','I', 6 
exec ApagarTodosIndicesTmp 'AJFscrcrd','AJF','codscrcrd'
exec AlterarCamposTmp 'AJFscrcrd', 'descrica', 'varchar', 'VARCHAR(60)', '60'
exec AlterarCamposTmp 'AJFscrcrd', 'valor', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFscrcrd', 'cor', 'varchar', 'VARCHAR(1)', '1'
exec AlterarCamposTmp 'AJFscrcrd', 'seta', 'varchar', 'VARCHAR(1)', '1'
exec AlterarCamposTmp 'AJFscrcrd', 'usernivl', 'float', 'FLOAT(53)', '53'
exec AlterarCamposTmp 'AJFscrcrd', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

if exists(select name from sysobjects where xtype = 'u' and name = 'AJFdocums')
BEGIN
	exec CriarTabelaTmp 'AJFdocums','coddocums','I', 6
exec ApagarTodosIndicesTmp 'AJFdocums','AJF','coddocums'
	if (not exists(select * from sysobjects where xtype = 'PK' and parent_obj = (select id from sysobjects where name = 'AJFdocums') and name = 'AJFDOCUMS_CODDOCUMS'))
		ALTER TABLE [AJFdocums] ADD CONSTRAINT [AJFDOCUMS_CODDOCUMS] PRIMARY KEY(coddocums)
	
	exec AlterarCamposTmp 'AJFdocums', 'documid', 'int', 'INT', '8'

--Caso a versão anterior tenha sido gerada para sql2005, a coluna document será do tipo IMAGE.
--Ao passar de uma versão para a outra, forçar a filestream numa coluna já existente dá erro por limitação do próprio sql.
--Tem de ser criada uma nova coluna e os dados passados para ela
--Dropar a image e rename a nova coluna para document
IF (SELECT [DATA_TYPE] FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = 'AJFdocums' AND [COLUMN_NAME] = 'document') = 'image'
BEGIN
	SET ANSI_WARNINGS OFF;
	exec sp_RENAME 'AJFdocums.document', 'document_temp' , 'COLUMN';
	exec AlterarCamposTmp 'AJFdocums', 'document', 'varbinary', 'VARBINARY(MAX)', '';
	EXECUTE sp_executesql N'UPDATE [AJFdocums] set document = document_temp; ALTER TABLE [AJFdocums] DROP COLUMN document_temp;';
	SET ANSI_WARNINGS ON;
END
ELSE
BEGIN 
	IF (SELECT [DATA_TYPE] FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = 'AJFdocums' AND [COLUMN_NAME] = 'document') = 'varchar'
	BEGIN
		SET ANSI_WARNINGS OFF	;
		exec sp_RENAME 'AJFdocums.document', 'document_temp' , 'COLUMN';
		exec AlterarCamposTmp 'AJFdocums', 'document', 'varbinary', 'VARBINARY(MAX)', '';
		exec AlterarCamposTmp 'AJFdocums', 'docpath', 'varchar', 'VARCHAR(260)', '260';
		EXECUTE sp_executesql N'UPDATE [AJFdocums] set docpath = document_temp; ALTER TABLE [AJFdocums] DROP COLUMN document_temp;';
	END
	ELSE
	BEGIN
		exec AlterarCamposTmp 'AJFdocums', 'document', 'varbinary', 'VARBINARY(MAX)', ''
	END
END

exec AlterarCamposTmp 'AJFdocums', 'docpath', 'varchar', 'VARCHAR(260)', '260'

	exec AlterarCamposTmp 'AJFdocums', 'tabela', 'varchar', 'VARCHAR(30)', '30'
	exec AlterarCamposTmp 'AJFdocums', 'campo', 'varchar', 'VARCHAR(30)', '30'
	exec AlterarCamposTmp 'AJFdocums', 'chave', 'varchar', 'VARCHAR(36)', '36'
	exec AlterarCamposTmp 'AJFdocums', 'form', 'varchar', 'VARCHAR(8)', '8'
	exec AlterarCamposTmp 'AJFdocums', 'nome', 'varchar', 'VARCHAR(255)', '255'
	exec AlterarCamposTmp 'AJFdocums', 'versao', 'varchar', 'VARCHAR(10)', '10'
	exec AlterarCamposTmp 'AJFdocums', 'tamanho', 'float', 'FLOAT(53)', '10'
	exec AlterarCamposTmp 'AJFdocums', 'extensao', 'varchar', 'VARCHAR(5)', '5'
	exec AlterarCamposTmp 'AJFdocums', 'opercria', 'varchar', 'VARCHAR(100)', '100'
	exec AlterarCamposTmp 'AJFdocums', 'datacria', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'AJFdocums', 'opermuda', 'varchar', 'VARCHAR(100)', '100'
	exec AlterarCamposTmp 'AJFdocums', 'datamuda', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'AJFdocums', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
END
GO

--A tabela docums deixou de ter o prefixo do sistema, e passa a chamar-se apenas "docums" de forma a poder ser reutilizada por sistemas partilhados.
--Caso esta bd tenha mais do que um sistema, é necessário migrar os documentos de todos os sistemas, excepto do primeiro que reindexar a bd. Ou seja,
--o primeiro faz o rename da tabela (visto não mudar nada a nivel da estrutura da tabela) e os restantes fazem inserts.
--EDIT:Adaptei e retirei o código do ficheiro ActStoredProcFIM e coloquei aqui de forma a conseguir evitar migração / duplicação de dados para BD's com um único sistema.
--Como este script corre primeiro que o ActStoredProcFIM, a docums já vai estar criada nessa altura, com os respectivos indices e filestream, pelo que apagar a docums e renomear a AJFDocums 
--iria originar uma segunda reindexação para corrigir os indices.
IF EXISTS(SELECT top 1 name FROM sysobjects WHERE name = 'AJFdocums')
BEGIN
    IF EXISTS(SELECT top 1 name FROM sysobjects WHERE name = 'docums')
    BEGIN
        INSERT INTO DOCUMS ([coddocums],[documid],[document],[docpath],[tabela],[campo],[chave],[form],[nome],[versao],[tamanho],[extensao],[opercria],[datacria],[opermuda],[datamuda],[ZZSTATE])
        SELECT [coddocums],[documid],[document],[docpath],[tabela],[campo],[chave],[form],[nome],[versao],[tamanho],[extensao],[opercria],[datacria],[opermuda],[datamuda],[ZZSTATE] FROM [AJFDOCUMS]
        EXEC sp_rename 'AJFdocums', 'backupAJFdocums'
    END
    ELSE
    BEGIN
        EXEC sp_rename 'AJFdocums', 'docums'
        EXEC sp_rename 'AJFdocums_CODDOCUMS', 'DOCUMS_CODDOCUMS'
    END
END
GO

	exec CriarTabelaTmp 'docums','coddocums','I', 8
	exec ApagarTodosIndicesTmp 'docums','AJF','coddocums'

	if (not exists(select * from sysobjects where xtype = 'PK' and parent_obj = (select id from sysobjects where name = 'docums') and name = 'DOCUMS_CODDOCUMS'))
		ALTER TABLE docums ADD CONSTRAINT [DOCUMS_CODDOCUMS] PRIMARY KEY(coddocums)
	
	exec AlterarCamposTmp 'docums', 'documid', 'int', 'INT', '8'

--Caso a versão anterior tenha sido gerada para sql2005, a coluna document será do tipo IMAGE.
--Ao passar de uma versão para a outra, forçar a filestream numa coluna já existente dá erro por limitação do próprio sql.
--Tem de ser criada uma nova coluna e os dados passados para ela
--Dropar a image e rename a nova coluna para document
IF (SELECT [DATA_TYPE] FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = 'docums' AND [COLUMN_NAME] = 'document') = 'image'
BEGIN
	SET ANSI_WARNINGS OFF	;
	exec sp_RENAME 'docums.document', 'document_temp' , 'COLUMN';
	exec AlterarCamposTmp 'docums', 'document', 'varbinary', 'VARBINARY(MAX)', '';
	EXECUTE sp_executesql N'UPDATE docums set document = document_temp; ALTER TABLE docums DROP COLUMN document_temp;';
	SET ANSI_WARNINGS ON;
END
ELSE
BEGIN 
	IF (SELECT [DATA_TYPE] FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = 'docums' AND [COLUMN_NAME] = 'document') = 'varchar' or (SELECT [DATA_TYPE] FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE [TABLE_NAME] = 'docums' AND [COLUMN_NAME] = 'document') = 'nvarchar'
	BEGIN
		SET ANSI_WARNINGS OFF	;
		exec sp_RENAME 'docums.document', 'document_temp' , 'COLUMN';
		exec AlterarCamposTmp 'docums', 'document', 'varbinary', 'VARBINARY(MAX)', '';
		exec AlterarCamposTmp 'docums', 'docpath', 'varchar', 'VARCHAR(260)', '260';
		EXECUTE sp_executesql N'UPDATE docums set docpath = document_temp; ALTER TABLE docums DROP COLUMN document_temp;';
	END
	ELSE
	BEGIN
		exec AlterarCamposTmp 'docums', 'document', 'varbinary', 'VARBINARY(MAX)', ''
	END
END

	exec AlterarCamposTmp 'docums', 'docpath', 'varchar', 'VARCHAR(260)', '260'

	exec AlterarCamposTmp 'docums', 'tabela', 'varchar', 'VARCHAR(30)', '30'
	exec AlterarCamposTmp 'docums', 'campo', 'varchar', 'VARCHAR(30)', '30'
	exec AlterarCamposTmp 'docums', 'chave', 'varchar', 'VARCHAR(36)', '36'
	exec AlterarCamposTmp 'docums', 'form', 'varchar', 'VARCHAR(8)', '8'
	exec AlterarCamposTmp 'docums', 'nome', 'varchar', 'VARCHAR(255)', '255'
	exec AlterarCamposTmp 'docums', 'versao', 'varchar', 'VARCHAR(10)', '10'
	exec AlterarCamposTmp 'docums', 'tamanho', 'float', 'FLOAT(53)', '10'
	exec AlterarCamposTmp 'docums', 'extensao', 'varchar', 'VARCHAR(5)', '5'
	exec AlterarCamposTmp 'docums', 'opercria', 'varchar', 'VARCHAR(100)', '100'
	exec AlterarCamposTmp 'docums', 'datacria', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'docums', 'opermuda', 'varchar', 'VARCHAR(100)', '100'
	exec AlterarCamposTmp 'docums', 'datamuda', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'docums', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'AJFpostit','codpostit','I', 6
exec ApagarTodosIndicesTmp 'AJFpostit','AJF','codpostit'
exec AlterarCamposTmp 'AJFpostit', 'tabela', 'varchar', 'VARCHAR(6)', '6'
exec AlterarCamposTmp 'AJFpostit', 'codtabel', 'varchar', 'VARCHAR(32)', '32'
exec AlterarCamposTmp 'AJFpostit', 'postit', 'varchar', 'VARCHAR(255)', '255'
exec AlterarCamposTmp 'AJFpostit', 'tpostit', 'varchar', 'VARCHAR(1)', '1'
exec AlterarCamposTmp 'AJFpostit', 'datacria', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFpostit', 'opercria', 'varchar', 'VARCHAR(100)', '100'

exec AlterarCamposTmp 'AJFpostit', 'codpsw', 'int', 'int', '8'
exec AlterarCamposTmp 'AJFpostit', 'lido', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFpostit', 'apagado', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFpostit', 'validade', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFpostit', 'nivel', 'float', 'FLOAT(53)', '53'

exec AlterarCamposTmp 'AJFpostit', 'codpost1', 'int', 'INT', '6'
exec AlterarCamposTmp 'AJFpostit', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'hashcd','codhashcd','I', 6
exec ApagarTodosIndicesTmp 'hashcd','AJF','codhashcd'
exec AlterarCamposTmp 'hashcd', 'tabela', 'varchar', 'VARCHAR(30)', '30'
exec AlterarCamposTmp 'hashcd', 'campos', 'varchar', 'VARCHAR(900)', '900'
exec AlterarCamposTmp 'hashcd', 'datacria', 'datetime', 'DATETIME', '6'
exec AlterarCamposTmp 'hashcd', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'AJFalerta','codalerta','I', 6
exec ApagarTodosIndicesTmp 'AJFalerta','AJF','codalerta'
exec AlterarCamposTmp 'AJFalerta', 'codaltent', 'int', 'INT', '6'
exec AlterarCamposTmp 'AJFalerta', 'mensagem', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'AJFalerta', 'tratado', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFalerta', 'activo', 'float', 'FLOAT(53)', '1'
exec AlterarCamposTmp 'AJFalerta', 'datacria', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFalerta', 'datareso', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFalerta', 'menu', 'varchar', 'VARCHAR(20)', '20'
exec AlterarCamposTmp 'AJFalerta', 'cor', 'varchar', 'VARCHAR(1)', '1'
exec AlterarCamposTmp 'AJFalerta', 'interno', 'float', 'FLOAT(53)', '1'
exec AlterarCamposTmp 'AJFalerta', 'backgrou', 'int', 'INT', '1'
exec AlterarCamposTmp 'AJFalerta', 'sms', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFalerta', 'email', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFalerta', 'emailenv', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFalerta', 'smsenvia', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFalerta', 'codigo', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFalerta', 'codigotp', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFalerta', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'AJFaltent','codaltent','I', 6
exec ApagarTodosIndicesTmp 'AJFaltent','AJF','codaltent'
exec AlterarCamposTmp 'AJFaltent', 'codtalert', 'int', 'INT', '6'

exec AlterarCamposTmp 'AJFaltent', 'codpsw', 'int', 'INT', '8'
exec AlterarCamposTmp 'AJFaltent', 'grupo', 'varchar', 'VARCHAR(30)', '30'
exec AlterarCamposTmp 'AJFaltent', 'contador', 'float', 'FLOAT(53)', '5'
exec AlterarCamposTmp 'AJFaltent', 'tipo', 'varchar', 'VARCHAR(1)', '1'
exec AlterarCamposTmp 'AJFaltent', 'mensagem', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFaltent', 'antecede', 'float', 'FLOAT(53)', '3'
exec AlterarCamposTmp 'AJFaltent', 'datainic', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFaltent', 'datafina', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFaltent', 'dtmodifi', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFaltent', 'todos', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFaltent', 'backgrou', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFaltent', 'sms', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFaltent', 'email', 'tinyint', 'TINYINT', '1'

exec AlterarCamposTmp 'AJFaltent', 'codtpgru', 'int', 'INT  NOT NULL ', '8'
exec AlterarCamposTmp 'AJFaltent', 'codtpess', 'int', 'INT  NOT NULL ', '8'

exec AlterarCamposTmp 'AJFaltent', 'menu', 'varchar', 'VARCHAR(20)', '20'
exec AlterarCamposTmp 'AJFaltent', 'incluian', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFaltent', 'activo', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFaltent', 'individu', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFaltent', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'AJFtalert','codtalert','I',  6
exec ApagarTodosIndicesTmp 'AJFtalert','AJF','codtalert'
exec AlterarCamposTmp 'AJFtalert', 'nome', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFtalert', 'metodo', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFtalert', 'priorida', 'varchar', 'VARCHAR(1)', '1'
exec AlterarCamposTmp 'AJFtalert', 'cor', 'varchar', 'VARCHAR(1)', '1'
exec AlterarCamposTmp 'AJFtalert', 'texto', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFtalert', 'menu', 'varchar', 'VARCHAR(20)', '20'
exec AlterarCamposTmp 'AJFtalert', 'cmpnome', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFtalert', 'daltinic', 'varchar', 'VARCHAR(20)', '20'
exec AlterarCamposTmp 'AJFtalert', 'daltfina', 'varchar', 'VARCHAR(20)', '20'
exec AlterarCamposTmp 'AJFtalert', 'incluian', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFtalert', 'diferenc', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFtalert', 'anodifer', 'float', 'FLOAT(53)', '2'
exec AlterarCamposTmp 'AJFtalert', 'mesdifer', 'float', 'FLOAT(53)', '2'
exec AlterarCamposTmp 'AJFtalert', 'diadifer', 'float', 'FLOAT(53)', '2'
exec AlterarCamposTmp 'AJFtalert', 'ntabmae', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFtalert', 'ntabfilh', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFtalert', 'formid', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFtalert', 'tabela', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFtalert', 'campo', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFtalert', 'tipo', 'float', 'FLOAT(53)', '4'
exec AlterarCamposTmp 'AJFtalert', 'modulo', 'varchar', 'VARCHAR(5)', '5'
exec AlterarCamposTmp 'AJFtalert', 'condicao', 'varchar', 'VARCHAR(8000)', '8000'
exec AlterarCamposTmp 'AJFtalert', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'AJFdelega','coddelega','I',  6
exec ApagarTodosIndicesTmp 'AJFdelega','AJF','coddelega'
exec AlterarCamposTmp 'AJFdelega', 'codpswup', 'int', 'INT', '8'
exec AlterarCamposTmp 'AJFdelega', 'codpswdw', 'int', 'INT', '8'
exec AlterarCamposTmp 'AJFdelega', 'dateini', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFdelega', 'dateend', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFdelega', 'message', 'varchar', 'VARCHAR(4000)', '4000'
exec AlterarCamposTmp 'AJFdelega', 'revoked', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFdelega', 'auditusr', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'AJFdelega', 'opercria', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'AJFdelega', 'datacria', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFdelega', 'opermuda', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'AJFdelega', 'datamuda', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFdelega', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO



exec CriarTabelaTmp 'AJFTABDINAMIC','codtabdinamic','I', 6
exec AlterarCamposTmp 'AJFTABDINAMIC', 'NOMETABELA', 'varchar', 'VARCHAR(25)', '25'
exec AlterarCamposTmp 'AJFTABDINAMIC', 'NOMECAMPO', 'varchar', 'VARCHAR(25)', '25'
exec AlterarCamposTmp 'AJFTABDINAMIC', 'TIPODADOS', 'varchar', 'VARCHAR(15)', '15'
exec AlterarCamposTmp 'AJFTABDINAMIC', 'TIPOSQL', 'varchar', 'VARCHAR(15)', '15'
exec AlterarCamposTmp 'AJFTABDINAMIC', 'LARGURA', 'int', 'INT', '2'
exec AlterarCamposTmp 'AJFTABDINAMIC', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

USE [W_GnBD]
if not exists(SELECT top 1 name FROM sysobjects where name = 'logAJFpro')
begin
	EXEC ('CREATE TABLE logAJFpro ( [Login] [varchar](100) NULL ) ')
end
exec ApagarTodosIndicesTmp 'logAJFpro','AJF'
exec AlterarCamposTmp 'logAJFpro', 'Login', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'logAJFpro', 'Data', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'logAJFpro', 'Accao', 'varchar', 'VARCHAR(200)', '200'
GO



exec CriarTabelaTmp 'AJFaltran','codaltran','I', 6
exec ApagarTodosIndicesTmp 'AJFaltran','AJF','codaltran'
exec AlterarCamposTmp 'AJFaltran', 'typlabel', 'varchar', 'VARCHAR(1)', '1'
exec AlterarCamposTmp 'AJFaltran', 'referenc', 'varchar', 'VARCHAR(500)', '500'
exec AlterarCamposTmp 'AJFaltran', 'language', 'varchar', 'VARCHAR(2)', '2'
exec AlterarCamposTmp 'AJFaltran', 'curlabel', 'varchar', 'VARCHAR(500)', '500'
exec AlterarCamposTmp 'AJFaltran', 'labellng', 'varchar', 'VARCHAR(500)', '500'
exec AlterarCamposTmp 'AJFaltran', 'altran', 'varchar', 'VARCHAR(500)', '500'
exec AlterarCamposTmp 'AJFaltran', 'opercria', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'AJFaltran', 'datacria', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFaltran', 'opermuda', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'AJFaltran', 'datamuda', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFaltran', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO



exec CriarTabelaTmp 'AJFworkflowtask','codtask','I',  6
exec ApagarTodosIndicesTmp 'AJFworkflowtask','AJF','codtask'
exec AlterarCamposTmp 'AJFworkflowtask', 'codprcess', 'int', 'INT', '6'

exec AlterarCamposTmp 'AJFworkflowtask', 'taskdefid', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFworkflowtask', 'taskid', 'varchar', 'VARCHAR(8000)', '8000'
exec AlterarCamposTmp 'AJFworkflowtask', 'performedby', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'AJFworkflowtask', 'runningsince', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFworkflowtask', 'nextrun', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFworkflowtask', 'modifieddate', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFworkflowtask', 'modifiedby', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'AJFworkflowtask', 'skipped', 'varchar', 'VARCHAR(30)', '30'
exec AlterarCamposTmp 'AJFworkflowtask', 'isactive', 'varchar', 'VARCHAR(30)', '30'
exec AlterarCamposTmp 'AJFworkflowtask', 'errorExecute', 'int', 'INT', '2'
exec AlterarCamposTmp 'AJFworkflowtask', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO



exec CriarTabelaTmp 'AJFworkflowprocess','codprcess','I',  6
exec ApagarTodosIndicesTmp 'AJFworkflowprocess','AJF','codprcess'
exec AlterarCamposTmp 'AJFworkflowprocess', 'prcessid', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFworkflowprocess', 'prcessdefid', 'varchar', 'VARCHAR(8000)', '8000'
exec AlterarCamposTmp 'AJFworkflowprocess', 'createdby', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'AJFworkflowprocess', 'status', 'varchar', 'VARCHAR(30)', '30'
exec AlterarCamposTmp 'AJFworkflowprocess', 'startdate', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFworkflowprocess', 'modifieddate', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'AJFworkflowprocess', 'modifiedby', 'varchar', 'VARCHAR(100)', '100'

exec AlterarCamposTmp 'AJFworkflowprocess', 'codinstance', 'int', 'INT', '6'

exec AlterarCamposTmp 'AJFworkflowprocess', 'dotgraph', 'varchar', 'VARCHAR(8000)', '8000'
exec AlterarCamposTmp 'AJFworkflowprocess', 'wferror', 'int', 'INT', '2'
exec AlterarCamposTmp 'AJFworkflowprocess', 'ltask', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFworkflowprocess', 'idhk', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFworkflowprocess', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

--Se por alguma razão ainda não existe a tabela de logs, cria-a
IF OBJECT_ID('dbo.logAJFall', 'U') IS NULL
BEGIN
  USE [W_GnBD]
	CREATE TABLE [dbo].[logAJFall](
	  [COD] [varchar](38) NOT NULL,
	  [LOGTABLE] [varchar](50) NULL,
		[LOGFIELD] [varchar](50) NULL,
		[OP] [char](1) NOT NULL,
		[VAL] [varchar](MAX) NULL,
		[DATE] [datetime] NOT NULL,
		[WHO] [varchar](50) NULL
	)
END
GO

IF OBJECT_ID('dbo.PswBlacklist', 'U') IS NULL
BEGIN
	USE [W_GnBD]
	CREATE TABLE PswBlacklist (
		pass VARCHAR(64) PRIMARY KEY CLUSTERED WITH (IGNORE_DUP_KEY = on)
	)
END
GO

exec CriarTabelaTmp 'AJFalerts','codalerts','I',6
exec ApagarTodosIndicesTmp 'AJFalerts','AJF','codalerts'
exec AlterarCamposTmp 'AJFalerts', 'Codpsw', 'int', 'INT', '6'
exec AlterarCamposTmp 'AJFalerts', 'Content', 'varchar', 'VARCHAR(8000)', '8000'
exec AlterarCamposTmp 'AJFalerts', 'Datacria', 'datetime', 'DATETIME', '8' 
exec AlterarCamposTmp 'AJFalerts', 'Datamuda', 'datetime', 'DATETIME', '8' 
exec AlterarCamposTmp 'AJFalerts', 'Delay', 'int', 'INT', '5' 
exec AlterarCamposTmp 'AJFalerts', 'Dismissable', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFalerts', 'Idalert', 'varchar','VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFalerts', 'Inactive', 'tinyint', 'TINYINT', '1'
exec AlterarCamposTmp 'AJFalerts', 'Modulo', 'varchar', 'VARCHAR(10)', '10'
exec AlterarCamposTmp 'AJFalerts', 'Nivel', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'AJFalerts', 'Title', 'varchar', 'VARCHAR(500)', '500'
exec AlterarCamposTmp 'AJFalerts', 'Type', 'int', 'INT', '1' --enum: success, info, warning, danger
exec AlterarCamposTmp 'AJFalerts', 'URL', 'varchar', 'VARCHAR(8000)', '8000'
exec AlterarCamposTmp 'AJFalerts', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'ReportList','codreport','I', 6
exec ApagarTodosIndicesTmp 'ReportList','AJF','codreport'
exec AlterarCamposTmp 'ReportList', 'REPORT', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'ReportList', 'SLOTID', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'ReportList', 'TITULO', 'varchar', 'VARCHAR(120)', '120'
exec AlterarCamposTmp 'ReportList', 'OPERCRIA', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'ReportList', 'DATACRIA', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'ReportList', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO

exec CriarTabelaTmp 'Cavreport','codreport','I', 6
exec ApagarTodosIndicesTmp 'Cavreport','AJF','codreport'
exec AlterarCamposTmp 'Cavreport', 'TITLE', 'varchar', 'VARCHAR(200)', '200'
exec AlterarCamposTmp 'Cavreport', 'ACESSO', 'varchar', 'VARCHAR(50)', '50'
exec AlterarCamposTmp 'Cavreport', 'DATAXML', 'varchar', 'VARCHAR(MAX)', '8000'
exec AlterarCamposTmp 'Cavreport', 'OPERCRIA', 'varchar', 'VARCHAR(100)', '100'
exec AlterarCamposTmp 'Cavreport', 'DATACRIA', 'datetime', 'DATETIME', '8'
exec AlterarCamposTmp 'Cavreport', 'ZZSTATE', 'tinyint', 'TINYINT', '1'
GO


