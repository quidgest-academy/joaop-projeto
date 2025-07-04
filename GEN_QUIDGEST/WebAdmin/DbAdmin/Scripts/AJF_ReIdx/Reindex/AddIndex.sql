USE [W_GnBD]
if (7 > isnull((select versindx from AJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'AJFAGENT_CODAGENT', 'codagent', 1, 1, 0, 1
 UNION ALL
-- Index with origin: Tabela NotDup AGENT
SELECT 'AJFAGENT_BB2C748F6A744DE0', 'email', 0, 1, 0, 0
UNION ALL
SELECT 'AJFAGENT_BB2C748F6A744DE0','zzState', 0, 0, 1, 0
UNION ALL
-- Index with origin: Tabela NotDup AGENT
SELECT 'AJFAGENT_D75F70DCE7764BBA', 'phone', 0, 1, 0, 0
UNION ALL
SELECT 'AJFAGENT_D75F70DCE7764BBA','zzState', 0, 0, 1, 0
UNION ALL
-- Index with origin: Menu AJF_11
SELECT 'AJFAGENT_56F63DF2509846BA', 'name', 0, 1, 0, 0

exec CheckIdxTmp @tabela, 'ajfagente', 'AJFAGENT_CODAGENT', 'ajf';
end
GO
if (2 > isnull((select versindx from AJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'AJFCNTRY_CODCNTRY', 'codcntry', 1, 1, 0, 1
 UNION ALL
-- Index with origin: Menu AJF_51
SELECT 'AJFCNTRY_4DCECD0F265B45F1', 'country', 0, 1, 0, 0

exec CheckIdxTmp @tabela, 'ajfcountry', 'AJFCNTRY_CODCNTRY', 'ajf';
end
GO
if (1 > isnull((select versindx from AJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'AJFMEM_CODMEM__', 'codmem', 1, 1, 0, 1
 
exec CheckIdxTmp @tabela, 'ajfmem', 'AJFMEM_CODMEM__', 'ajf';
end
GO
if (1 > isnull((select versindx from AJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'USERLOGIN_CODPSW__', 'codpsw', 1, 1, 0, 1
UNION ALL
SELECT 'USERLOGIN_nome', 'nome', 0, 1, 0, 0
 
exec CheckIdxTmp @tabela, 'userlogin', 'USERLOGIN_CODPSW__', 'ajf';
end
GO
if (1 > isnull((select versindx from AJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'ASYNCPROCESS_CODASCPR', 'codascpr', 1, 1, 0, 1
 
exec CheckIdxTmp @tabela, 'asyncprocess', 'ASYNCPROCESS_CODASCPR', 'ajf';
end
GO
if (1 > isnull((select versindx from AJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'NOTIFICATIONEMAILSIGNATURE_CODSIGNA', 'codsigna', 1, 1, 0, 1
 
exec CheckIdxTmp @tabela, 'notificationemailsignature', 'NOTIFICATIONEMAILSIGNATURE_CODSIGNA', 'ajf';
end
GO
if (1 > isnull((select versindx from AJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'NOTIFICATIONMESSAGE_CODMESGS', 'codmesgs', 1, 1, 0, 1
 
exec CheckIdxTmp @tabela, 'notificationmessage', 'NOTIFICATIONMESSAGE_CODMESGS', 'ajf';
end
GO
if (5 > isnull((select versindx from AJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'AJFCLUB_CODCLUB_', 'codclub', 1, 1, 0, 1
 UNION ALL
-- Index with origin: Menu AJF_41
SELECT 'AJFCLUB_E40AF00204F547FC', 'name', 0, 1, 0, 0

exec CheckIdxTmp @tabela, 'ajfclub', 'AJFCLUB_CODCLUB_', 'ajf';
end
GO
if (6 > isnull((select versindx from AJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'AJFPLAYR_CODPLAYR', 'codplayr', 1, 1, 0, 1
 UNION ALL
-- Index with origin: Menu AJF_21
SELECT 'AJFPLAYR_3718ED152227433D', 'posic', 0, 1, 0, 0
UNION ALL
-- Index with origin: Menu AJF_611
SELECT 'AJFPLAYR_0793DA6721CA4164', 'codagent', 0, 1, 0, 0
UNION ALL
-- Index with origin: Menu AJF_611
SELECT 'AJFPLAYR_0793DA6721CA4164', 'posic', 0, 2, 0, 0
UNION ALL
-- Index with origin: DB lookup F_CNTRCTPLAYRNAME
SELECT 'AJFPLAYR_558E64C807F143A6', 'name', 0, 1, 0, 0

exec CheckIdxTmp @tabela, 'ajfplayer', 'AJFPLAYR_CODPLAYR', 'ajf';
end
GO
if (1 > isnull((select versindx from AJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'ASYNCPROCESSARGUMENT_CODARGPR', 'codargpr', 1, 1, 0, 1
 
exec CheckIdxTmp @tabela, 'asyncprocessargument', 'ASYNCPROCESSARGUMENT_CODARGPR', 'ajf';
end
GO
if (1 > isnull((select versindx from AJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'ASYNCPROCESSATTACHMENTS_CODPRANX', 'codpranx', 1, 1, 0, 1
 
exec CheckIdxTmp @tabela, 'asyncprocessattachments', 'ASYNCPROCESSATTACHMENTS_CODPRANX', 'ajf';
end
GO
if (1 > isnull((select versindx from AJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'USERAUTHORIZATION_CODUA___', 'codua', 1, 1, 0, 1
 UNION ALL
-- Index with origin: Tabela NotDup S_UA
SELECT 'AJFS_UA_E27D06903C9B43D3', 'naodupli', 0, 1, 0, 0
UNION ALL
-- Index with origin: Tabela NotDup S_UA
SELECT 'AJFS_UA_E27D06903C9B43D3', 'role', 0, 2, 0, 0
UNION ALL
SELECT 'AJFS_UA_E27D06903C9B43D3','zzState', 0, 0, 1, 0

exec CheckIdxTmp @tabela, 'userauthorization', 'USERAUTHORIZATION_CODUA___', 'ajf';
end
GO
if (6 > isnull((select versindx from AJFcfg),0) or 'W_GnZeroTrue'='1')
begin
set nocount on
DECLARE @tabela as IndexCheckType;

 INSERT INTO @tabela (idxName, columnName, uniqueIdx, ordem, include, pk)
SELECT 'AJFCONTR_CODCONTR', 'codcontr', 1, 1, 0, 1
 UNION ALL
-- Index with origin: Formula SR AGENT
SELECT 'AJFCONTR_DF91801CDDE446AE', 'codagent', 0, 1, 0, 0
UNION ALL
SELECT 'AJFCONTR_DF91801CDDE446AE','zzState', 0, 0, 1, 0
UNION ALL
-- Index with origin: Menu AJF_31
SELECT 'AJFCONTR_E55A7FFDACA544F5', 'startdat', 0, 1, 0, 0
UNION ALL
-- Index with origin: Menu AJF_6111
SELECT 'AJFCONTR_AD2968C5E2A6478C', 'codplayr', 0, 1, 0, 0
UNION ALL
-- Index with origin: Menu AJF_6111
SELECT 'AJFCONTR_AD2968C5E2A6478C', 'codagent', 0, 2, 0, 0
UNION ALL
-- Index with origin: Menu AJF_6111
SELECT 'AJFCONTR_AD2968C5E2A6478C', 'startdat', 0, 3, 0, 0
UNION ALL
-- Index with origin: DP F_CLUBPSEUDFIELD001
SELECT 'AJFCONTR_48E660A67C8E4C92', 'codclub', 0, 1, 0, 0

exec CheckIdxTmp @tabela, 'ajfcontract', 'AJFCONTR_CODCONTR', 'ajf';
end
GO

if (7 > isnull((select versindx from AJFcfg),0) or 'W_GnZeroTrue'='1')
begin
-- Indíces de tabelas hardcoded (continuam da forma antiga [apagar e criar])
if (exists(select top 1 name from sys.indexes where name = 'ajfalerta_alerta01'))
	DROP INDEX ajfalerta_alerta01 ON ajfalerta
CREATE INDEX ajfalerta_alerta01 ON ajfalerta (codaltent)

if (exists(select top 1 name from sys.indexes where name = 'ajfpostit_postit01'))
	DROP INDEX ajfpostit_postit01 ON ajfpostit
CREATE INDEX ajfpostit_postit01 ON ajfpostit (tabela,codtabel)

if (exists(select top 1 name from sys.indexes where name = 'ajfpostit_postit02'))
	DROP INDEX ajfpostit_postit02 ON ajfpostit
CREATE INDEX ajfpostit_postit02 ON ajfpostit (codtabel)

if (exists(select top 1 name from sys.indexes where name = 'ajfpostit_postit03'))
	DROP INDEX ajfpostit_postit03 ON ajfpostit
CREATE INDEX ajfpostit_postit03 ON ajfpostit (postit)

if (exists(select top 1 name from sys.indexes where name = 'ajfpostit_postit04'))
	DROP INDEX ajfpostit_postit04 ON ajfpostit
CREATE INDEX ajfpostit_postit04 ON ajfpostit (tpostit)

if (exists(select top 1 name from sys.indexes where name = 'ajfpostit_postit05'))
	DROP INDEX ajfpostit_postit05 ON ajfpostit
CREATE INDEX ajfpostit_postit05 ON ajfpostit (codpsw)


if (exists(select top 1 name from sys.indexes where name = 'ajfpostit_postit06'))
	DROP INDEX ajfpostit_postit06 ON ajfpostit
CREATE INDEX ajfpostit_postit06 ON ajfpostit (nivel)

if (exists(select top 1 name from sys.indexes where name = 'ajfpostit_postit07'))
	DROP INDEX ajfpostit_postit07 ON ajfpostit
CREATE INDEX ajfpostit_postit07 ON ajfpostit (codpost1)

if (exists(select top 1 name from sys.indexes where name = 'ajfaltent_altent01'))
	DROP INDEX ajfaltent_altent01 ON ajfaltent
CREATE INDEX ajfaltent_altent01 ON ajfaltent (codtalert,tipo)

if (exists(select top 1 name from sys.indexes where name = 'ajfdelega_delega01'))
	DROP INDEX ajfdelega_delega01 ON ajfdelega
CREATE INDEX ajfdelega_delega01 ON ajfdelega (coddelega,codpswup)

if (exists(select top 1 name from sys.indexes where name = 'ajfdelega_delega02'))
	DROP INDEX ajfdelega_delega02 ON ajfdelega
CREATE INDEX ajfdelega_delega02 ON ajfdelega (coddelega,codpswdw)

if (exists(select top 1 name from sys.indexes where name = 'docums_docums01'))
	DROP INDEX docums_docums01 ON docums
CREATE INDEX docums_docums01 ON docums (documid,versao)

if (exists(select top 1 name from sys.indexes where name = 'docums_docums02'))
	DROP INDEX docums_docums02 ON docums
CREATE INDEX docums_docums02 ON docums (nome)


if (exists(select top 1 name from sys.indexes where name = 'docums_docums03'))
	DROP INDEX docums_docums03 ON docums
CREATE INDEX docums_docums03 ON docums (tabela,ZZSTATE)

if (exists(select top 1 name from sys.indexes where name = 'ajflstusr_codpsw'))
	DROP INDEX ajflstusr_codpsw ON ajflstusr
CREATE INDEX ajflstusr_codpsw ON ajflstusr (codpsw, descric)

if (exists(select top 1 name from sys.indexes where name = 'ajflstcol_codlstusr'))
	DROP INDEX ajflstcol_codlstusr ON ajflstcol
CREATE INDEX ajflstcol_codlstusr ON ajflstcol (codlstusr)

if (exists(select top 1 name from sys.indexes where name = 'ajflstren_codlstusr'))
	DROP INDEX ajflstren_codlstusr ON ajflstren
CREATE INDEX ajflstren_codlstusr ON ajflstren (codlstusr)

if (exists(select top 1 name from sys.indexes where name = 'ajfusrwid_codlstusr'))
	DROP INDEX ajfusrwid_codlstusr ON ajfusrwid
CREATE INDEX ajfusrwid_codlstusr ON ajfusrwid (codlstusr)

if (exists(select top 1 name from sys.indexes where name = 'ajftblcfg_codpsw_uuid_name'))
	DROP INDEX ajftblcfg_codpsw_uuid_name ON ajftblcfg
CREATE INDEX ajftblcfg_codpsw_uuid_name ON ajftblcfg (codpsw, uuid, name)

if (exists(select top 1 name from sys.indexes where name = 'ajftblcfg_codpsw_uuid'))
	DROP INDEX ajftblcfg_codpsw_uuid ON ajftblcfg
CREATE INDEX ajftblcfg_codpsw_uuid ON ajftblcfg (codpsw, uuid)

if (exists(select top 1 name from sys.indexes where name = 'ajftblcfgsel_codpsw_uuid'))
	DROP INDEX ajftblcfgsel_codpsw_uuid ON ajftblcfgsel
CREATE INDEX ajftblcfgsel_codpsw_uuid ON ajftblcfgsel (codpsw, uuid)



if (exists(select top 1 name from sys.indexes where name = 'logajfall_logajfall01'))
	DROP INDEX logajfall_logajfall01 ON logajfall
CREATE CLUSTERED INDEX [logajfall_logajfall01] ON [dbo].[logAJFall]([LOGTABLE] ASC, [LOGFIELD] ASC, [OP] ASC,[DATE] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


UPDATE AJFcfg set versindx = 7
end
GO