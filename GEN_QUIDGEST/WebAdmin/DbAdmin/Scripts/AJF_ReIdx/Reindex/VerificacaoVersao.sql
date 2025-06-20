USE [W_GnBD]
declare @checkdat as datetime
declare @versao as float
declare @sqlver as varchar(20)

select @sqlver=cast(serverproperty('ProductVersion') as varchar(20))
if cast(left(@sqlver,charindex('.',@sqlver)-1) as int)<=9 RAISERROR ('Versão de SQL obsoleta: necessita SQL Server 2008 ou superior!', 16, -1)

set @checkdat = case when (select checkdat from AJFcfg) is null then dateadd(day, -1, getdate()) else (select checkdat from AJFcfg) end
set @versao = (select cast(versao as decimal(6, 2)) from AJFcfg)

if (@versao = '2507')--XXXX.X
begin

	--(RS,SM,NH 2010-05-28) verifica se o relogio do utilizador está sincronizado com o servidor
	--se o dia for inferior damos um intervalo de 2 minutos para ainda poder entrar
	declare @dataUser datetime
	set @dataUser = convert(datetime, 'W_GnDateUser',101)--AAAA-MM-DD
	declare @diferenca int
	set @diferenca = (select datediff(day,@dataUser,getdate()))
	declare @valor bit
	set @valor = 1
	if (@diferenca!=0)
		begin
			if (@diferenca >0)
				begin
					set @diferenca = (select datediff(minute,@dataUser,getdate()))
					if (@diferenca>2)
						set @valor =0
				end
			else
				set @valor = 0
		end
	
	if (@valor =0)
		RAISERROR ('Acesso inválido(Data incompatível com a data do servidor)!', 16, -1)

	declare @dataLim datetime
	set @dataLim = convert(datetime, 'W_GnDateLim',101)--AAAA-MM-DD
	if (datediff(day, GETDATE(), @dataLim) >= 0)
	begin
		if (not(datediff(day, dateadd(day, 15, GETDATE()), @dataLim) > 0))
		begin
			declare @erro as nvarchar (4000)
			set @erro = 'ATENÇÃO: O acesso ao sistema apenas é permitido até ' + convert(varchar,@dataLim,103) + '!\nPor favor contacte a Quidgest.'
			RAISERROR (@erro, 0, -1) --nao é erro, é só um aviso	
		end
		if (datediff(day, @checkdat, GETDATE()) >= 0)
		begin
			if (datediff(day, @checkdat, GETDATE()) != 0)
				update AJFcfg set checkdat = GETDATE()
		end
		else
			RAISERROR ('Por favor, sincronize os relógios dos PCs que utilizam a aplicação e tente de novo!', 16, -1)
	end
	else
		RAISERROR ('A data de verificação não permite o acesso à aplicação!\nPor favor, contacte a Quidgest.', 16, -1)
end
else
	RAISERROR ('É necessário actualizar a Base de Dados antes de utilizar esta versão da aplicação!', 16, -1)
GO
