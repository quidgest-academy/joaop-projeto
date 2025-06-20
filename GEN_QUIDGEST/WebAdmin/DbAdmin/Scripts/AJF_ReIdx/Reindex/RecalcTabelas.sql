-- Delete all stored procedures that start with Genio. 
-- This is needed because previous changes to the procedure signature keep the old versions active, 
-- which can pass unnoticed very easily in existing applications
DECLARE @deleteSql NVARCHAR(MAX) = '';
SELECT @deleteSql += 'DROP PROCEDURE ' + QUOTENAME(SCHEMA_NAME(schema_id)) + '.' + QUOTENAME(name) + ';' + CHAR(13)
FROM sys.procedures
WHERE name LIKE 'genio_%';

USE [W_GnBD]
EXEC sp_executesql @deleteSql;
-----------------------------------------------------------
-- AGENT
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_Calc_Agente 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de AGENT
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- AGENT
-- Assumimos que as formulas dos seguintes campos estão bem calculadas:
-----------------------------------------------------------
-- [CONTR -> COMISEUR]
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR
update [ajfagente] set
     [totcomis] = + (select isnull(sum(source.[COMISEUR]),0) from [ajfcontract] as source where [ajfagente].[codagent] = source.[codagent] and source.zzstate = 0)
where ([ajfagente].[codagent] = @x OR @x IS NULL)

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
-- Layer 0
END')
GO
-----------------------------------------------------------
-- AGENT
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_CalcBlock_Agente 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de AGENT
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- AGENT
-- Assumimos que as formulas dos seguintes campos estão bem calculadas:
-----------------------------------------------------------
-- [CONTR -> COMISEUR]
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR
update [ajfagente] set
     [totcomis] = + (select isnull(sum(source.[COMISEUR]),0) from [ajfcontract] as source where [ajfagente].[codagent] = source.[codagent] and source.zzstate = 0)
where ([ajfagente].[codagent] in (select item from @x))

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
-- Layer 0
END')
GO
EXEC('
CREATE PROCEDURE dbo.Genio_Default_Agente @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for AGENT
-----------------------------------------------------------
SET NOCOUNT ON;

UPDATE [agent] set 
	[PERC_COM] = COALESCE([agent].[PERC_COM], 0)
 ,	[TOTCOMIS] = COALESCE([agent].[TOTCOMIS], 0)
	FROM [ajfagente] AS [agent]

	WHERE ([agent].[codagent] in (select item from @x))
END')
GO
-----------------------------------------------------------
-- CNTRY
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_Calc_Country 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de CNTRY
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- CNTRY
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_CalcBlock_Country 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de CNTRY
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
EXEC('
CREATE PROCEDURE dbo.Genio_Default_Country @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for CNTRY
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
-----------------------------------------------------------
-- MEM
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_Calc_MEM 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de MEM
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- MEM
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_CalcBlock_MEM 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de MEM
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
EXEC('
CREATE PROCEDURE dbo.Genio_Default_MEM @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for MEM
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
-----------------------------------------------------------
-- PSW
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_Calc_UserLogin 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de PSW
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- PSW
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_CalcBlock_UserLogin 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de PSW
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
EXEC('
CREATE PROCEDURE dbo.Genio_Default_UserLogin @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for PSW
-----------------------------------------------------------
SET NOCOUNT ON;

UPDATE [psw] set 
	[ATTEMPTS] = COALESCE([psw].[ATTEMPTS], 0)
 ,	[STATUS] = COALESCE([psw].[STATUS], 0)
	FROM [userlogin] AS [psw]

	WHERE ([psw].[codpsw] in (select item from @x))
END')
GO
-----------------------------------------------------------
-- S_APR
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_Calc_AsyncProcess 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_APR
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
-- Layer 0
update [s_apr]
SET [s_apr].[finished] =(case when ([s_apr].[status]=''T'' or [s_apr].[status]=''AB'' or [s_apr].[status]=''C'') then 1 else 0 end)
FROM [asyncprocess] AS [s_apr]

 where ([s_apr].[codascpr] = @x OR @x IS NULL)
END')
GO
-----------------------------------------------------------
-- S_APR
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_CalcBlock_AsyncProcess 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_APR
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
-- Layer 0
update [s_apr]
SET [s_apr].[finished] =(case when ([s_apr].[status]=''T'' or [s_apr].[status]=''AB'' or [s_apr].[status]=''C'') then 1 else 0 end)
FROM [asyncprocess] AS [s_apr]

 where ([s_apr].[codascpr] in (select item from @x))
END')
GO
EXEC('
CREATE PROCEDURE dbo.Genio_Default_AsyncProcess @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for S_APR
-----------------------------------------------------------
SET NOCOUNT ON;

UPDATE [s_apr] set 
	[PERCENTA] = COALESCE([s_apr].[PERCENTA], 0)
	FROM [asyncprocess] AS [s_apr]

	WHERE ([s_apr].[codascpr] in (select item from @x))
END')
GO
-----------------------------------------------------------
-- S_NES
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_Calc_NotificationEmailSignature 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_NES
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- S_NES
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_CalcBlock_NotificationEmailSignature 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_NES
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
EXEC('
CREATE PROCEDURE dbo.Genio_Default_NotificationEmailSignature @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for S_NES
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
-----------------------------------------------------------
-- S_NM
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_Calc_NotificationMessage 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_NM
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- S_NM
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_CalcBlock_NotificationMessage 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_NM
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
EXEC('
CREATE PROCEDURE dbo.Genio_Default_NotificationMessage @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for S_NM
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
-----------------------------------------------------------
-- CLUB
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_Calc_CLUB 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de CLUB
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- CLUB
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_CalcBlock_CLUB 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de CLUB
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
EXEC('
CREATE PROCEDURE dbo.Genio_Default_CLUB @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for CLUB
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
-----------------------------------------------------------
-- PLAYR
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_Calc_Player 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de PLAYR
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
-- Layer 0
update [playr]
SET [playr].[age] =year(cast(floor(cast(CURRENT_TIMESTAMP as float)) as datetime))-year([playr].[birthdat])
FROM [ajfplayer] AS [playr]

 where ([playr].[codplayr] = @x OR @x IS NULL)
END')
GO
-----------------------------------------------------------
-- PLAYR
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_CalcBlock_Player 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de PLAYR
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
-- Layer 0
update [playr]
SET [playr].[age] =year(cast(floor(cast(CURRENT_TIMESTAMP as float)) as datetime))-year([playr].[birthdat])
FROM [ajfplayer] AS [playr]

 where ([playr].[codplayr] in (select item from @x))
END')
GO
EXEC('
CREATE PROCEDURE dbo.Genio_Default_Player @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for PLAYR
-----------------------------------------------------------
SET NOCOUNT ON;

UPDATE [playr] set 
	[AGE] = COALESCE([playr].[AGE], 0)
	FROM [ajfplayer] AS [playr]

	WHERE ([playr].[codplayr] in (select item from @x))
END')
GO
-----------------------------------------------------------
-- S_ARG
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_Calc_AsyncProcessArgument 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_ARG
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- S_ARG
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_CalcBlock_AsyncProcessArgument 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_ARG
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
EXEC('
CREATE PROCEDURE dbo.Genio_Default_AsyncProcessArgument @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for S_ARG
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
-----------------------------------------------------------
-- S_PAX
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_Calc_AsyncProcessAttachments 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_PAX
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
-----------------------------------------------------------
-- S_PAX
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_CalcBlock_AsyncProcessAttachments 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_PAX
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
END')
GO
EXEC('
CREATE PROCEDURE dbo.Genio_Default_AsyncProcessAttachments @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for S_PAX
-----------------------------------------------------------
SET NOCOUNT ON;

END')
GO
-----------------------------------------------------------
-- S_UA
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_Calc_UserAuthorization 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_UA
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
-- Layer 0
update [s_ua]
SET [s_ua].[naodupli] =dbo.KeyToString([s_ua].[codpsw])+[s_ua].[modulo]
,[s_ua].[nivel] =dbo.GetLevelFromRole(0,[s_ua].[role])
FROM [userauthorization] AS [s_ua]

 where ([s_ua].[codua] = @x OR @x IS NULL)
END')
GO
-----------------------------------------------------------
-- S_UA
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_CalcBlock_UserAuthorization 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de S_UA
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
-- Layer 0
update [s_ua]
SET [s_ua].[naodupli] =dbo.KeyToString([s_ua].[codpsw])+[s_ua].[modulo]
,[s_ua].[nivel] =dbo.GetLevelFromRole(0,[s_ua].[role])
FROM [userauthorization] AS [s_ua]

 where ([s_ua].[codua] in (select item from @x))
END')
GO
EXEC('
CREATE PROCEDURE dbo.Genio_Default_UserAuthorization @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for S_UA
-----------------------------------------------------------
SET NOCOUNT ON;

UPDATE [s_ua] set 
	[NIVEL] = COALESCE([s_ua].[NIVEL], 0)
	FROM [userauthorization] AS [s_ua]

	WHERE ([s_ua].[codua] in (select item from @x))
END')
GO
-----------------------------------------------------------
-- CONTR
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_Calc_Contract 
@x VARCHAR(50) = NULL
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de CONTR
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
-- Layer 0
update [contr]
SET [contr].[comiseur] =[contr].[transval]*ISNULL([agent].[perc_com], 0)
,[contr].[ctrdurat] =year([contr].[findate])-year([contr].[startdat])
,[contr].[slryyr] =[contr].[salary]*12
FROM [ajfcontract] AS [contr]
LEFT JOIN [ajfagente] as [agent] ON [contr].[codagent]=[agent].[codagent]

 where ([contr].[codcontr] = @x OR @x IS NULL)
END')
GO
-----------------------------------------------------------
-- CONTR
-----------------------------------------------------------
USE [W_GnBD]
EXEC('
CREATE PROCEDURE dbo.Genio_CalcBlock_Contract 
@x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Recalcular o registo x de CONTR
-----------------------------------------------------------
SET NOCOUNT ON;
-----------------------------------------------------------
-- Formulas externas podem ser calculadas primeiro e de forma agregada
-----------------------------------------------------------
-- SR

-- UV
-----------------------------------------------------------
-- Formulas internas podem depender umas das outras
-----------------------------------------------------------
-- Layer 0
update [contr]
SET [contr].[comiseur] =[contr].[transval]*ISNULL([agent].[perc_com], 0)
,[contr].[ctrdurat] =year([contr].[findate])-year([contr].[startdat])
,[contr].[slryyr] =[contr].[salary]*12
FROM [ajfcontract] AS [contr]
LEFT JOIN [ajfagente] as [agent] ON [contr].[codagent]=[agent].[codagent]

 where ([contr].[codcontr] in (select item from @x))
END')
GO
EXEC('
CREATE PROCEDURE dbo.Genio_Default_Contract @x KeyListType READONLY
AS BEGIN
-----------------------------------------------------------
-- Defaults for CONTR
-----------------------------------------------------------
SET NOCOUNT ON;

UPDATE [contr] set 
	[SALARY] = COALESCE([contr].[SALARY], 0)
 ,	[TRANSVAL] = COALESCE([contr].[TRANSVAL], 0)
 ,	[COMISEUR] = COALESCE([contr].[COMISEUR], 0)
 ,	[CTRDURAT] = COALESCE([contr].[CTRDURAT], 0)
 ,	[SLRYYR] = COALESCE([contr].[SLRYYR], 0)
	FROM [ajfcontract] AS [contr]

	WHERE ([contr].[codcontr] in (select item from @x))
END')
GO
