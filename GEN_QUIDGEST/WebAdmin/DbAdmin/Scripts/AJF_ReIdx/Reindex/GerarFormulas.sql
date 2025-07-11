
-- recalculo de fórmulas para a tabela AJFContract
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
-- Layer 0
update [contr]
SET [contr].[comiseur] =[contr].[transval]*ISNULL([agent].[perc_com], 0)
,[contr].[ctrdurat] =year([contr].[findate])-year([contr].[startdat])
,[contr].[slryyr] =[contr].[salary]*12
FROM [ajfcontract] AS [contr]
LEFT JOIN [ajfagente] as [agent] ON [contr].[codagent]=[agent].[codagent]


GO
GO
-- recalculo de fórmulas para a tabela UserAuthorization
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
-- Layer 0
update [s_ua]
SET [s_ua].[naodupli] =dbo.KeyToString([s_ua].[codpsw])+[s_ua].[modulo]
,[s_ua].[nivel] =dbo.GetLevelFromRole(0,[s_ua].[role])
FROM [userauthorization] AS [s_ua]


GO
GO
-- recalculo de fórmulas para a tabela AsyncProcessAttachments
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela AsyncProcessArgument
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela AJFPlayer
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
-- Layer 0
update [playr]
SET [playr].[age] =year(cast(floor(cast(CURRENT_TIMESTAMP as float)) as datetime))-year([playr].[birthdat])
FROM [ajfplayer] AS [playr]


GO
GO
-- recalculo de fórmulas para a tabela AJFCLUB
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela NotificationMessage
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela NotificationEmailSignature
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela AsyncProcess
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
-- Layer 0
update [s_apr]
SET [s_apr].[finished] =(case when ([s_apr].[status]='T' or [s_apr].[status]='AB' or [s_apr].[status]='C') then 1 else 0 end)
FROM [asyncprocess] AS [s_apr]


GO
GO
-- recalculo de fórmulas para a tabela UserLogin
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela AJFMEM
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela AJFCountry
USE [W_GnBD]
GO
USE [W_GnBD]
GO
GO
USE [W_GnBD]
GO
GO
GO
-- recalculo de fórmulas para a tabela AJFAgente
USE [W_GnBD]
GO
USE [W_GnBD]
GO
USE [W_GnBD]
update [ajfagente] set
     [totcomis] = + (select isnull(sum(source.[COMISEUR]),0) from [ajfcontract] as source where [ajfagente].[codagent] = source.[codagent] and source.zzstate = 0)
GO
USE [W_GnBD]
GO
-- Layer 0
GO
GO


GO