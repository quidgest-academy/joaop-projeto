EXEC BackupComputedColumns
GO

use [W_GnBD]

if (object_id(N'[dbo].[emptyL]', 'FN') is not null) drop function [dbo].[emptyL]
exec ('CREATE FUNCTION dbo.emptyL (@value bigint)  RETURNS INT WITH SCHEMABINDING AS  BEGIN if @value is null or @value = 0 return 1 return 0 END')

if (object_id(N'[dbo].[emptyD]', 'FN') is not null) drop function [dbo].[emptyD]
exec ('CREATE FUNCTION dbo.emptyD (@value datetime)  RETURNS INT WITH SCHEMABINDING AS  BEGIN if @value is null return 1 declare @limitDate datetime set @limitDate = convert(datetime, ''01-01-1900'', 105) if @limitDate > @value return 1 return 0 END')

if (object_id(N'[dbo].[emptyN]', 'FN') is not null) drop function [dbo].[emptyN]
exec ('CREATE FUNCTION dbo.emptyN (@value float)  RETURNS INT WITH SCHEMABINDING AS  BEGIN if @value is null or @value = 0.0 return 1 return 0 END')

if (object_id(N'[dbo].[emptyC]', 'FN') is not null) drop function [dbo].[emptyC]
exec ('CREATE FUNCTION dbo.emptyC (@value varchar(8000))  RETURNS INT WITH SCHEMABINDING AS  BEGIN if @value is null or len(@value) = 0 or len(rtrim(@value)) = 0 return 1 return 0 END')

if (object_id(N'[dbo].[emptyG]', 'FN') is not null) drop function [dbo].[emptyG]
exec ('CREATE FUNCTION dbo.emptyG (@value varchar(38))  RETURNS INT WITH SCHEMABINDING AS  BEGIN if @value is null or @value = ''00000000-0000-0000-0000-000000000000'' or @value = '''' or @value = ''{00000000-0000-0000-0000-000000000000}'' or @value = ''0'' return 1 return 0 END')

if (object_id(N'[dbo].[emptyT]', 'FN') is not null) drop function [dbo].[emptyT]
exec ('CREATE FUNCTION [dbo].[emptyT] (@value varchar(8000))  RETURNS INT WITH SCHEMABINDING AS  BEGIN if @value is null or len(@value) = 0 or len(rtrim(@value)) = 0 or @value = ''__:__'' return 1 return 0 END')

if (object_id(N'[dbo].[theAppAno]', 'FN') is not null) drop function [dbo].[theAppAno]
exec ('CREATE FUNCTION dbo.theAppAno () RETURNS bigint WITH SCHEMABINDING AS BEGIN return W_GnAppAno END')

if (object_id(N'[dbo].[theAppSigla]', 'FN') is not null) drop function [dbo].[theAppSigla]
exec ('CREATE FUNCTION dbo.theAppSigla () RETURNS varchar(10) WITH SCHEMABINDING AS BEGIN return ''W_GnAppSigla'' END')

if (object_id(N'[dbo].[minD]', 'FN') is not null) drop function [dbo].[minD]
exec ('CREATE FUNCTION dbo.minD (@date1 datetime, @date2 datetime) RETURNS datetime WITH SCHEMABINDING AS BEGIN if @date1< @date2 return @date1 return @date2 END')

if (object_id(N'[dbo].[minN]', 'FN') is not null) drop function [dbo].[minN]
exec ('CREATE FUNCTION dbo.minN (@value1 float, @value2 float) RETURNS float WITH SCHEMABINDING AS  BEGIN if @value1< @value2  return @value1 return @value2 END')

if (object_id(N'[dbo].[maxD]', 'FN') is not null) drop function [dbo].[maxD]
exec ('CREATE FUNCTION dbo.maxD (@date1 datetime, @date2 datetime) RETURNS datetime WITH SCHEMABINDING AS BEGIN if @date1> @date2 return @date1 return @date2 END')

if (object_id(N'[dbo].[maxN]', 'FN') is not null) drop function [dbo].[maxN]
exec ('CREATE FUNCTION dbo.maxN (@value1 float, @value2 float) RETURNS float WITH SCHEMABINDING AS  BEGIN if @value1> @value2  return @value1 return @value2 END')

if (object_id(N'[dbo].[atoi]', 'FN') is not null) drop function [dbo].[atoi]
exec ('CREATE FUNCTION dbo.atoi (@value VARCHAR(50)) RETURNS BIGINT WITH SCHEMABINDING AS BEGIN RETURN CASE WHEN ISNUMERIC(@value)=1 THEN CAST (@value AS BIGINT) ELSE 0 END END')

if (object_id(N'[dbo].[_ttoi]', 'FN') is not null) drop function [dbo].[_ttoi]
exec ('CREATE FUNCTION dbo._ttoi (@value VARCHAR(50)) RETURNS BIGINT WITH SCHEMABINDING AS BEGIN RETURN CASE WHEN ISNUMERIC(@value)=1 THEN CAST (@value AS BIGINT) ELSE 0 END END')

if (object_id(N'[dbo].[IntToString]', 'FN') is not null) drop function [dbo].[IntToString]
exec ('CREATE FUNCTION dbo.IntToString (@val FLOAT) RETURNS VARCHAR(50) WITH SCHEMABINDING AS BEGIN DECLARE @aux VARCHAR(50) IF IsNumeric(@val)=0 SET @aux='''' ELSE SET @aux=CAST(CAST(@val AS DECIMAL(38,0)) AS VARCHAR) RETURN @aux END')

if (object_id(N'[dbo].[NumericToString]', 'FN') is not null) drop function [dbo].[NumericToString]
exec ('CREATE FUNCTION [dbo].[NumericToString] (@val FLOAT, @nCasas int) RETURNS VARCHAR(50) WITH SCHEMABINDING AS BEGIN DECLARE @aux VARCHAR(50) IF IsNumeric(@val)=0 SET @aux='''' ELSE SET @aux=LTRIM(str(Round(@val,@nCasas),25,@nCasas)) RETURN @aux END')

if (object_id(N'[dbo].[SomaDias]', 'FN') is not null) drop function [dbo].[SomaDias]
exec ('CREATE FUNCTION dbo.SomaDias (@date1 datetime, @dias INT) RETURNS datetime WITH SCHEMABINDING AS BEGIN RETURN @date1 + @dias END')

/* MF (2013.08.19 - Acrescentei função que valida se o ano é bissexto) */
if (object_id(N'[dbo].[IsLeapYear]', 'FN') is not null) drop function [dbo].[IsLeapYear]
exec ('CREATE FUNCTION dbo.IsLeapYear (@YEAR INT) RETURNS INT WITH SCHEMABINDING AS BEGIN IF (@YEAR % 4 = 0 AND ( @YEAR % 100 != 0 OR @YEAR % 400 = 0) ) RETURN 1 RETURN 0 END')

/*MF (2014.02.13) - Acrescentei a função que valida se a data é válida. A função já existia em c++.*/
if (object_id(N'[dbo].[IsValid]', 'FN') is not null) drop function [dbo].[IsValid]
EXEC ('CREATE FUNCTION dbo.IsValid (@VAL DATETIME) RETURNS INT WITH SCHEMABINDING AS BEGIN RETURN CASE WHEN ISDATE(@VAL) > 0 THEN 1 ELSE 0 END END')

if (object_id(N'[dbo].[RoundQG]', 'FN') is not null) drop function [dbo].[RoundQG]
--CHN 2016-04-18 Alterado para permitir processamento de valores em notação científica, bem como o tratamento com precisão nos dados.
--OLD: exec ('CREATE FUNCTION dbo.RoundQG (@x FLOAT, @c INT) RETURNS FLOAT AS BEGIN DECLARE @v FLOAT, @i FLOAT, @sinal INT, @str VARCHAR(50), @signal INT SET @v=1 SET @sinal=CASE WHEN @x<0 THEN -1 ELSE 1 END SET @signal=SIGN(@x) SET @x=ABS(@x) SET @v=POWER(10,@c) SET @x=@x*@v*100+0.1 IF @x<50.0 RETURN 0.0 SET @str=LTRIM(STR(FLOOR(@x),50,0)) SET @i=FLOOR(CAST(@str AS FLOAT)/100)*@signal IF CAST(SUBSTRING(@str,LEN(@str)-1,1) AS INT)>4 SET @i=@i+@sinal RETURN @i/@v END')
-- Processamento de Decimals: 23 algarismos de ordem (38-15); 
--arredondamento vai bater certo com até nºs com 15 casas de precisão, deixando 23 casas à esquerda como grandeza de trabalho com precisão; 
--caso sejam valores absurdamente elevados, passa-os directamente (a precisão não será possível de calcular da forma acima e talvez até seja desnecessária)
-- Deixa também de fazer conversões estranhas para strings, o que deve tornar o processo mais rápido.
exec ('CREATE FUNCTION dbo.RoundQG (@x FLOAT, @c INT) RETURNS FLOAT WITH SCHEMABINDING AS BEGIN DECLARE @sinal FLOAT, @folga DECIMAL(38,37) SET @sinal=CASE WHEN @x<0 THEN -1 ELSE 1 END SET @folga=0.001*POWER(CAST(0.1 as float),@c)*@sinal RETURN CASE WHEN @x BETWEEN -99999999999999999999999 AND 99999999999999999999999 THEN ROUND(CAST(@x AS DECIMAL(38, 15)) + @folga, @c) ELSE ROUND(@x + @folga, @c) END END')

/*RS(2008.01.22) Acrescentei estas funções para facilitar a construção das querys das formulas internas quando acedem a campos por LEFT JOIN*/
if (object_id(N'[dbo].[ansi_C]', 'FN') is not null) drop function [dbo].[ansi_C]
exec ('CREATE FUNCTION dbo.ansi_C(@x VARCHAR(8000)) RETURNS VARCHAR(8000) WITH SCHEMABINDING  AS BEGIN RETURN (CASE WHEN @x IS NULL THEN '''' ELSE @x END) END')

if (object_id(N'[dbo].[ansi_N]', 'FN') is not null) drop function [dbo].[ansi_N]
exec ('CREATE FUNCTION dbo.ansi_N(@x float) RETURNS float  WITH SCHEMABINDING AS BEGIN RETURN (CASE WHEN @x IS NULL THEN 0 ELSE @x END) END')

if (object_id(N'[dbo].[ansi_L]', 'FN') is not null) drop function [dbo].[ansi_L]
exec ('CREATE FUNCTION dbo.ansi_L(@x BIGINT) RETURNS BIT  WITH SCHEMABINDING AS BEGIN RETURN (CASE WHEN @x IS NULL THEN 0 ELSE @x END) END')

/*use "+theApp.m_SQLDB+" if (object_id(N'[dbo].[ansi_D]', 'FN') is not null) drop function [dbo].[ansi_D]
CREATE FUNCTION dbo.ansi_D(@x DATETIME) RETURNS DATETIME  WITH SCHEMABINDING AS BEGIN RETURN (CASE WHEN @x IS NULL THEN @x ELSE @x END) END*/

/*JMT(2010.02.14) Acrescentei validação para devolver uma string vazia e não null quando é passada um GUID vazio*/
if (object_id(N'[dbo].[KeyToString]', 'FN') is not null) drop function [dbo].[KeyToString]
exec ('CREATE FUNCTION dbo.KeyToString(@x VARCHAR(38)) RETURNS VARCHAR(32)  WITH SCHEMABINDING AS BEGIN IF @x IS NULL or @x = ''00000000-0000-0000-0000-000000000000'' or @x = '''' or @x = ''{00000000-0000-0000-0000-000000000000}'' or @x=''0'' BEGIN RETURN '''' END RETURN REPLACE(@x,''-'','''') END')

/*ARR(2012.07.26) Transforma uma string num GUID*/
if (object_id(N'[dbo].[StringToKey]', 'FN') is not null) drop function [dbo].[StringToKey]
exec ('CREATE FUNCTION [dbo].[StringToKey](@x VARCHAR(32))
RETURNS VARCHAR(38) WITH SCHEMABINDING AS BEGIN
declare @res as varchar(38)
set @res = @x

IF len(@x)=32
BEGIN
set @res = STUFF(@res, 9, 0, ''-'')
set @res = STUFF(@res, 14, 0, ''-'')
set @res = STUFF(@res, 19, 0, ''-'')
set @res = STUFF(@res, 24, 0, ''-'')
END
RETURN @res
END')

/*SM(2008.12.15) Acrescentei ComparaDatas para SQL*/
if (object_id(N'[dbo].[ComparaDatas]', 'FN') is not null) drop function [dbo].[ComparaDatas]
exec ('CREATE FUNCTION dbo.ComparaDatas (@data1 DATETIME, @data2 DATETIME) RETURNS INT WITH SCHEMABINDING AS BEGIN DECLARE @res INT IF @data1 IS NULL AND @data2 IS NULL SET @res=0 ELSE IF @data1 IS NULL OR @data1<@data2 SET @res=-1 ELSE IF @data2 IS NULL OR @data1>@data2 SET @res=1 ELSE SET @res=0 RETURN @res END')

/*JG(2010.03.12) Acrescentei LengthString para sql*/
if (object_id(N'[dbo].[LengthString]', 'FN') is not null) drop function [dbo].[LengthString]
exec ('CREATE FUNCTION dbo.LengthString (@value varchar(8000))  RETURNS int WITH SCHEMABINDING AS  BEGIN return len(@value) END')

if (object_id(N'[dbo].[Impar]', 'FN') is not null) drop function [dbo].[Impar]
exec ('CREATE FUNCTION dbo.Impar (@n INT) RETURNS INT WITH SCHEMABINDING AS BEGIN RETURN @n % 2 END')

/* 1.O ficheiro ORAFUNC.GQF é integrado em XXXMain.cpp através do comando LDSQL do WINCASE;;
 2.Para funções muito grandes usar uma linha apenas com uma \;;
 o WINCASE vai substituir essa \ por "+_cr_+\";;
 3.O LDSQL do WINCASE só faz mudança de linha quando encontra dois pontivírgulas ;;
 4.Para as funções inseridas em MANWIN, o Genio cria a query que apaga a anterior função.;;
  No sqlfunc.gqf, isso não é feito automaticamente, pelo que tem que ser incluída essa query ;;*/

if (object_id(N'[dbo].[FormatDate]', 'FN') is not null) DROP FUNCTION [dbo].[FormatDate]
exec ('CREATE FUNCTION dbo.FormatDate (@data DATETIME, @str VARCHAR(2000))
RETURNS VARCHAR(2000) WITH SCHEMABINDING AS
BEGIN
	DECLARE @tempStr1 VARCHAR(2000)
	DECLARE @tempStr2 VARCHAR(2)
	DECLARE @index INT
	SET @index = 1
	SET @tempStr1 = ''''
	SET @tempStr2 = ''''
	WHILE LEN(@str) > @index
	BEGIN
		SET @tempStr2 = SUBSTRING(@str, @index, 1)
		SET @index = @index + 1
		IF @tempStr2 = ''%''
		BEGIN
			SET @tempStr2 = @tempStr2 + SUBSTRING(@str, @index, 1)
			SET @index = @index + 1
			-- warning: SQL in our apps is case insensitive, cannot resolve ''%A'' from ''%a'' by comparing just strings, needs also ASCII code
			IF @tempStr2 = ''%A'' AND ASCII(RIGHT(@tempStr2, 1)) = 65
				SET @tempStr1 = @tempStr1 + DATENAME(dw, @data)
			ELSE IF @tempStr2 = ''%a'' AND ASCII(RIGHT(@tempStr2, 1)) = 97
				SET @tempStr1 = @tempStr1 + SUBSTRING(DATENAME(dw, @data), 1, 3)
			ELSE IF @tempStr2 = ''%B'' AND ASCII(RIGHT(@tempStr2, 1)) = 66
				SET @tempStr1 = @tempStr1 + DATENAME(mm, @data)
			ELSE IF @tempStr2 = ''%b'' AND ASCII(RIGHT(@tempStr2, 1)) = 98
				SET @tempStr1 = @tempStr1 + SUBSTRING(DATENAME(mm, @data), 1, 3)
			ELSE IF @tempStr2 = ''%d''
				SET @tempStr1 = @tempStr1 + CASE WHEN DAY(@data) < 10 THEN ''0'' ELSE '''' END + DATENAME(dd, @data)
			ELSE IF @tempStr2 = ''%H''
				SET @tempStr1 = @tempStr1 + CASE WHEN DATEPART(hh, @data) < 10 THEN ''0'' ELSE '''' END + DATENAME(hh, @data)
			ELSE IF @tempStr2 = ''%I''
			BEGIN
				IF DATEPART(hh, @data) > 12
				BEGIN
					SET @tempStr1 = @tempStr1 + CASE WHEN DATEPART(hh, @data) BETWEEN 13 AND 21 THEN ''0'' ELSE '''' END + CAST(DATENAME(hh, @data) - 12 as VARCHAR(10))
				END
				ELSE
					SET @tempStr1 = @tempStr1 + CASE WHEN DATEPART(hh, @data) < 10 THEN ''0'' ELSE '''' END + DATENAME(hh, @data)
			END
			ELSE IF @tempStr2 = ''%j''
				SET @tempStr1 = @tempStr1 + CASE WHEN DATEPART(dy, @data) < 10 THEN ''00'' WHEN DATEPART(dy, @data) BETWEEN 10 AND 99 THEN ''0'' ELSE '''' END + DATENAME(dy, @data)
			ELSE IF @tempStr2 = ''%m'' AND ASCII(RIGHT(@tempStr2, 1)) = 109
				SET @tempStr1 = @tempStr1 + CASE WHEN MONTH(@data) < 10 THEN ''0'' ELSE '''' END + CAST(DATEPART(mm, @data) as VARCHAR)
			ELSE IF @tempStr2 = ''%M'' AND ASCII(RIGHT(@tempStr2, 1)) = 77
				SET @tempStr1 = @tempStr1 + CASE WHEN DATEPART(mi, @data) < 10 THEN ''0'' ELSE '''' END + DATENAME(mi, @data)
			ELSE IF @tempStr2 = ''%S''
				SET @tempStr1 = @tempStr1 + CASE WHEN DATEPART(ss, @data) < 10 THEN ''0'' ELSE '''' END + DATENAME(ss, @data)
			ELSE IF @tempStr2 = ''%U''
				SET @tempStr1 = @tempStr1 + CASE WHEN DATEPART(wk, @data) < 10 THEN ''0'' ELSE '''' END + DATENAME(wk, @data)
			ELSE IF @tempStr2 = ''%w''
				SET @tempStr1 = @tempStr1 + CAST(DATEPART(dw, @data) as VARCHAR(1))
			ELSE IF @tempStr2 = ''%Y'' AND ASCII(RIGHT(@tempStr2, 1)) = 89
				SET @tempStr1 = @tempStr1 + DATENAME(yy, @data)
			ELSE IF @tempStr2 = ''%y'' AND ASCII(RIGHT(@tempStr2, 1)) = 121
				SET @tempStr1 = @tempStr1 + SUBSTRING(DATENAME(yy, @data), 3, 2)
			ELSE
				SET @tempStr1 = @tempStr1 + SUBSTRING(@tempStr2, 2, 1)
		END
		ELSE
		BEGIN
			SET @tempStr1 = @tempStr1 + @tempStr2
		END
	END
	RETURN @tempStr1
END')

if (object_id(N'[dbo].[HorasToDouble]', 'FN') is not null) DROP FUNCTION [dbo].[HorasToDouble]
exec ('CREATE FUNCTION dbo.HorasToDouble(@horas VARCHAR(5))
RETURNS float WITH SCHEMABINDING AS
BEGIN
	DECLARE @horasParte INT
	DECLARE @minutosParte INT
	DECLARE @horasIndex INT
	IF @horas = ''__:__'' RETURN 0
	SET @horas = REPLACE(@horas,''_'',''0'')
	SET @horasIndex = CHARINDEX('':'',@horas)
	SET @horasParte = CONVERT(INT, SUBSTRING(@horas, 0, @horasIndex))
	SET @minutosParte = CONVERT(INT, SUBSTRING(@horas, @horasIndex + 1, LEN(@horas)))
	RETURN @minutosParte / 60.0 + @horasParte
END')

if (object_id(N'[dbo].[DoubleToHoras]', 'FN') is not null) DROP FUNCTION [dbo].[DoubleToHoras]
exec ('CREATE FUNCTION dbo.DoubleToHoras(@horas float)
RETURNS VARCHAR(5) WITH SCHEMABINDING AS
BEGIN
	DECLARE @minutosTotais INT
	DECLARE @horasParte INT
	DECLARE @minutosParte INT
	DECLARE @res VARCHAR(5)
	SET @minutosTotais = ROUND(@horas * 60.0, 0)
    SET @horasParte = FLOOR(@minutosTotais / 60)
	SET @minutosParte = @minutosTotais % 60
		
	SET @res = REPLACE(STR(@horasParte,2) + '':'' + STR(@minutosParte,2), '' '', ''0'')
	RETURN @res
END')

if (object_id(N'[dbo].[HorasAdd]', 'FN') is not null) DROP FUNCTION [dbo].[HorasAdd]
exec ('CREATE FUNCTION dbo.HorasAdd(@h varchar(5), @minutos int)
RETURNS VARCHAR(5) WITH SCHEMABINDING AS
BEGIN
	DECLARE @horas VARCHAR(5)
	DECLARE @res VARCHAR(5)
	DECLARE @horasParte INT
	DECLARE @minutosParte INT
	DECLARE @horasIndex INT
	SET @horas = @h

  IF @horas is null RETURN null
  IF @horas = ''__:__'' RETURN ''__:__''

  SET @horas = REPLACE(@horas, ''_'', ''0'')
  SET @horasIndex = CHARINDEX('':'',@horas)
  IF @horasIndex = 0 RETURN null
  SET @horasParte = CONVERT(INT, SUBSTRING(@horas, 0, @horasIndex))
  SET @minutosParte = CONVERT(INT, SUBSTRING(@horas, @horasIndex + 1, LEN(@horas)))
  
  SET @minutosParte = @horasParte*60 + @minutosParte + @minutos
  IF @minutosParte < 0 SET @minutosParte = 0
  IF @minutosParte > 23*60+59 SET @minutosParte = 23*60+59

  SET @res = REPLACE(STR(floor(@minutosParte/60),2) + '':'' + STR(@minutosParte%60,2), '' '', ''0'')
  RETURN @res
END')

if (object_id(N'[dbo].[CreateDateTime]', 'FN') is not null) DROP FUNCTION [dbo].[CreateDateTime]
exec ('CREATE FUNCTION dbo.CreateDateTime (@year INT, @month INT, @day INT, @hour INT, @minute INT, @second INT)
RETURNS DATETIME WITH SCHEMABINDING AS
BEGIN
	RETURN CONVERT(DATETIME,REPLACE(STR(@year,4)+''-''+STR(@month,2)+''-''+STR(@day,2),'' '',''0'')+'' ''+REPLACE(STR(@hour,2)+'':''+STR(@minute,2)+'':''+STR(@second,2),'' '',''0''),120)
END')

if (object_id(N'[dbo].[DateSetTime]', 'FN') is not null) DROP FUNCTION [dbo].[DateSetTime]
exec ('CREATE FUNCTION dbo.DateSetTime(@date DATETIME, @time VARCHAR(5))
RETURNS DATETIME WITH SCHEMABINDING AS
BEGIN
	DECLARE @result DATETIME
	DECLARE @idx INT
	DECLARE @hours INT
	DECLARE @minutes INT
	IF (@time IS NULL OR @time = ''__:__'' OR @time = '''')
		RETURN DATEADD(DD, DATEDIFF(DD, 0, @date),0)
	SET @idx = CHARINDEX('':'', @time)
	SET @hours = CONVERT(INT, SUBSTRING(@time, 0, @idx))
	SET @minutes = CONVERT(INT, SUBSTRING(@time, @idx + 1, LEN(@time)))
	SET @result = DATEADD(MI, @hours * 60 + @minutes, DATEADD(DD, DATEDIFF(DD, 0, @date),0))
	RETURN @result
END')

if (object_id(N'[dbo].[CriaData]', 'FN') is not null) DROP FUNCTION [dbo].[CriaData]
exec ('CREATE FUNCTION dbo.CriaData (@ano INT, @mes INT, @dia INT, @hora INT, @minuto INT, @segundo INT)
RETURNS DATETIME WITH SCHEMABINDING AS
BEGIN
	RETURN CONVERT(DATETIME,REPLACE(STR(@ano,4)+''-''+STR(@mes,2)+''-''+STR(@dia,2),'' '',''0'')+'' ''+REPLACE(STR(@hora,2)+'':''+STR(@minuto,2)+'':''+STR(@segundo,2),'' '',''0''),120)
END')

if (object_id(N'[dbo].[CriaDataHora]', 'FN') is not null) DROP FUNCTION [dbo].[CriaDataHora]
exec ('CREATE FUNCTION dbo.CriaDataHora(@data DATETIME, @inicio VARCHAR(5))
RETURNS DATETIME WITH SCHEMABINDING AS
BEGIN
	DECLARE @result DATETIME
	DECLARE @horasInicio INT
	DECLARE @inicioIndex INT
	DECLARE @minutosInicio INT
	IF (@inicio IS NULL OR @inicio = ''__:__'' OR @inicio = '''')
		RETURN DATEADD(DD, DATEDIFF(DD, 0, @data),0)
	SET @inicioIndex = CHARINDEX('':'',@inicio)
	SET @horasInicio = CONVERT(INT, SUBSTRING(@inicio, 0, @inicioIndex))
	SET @minutosInicio = CONVERT(INT, SUBSTRING(@inicio, @inicioIndex + 1, LEN(@inicio)))
	SET @result = DATEADD(MI , @horasInicio * 60 + @minutosInicio, DATEADD(DD, DATEDIFF(DD, 0, @data),0))
	RETURN @result
END')

if (object_id(N'[dbo].[DateCompare]', 'FN') is not null) drop function [dbo].[DateCompare]
exec ('CREATE FUNCTION dbo.DateCompare (@date1 DATETIME, @date2 DATETIME)
RETURNS INT WITH SCHEMABINDING AS 
BEGIN
	DECLARE @res INT
	IF @date1 IS NULL AND @date2 IS NULL SET @res=0
	ELSE IF @date1 IS NULL OR @date1<@date2 SET @res=-1
	ELSE IF @date2 IS NULL OR @date1>@date2 SET @res=1
	ELSE SET @res=0
	RETURN @res
END')

if (object_id(N'[dbo].[CreateDuration]', 'FN') is not null) DROP FUNCTION [dbo].[CreateDuration]
exec ('CREATE FUNCTION dbo.CreateDuration(@days INT, @hours INT, @minutes INT, @seconds INT)
RETURNS INT WITH SCHEMABINDING AS
BEGIN
	DECLARE @result INT
	SET @result = ABS(@days) * 24 * 3600
	SET @result = @result + ABS(@hours) * 3600
	SET @result = @result + ABS(@minutes) * 60
	SET @result = @result + ABS(@seconds)

	RETURN @result
END')

if (object_id(N'[dbo].[DateDiffDur]', 'FN') is not null) DROP FUNCTION [dbo].[DateDiffDur]
exec ('CREATE FUNCTION dbo.DateDiffDur(@startDate DATETIME, @endDate DATETIME)
RETURNS INT WITH SCHEMABINDING AS
BEGIN
	RETURN CAST(DATEDIFF(second, @startDate, @endDate) AS INT)
END')

if (object_id(N'[dbo].[DateDiffPart]', 'FN') is not null) DROP FUNCTION [dbo].[DateDiffPart]
exec ('CREATE FUNCTION dbo.DateDiffPart (@startDate DATETIME, @endDate DATETIME, @unit VARCHAR(1))
RETURNS INT WITH SCHEMABINDING
AS
BEGIN
	DECLARE @diff INT
	SET @diff = 0
	IF ISDATE(@startDate) = 1 AND ISDATE(@endDate) = 1
	BEGIN
		SET @diff = CASE UPPER(@unit)
			WHEN ''D'' THEN DATEDIFF(DD, @startDate, @endDate)
			WHEN ''H'' THEN DATEDIFF(HH, @startDate, @endDate)
			WHEN ''M'' THEN DATEDIFF(MI, @startDate, @endDate)
			WHEN ''S'' THEN DATEDIFF(SS, @startDate, @endDate)
			ELSE 0
		END
	END
	RETURN @diff
END')

if (object_id(N'[dbo].[DateAddDuration]', 'FN') is not null) DROP FUNCTION [dbo].[DateAddDuration]
exec ('CREATE FUNCTION dbo.DateAddDuration(@date DATETIME, @duration INT)
RETURNS DATETIME WITH SCHEMABINDING AS
BEGIN
	RETURN DATEADD(s, @duration, @date)
END')

if (object_id(N'[dbo].[DateSubtractDuration]', 'FN') is not null) DROP FUNCTION [dbo].[DateSubtractDuration]
exec ('CREATE FUNCTION dbo.DateSubtractDuration(@date DATETIME, @duration INT)
RETURNS DATETIME WITH SCHEMABINDING AS
BEGIN

	RETURN DATEADD(s, -1 * @duration, @date)
END')


if (object_id(N'[dbo].[DateAddYears]', 'FN') is not null) DROP FUNCTION [dbo].[DateAddYears]
exec ('CREATE FUNCTION dbo.DateAddYears(@date DATETIME, @duration INT)
RETURNS DATETIME WITH SCHEMABINDING AS
BEGIN
	RETURN DATEADD(year, @duration, @date)
END')

if (object_id(N'[dbo].[DateAddMonths]', 'FN') is not null) DROP FUNCTION [dbo].[DateAddMonths]
exec ('CREATE FUNCTION dbo.DateAddMonths(@date DATETIME, @duration INT)
RETURNS DATETIME WITH SCHEMABINDING AS
BEGIN
	RETURN DATEADD(month, @duration, @date)
END')

if (object_id(N'[dbo].[DateAddDays]', 'FN') is not null) DROP FUNCTION [dbo].[DateAddDays]
exec ('CREATE FUNCTION dbo.DateAddDays(@date DATETIME, @duration INT)
RETURNS DATETIME WITH SCHEMABINDING AS
BEGIN
	RETURN DATEADD(day, @duration, @date)
END')

if (object_id(N'[dbo].[DateAddHours]', 'FN') is not null) DROP FUNCTION [dbo].[DateAddHours]
exec ('CREATE FUNCTION dbo.DateAddHours(@date DATETIME, @duration INT)
RETURNS DATETIME WITH SCHEMABINDING AS
BEGIN
	RETURN DATEADD(hour, @duration, @date)
END')

if (object_id(N'[dbo].[DateAddMinutes]', 'FN') is not null) DROP FUNCTION [dbo].[DateAddMinutes]
exec ('CREATE FUNCTION dbo.DateAddMinutes(@date DATETIME, @duration INT)
RETURNS DATETIME WITH SCHEMABINDING AS
BEGIN
	RETURN DATEADD(minute, @duration, @date)
END')

if (object_id(N'[dbo].[DateAddSeconds]', 'FN') is not null) DROP FUNCTION [dbo].[DateAddSeconds]
exec ('CREATE FUNCTION dbo.DateAddSeconds(@date DATETIME, @duration INT)
RETURNS DATETIME WITH SCHEMABINDING AS
BEGIN
	RETURN DATEADD(second, @duration, @date)
END')


if (object_id(N'[dbo].[DateGetYear]', 'FN') is not null) DROP FUNCTION [dbo].[DateGetYear]
exec ('CREATE FUNCTION dbo.DateGetYear(@date DATETIME)
RETURNS INT WITH SCHEMABINDING AS
BEGIN
	RETURN DATEPART(year, @date)
END')

if (object_id(N'[dbo].[DateGetMonth]', 'FN') is not null) DROP FUNCTION [dbo].[DateGetMonth]
exec ('CREATE FUNCTION dbo.DateGetMonth(@date DATETIME)
RETURNS INT WITH SCHEMABINDING AS
BEGIN
	RETURN DATEPART(month, @date)
END')

if (object_id(N'[dbo].[DateGetDay]', 'FN') is not null) DROP FUNCTION [dbo].[DateGetDay]
exec ('CREATE FUNCTION dbo.DateGetDay(@date DATETIME)
RETURNS INT WITH SCHEMABINDING AS
BEGIN
	RETURN DATEPART(day, @date)
END')

if (object_id(N'[dbo].[DateGetHour]', 'FN') is not null) DROP FUNCTION [dbo].[DateGetHour]
exec ('CREATE FUNCTION dbo.DateGetHour(@date DATETIME)
RETURNS INT WITH SCHEMABINDING AS
BEGIN
	RETURN DATEPART(hour, @date)
END')

if (object_id(N'[dbo].[DateGetMinute]', 'FN') is not null) DROP FUNCTION [dbo].[DateGetMinute]
exec ('CREATE FUNCTION dbo.DateGetMinute(@date DATETIME)
RETURNS INT WITH SCHEMABINDING AS
BEGIN
	RETURN DATEPART(minute, @date)
END')

if (object_id(N'[dbo].[DateGetSecond]', 'FN') is not null) DROP FUNCTION [dbo].[DateGetSecond]
exec ('CREATE FUNCTION dbo.DateGetSecond(@date DATETIME)
RETURNS INT WITH SCHEMABINDING AS
BEGIN
	RETURN DATEPART(second, @date)
END')

if (object_id(N'[dbo].[DurationTotalDays]', 'FN') is not null) DROP FUNCTION [dbo].[DurationTotalDays]
exec ('CREATE FUNCTION dbo.DurationTotalDays(@duration INT)
RETURNS FLOAT WITH SCHEMABINDING AS
BEGIN
	RETURN @duration / (24*3600.0)
END')

if (object_id(N'[dbo].[DurationTotalHours]', 'FN') is not null) DROP FUNCTION [dbo].[DurationTotalHours]
exec ('CREATE FUNCTION dbo.DurationTotalHours(@duration INT)
RETURNS FLOAT WITH SCHEMABINDING AS
BEGIN
	RETURN @duration / 3600.0
END')

if (object_id(N'[dbo].[DurationTotalMinutes]', 'FN') is not null) DROP FUNCTION [dbo].[DurationTotalMinutes]
exec ('CREATE FUNCTION dbo.DurationTotalMinutes(@duration INT)
RETURNS FLOAT WITH SCHEMABINDING AS
BEGIN
	RETURN @duration / 60.0
END')

if (object_id(N'[dbo].[DurationTotalSeconds]', 'FN') is not null) DROP FUNCTION [dbo].[DurationTotalSeconds]
exec ('CREATE FUNCTION dbo.DurationTotalSeconds(@duration INT)
RETURNS INT WITH SCHEMABINDING AS
BEGIN
	RETURN @duration
END')


if (object_id(N'[dbo].[strAno]', 'FN') is not null) DROP FUNCTION [dbo].[strAno]
exec ('CREATE FUNCTION dbo.strAno(@data DATETIME)
RETURNS VARCHAR(4) WITH SCHEMABINDING AS
BEGIN
	RETURN CAST(YEAR(@data) AS VARCHAR(4))
END')

if (object_id(N'[dbo].[DateFloorDay]', 'FN') is not null) DROP FUNCTION [dbo].[DateFloorDay]
exec ('CREATE FUNCTION dbo.DateFloorDay (@data DATETIME)
RETURNS DATETIME WITH SCHEMABINDING AS
BEGIN
	RETURN DATEADD(dd, DATEDIFF(dd,0, @data), 0)
END')

if (object_id(N'[dbo].[Diferenca_entre_Datas]', 'FN') is not null) DROP FUNCTION [dbo].[Diferenca_entre_Datas]
exec ('CREATE FUNCTION dbo.Diferenca_entre_Datas (@dt_ini DATETIME, @dt_fim DATETIME, @escala VARCHAR(1))
RETURNS INT WITH SCHEMABINDING
AS
BEGIN
	DECLARE @dif_val INT
	SET @dif_val = 0
	IF ISDATE(@dt_ini) = 1 AND ISDATE(@dt_fim) = 1
	BEGIN
		SET @dif_val = CASE @escala WHEN ''D'' THEN DATEDIFF(DD, @dt_ini, @dt_fim)
									WHEN ''H'' THEN DATEDIFF(HH, @dt_ini, @dt_fim)
									WHEN ''M'' THEN DATEDIFF(MI, @dt_ini, @dt_fim)
									WHEN ''S'' THEN DATEDIFF(SS, @dt_ini, @dt_fim) ELSE 0 END
	END
	RETURN @dif_val
END')

-- MF (2013.08.23 - Acrescentei funções Capitalize e CapitalizeInitials)
if (object_id(N'[dbo].[Capitalize]', 'FN') is not null) DROP FUNCTION [dbo].[Capitalize]
exec ('CREATE FUNCTION [dbo].[Capitalize] (@string VARCHAR(MAX)) RETURNS VARCHAR(MAX) WITH SCHEMABINDING AS
BEGIN 
	DECLARE @str2 VARCHAR(MAX)
	IF (LEN(ISNULL(@string,''''))>0)
		SET @str2=UPPER(LEFT(@string, 1)) + RIGHT(@string, LEN(@string) - 1) 
	ELSE
		SET @str2=''''
	RETURN @str2
END')


if (object_id(N'[dbo].[CapitalizeInitials]', 'FN') is not null) DROP FUNCTION [dbo].[CapitalizeInitials]
exec ('CREATE FUNCTION [dbo].[CapitalizeInitials] ( @InputString varchar(4000) ) RETURNS VARCHAR(4000) WITH SCHEMABINDING AS
BEGIN
	DECLARE @Index          INT
	DECLARE @Char           CHAR(1)
	DECLARE @PrevChar       CHAR(1)
	DECLARE @OutputString   VARCHAR(4000)

	SET @OutputString = LOWER(@InputString)
	SET @Index = 1

	WHILE @Index <= LEN(@InputString)
	BEGIN
    	SET @Char     = SUBSTRING(@InputString, @Index, 1)
    	SET @PrevChar = CASE WHEN @Index = 1 THEN '' '' ELSE SUBSTRING(@InputString, @Index - 1, 1) END

    	IF @PrevChar IN ('' '', '';'', '':'', ''!'', ''?'', '','', ''.'', ''_'', ''-'', ''/'', ''&'', '''', ''('')
    	BEGIN
        	IF @PrevChar != '''' OR UPPER(@Char) != ''S''
            	SET @OutputString = STUFF(@OutputString, @Index, 1, UPPER(@Char))
		END
		SET @Index = @Index + 1
	END
	RETURN @OutputString
END')

--JGF 2021.02.24 Check if a feature is active
if (object_id(N'[dbo].[IsFeatureActive]', 'FN') is not null) DROP FUNCTION [dbo].[IsFeatureActive]
exec ('CREATE FUNCTION IsFeatureActive (@feature varchar(5)) RETURNS SMALLINT AS BEGIN RETURN 
	0
END')

--SVF 2022.01.18 GetAppThemeVariable
if (object_id(N'[dbo].[GetAppThemeVariable]', 'FN') is not null) drop function [dbo].[GetAppThemeVariable]
exec ('CREATE FUNCTION GetAppThemeVariable (@variable nvarchar(100))
RETURNS nvarchar(max) AS
BEGIN 
--This Function should not be used in SQL, there is no current app. Use GetThemeVariable instead
RETURN NULL
END')


--SVF 2022.01.19 GetAppThemeVariable
if (object_id(N'[dbo].[GetThemeVariable]', 'FN') is not null) drop function [dbo].[GetThemeVariable]
exec ('CREATE FUNCTION GetThemeVariable (@app nvarchar(16), @variable nvarchar(100))
RETURNS nvarchar(max) AS
BEGIN 
IF ''MYAPP''= @app AND ''$footer-bg''= @variable
RETURN ''transparent'';
IF ''MYAPP''= @app AND ''$menu-sidebar-width''= @variable
RETURN ''16rem'';
IF ''MYAPP''= @app AND ''$menu-behaviour''= @variable
RETURN ''partial_collapse'';
IF ''MYAPP''= @app AND ''$compactheader''= @variable
RETURN ''false'';
IF ''MYAPP''= @app AND ''$save-icon''= @variable
RETURN ''floppy-disk'';
IF ''MYAPP''= @app AND ''$compactstyle''= @variable
RETURN ''true'';
IF ''MYAPP''= @app AND ''$border-radius''= @variable
RETURN ''0.25rem'';
IF ''MYAPP''= @app AND ''$table-striped''= @variable
RETURN ''false'';
IF ''MYAPP''= @app AND ''$table-head-inverse''= @variable
RETURN ''false'';
IF ''MYAPP''= @app AND ''$table-vertical-border''= @variable
RETURN ''true'';
IF ''MYAPP''= @app AND ''$enable-table-wrap''= @variable
RETURN ''true'';
IF ''MYAPP''= @app AND ''$font-size-base''= @variable
RETURN ''0.9rem'';
IF ''MYAPP''= @app AND ''$font-family-sans-serif''= @variable
RETURN ''"Lato", Roboto, "Helvetica Neue", Arial, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji"'';
IF ''MYAPP''= @app AND ''$font-headings''= @variable
RETURN ''$font-family-sans-serif'';
IF ''MYAPP''= @app AND ''$primary''= @variable
RETURN ''#1e2436'';
IF ''MYAPP''= @app AND ''$secondary''= @variable
RETURN ''#1e2436'';
IF ''MYAPP''= @app AND ''$highlight''= @variable
RETURN ''#17a2b8'';
IF ''MYAPP''= @app AND ''$action-focus-width''= @variable
RETURN ''2px'';
IF ''MYAPP''= @app AND ''$action-focus-style''= @variable
RETURN ''solid'';
IF ''MYAPP''= @app AND ''$action-focus-color''= @variable
RETURN ''#201060'';
IF ''MYAPP''= @app AND ''$input-focus-color''= @variable
RETURN ''rgba(0, 169, 206, 0.35)'';
IF ''MYAPP''= @app AND ''$button-focus-color''= @variable
RETURN ''rgba(238, 96, 2, 0.5)'';
IF ''MYAPP''= @app AND ''$body-bg''= @variable
RETURN ''$white'';
IF ''MYAPP''= @app AND ''$body-color''= @variable
RETURN ''#202428'';
IF ''MYAPP''= @app AND ''$input-btn-padding-y''= @variable
RETURN ''0.26rem'';
IF ''MYAPP''= @app AND ''$input-btn-padding-x''= @variable
RETURN ''0.25rem'';
IF ''MYAPP''= @app AND ''$enable-switch-single-label''= @variable
RETURN ''false'';
IF ''MYAPP''= @app AND ''$wizard-steps''= @variable
RETURN ''circle'';
IF ''MYAPP''= @app AND ''$wizard-content''= @variable
RETURN ''standard'';
IF ''MYAPP''= @app AND ''$btn-align-right''= @variable
RETURN ''false'';
IF ''MYAPP''= @app AND ''$menu-multi-level''= @variable
RETURN ''true'';
IF ''MYAPP''= @app AND ''$primary-light''= @variable
RETURN ''#fff'';
IF ''MYAPP''= @app AND ''$primary-dark''= @variable
RETURN ''#1e2436'';
IF ''MYAPP''= @app AND ''$success''= @variable
RETURN ''#28a745'';
IF ''MYAPP''= @app AND ''$danger''= @variable
RETURN ''#b71c1c'';
IF ''MYAPP''= @app AND ''$light''= @variable
RETURN ''#1e2436'';
IF ''MYAPP''= @app AND ''$red''= @variable
RETURN ''#b71c1c'';
IF ''MYAPP''= @app AND ''$info''= @variable
RETURN ''#17a2b8'';
IF ''MYAPP''= @app AND ''$warning''= @variable
RETURN ''#ffa900'';
IF ''MYAPP''= @app AND ''$gray''= @variable
RETURN ''#717485'';
IF ''MYAPP''= @app AND ''$gray-light''= @variable
RETURN ''#3f4354'';
IF ''MYAPP''= @app AND ''$gray-dark''= @variable
RETURN ''#c5cad4'';
IF ''MYAPP''= @app AND ''$navbar-font-size''= @variable
RETURN ''0.9rem'';
IF ''MYAPP''= @app AND ''$navbar-font-weight''= @variable
RETURN ''400'';
IF ''MYAPP''= @app AND ''$tab-style''= @variable
RETURN ''line'';
IF ''MYAPP''= @app AND ''$group-border-top''= @variable
RETURN ''none'';
IF ''MYAPP''= @app AND ''$group-border-bottom''= @variable
RETURN ''none'';
IF ''MYAPP''= @app AND ''$input-bg''= @variable
RETURN ''transparent'';
IF ''MYAPP''= @app AND ''$input-bg-readonly''= @variable
RETURN ''rgb($neutral-light-rgb / 0.25)'';
IF ''MYAPP''= @app AND ''$hover-item''= @variable
RETURN ''rgb($primary-light-rgb / 0.5)'';
IF ''MYAPP''= @app AND ''$header-bg''= @variable
RETURN ''$background'';
IF ''MYAPP''= @app AND ''$header-color''= @variable
RETURN ''$on-background'';
IF ''MYAPP''= @app AND ''$navbar-bg''= @variable
RETURN ''$primary'';
IF ''MYAPP''= @app AND ''$navbar-color''= @variable
RETURN ''$on-primary'';
IF ''MYAPP''= @app AND ''$menu-multi-level-border''= @variable
RETURN ''false'';
RETURN NULL
END')

--PG 2022.09.05 GetLevelFromRole
if (object_id(N'[dbo].[GetLevelFromRole]', 'FN') is not null) drop function [dbo].[GetLevelFromRole]
exec ('CREATE FUNCTION GetLevelFromRole (@level bigint, @roleId nvarchar(16))
RETURNS bigint AS
BEGIN
IF @roleId is null
	RETURN @level
ELSE IF @roleId in ('''')
	RETURN 0
ELSE IF @roleId in ('''', ''0'', ''20'', ''40'', ''50'', ''70'', ''99'')
	RETURN CAST(@roleId AS BIGINT)
RETURN 0
END')



 
if (object_id(N'[dbo].[GetValArrayCgender]', 'FN') is not null) drop function [dbo].[GetValArrayCgender]
exec('CREATE FUNCTION dbo.GetValArrayCgender (@codigo varchar(12) )
RETURNS varchar(100) AS 
BEGIN 
DECLARE @valor varchar(100) 
SELECT 
@valor = CASE @codigo 
 	WHEN ''M'' THEN ''Male'' 
  	WHEN ''F'' THEN ''Feminine'' 
  	WHEN ''O'' THEN ''Other'' 
     ELSE ''        '' 
   END 
   RETURN ( @valor ) 
END')
GO

 
if (object_id(N'[dbo].[GetValArrayCs_modpro]', 'FN') is not null) drop function [dbo].[GetValArrayCs_modpro]
exec('CREATE FUNCTION dbo.GetValArrayCs_modpro (@codigo varchar(12) )
RETURNS varchar(100) AS 
BEGIN 
DECLARE @valor varchar(100) 
SELECT 
@valor = CASE @codigo 
 	WHEN ''INDIV'' THEN ''Individual'' 
  	WHEN ''global'' THEN ''Global'' 
  	WHEN ''unidade'' THEN ''Unidade orgânica'' 
  	WHEN ''horario'' THEN ''Horário'' 
     ELSE ''                '' 
   END 
   RETURN ( @valor ) 
END')
GO

 
if (object_id(N'[dbo].[GetValArrayCs_module]', 'FN') is not null) drop function [dbo].[GetValArrayCs_module]
exec('CREATE FUNCTION dbo.GetValArrayCs_module (@codigo varchar(12) )
RETURNS varchar(100) AS 
BEGIN 
DECLARE @valor varchar(100) 
SELECT 
    @valor = '' '' 
   RETURN ( @valor ) 
END')
GO

 
if (object_id(N'[dbo].[GetValArrayCs_prstat]', 'FN') is not null) drop function [dbo].[GetValArrayCs_prstat]
exec('CREATE FUNCTION dbo.GetValArrayCs_prstat (@codigo varchar(12) )
RETURNS varchar(100) AS 
BEGIN 
DECLARE @valor varchar(100) 
SELECT 
@valor = CASE @codigo 
 	WHEN ''EE'' THEN ''Em execução'' 
  	WHEN ''FE'' THEN ''Em fila de espera'' 
  	WHEN ''AG'' THEN ''Agendado para execução'' 
  	WHEN ''T'' THEN ''Terminado'' 
  	WHEN ''C'' THEN ''Cancelado'' 
  	WHEN ''NR'' THEN ''Não responde'' 
  	WHEN ''AB'' THEN ''Abortado'' 
  	WHEN ''AC'' THEN ''A cancelar'' 
     ELSE ''                      '' 
   END 
   RETURN ( @valor ) 
END')
GO

 
if (object_id(N'[dbo].[GetValArrayCs_resul]', 'FN') is not null) drop function [dbo].[GetValArrayCs_resul]
exec('CREATE FUNCTION dbo.GetValArrayCs_resul (@codigo varchar(12) )
RETURNS varchar(100) AS 
BEGIN 
DECLARE @valor varchar(100) 
SELECT 
@valor = CASE @codigo 
 	WHEN ''ok'' THEN ''Sucesso'' 
  	WHEN ''er'' THEN ''Erro'' 
  	WHEN ''wa'' THEN ''Aviso'' 
  	WHEN ''c'' THEN ''Cancelado'' 
     ELSE ''         '' 
   END 
   RETURN ( @valor ) 
END')
GO

 
if (object_id(N'[dbo].[GetValArrayCs_roles]', 'FN') is not null) drop function [dbo].[GetValArrayCs_roles]
exec('CREATE FUNCTION dbo.GetValArrayCs_roles (@codigo varchar(12) )
RETURNS varchar(100) AS 
BEGIN 
DECLARE @valor varchar(100) 
SELECT 
    @valor = '' '' 
   RETURN ( @valor ) 
END')
GO

 
if (object_id(N'[dbo].[GetValArrayCs_tpproc]', 'FN') is not null) drop function [dbo].[GetValArrayCs_tpproc]
exec('CREATE FUNCTION dbo.GetValArrayCs_tpproc (@codigo varchar(12) )
RETURNS varchar(100) AS 
BEGIN 
DECLARE @valor varchar(100) 
SELECT 
    @valor = '' '' 
   RETURN ( @valor ) 
END')
GO

 
if (object_id(N'[dbo].[GetValArrayLundercontract]', 'FN') is not null) drop function [dbo].[GetValArrayLundercontract]
exec('CREATE FUNCTION dbo.GetValArrayLundercontract (@codigo int)
RETURNS varchar(100) AS 
BEGIN 
DECLARE @valor varchar(100) 
SELECT 
@valor = CASE @codigo 
	WHEN 1 THEN ''Yes'' 
 	WHEN 0 THEN ''No'' 
     ELSE ''   '' 
   END 
   RETURN ( @valor ) 
END')
GO



 
if (object_id(N'[dbo].[GetValArrayMLCgender]', 'FN') is not null) drop function [dbo].[GetValArrayMLCgender]
exec('CREATE FUNCTION dbo.GetValArrayMLCgender (@codigo varchar(12), @language nvarchar(3))
RETURNS varchar(100) AS 
BEGIN 
DECLARE @valor varchar(100) 
SELECT
@valor = CASE 
 	WHEN ''M'' = @codigo AND ''eng'' = @language  THEN ''Male'' 
  	WHEN ''F'' = @codigo AND ''eng'' = @language  THEN ''Feminine'' 
  	WHEN ''O'' = @codigo AND ''eng'' = @language  THEN ''Other'' 
     ELSE ''        '' 
   END
   RETURN ( @valor ) 
END')
GO

 
if (object_id(N'[dbo].[GetValArrayMLCs_modpro]', 'FN') is not null) drop function [dbo].[GetValArrayMLCs_modpro]
exec('CREATE FUNCTION dbo.GetValArrayMLCs_modpro (@codigo varchar(12), @language nvarchar(3))
RETURNS varchar(100) AS 
BEGIN 
DECLARE @valor varchar(100) 
SELECT
@valor = CASE 
 	WHEN ''INDIV'' = @codigo AND ''eng'' = @language  THEN ''Individual'' 
  	WHEN ''global'' = @codigo AND ''eng'' = @language  THEN ''Global'' 
  	WHEN ''unidade'' = @codigo AND ''eng'' = @language  THEN ''Unidade orgânica'' 
  	WHEN ''horario'' = @codigo AND ''eng'' = @language  THEN ''Horário'' 
     ELSE ''                '' 
   END
   RETURN ( @valor ) 
END')
GO

 
if (object_id(N'[dbo].[GetValArrayMLCs_module]', 'FN') is not null) drop function [dbo].[GetValArrayMLCs_module]
exec('CREATE FUNCTION dbo.GetValArrayMLCs_module (@codigo varchar(12), @language nvarchar(3))
RETURNS varchar(100) AS 
BEGIN 
DECLARE @valor varchar(100) 
SELECT
    @valor = '' '' 
   RETURN ( @valor ) 
END')
GO

 
if (object_id(N'[dbo].[GetValArrayMLCs_prstat]', 'FN') is not null) drop function [dbo].[GetValArrayMLCs_prstat]
exec('CREATE FUNCTION dbo.GetValArrayMLCs_prstat (@codigo varchar(12), @language nvarchar(3))
RETURNS varchar(100) AS 
BEGIN 
DECLARE @valor varchar(100) 
SELECT
@valor = CASE 
 	WHEN ''EE'' = @codigo AND ''eng'' = @language  THEN ''Em execução'' 
  	WHEN ''FE'' = @codigo AND ''eng'' = @language  THEN ''Em fila de espera'' 
  	WHEN ''AG'' = @codigo AND ''eng'' = @language  THEN ''Agendado para execução'' 
  	WHEN ''T'' = @codigo AND ''eng'' = @language  THEN ''Terminado'' 
  	WHEN ''C'' = @codigo AND ''eng'' = @language  THEN ''Cancelado'' 
  	WHEN ''NR'' = @codigo AND ''eng'' = @language  THEN ''Não responde'' 
  	WHEN ''AB'' = @codigo AND ''eng'' = @language  THEN ''Abortado'' 
  	WHEN ''AC'' = @codigo AND ''eng'' = @language  THEN ''A cancelar'' 
     ELSE ''                      '' 
   END
   RETURN ( @valor ) 
END')
GO

 
if (object_id(N'[dbo].[GetValArrayMLCs_resul]', 'FN') is not null) drop function [dbo].[GetValArrayMLCs_resul]
exec('CREATE FUNCTION dbo.GetValArrayMLCs_resul (@codigo varchar(12), @language nvarchar(3))
RETURNS varchar(100) AS 
BEGIN 
DECLARE @valor varchar(100) 
SELECT
@valor = CASE 
 	WHEN ''ok'' = @codigo AND ''eng'' = @language  THEN ''Sucesso'' 
  	WHEN ''er'' = @codigo AND ''eng'' = @language  THEN ''Erro'' 
  	WHEN ''wa'' = @codigo AND ''eng'' = @language  THEN ''Aviso'' 
  	WHEN ''c'' = @codigo AND ''eng'' = @language  THEN ''Cancelado'' 
     ELSE ''         '' 
   END
   RETURN ( @valor ) 
END')
GO

 
if (object_id(N'[dbo].[GetValArrayMLCs_roles]', 'FN') is not null) drop function [dbo].[GetValArrayMLCs_roles]
exec('CREATE FUNCTION dbo.GetValArrayMLCs_roles (@codigo varchar(12), @language nvarchar(3))
RETURNS varchar(100) AS 
BEGIN 
DECLARE @valor varchar(100) 
SELECT
    @valor = '' '' 
   RETURN ( @valor ) 
END')
GO

 
if (object_id(N'[dbo].[GetValArrayMLCs_tpproc]', 'FN') is not null) drop function [dbo].[GetValArrayMLCs_tpproc]
exec('CREATE FUNCTION dbo.GetValArrayMLCs_tpproc (@codigo varchar(12), @language nvarchar(3))
RETURNS varchar(100) AS 
BEGIN 
DECLARE @valor varchar(100) 
SELECT
    @valor = '' '' 
   RETURN ( @valor ) 
END')
GO

 
if (object_id(N'[dbo].[GetValArrayMLLundercontract]', 'FN') is not null) drop function [dbo].[GetValArrayMLLundercontract]
exec('CREATE FUNCTION dbo.GetValArrayMLLundercontract (@codigo int, @language nvarchar(3))
RETURNS varchar(100) AS 
BEGIN 
DECLARE @valor varchar(100) 
SELECT
@valor = CASE 
	WHEN 1 = @codigo AND ''eng'' = @language THEN ''Yes'' 
 	WHEN 0 = @codigo AND ''eng'' = @language THEN ''No'' 
     ELSE ''   '' 
   END
   RETURN ( @valor ) 
END')
GO


 EXEC RestoreComputedColumns
GO
