*{ajfagente}*
GO
*{ajfcountry}*
GO
*{ajfmem}*
GO
*{userlogin}*
GO
*{asyncprocess}*
USE [W_GnBD]
update [s_apr] set [finished] = (case when ([s_apr].[status]='T' or [s_apr].[status]='AB' or [s_apr].[status]='C') then 1 else 0 end) from [asyncprocess] as [s_apr]
GO
*{notificationemailsignature}*
GO
*{notificationmessage}*
GO
*{ajfclub}*
GO
*{ajfplayer}*
USE [W_GnBD]
update [playr] set [age] = year(cast(floor(cast(CURRENT_TIMESTAMP as float)) as datetime))-year([playr].[birthdat]) from [ajfplayer] as [playr]
GO
*{asyncprocessargument}*
GO
*{asyncprocessattachments}*
GO
*{userauthorization}*
USE [W_GnBD]
update [s_ua] set [naodupli] = dbo.KeyToString([s_ua].[codpsw])+[s_ua].[modulo] from [userauthorization] as [s_ua]
update [s_ua] set [nivel] = dbo.GetLevelFromRole(0,[s_ua].[role]) from [userauthorization] as [s_ua]
GO
*{ajfcontract}*
USE [W_GnBD]
update [contr] set [comiseur] = [contr].[transval]*dbo.ansi_N([agent].[perc_com]) from [ajfcontract] as [contr] LEFT JOIN [ajfagente] as [agent] ON [contr].[codagent] = [agent].[codagent]
update [contr] set [ctrdurat] = year([contr].[findate])-year([contr].[startdat]) from [ajfcontract] as [contr]
update [contr] set [slryyr] = [contr].[salary]*12 from [ajfcontract] as [contr]
GO
