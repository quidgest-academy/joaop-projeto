*{ajfcontract}*
GO
USE [W_GnBD]
GO
*{userauthorization}*
GO
USE [W_GnBD]
GO
*{asyncprocessattachments}*
GO
USE [W_GnBD]
GO
*{asyncprocessargument}*
GO
USE [W_GnBD]
GO
*{ajfplayer}*
GO
USE [W_GnBD]
GO
*{ajfclub}*
GO
USE [W_GnBD]
GO
*{notificationmessage}*
GO
USE [W_GnBD]
GO
*{notificationemailsignature}*
GO
USE [W_GnBD]
GO
*{asyncprocess}*
GO
USE [W_GnBD]
GO
*{userlogin}*
GO
USE [W_GnBD]
GO
*{ajfmem}*
GO
USE [W_GnBD]
GO
*{ajfcountry}*
GO
USE [W_GnBD]
GO
*{ajfagente}*
USE [W_GnBD]
update [ajfagente] set
     [totcomis] = + (select isnull(sum(source.[COMISEUR]),0) from [ajfcontract] as source where [ajfagente].[codagent] = source.[codagent] and source.zzstate = 0)
GO
USE [W_GnBD]
GO
