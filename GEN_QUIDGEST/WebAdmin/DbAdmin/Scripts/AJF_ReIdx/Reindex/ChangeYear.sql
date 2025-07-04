USE [W_GnBD]

GO

USE [W_GnSrcBD]

-- migração de dados da tabela AJFAgente (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[AJFAgente] ([CODAGENT], [NAME], [PHOTO], [EMAIL], [PHONE], [PERC_COM], [TOTCOMIS], [GENDER], [ZZSTATE])
SELECT [AGENT].[CODAGENT], [AGENT].[NAME], [AGENT].[PHOTO], [AGENT].[EMAIL], [AGENT].[PHONE], [AGENT].[PERC_COM], [AGENT].[TOTCOMIS], [AGENT].[GENDER], [AGENT].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[AJFAgente] AS [AGENT]
WHERE [AGENT].ZZSTATE = 0
GO

-- migração de dados da tabela AJFCountry (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[AJFCountry] ([CODCNTRY], [COUNTRY], [ZZSTATE])
SELECT [CNTRY].[CODCNTRY], [CNTRY].[COUNTRY], [CNTRY].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[AJFCountry] AS [CNTRY]
WHERE [CNTRY].ZZSTATE = 0
GO

-- migração de dados da tabela AJFMEM (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[AJFMEM] ([CODMEM], [LOGIN], [ROTINA], [ALTURA], [OBS], [HOSTID], [CLIENTID], [ZZSTATE])
SELECT [MEM].[CODMEM], [MEM].[LOGIN], [MEM].[ROTINA], [MEM].[ALTURA], [MEM].[OBS], [MEM].[HOSTID], [MEM].[CLIENTID], [MEM].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[AJFMEM] AS [MEM]
WHERE [MEM].ZZSTATE = 0
GO

-- migração de dados da tabela UserLogin (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[UserLogin] ([CODPSW], [NOME], [PASSWORD], [CERTSN], [EMAIL], [PSWTYPE], [SALT], [DATAPSW], [USERID], [PSW2FAVL], [PSW2FATP], [DATEXP], [ATTEMPTS], [PHONE], [STATUS], [ASSOCIA], [OPERCRIA], [DATACRIA], [OPERMUDA], [DATAMUDA], [ZZSTATE])
SELECT [PSW].[CODPSW], [PSW].[NOME], [PSW].[PASSWORD], [PSW].[CERTSN], [PSW].[EMAIL], [PSW].[PSWTYPE], [PSW].[SALT], [PSW].[DATAPSW], [PSW].[USERID], [PSW].[PSW2FAVL], [PSW].[PSW2FATP], [PSW].[DATEXP], [PSW].[ATTEMPTS], [PSW].[PHONE], [PSW].[STATUS], [PSW].[ASSOCIA], [PSW].[OPERCRIA], [PSW].[DATACRIA], [PSW].[OPERMUDA], [PSW].[DATAMUDA], [PSW].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[UserLogin] AS [PSW]
WHERE [PSW].ZZSTATE = 0
GO

-- migração de dados da tabela AsyncProcess (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[AsyncProcess] ([CODASCPR], [TYPE], [DATEREQU], [INITPRC], [ENDPRC], [DURATION], [STATUS], [RSLTMSG], [FINISHED], [LASTUPDT], [RESULT], [INFO], [PERCENTA], [MODOPROC], [EXTERNAL], [ID], [CODENTIT], [MOTIVO], [CODPSW], [OPERSHUT], [OPERCRIA], [DATACRIA], [OPERMUDA], [DATAMUDA], [ZZSTATE])
SELECT [S_APR].[CODASCPR], [S_APR].[TYPE], [S_APR].[DATEREQU], [S_APR].[INITPRC], [S_APR].[ENDPRC], [S_APR].[DURATION], [S_APR].[STATUS], [S_APR].[RSLTMSG], [S_APR].[FINISHED], [S_APR].[LASTUPDT], [S_APR].[RESULT], [S_APR].[INFO], [S_APR].[PERCENTA], [S_APR].[MODOPROC], [S_APR].[EXTERNAL], [S_APR].[ID], [S_APR].[CODENTIT], [S_APR].[MOTIVO], [S_APR].[CODPSW], [S_APR].[OPERSHUT], [S_APR].[OPERCRIA], [S_APR].[DATACRIA], [S_APR].[OPERMUDA], [S_APR].[DATAMUDA], [S_APR].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[AsyncProcess] AS [S_APR]
WHERE [S_APR].ZZSTATE = 0
GO

-- migração de dados da tabela NotificationEmailSignature (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[NotificationEmailSignature] ([CODSIGNA], [NAME], [IMAGE], [TEXTASS], [USERNAME], [PASSWORD], [OPERCRIA], [DATACRIA], [OPERMUDA], [DATAMUDA], [ZZSTATE])
SELECT [S_NES].[CODSIGNA], [S_NES].[NAME], [S_NES].[IMAGE], [S_NES].[TEXTASS], [S_NES].[USERNAME], [S_NES].[PASSWORD], [S_NES].[OPERCRIA], [S_NES].[DATACRIA], [S_NES].[OPERMUDA], [S_NES].[DATAMUDA], [S_NES].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[NotificationEmailSignature] AS [S_NES]
WHERE [S_NES].ZZSTATE = 0
GO

-- migração de dados da tabela NotificationMessage (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[NotificationMessage] ([CODMESGS], [CODSIGNA], [CODPMAIL], [FROM], [CODTPNOT], [CODDESTN], [TO], [DESTNMAN], [TOMANUAL], [CC], [BCC], [IDNOTIF], [NOTIFICA], [EMAIL], [ASSUNTO], [AGREGADO], [ANEXO], [HTML], [ATIVO], [DESIGNAC], [MENSAGEM], [GRAVABD], [OPERCRIA], [DATACRIA], [OPERMUDA], [DATAMUDA], [ZZSTATE])
SELECT [S_NM].[CODMESGS], [S_NM].[CODSIGNA], [S_NM].[CODPMAIL], [S_NM].[FROM], [S_NM].[CODTPNOT], [S_NM].[CODDESTN], [S_NM].[TO], [S_NM].[DESTNMAN], [S_NM].[TOMANUAL], [S_NM].[CC], [S_NM].[BCC], [S_NM].[IDNOTIF], [S_NM].[NOTIFICA], [S_NM].[EMAIL], [S_NM].[ASSUNTO], [S_NM].[AGREGADO], [S_NM].[ANEXO], [S_NM].[HTML], [S_NM].[ATIVO], [S_NM].[DESIGNAC], [S_NM].[MENSAGEM], [S_NM].[GRAVABD], [S_NM].[OPERCRIA], [S_NM].[DATACRIA], [S_NM].[OPERMUDA], [S_NM].[DATAMUDA], [S_NM].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[NotificationMessage] AS [S_NM]
WHERE [S_NM].ZZSTATE = 0
GO

-- migração de dados da tabela AJFCLUB (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[AJFCLUB] ([CODCLUB], [NAME], [CODCNTRY], [ZZSTATE])
SELECT [CLUB].[CODCLUB], [CLUB].[NAME], [CLUB].[CODCNTRY], [CLUB].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[AJFCLUB] AS [CLUB]
WHERE [CLUB].ZZSTATE = 0
GO

-- migração de dados da tabela AJFPlayer (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[AJFPlayer] ([CODPLAYR], [NAME], [BIRTHDAT], [COUNTRY], [POSIC], [AGE], [GENDER], [UNDCTC], [CODCNTRY], [CODAGENT], [ZZSTATE])
SELECT [PLAYR].[CODPLAYR], [PLAYR].[NAME], [PLAYR].[BIRTHDAT], [PLAYR].[COUNTRY], [PLAYR].[POSIC], [PLAYR].[AGE], [PLAYR].[GENDER], [PLAYR].[UNDCTC], [PLAYR].[CODCNTRY], [PLAYR].[CODAGENT], [PLAYR].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[AJFPlayer] AS [PLAYR]
WHERE [PLAYR].ZZSTATE = 0
GO

-- migração de dados da tabela AsyncProcessArgument (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[AsyncProcessArgument] ([CODARGPR], [CODS_APR], [ID], [VALOR], [DOCUMENT], [DOCUMENTFK], [TIPO], [DESIGNAC], [HIDDEN], [OPERCRIA], [DATACRIA], [OPERMUDA], [DATAMUDA], [ZZSTATE])
SELECT [S_ARG].[CODARGPR], [S_ARG].[CODS_APR], [S_ARG].[ID], [S_ARG].[VALOR], [S_ARG].[DOCUMENT], [S_ARG].[DOCUMENTFK], [S_ARG].[TIPO], [S_ARG].[DESIGNAC], [S_ARG].[HIDDEN], [S_ARG].[OPERCRIA], [S_ARG].[DATACRIA], [S_ARG].[OPERMUDA], [S_ARG].[DATAMUDA], [S_ARG].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[AsyncProcessArgument] AS [S_ARG]
WHERE [S_ARG].ZZSTATE = 0
GO

-- migração de dados da tabela AsyncProcessAttachments (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[AsyncProcessAttachments] ([CODPRANX], [CODS_APR], [DOCUMENT], [DOCUMENTFK], [OPERCRIA], [DATACRIA], [ZZSTATE])
SELECT [S_PAX].[CODPRANX], [S_PAX].[CODS_APR], [S_PAX].[DOCUMENT], [S_PAX].[DOCUMENTFK], [S_PAX].[OPERCRIA], [S_PAX].[DATACRIA], [S_PAX].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[AsyncProcessAttachments] AS [S_PAX]
WHERE [S_PAX].ZZSTATE = 0
GO

-- migração de dados da tabela UserAuthorization (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[UserAuthorization] ([CODUA], [CODPSW], [SISTEMA], [MODULO], [NAODUPLI], [ROLE], [NIVEL], [OPERCRIA], [DATACRIA], [OPERMUDA], [DATAMUDA], [ZZSTATE])
SELECT [S_UA].[CODUA], [S_UA].[CODPSW], [S_UA].[SISTEMA], [S_UA].[MODULO], [S_UA].[NAODUPLI], [S_UA].[ROLE], [S_UA].[NIVEL], [S_UA].[OPERCRIA], [S_UA].[DATACRIA], [S_UA].[OPERMUDA], [S_UA].[DATAMUDA], [S_UA].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[UserAuthorization] AS [S_UA]
WHERE [S_UA].ZZSTATE = 0
GO

-- migração de dados da tabela AJFContract (Modo: 0)
INSERT INTO [W_GnBD].[dbo].[AJFContract] ([CODCONTR], [STARTDAT], [FINDATE], [SALARY], [CODPLAYR], [CODCLUB], [CODAGENT], [TRANSVAL], [COMISEUR], [CTRDURAT], [SLRYYR], [ZZSTATE])
SELECT [CONTR].[CODCONTR], [CONTR].[STARTDAT], [CONTR].[FINDATE], [CONTR].[SALARY], [CONTR].[CODPLAYR], [CONTR].[CODCLUB], [CONTR].[CODAGENT], [CONTR].[TRANSVAL], [CONTR].[COMISEUR], [CONTR].[CTRDURAT], [CONTR].[SLRYYR], [CONTR].[ZZSTATE]
 FROM [W_GnSrcBD].[dbo].[AJFContract] AS [CONTR]
WHERE [CONTR].ZZSTATE = 0
GO

-- Tabelas Hardcoded
-- migração de dados da tabela Codigos Sequenciais
INSERT INTO [W_GnBD].[dbo].[Codigos_Sequenciais] (id_objecto, proximo)
SELECT id_objecto, proximo FROM [W_GnSrcBD].[dbo].[Codigos_Sequenciais]
GO

-- migração de dados da tabela UserAuthorization
INSERT INTO [W_GnBD].[dbo].[UserAuthorization] (CODUA, CODPSW, SISTEMA, MODULO, ROLE, NIVEL, ZZSTATE)
SELECT UA.CODUA, UA.CODPSW, UA.SISTEMA, UA.MODULO, UA.ROLE, UA.NIVEL, UA.ZZSTATE FROM [W_GnSrcBD].[dbo].[UserAuthorization] AS UA
WHERE UA.ZZSTATE = 0
GO

-- migração de dados da tabela CFG (ao criar schema, fica criada uma linha nesta tabela)
--INSERT INTO [W_GnBD].[dbo].[AJFcfg] (codcfg, checkdat, versao, versindx, manutdat, upgrindx, ZZSTATE)
--SELECT codcfg, checkdat, versao, versindx, manutdat, upgrindx, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFcfg]
--WHERE ZZSTATE = 0
--GO

-- migração de dados da tabela LSTUSR
INSERT INTO [W_GnBD].[dbo].[AJFlstusr] (CODLSTUSR, CODPSW, DESCRIC, IDLIST, MODULO, SISTEMA, ORDERCOL, ORDERTYPE, [DATA], ZZSTATE)
SELECT CODLSTUSR, CODPSW, DESCRIC, IDLIST, MODULO, SISTEMA, ORDERCOL, ORDERTYPE, [DATA], ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFlstusr]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela LSTCOL
INSERT INTO [W_GnBD].[dbo].[AJFlstcol] (CODLSTCOL, CODLSTUSR, TABELA, ALIAS, CAMPO, VISIVEL, POSICAO, OPERACAO, TIPO, ZZSTATE)
SELECT CODLSTCOL, CODLSTUSR, TABELA, ALIAS, CAMPO, VISIVEL, POSICAO, OPERACAO, TIPO, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFlstcol]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela LSTREN
INSERT INTO [W_GnBD].[dbo].[AJFlstren] (CODLSTREN, CODLSTUSR, RENDERIZACAO, VISIVEL, POSICAO, OPERACAO, TIPO, ZZSTATE)
SELECT CODLSTREN, CODLSTUSR, RENDERIZACAO, VISIVEL, POSICAO, OPERACAO, TIPO, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFlstren]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela USRWID
INSERT INTO [W_GnBD].[dbo].[AJFusrwid] (CODUSRWID, CODLSTUSR, WIDGET, ROWKEY, VISIBLE, HPOSITION, VPOSITION, ZZSTATE)
SELECT CODUSRWID, CODLSTUSR, WIDGET, ROWKEY, VISIBLE, HPOSITION, VPOSITION, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFusrwid]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela USRCFG
INSERT INTO [W_GnBD].[dbo].[AJFusrcfg] (codusrcfg, modulo, codpsw, tipo, id, ZZSTATE)
SELECT codusrcfg, modulo, codpsw, tipo, id, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFusrcfg]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela USRSET
INSERT INTO [W_GnBD].[dbo].[AJFusrset] (codusrset, modulo, codpsw, chave, valor, ZZSTATE)
SELECT codusrset, modulo, codpsw, chave, valor, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFusrset]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela WKFACT
INSERT INTO [W_GnBD].[dbo].[AJFwkfact] (codwkfact, wfid, actid, tpactid, descrica, duracao, perfil, perfilu, x, y, ZZSTATE)
SELECT codwkfact, wfid, actid, tpactid, descrica, duracao, perfil, perfilu, x, y, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFwkfact]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela WKFCON
INSERT INTO [W_GnBD].[dbo].[AJFwkfcon] (codwkfcon, wfid, condid, tpcondid, descrica, tiporegr, sinal, x, y, valor, ZZSTATE)
SELECT codwkfcon, wfid, condid, tpcondid, descrica, tiporegr, sinal, x, y, valor, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFwkfcon]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela WKFLIG
INSERT INTO [W_GnBD].[dbo].[AJFwkflig] (codwkflig, wfid, parentid, childid, ptoy, ptox, ptor, tipo, pfromx, pfromy, pfromr, ZZSTATE)
SELECT codwkflig, wfid, parentid, childid, ptoy, ptox, ptor, tipo, pfromx, pfromy, pfromr, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFwkflig]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela WKFLOW
INSERT INTO [W_GnBD].[dbo].[AJFwkflow] (codwkflow, descrica, modulo, ZZSTATE)
SELECT codwkflow, descrica, modulo, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFwkflow]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela NOTIFI
INSERT INTO [W_GnBD].[dbo].[AJFnotifi] (codnotifi, modulo, descrica, activid, menuid, usernivl, wfid, ZZSTATE)
SELECT codnotifi, modulo, descrica, activid, menuid, usernivl, wfid, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFnotifi]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela PRMFRM
INSERT INTO [W_GnBD].[dbo].[AJFprmfrm] (codprmfrm, desform, perfil, autoriza, sevalida, prfvalid, prazodia, comprova, prazohor, secompro, mensag1, mensag2, mensag3, mensag4, ZZSTATE)
SELECT codprmfrm, desform, perfil, autoriza, sevalida, prfvalid, prazodia, comprova, prazohor, secompro, mensag1, mensag2, mensag3, mensag4, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFprmfrm]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela SCRCRD
INSERT INTO [W_GnBD].[dbo].[AJFscrcrd] (codscrcrd, descrica, valor, cor, seta, usernivl, ZZSTATE)
SELECT codscrcrd, descrica, valor, cor, seta, usernivl, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFscrcrd]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela DOCUMS
INSERT INTO [W_GnBD].[dbo].[docums] (coddocums, documid, document, docpath, tabela, campo, chave, form, nome, versao, tamanho, extensao, opercria, datacria, opermuda, datamuda, ZZSTATE)
SELECT coddocums, documid, document, docpath, tabela, campo, chave, form, nome, versao, tamanho, extensao, opercria, datacria, opermuda, datamuda, ZZSTATE FROM [W_GnSrcBD].[dbo].[docums]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela POSTIT
INSERT INTO [W_GnBD].[dbo].[AJFpostit] (codpostit, tabela, codtabel, postit, tpostit, datacria, opercria, codpsw, lido, apagado, validade, nivel, codpost1, ZZSTATE)
SELECT codpostit, tabela, codtabel, postit, tpostit, datacria, opercria, codpsw, lido, apagado, validade, nivel, codpost1, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFpostit]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela HASHCD
INSERT INTO [W_GnBD].[dbo].[hashcd] (codhashcd, tabela, campos, datacria, ZZSTATE)
SELECT codhashcd, tabela, campos, datacria, ZZSTATE FROM [W_GnSrcBD].[dbo].[hashcd]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela ALERTA
INSERT INTO [W_GnBD].[dbo].[AJFalerta] (codalerta, codaltent, mensagem, tratado, activo, datacria, datareso, menu, cor, interno, backgrou, sms, email, emailenv, smsenvia, codigo, codigotp, ZZSTATE)
SELECT codalerta, codaltent, mensagem, tratado, activo, datacria, datareso, menu, cor, interno, backgrou, sms, email, emailenv, smsenvia, codigo, codigotp, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFalerta]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela ALTENT
INSERT INTO [W_GnBD].[dbo].[AJFaltent] (codaltent, codtalert, codpsw, grupo, contador, tipo, mensagem, antecede, datainic, datafina, dtmodifi, todos, backgrou, sms, email, codtpgru, codtpess, menu, incluian, activo, individu, ZZSTATE)
SELECT codaltent, codtalert, codpsw, grupo, contador, tipo, mensagem, antecede, datainic, datafina, dtmodifi, todos, backgrou, sms, email, codtpgru, codtpess, menu, incluian, activo, individu, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFaltent]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela TALERT
INSERT INTO [W_GnBD].[dbo].[AJFtalert] (codtalert, nome, metodo, priorida, cor, texto, menu, cmpnome, daltinic, daltfina, incluian, diferenc, anodifer, mesdifer, diadifer, ntabmae, ntabfilh, formid, tabela, campo, tipo, modulo, condicao, ZZSTATE)
SELECT codtalert, nome, metodo, priorida, cor, texto, menu, cmpnome, daltinic, daltfina, incluian, diferenc, anodifer, mesdifer, diadifer, ntabmae, ntabfilh, formid, tabela, campo, tipo, modulo, condicao, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFtalert]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela DELEGA
INSERT INTO [W_GnBD].[dbo].[AJFdelega] (coddelega, codpswup, codpswdw, dateini, dateend, message, revoked, auditusr, opercria, datacria, opermuda, datamuda, ZZSTATE)
SELECT coddelega, codpswup, codpswdw, dateini, dateend, message, revoked, auditusr, opercria, datacria, opermuda, datamuda, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFdelega]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela TABDINAMIC
INSERT INTO [W_GnBD].[dbo].[AJFTABDINAMIC] (codtabdinamic, NOMETABELA, NOMECAMPO, TIPODADOS, TIPOSQL, LARGURA, ZZSTATE)
SELECT codtabdinamic, NOMETABELA, NOMECAMPO, TIPODADOS, TIPOSQL, LARGURA, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFTABDINAMIC]
WHERE ZZSTATE = 0
GO


-- migração de dados da tabela ALTRAN
INSERT INTO [W_GnBD].[dbo].[AJFaltran] (codaltran, typlabel, referenc, [language], curlabel, labellng, altran, opercria, datacria, opermuda, datamuda, ZZSTATE)
SELECT codaltran, typlabel, referenc, [language], curlabel, labellng, altran, opercria, datacria, opermuda, datamuda, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFaltran]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela WORKFLOWTASK
INSERT INTO [W_GnBD].[dbo].[AJFworkflowtask] (codtask, codprcess, taskdefid, taskid, performedby, runningsince, nextrun, modifieddate, modifiedby, skipped, isactive, errorExecute, ZZSTATE)
SELECT codtask, codprcess, taskdefid, taskid, performedby, runningsince, nextrun, modifieddate, modifiedby, skipped, isactive, errorExecute, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFworkflowtask]
WHERE ZZSTATE = 0
GO

-- migração de dados da tabela WORKFLOWPROCESS
INSERT INTO [W_GnBD].[dbo].[AJFworkflowprocess] (codprcess, prcessid, prcessdefid, createdby, status, startdate, modifieddate, modifiedby, codinstance, dotgraph, wferror, ltask, idhk, ZZSTATE)
SELECT codprcess, prcessid, prcessdefid, createdby, status, startdate, modifieddate, modifiedby, codinstance, dotgraph, wferror, ltask, idhk, ZZSTATE FROM [W_GnSrcBD].[dbo].[AJFworkflowprocess]
WHERE ZZSTATE = 0
GO


USE [W_GnBD]
GO
-- Removing invalid FK values
UPDATE [CLUB] SET
[CLUB].[CODCNTRY] = [q0_CNTRY].[CODCNTRY]
 FROM [W_GnBD].[dbo].[AJFCLUB] AS [CLUB]
LEFT JOIN [AJFCountry] AS [q0_CNTRY] ON [CLUB].[CODCNTRY] = [q0_CNTRY].[CODCNTRY]
GO

UPDATE [PLAYR] SET
[PLAYR].[CODAGENT] = [q0_AGENT].[CODAGENT]
, [PLAYR].[CODCNTRY] = [q1_CNTRY].[CODCNTRY]
 FROM [W_GnBD].[dbo].[AJFPlayer] AS [PLAYR]
LEFT JOIN [AJFAgente] AS [q0_AGENT] ON [PLAYR].[CODAGENT] = [q0_AGENT].[CODAGENT]
LEFT JOIN [AJFCountry] AS [q1_CNTRY] ON [PLAYR].[CODCNTRY] = [q1_CNTRY].[CODCNTRY]
GO

UPDATE [S_ARG] SET
[S_ARG].[CODS_APR] = [q0_S_APR].[CODASCPR]
 FROM [W_GnBD].[dbo].[AsyncProcessArgument] AS [S_ARG]
LEFT JOIN [AsyncProcess] AS [q0_S_APR] ON [S_ARG].[CODS_APR] = [q0_S_APR].[CODASCPR]
GO

UPDATE [S_PAX] SET
[S_PAX].[CODS_APR] = [q0_S_APR].[CODASCPR]
 FROM [W_GnBD].[dbo].[AsyncProcessAttachments] AS [S_PAX]
LEFT JOIN [AsyncProcess] AS [q0_S_APR] ON [S_PAX].[CODS_APR] = [q0_S_APR].[CODASCPR]
GO

UPDATE [S_UA] SET
[S_UA].[CODPSW] = [q0_PSW].[CODPSW]
 FROM [W_GnBD].[dbo].[UserAuthorization] AS [S_UA]
LEFT JOIN [UserLogin] AS [q0_PSW] ON [S_UA].[CODPSW] = [q0_PSW].[CODPSW]
GO

UPDATE [CONTR] SET
[CONTR].[CODAGENT] = [q0_AGENT].[CODAGENT]
, [CONTR].[CODCLUB] = [q1_CLUB].[CODCLUB]
, [CONTR].[CODPLAYR] = [q2_PLAYR].[CODPLAYR]
 FROM [W_GnBD].[dbo].[AJFContract] AS [CONTR]
LEFT JOIN [AJFAgente] AS [q0_AGENT] ON [CONTR].[CODAGENT] = [q0_AGENT].[CODAGENT]
LEFT JOIN [AJFCLUB] AS [q1_CLUB] ON [CONTR].[CODCLUB] = [q1_CLUB].[CODCLUB]
LEFT JOIN [AJFPlayer] AS [q2_PLAYR] ON [CONTR].[CODPLAYR] = [q2_PLAYR].[CODPLAYR]
GO


USE [W_GnBD]

GO
