USE [W_GnBD]
DECLARE @nextcod bigint

if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFAgente')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFAgente', coalesce(cast((select max(codagent) from AJFAgente) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codagent) from AJFAgente) as bigint) + 1, 1) where id_objecto = 'AJFAgente'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFCLUB')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFCLUB', coalesce(cast((select max(codclub) from AJFCLUB) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codclub) from AJFCLUB) as bigint) + 1, 1) where id_objecto = 'AJFCLUB'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFCountry')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFCountry', coalesce(cast((select max(codcntry) from AJFCountry) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codcntry) from AJFCountry) as bigint) + 1, 1) where id_objecto = 'AJFCountry'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFContract')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFContract', coalesce(cast((select max(codcontr) from AJFContract) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codcontr) from AJFContract) as bigint) + 1, 1) where id_objecto = 'AJFContract'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFPlayer')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFPlayer', coalesce(cast((select max(codplayr) from AJFPlayer) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codplayr) from AJFPlayer) as bigint) + 1, 1) where id_objecto = 'AJFPlayer'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'UserLogin')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('UserLogin', coalesce(cast((select max(codpsw) from UserLogin) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codpsw) from UserLogin) as bigint) + 1, 1) where id_objecto = 'UserLogin'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'NotificationEmailSignature')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('NotificationEmailSignature', coalesce(cast((select max(codsigna) from NotificationEmailSignature) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codsigna) from NotificationEmailSignature) as bigint) + 1, 1) where id_objecto = 'NotificationEmailSignature'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'NotificationMessage')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('NotificationMessage', coalesce(cast((select max(codmesgs) from NotificationMessage) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codmesgs) from NotificationMessage) as bigint) + 1, 1) where id_objecto = 'NotificationMessage'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AsyncProcessAttachments')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AsyncProcessAttachments', coalesce(cast((select max(codpranx) from AsyncProcessAttachments) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codpranx) from AsyncProcessAttachments) as bigint) + 1, 1) where id_objecto = 'AsyncProcessAttachments'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'UserAuthorization')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('UserAuthorization', coalesce(cast((select max(codua) from UserAuthorization) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codua) from UserAuthorization) as bigint) + 1, 1) where id_objecto = 'UserAuthorization'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFMEM')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFMEM', coalesce(cast((select max(CODMEM) from AJFMEM) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODMEM) from AJFMEM) as bigint) + 1, 1) where id_objecto = 'AJFMEM'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFCFG')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFCFG', coalesce(cast((select max(CODCFG) from AJFCFG) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODCFG) from AJFCFG) as bigint) + 1, 1) where id_objecto = 'AJFCFG'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFUSRSET')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFUSRSET', coalesce(cast((select max(CODUSRSET) from AJFUSRSET) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODUSRSET) from AJFUSRSET) as bigint) + 1, 1) where id_objecto = 'AJFUSRSET'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFUSRCFG')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFUSRCFG', coalesce(cast((select max(CODUSRCFG) from AJFUSRCFG) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODUSRCFG) from AJFUSRCFG) as bigint) + 1, 1) where id_objecto = 'AJFUSRCFG'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFWKFACT')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFWKFACT', coalesce(cast((select max(CODWKFACT) from AJFWKFACT) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODWKFACT) from AJFWKFACT) as bigint) + 1, 1) where id_objecto = 'AJFWKFACT'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFWKFCON')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFWKFCON', coalesce(cast((select max(CODWKFCON) from AJFWKFCON) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODWKFCON) from AJFWKFCON) as bigint) + 1, 1) where id_objecto = 'AJFWKFCON'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFWKFLIG')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFWKFLIG', coalesce(cast((select max(CODWKFLIG) from AJFWKFLIG) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODWKFLIG) from AJFWKFLIG) as bigint) + 1, 1) where id_objecto = 'AJFWKFLIG'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFWKFLOW')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFWKFLOW', coalesce(cast((select max(CODWKFLOW) from AJFWKFLOW) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODWKFLOW) from AJFWKFLOW) as bigint) + 1, 1) where id_objecto = 'AJFWKFLOW'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFNOTIFI')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFNOTIFI', coalesce(cast((select max(CODNOTIFI) from AJFNOTIFI) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODNOTIFI) from AJFNOTIFI) as bigint) + 1, 1) where id_objecto = 'AJFNOTIFI'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFSCRCRD')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFSCRCRD', coalesce(cast((select max(CODSCRCRD) from AJFSCRCRD) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODSCRCRD) from AJFSCRCRD) as bigint) + 1, 1) where id_objecto = 'AJFSCRCRD'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFPOSTIT')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFPOSTIT', coalesce(cast((select max(CODPOSTIT) from AJFPOSTIT) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODPOSTIT) from AJFPOSTIT) as bigint) + 1, 1) where id_objecto = 'AJFPOSTIT'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFPRMFRM')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFPRMFRM', coalesce(cast((select max(CODPRMFRM) from AJFPRMFRM) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODPRMFRM) from AJFPRMFRM) as bigint) + 1, 1) where id_objecto = 'AJFPRMFRM'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFALERTA')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFALERTA', coalesce(cast((select max(CODALERTA) from AJFALERTA) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODALERTA) from AJFALERTA) as bigint) + 1, 1) where id_objecto = 'AJFALERTA'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFALTENT')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFALTENT', coalesce(cast((select max(CODALTENT) from AJFALTENT) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODALTENT) from AJFALTENT) as bigint) + 1, 1) where id_objecto = 'AJFALTENT'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFTALERT')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFTALERT', coalesce(cast((select max(CODTALERT) from AJFTALERT) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODTALERT) from AJFTALERT) as bigint) + 1, 1) where id_objecto = 'AJFTALERT'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFDELEGA')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFDELEGA', coalesce(cast((select max(CODDELEGA) from AJFDELEGA) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODDELEGA) from AJFDELEGA) as bigint) + 1, 1) where id_objecto = 'AJFDELEGA'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFLSTUSR')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFLSTUSR', coalesce(cast((select max(CODLSTUSR) from AJFLSTUSR) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODLSTUSR) from AJFLSTUSR) as bigint) + 1, 1) where id_objecto = 'AJFLSTUSR'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFLSTCOL')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFLSTCOL', coalesce(cast((select max(CODLSTCOL) from AJFLSTCOL) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODLSTCOL) from AJFLSTCOL) as bigint) + 1, 1) where id_objecto = 'AJFLSTCOL'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFLSTREN')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFLSTREN', coalesce(cast((select max(CODLSTREN) from AJFLSTREN) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODLSTREN) from AJFLSTREN) as bigint) + 1, 1) where id_objecto = 'AJFLSTREN'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFUSRWID')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFUSRWID', coalesce(cast((select max(CODUSRWID) from AJFUSRWID) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODUSRWID) from AJFUSRWID) as bigint) + 1, 1) where id_objecto = 'AJFUSRWID'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFTBLCFG')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFTBLCFG', coalesce(cast((select max(CODTBLCFG) from AJFTBLCFG) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODTBLCFG) from AJFTBLCFG) as bigint) + 1, 1) where id_objecto = 'AJFTBLCFG'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFTBLCFGSEL')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFTBLCFGSEL', coalesce(cast((select max(CODTBLCFGSEL) from AJFTBLCFGSEL) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODTBLCFGSEL) from AJFTBLCFGSEL) as bigint) + 1, 1) where id_objecto = 'AJFTBLCFGSEL'

if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'HASHCD')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('HASHCD', coalesce(cast((select max(codHASHCD) from HASHCD) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codHASHCD) from HASHCD) as bigint) + 1, 1) where id_objecto = 'HASHCD'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'DOCUMS')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('DOCUMS', coalesce(cast((select max(codDOCUMS) from DOCUMS) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codDOCUMS) from DOCUMS) as bigint) + 1, 1) where id_objecto = 'DOCUMS'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'UserAuthorization')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('UserAuthorization', coalesce(cast((select max(CODUA) from UserAuthorization) as int) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODUA) from UserAuthorization) as int) + 1, 1) where id_objecto = 'UserAuthorization'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFWORKFLOWPROCESS')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFWORKFLOWPROCESS', coalesce(cast((select max(CODPRCESS) from AJFWORKFLOWPROCESS) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODPRCESS) from AJFWORKFLOWPROCESS) as bigint) + 1, 1) where id_objecto = 'AJFWORKFLOWPROCESS'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'AJFWORKFLOWTASK')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('AJFWORKFLOWTASK', coalesce(cast((select max(CODTASK) from AJFWORKFLOWTASK) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODTASK) from AJFWORKFLOWTASK) as bigint) + 1, 1) where id_objecto = 'AJFWORKFLOWTASK'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'NotificationEmailSignature')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('NotificationEmailSignature', coalesce(cast((select max(codsigna) from NotificationEmailSignature) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codsigna) from NotificationEmailSignature) as bigint) + 1, 1) where id_objecto = 'NotificationEmailSignature'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'NotificationMessage')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('NotificationMessage', coalesce(cast((select max(codmesgs) from NotificationMessage) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(codmesgs) from NotificationMessage) as bigint) + 1, 1) where id_objecto = 'NotificationMessage'
if not exists (select id_objecto from Codigos_Sequenciais where id_objecto = 'ReportList')
	insert into Codigos_Sequenciais (id_objecto, proximo) values ('ReportList', coalesce(cast((select max(CODREPORT) from ReportList) as bigint) + 1, 1))
else
	update Codigos_Sequenciais set proximo = coalesce(cast((select max(CODREPORT) from ReportList) as bigint) + 1, 1) where id_objecto = 'ReportList'
GO
 