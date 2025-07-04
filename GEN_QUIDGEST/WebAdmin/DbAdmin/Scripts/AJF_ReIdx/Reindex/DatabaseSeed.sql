USE [W_GnBD]


DECLARE @codPsw bigint 

DECLARE @codUserAuth bigint 

IF NOT EXISTS (SELECT * FROM UserLogin WHERE nome = 'QUIDGEST') 
BEGIN
		SET @codPsw = (select  proximo  from Codigos_Sequenciais where id_objecto = 'UserLogin')
	EXEC dbo.updateCod 'UserLogin',1
		INSERT INTO UserLogin (codpsw, nome, password, zzstate) VALUES (@codPsw,'QUIDGEST', '', 0)
END
else
	SELECT @codPsw = codpsw FROM UserLogin WHERE nome = 'QUIDGEST'

IF NOT EXISTS (SELECT * FROM UserAuthorization WHERE sistema = 'AJF' AND modulo = 'AJF' and codpsw = @codPsw) 
BEGIN
	SET @codUserAuth = (select  proximo from Codigos_Sequenciais where id_objecto = 'UserAuthorization')
	EXEC dbo.updateCod 'UserAuthorization',1
	INSERT INTO UserAuthorization (codua, codpsw, sistema, modulo, nivel, zzstate) VALUES (@codUserAuth, @codPsw,'AJF', 'AJF', 99, 0)	
END
