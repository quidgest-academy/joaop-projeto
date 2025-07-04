USE [W_GnBD]
if ('W_GnZeroTrue'='1')
begin
    IF((SELECT COUNT(1) FROM [AJFcfg]) > 0)
        UPDATE [AJFcfg] SET versindx = 0
end
GO
IF ('W_GnZeroTrue'='1' AND EXISTS (SELECT * FROM [W_GnBD].INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ASYNCPROCESS'))
BEGIN
if (not exists(SELECT CODASCPR FROM ASYNCPROCESS ))
begin	
	DROP TABLE ASYNCPROCESS	
end
END
GO
IF ('W_GnZeroTrue'='1' AND EXISTS (SELECT * FROM [W_GnBD].INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ASYNCPROCESSARGUMENT'))
BEGIN
if (not exists(SELECT CODARGPR FROM ASYNCPROCESSARGUMENT ))
begin
	DROP TABLE ASYNCPROCESSARGUMENT	
end
END
GO
IF ('W_GnZeroTrue'='1' AND EXISTS (SELECT * FROM [W_GnBD].INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ASYNCPROCESSATTACHMENTS'))
BEGIN
if (not exists(SELECT CODPRANX FROM ASYNCPROCESSATTACHMENTS ))
begin
	DROP TABLE ASYNCPROCESSATTACHMENTS	
end
END
GO



if ('W_GnZeroTrue'='1' OR 2501 > isnull((select versao from [AJFcfg]),0))
begin
	exec CriarTabelaTmp 'USERLOGIN','CODPSW','I', 8
	exec ApagarTodosIndicesTmp 'USERLOGIN','AJF','CODPSW'
	exec AlterarCamposTmp 'USERLOGIN', 'CODPSW', 'int', 'INT NOT NULL', '4', 1
	exec AlterarCamposTmp 'USERLOGIN', 'NOME', 'varchar', 'VARCHAR(100)', '100'
	exec AlterarCamposTmp 'USERLOGIN', 'PASSWORD', 'varchar', 'VARCHAR(150)', '150'
	exec AlterarCamposTmp 'USERLOGIN', 'CERTSN', 'varchar', 'VARCHAR(32)', '32'
	exec AlterarCamposTmp 'USERLOGIN', 'EMAIL', 'varchar', 'VARCHAR(254)', '254'
	exec AlterarCamposTmp 'USERLOGIN', 'PSWTYPE', 'varchar', 'VARCHAR(3)', '3'
	exec AlterarCamposTmp 'USERLOGIN', 'SALT', 'varchar', 'VARCHAR(32)', '32'
	exec AlterarCamposTmp 'USERLOGIN', 'DATAPSW', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'USERLOGIN', 'USERID', 'varchar', 'VARCHAR(250)', '250'
	exec AlterarCamposTmp 'USERLOGIN', 'PSW2FAVL', 'varchar', 'VARCHAR(1000)', '1000'
	exec AlterarCamposTmp 'USERLOGIN', 'PSW2FATP', 'varchar', 'VARCHAR(16)', '16'
	exec AlterarCamposTmp 'USERLOGIN', 'DATEXP', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'USERLOGIN', 'ATTEMPTS', 'smallint', 'SMALLINT', '2'
	exec AlterarCamposTmp 'USERLOGIN', 'PHONE', 'varchar', 'VARCHAR(16)', '16'
	exec AlterarCamposTmp 'USERLOGIN', 'STATUS', 'smallint', 'SMALLINT', '2'
	exec AlterarCamposTmp 'USERLOGIN', 'ASSOCIA', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'USERLOGIN', 'OPERCRIA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'USERLOGIN', 'DATACRIA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'USERLOGIN', 'OPERMUDA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'USERLOGIN', 'DATAMUDA', 'datetime', 'DATETIME', '8'
  exec AlterarCamposTmp 'USERLOGIN', 'PSWTYPE', 'varchar', 'VARCHAR(3)', '3'
  exec AlterarCamposTmp 'USERLOGIN', 'SALT', 'varchar', 'VARCHAR(32)', '32'
  exec AlterarCamposTmp 'USERLOGIN', 'DATAPSW', 'datetime', 'DATETIME', '8'
  exec AlterarCamposTmp 'USERLOGIN', 'USERID', 'varchar', 'VARCHAR(250)', '250'
  exec AlterarCamposTmp 'USERLOGIN', 'PSW2FAVL', 'varchar', 'VARCHAR(1000)', '1000'
  exec AlterarCamposTmp 'USERLOGIN', 'PSW2FATP', 'varchar', 'VARCHAR(16)', '16'
  exec AlterarCamposTmp 'USERLOGIN', 'EMAIL', 'varchar', 'VARCHAR(254)', '254'
  exec AlterarCamposTmp 'USERLOGIN', 'DATEXP', 'datetime', 'DATETIME', '8'
  exec AlterarCamposTmp 'USERLOGIN', 'ATTEMPTS', 'int', 'INT', '2'
  exec AlterarCamposTmp 'USERLOGIN', 'PHONE', 'varchar', 'VARCHAR(16)', '16'
  exec AlterarCamposTmp 'USERLOGIN', 'STATUS', 'int', 'INT', '2'
	exec AlterarCamposTmp 'USERLOGIN', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2501 > isnull((select versao from [AJFcfg]),0))
begin
	exec CriarTabelaTmp 'ASYNCPROCESS','CODASCPR','G', 16
	exec ApagarTodosIndicesTmp 'ASYNCPROCESS','AJF','CODASCPR'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'CODASCPR', 'uniqueidentifier', 'uniqueidentifier NOT NULL', '16'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'TYPE', 'varchar', 'VARCHAR(12)', '12'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'DATEREQU', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'INITPRC', 'datetime', 'DATETIME', '16'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'ENDPRC', 'datetime', 'DATETIME', '16'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'DURATION', 'varchar', 'VARCHAR(5)', '5'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'STATUS', 'varchar', 'VARCHAR(2)', '2'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'RSLTMSG', 'varchar', 'VARCHAR(250)', '250'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'FINISHED', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'LASTUPDT', 'datetime', 'DATETIME', '19'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'RESULT', 'varchar', 'VARCHAR(2)', '2'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'INFO', 'varchar', 'VARCHAR(500)', '500'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'PERCENTA', 'smallint', 'SMALLINT', '2'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'MODOPROC', 'varchar', 'VARCHAR(9)', '9'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'EXTERNAL', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'ID', 'int', 'INT', '4'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'CODENTIT', 'int', 'INT', '4', 1
	exec AlterarCamposTmp 'ASYNCPROCESS', 'MOTIVO', 'varchar', 'VARCHAR(200)', '200'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'CODPSW', 'int', 'INT', '4', 1
	exec AlterarCamposTmp 'ASYNCPROCESS', 'OPERSHUT', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'OPERCRIA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'DATACRIA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'OPERMUDA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'DATAMUDA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'ASYNCPROCESS', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2501 > isnull((select versao from [AJFcfg]),0))
begin
	exec CriarTabelaTmp 'ASYNCPROCESSARGUMENT','CODARGPR','G', 16
	exec ApagarTodosIndicesTmp 'ASYNCPROCESSARGUMENT','AJF','CODARGPR'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'CODARGPR', 'uniqueidentifier', 'uniqueidentifier NOT NULL', '16'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'CODS_APR', 'uniqueidentifier', 'uniqueidentifier', '16'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'ID', 'varchar', 'VARCHAR(50)', '50'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'VALOR', 'varchar', 'VARCHAR(250)', '250'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'DOCUMENTFK', 'int', 'int', '16'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'DOCUMENT', 'varchar', 'VARCHAR(200)', '200'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'TIPO', 'varchar', 'VARCHAR(250)', '250'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'DESIGNAC', 'varchar', 'VARCHAR(200)', '200'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'HIDDEN', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'OPERCRIA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'DATACRIA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'OPERMUDA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'DATAMUDA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'ASYNCPROCESSARGUMENT', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2501 > isnull((select versao from [AJFcfg]),0))
begin
	exec CriarTabelaTmp 'NOTIFICATIONEMAILSIGNATURE','CODSIGNA','I', 8
	exec ApagarTodosIndicesTmp 'NOTIFICATIONEMAILSIGNATURE','AJF','CODSIGNA'
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'CODSIGNA', 'int', 'INT NOT NULL', '4', 1
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'NAME', 'varchar', 'VARCHAR(100)', '100'
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'IMAGE', 'varbinary', 'VARBINARY(MAX)', '3'
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'TEXTASS', 'varchar', 'VARCHAR(300)', '300'
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'USERNAME', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'PASSWORD', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'OPERCRIA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'DATACRIA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'OPERMUDA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'DATAMUDA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'NOTIFICATIONEMAILSIGNATURE', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2501 > isnull((select versao from [AJFcfg]),0))
begin
	exec CriarTabelaTmp 'NOTIFICATIONMESSAGE','CODMESGS','I', 8
	exec ApagarTodosIndicesTmp 'NOTIFICATIONMESSAGE','AJF','CODMESGS'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'CODMESGS', 'int', 'INT NOT NULL', '4', 1
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'CODSIGNA', 'varchar', 'VARCHAR(50)', '50'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'CODPMAIL', 'varchar', 'VARCHAR(50)', '50'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'FROM', 'varchar', 'VARCHAR(254)', '254'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'CODTPNOT', 'varchar', 'VARCHAR(50)', '50'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'CODDESTN', 'varchar', 'VARCHAR(50)', '50'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'TO', 'varchar', 'VARCHAR(254)', '254'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'DESTNMAN', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'TOMANUAL', 'varchar', 'VARCHAR(MAX)', '8000'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'CC', 'varchar', 'VARCHAR(MAX)', '8000'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'BCC', 'varchar', 'VARCHAR(MAX)', '8000'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'IDNOTIF', 'varchar', 'VARCHAR(100)', '100'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'NOTIFICA', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'EMAIL', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'ASSUNTO', 'varchar', 'VARCHAR(100)', '100'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'AGREGADO', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'ANEXO', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'HTML', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'ATIVO', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'DESIGNAC', 'varchar', 'VARCHAR(100)', '100'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'MENSAGEM', 'varchar', 'VARCHAR(MAX)', '8000'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'GRAVABD', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'OPERCRIA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'DATACRIA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'OPERMUDA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'DATAMUDA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'NOTIFICATIONMESSAGE', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2501 > isnull((select versao from [AJFcfg]),0))
begin
	exec CriarTabelaTmp 'ASYNCPROCESSATTACHMENTS','CODPRANX','I', 8
	exec ApagarTodosIndicesTmp 'ASYNCPROCESSATTACHMENTS','AJF','CODPRANX'
	exec AlterarCamposTmp 'ASYNCPROCESSATTACHMENTS', 'CODPRANX', 'int', 'INT NOT NULL', '4', 1
	exec AlterarCamposTmp 'ASYNCPROCESSATTACHMENTS', 'CODS_APR', 'uniqueidentifier', 'uniqueidentifier', '16'
	exec AlterarCamposTmp 'ASYNCPROCESSATTACHMENTS', 'DOCUMENTFK', 'int', 'int', '16'
	exec AlterarCamposTmp 'ASYNCPROCESSATTACHMENTS', 'DOCUMENT', 'varchar', 'VARCHAR(200)', '200'
	exec AlterarCamposTmp 'ASYNCPROCESSATTACHMENTS', 'OPERCRIA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'ASYNCPROCESSATTACHMENTS', 'DATACRIA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'ASYNCPROCESSATTACHMENTS', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2501 > isnull((select versao from [AJFcfg]),0))
begin
	exec CriarTabelaTmp 'USERAUTHORIZATION','CODUA','I', 8
	exec ApagarTodosIndicesTmp 'USERAUTHORIZATION','AJF','CODUA'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'CODUA', 'int', 'INT NOT NULL', '4', 1
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'CODPSW', 'int', 'INT', '4', 1
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'SISTEMA', 'varchar', 'VARCHAR(20)', '20'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'MODULO', 'varchar', 'VARCHAR(3)', '3'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'NAODUPLI', 'varchar', 'VARCHAR(39)', '39'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'ROLE', 'varchar', 'VARCHAR(16)', '16'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'NIVEL', 'bigint', 'BIGINT', '8'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'OPERCRIA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'DATACRIA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'OPERMUDA', 'varchar', 'VARCHAR(128)', '128'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'DATAMUDA', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'USERAUTHORIZATION', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2502 > isnull((select versao from [AJFcfg]),0))
begin
	exec CriarTabelaTmp 'AJFCOUNTRY','CODCNTRY','I', 8
	exec ApagarTodosIndicesTmp 'AJFCOUNTRY','AJF','CODCNTRY'
	exec AlterarCamposTmp 'AJFCOUNTRY', 'CODCNTRY', 'int', 'INT NOT NULL', '4', 1
	exec AlterarCamposTmp 'AJFCOUNTRY', 'COUNTRY', 'varchar', 'VARCHAR(50)', '50'
	exec AlterarCamposTmp 'AJFCOUNTRY', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2505 > isnull((select versao from [AJFcfg]),0))
begin
	exec CriarTabelaTmp 'AJFCLUB','CODCLUB','I', 8
	exec ApagarTodosIndicesTmp 'AJFCLUB','AJF','CODCLUB'
	exec AlterarCamposTmp 'AJFCLUB', 'CODCLUB', 'int', 'INT NOT NULL', '4', 1
	exec AlterarCamposTmp 'AJFCLUB', 'NAME', 'varchar', 'VARCHAR(50)', '50'
	exec AlterarCamposTmp 'AJFCLUB', 'CODCNTRY', 'int', 'INT', '4', 1
	exec AlterarCamposTmp 'AJFCLUB', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2506 > isnull((select versao from [AJFcfg]),0))
begin
	exec CriarTabelaTmp 'AJFCONTRACT','CODCONTR','I', 8
	exec ApagarTodosIndicesTmp 'AJFCONTRACT','AJF','CODCONTR'
	exec AlterarCamposTmp 'AJFCONTRACT', 'CODCONTR', 'int', 'INT NOT NULL', '4', 1
	exec AlterarCamposTmp 'AJFCONTRACT', 'STARTDAT', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'AJFCONTRACT', 'FINDATE', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'AJFCONTRACT', 'SALARY', 'real', 'REAL', '4'
	exec AlterarCamposTmp 'AJFCONTRACT', 'CODPLAYR', 'int', 'INT', '4', 1
	exec AlterarCamposTmp 'AJFCONTRACT', 'CODCLUB', 'int', 'INT', '4', 1
	exec AlterarCamposTmp 'AJFCONTRACT', 'CODAGENT', 'int', 'INT', '4', 1
	exec AlterarCamposTmp 'AJFCONTRACT', 'TRANSVAL', 'float', 'FLOAT', '8'
	exec AlterarCamposTmp 'AJFCONTRACT', 'COMISEUR', 'float', 'FLOAT', '8'
	exec AlterarCamposTmp 'AJFCONTRACT', 'CTRDURAT', 'smallint', 'SMALLINT', '2'
	exec AlterarCamposTmp 'AJFCONTRACT', 'SLRYYR', 'float', 'FLOAT', '8'
	exec AlterarCamposTmp 'AJFCONTRACT', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2506 > isnull((select versao from [AJFcfg]),0))
begin
	exec CriarTabelaTmp 'AJFPLAYER','CODPLAYR','I', 8
	exec ApagarTodosIndicesTmp 'AJFPLAYER','AJF','CODPLAYR'
	exec AlterarCamposTmp 'AJFPLAYER', 'CODPLAYR', 'int', 'INT NOT NULL', '4', 1
	exec AlterarCamposTmp 'AJFPLAYER', 'NAME', 'varchar', 'VARCHAR(85)', '85'
	exec AlterarCamposTmp 'AJFPLAYER', 'BIRTHDAT', 'datetime', 'DATETIME', '8'
	exec AlterarCamposTmp 'AJFPLAYER', 'COUNTRY', 'varchar', 'VARCHAR(50)', '50'
	exec AlterarCamposTmp 'AJFPLAYER', 'POSIC', 'varchar', 'VARCHAR(50)', '50'
	exec AlterarCamposTmp 'AJFPLAYER', 'AGE', 'smallint', 'SMALLINT', '2'
	exec AlterarCamposTmp 'AJFPLAYER', 'GENDER', 'varchar', 'VARCHAR(1)', '1'
	exec AlterarCamposTmp 'AJFPLAYER', 'UNDCTC', 'tinyint', 'TINYINT', '1'
	exec AlterarCamposTmp 'AJFPLAYER', 'CODCNTRY', 'int', 'INT', '4', 1
	exec AlterarCamposTmp 'AJFPLAYER', 'CODAGENT', 'int', 'INT', '4', 1
	exec AlterarCamposTmp 'AJFPLAYER', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

if ('W_GnZeroTrue'='1' OR 2507 > isnull((select versao from [AJFcfg]),0))
begin
	exec CriarTabelaTmp 'AJFAGENTE','CODAGENT','I', 8
	exec ApagarTodosIndicesTmp 'AJFAGENTE','AJF','CODAGENT'
	exec AlterarCamposTmp 'AJFAGENTE', 'CODAGENT', 'int', 'INT NOT NULL', '4', 1
	exec AlterarCamposTmp 'AJFAGENTE', 'NAME', 'varchar', 'VARCHAR(85)', '85'
	exec AlterarCamposTmp 'AJFAGENTE', 'PHOTO', 'varbinary', 'VARBINARY(MAX)', '3'
	exec AlterarCamposTmp 'AJFAGENTE', 'EMAIL', 'varchar', 'VARCHAR(50)', '50'
	exec AlterarCamposTmp 'AJFAGENTE', 'PHONE', 'varchar', 'VARCHAR(14)', '14'
	exec AlterarCamposTmp 'AJFAGENTE', 'PERC_COM', 'real', 'REAL', '4'
	exec AlterarCamposTmp 'AJFAGENTE', 'TOTCOMIS', 'float', 'FLOAT', '8'
	exec AlterarCamposTmp 'AJFAGENTE', 'GENDER', 'varchar', 'VARCHAR(1)', '1'
	exec AlterarCamposTmp 'AJFAGENTE', 'ZZSTATE', 'tinyint', 'TINYINT', '1'

end
GO

-- Create Placeholder Computed columns
--AJFAGENTE
--AJFCOUNTRY
--AJFMEM
--USERLOGIN
--ASYNCPROCESS
if exists (select Col.name from systypes as tp, sysobjects as Tbl  inner join syscolumns as Col on Tbl.id = Col.id  where Col.xtype = tp.xtype and Tbl.name = 'ASYNCPROCESS' and Col.name = 'RTSTATUS')
BEGIN
  EXEC dbo.DropConstraintsTmp 'ASYNCPROCESS', 'RTSTATUS'
  EXEC('ALTER TABLE [ASYNCPROCESS] DROP COLUMN [RTSTATUS]')
END
EXEC('ALTER TABLE [ASYNCPROCESS] ADD [RTSTATUS] AS cast(null as varchar(2))')
--NOTIFICATIONEMAILSIGNATURE
--NOTIFICATIONMESSAGE
--AJFCLUB
--AJFPLAYER
--ASYNCPROCESSARGUMENT
--ASYNCPROCESSATTACHMENTS
--USERAUTHORIZATION
--AJFCONTRACT
GO

-- Update Computed Column functions
--AJFAGENTE
--AJFCOUNTRY
--AJFMEM
--USERLOGIN
--ASYNCPROCESS
EXEC dbo.DropConstraintsTmp 'ASYNCPROCESS', 'RTSTATUS'
EXEC('ALTER TABLE [ASYNCPROCESS] DROP COLUMN [RTSTATUS]')
EXEC('ALTER TABLE [ASYNCPROCESS] ADD [RTSTATUS] AS (case when ([status]=''EE'' or [status]=''D'' or [status]=''AC'' or [status]=''AG'') then (case when ((dbo.Diferenca_entre_Datas([lastupdt],CONVERT(datetime,CURRENT_TIMESTAMP),''S'')>10 and [status]<>''AG'') or (dbo.Diferenca_entre_Datas([lastupdt],CONVERT(datetime,CURRENT_TIMESTAMP),''S'')>45 and [status]=''AG'')) then ''NR'' else [status] end) else [status] end)')
--NOTIFICATIONEMAILSIGNATURE
--NOTIFICATIONMESSAGE
--AJFCLUB
--AJFPLAYER
--ASYNCPROCESSARGUMENT
--ASYNCPROCESSATTACHMENTS
--USERAUTHORIZATION
--AJFCONTRACT
GO

	exec estrutura_dinamica
GO
