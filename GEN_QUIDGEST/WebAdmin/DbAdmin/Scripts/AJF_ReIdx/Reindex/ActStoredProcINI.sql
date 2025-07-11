use [W_GnBD]
IF TYPE_ID('KeyListType') IS NULL
	create type KeyListType as TABLE (item varchar(50))
GO
use [W_GnBD]

if (object_id(N'[dbo].[updateCod]', 'P') is not null) drop procedure [dbo].[updateCod]
EXEC ('CREATE PROCEDURE [dbo].[updateCod] 
    @id_objecto VARCHAR(50), 
    @blocksize INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if blocksize is NULL or 0 and throw an error
    IF(@blocksize IS NULL)
    BEGIN
		RAISERROR (''Block size must not be NULL or zero.'', 16, 1);
		RETURN;
    END

	-- No need to lock the table to increment nothing, so yearly return
	IF(@blocksize = 0)
    BEGIN
		RETURN;
    END

    BEGIN TRANSACTION;
    
    -- Update row to lock it before select
    UPDATE Codigos_Sequenciais 
    SET proximo = proximo + @blocksize 
    WHERE id_objecto = @id_objecto;

    -- Return the updated value
    SELECT proximo - @blocksize 
    FROM Codigos_Sequenciais 
    WHERE id_objecto = @id_objecto;

    COMMIT TRANSACTION;
END')


if (object_id(N'[dbo].[GetListAggregate]', 'P') is not null) drop procedure [dbo].[GetListAggregate]
EXEC ('CREATE PROCEDURE dbo.GetListAggregate @relName VARCHAR(50),@relValue VARCHAR(50),@tablename VARCHAR(50),@concatName VARCHAR(50),@orderbyName VARCHAR(50),@separador VARCHAR(50)
AS BEGIN
	declare @returnvalue VARCHAR(MAX)
	declare @sqlstring NVARCHAR(4000)
	
	set @sqlstring = ''Select @output = (SELECT cast(''+@concatName+'' as nvarchar(MAX)) +''''''+@separador+'''''' AS [text()]''
		+'' From ''+@tablename+''''
		+'' where dbo.emptyC(cast(''+@concatName+'' as VARCHAR(MAX))) = 0 and cast(''+@concatName+'' as VARCHAR(MAX))<> '''''''' 	and ''+@relName+'' = ''''''+@relValue+''''''''
		+'' order by ''+@orderbyName+'' For XML PATH (''''''''), TYPE).value(''''.'''', ''''VARCHAR(MAX)'''')''
	
	EXEC sp_executesql
		@sqlstring
		,N''@output VARCHAR(MAX) OUTPUT''
		,@returnvalue OUTPUT
			
	set @returnvalue = LEFT(@returnvalue, LEN(REPLACE(@returnvalue, '' '', ''_''))-LEN(REPLACE(@separador, '' '', ''_'')))
	select @returnvalue
END')





if (object_id(N'[dbo].[CalculateInternalCode]', 'P') is not null) 
	drop procedure [dbo].[CalculateInternalCode]
EXEC ('Create PROCEDURE CalculateInternalCode
	@table nvarchar(100),
	@trans bit,
	@nameCampo NVARCHAR(300) =''''
AS
begin
set nocount on
--verificar se o tipo de dados são diferentes dos inseridos
BEGIN TRY

	if (@trans=1)
	begin
		begin transaction
	end
	if (@nameCampo = '''' or @nameCampo is null)
	begin
		SELECT top 1 @nameCampo = column_name 
			FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC
			INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KU
					ON TC.CONSTRAINT_TYPE = ''PRIMARY KEY'' AND
					TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME
					and ku.table_name = @table
			ORDER BY KU.TABLE_NAME, KU.ORDINAL_POSITION;
	end
	
	if (@nameCampo is null or @nameCampo ='''')
	begin
		RAISERROR (N''Invalid Column Name'', 16, -1)
	end
	if( exists (SELECT DATA_TYPE fROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @table AND  COLUMN_NAME = @nameCampo
		and DATA_TYPE in(''bigint'',''int'',''smallint'',''tinyint'',''varchar'',''nvarchar'')))
	begin
		declare @nextCod bigint
		declare @query nvarchar(1000)
		set @query =N''set @nextCod = coalesce(cast((select max('' + @nameCampo +'') from '' + @table + '') as bigint) + 1, 1)''
	
		exec sp_executesql @query, N''@nextCod bigint out'', @nextCod out
				
		if exists (select id_objecto from Codigos_Sequenciais where id_objecto = @table)
			update Codigos_Sequenciais set proximo = @nextcod where id_objecto = @table
		else
			insert into Codigos_Sequenciais (id_objecto, proximo) values (@table, @nextcod)
	end
	if (@trans=1)
	begin
		commit transaction
	end

	END TRY
	BEGIN CATCH
		if (@trans=1)
		begin
			rollback transaction
		end
		declare @erro as nvarchar (4000)
		set @erro = ''Error while recalculating internal codes on table '' + @table + '': '' + CHAR(13) + ERROR_MESSAGE()
		RAISERROR (@erro, 16, -1)
	END CATCH
end')

if (object_id(N'[dbo].[CalculateAllInternalCodes]', 'P') is not null) 
	drop procedure [dbo].[CalculateAllInternalCodes]
EXEC ('CREATE PROCEDURE CalculateAllInternalCodes
AS
begin
	set nocount on
	BEGIN TRY
		begin transaction
			
			exec dbo.CalculateInternalCode ''AJFAGENTE'' , 0, ''codagent''
			exec dbo.CalculateInternalCode ''AJFCLUB'' , 0, ''codclub''
			exec dbo.CalculateInternalCode ''AJFCOUNTRY'' , 0, ''codcntry''
			exec dbo.CalculateInternalCode ''AJFCONTRACT'' , 0, ''codcontr''
			exec dbo.CalculateInternalCode ''AJFPLAYER'' , 0, ''codplayr''
			exec dbo.CalculateInternalCode ''USERLOGIN'' , 0, ''codpsw''
			exec dbo.CalculateInternalCode ''NOTIFICATIONEMAILSIGNATURE'' , 0, ''codsigna''
			exec dbo.CalculateInternalCode ''NOTIFICATIONMESSAGE'' , 0, ''codmesgs''
			exec dbo.CalculateInternalCode ''ASYNCPROCESSATTACHMENTS'' , 0, ''codpranx''
			exec dbo.CalculateInternalCode ''USERAUTHORIZATION'' , 0, ''codua''

			exec dbo.CalculateInternalCode ''AJFMEMMEM'', 0, ''CODMEM''
			exec dbo.CalculateInternalCode ''AJFCFGCFG'', 0, ''CODCFG''
			exec dbo.CalculateInternalCode ''AJFUSRSETUSRSET'', 0, ''CODUSRSET''
			exec dbo.CalculateInternalCode ''AJFUSRCFGUSRCFG'', 0, ''CODUSRCFG''
			exec dbo.CalculateInternalCode ''AJFWKFACTWKFACT'', 0, ''CODWKFACT''
			exec dbo.CalculateInternalCode ''AJFWKFCONWKFCON'', 0, ''CODWKFCON''
			exec dbo.CalculateInternalCode ''AJFWKFLIGWKFLIG'', 0, ''CODWKFLIG''
			exec dbo.CalculateInternalCode ''AJFWKFLOWWKFLOW'', 0, ''CODWKFLOW''
			exec dbo.CalculateInternalCode ''AJFNOTIFINOTIFI'', 0, ''CODNOTIFI''
			exec dbo.CalculateInternalCode ''AJFSCRCRDSCRCRD'', 0, ''CODSCRCRD''
			exec dbo.CalculateInternalCode ''AJFPOSTITPOSTIT'', 0, ''CODPOSTIT''
			exec dbo.CalculateInternalCode ''AJFPRMFRMPRMFRM'', 0, ''CODPRMFRM''
			exec dbo.CalculateInternalCode ''AJFALERTAALERTA'', 0, ''CODALERTA''
			exec dbo.CalculateInternalCode ''AJFALTENTALTENT'', 0, ''CODALTENT''
			exec dbo.CalculateInternalCode ''AJFTALERTTALERT'', 0, ''CODTALERT''
			exec dbo.CalculateInternalCode ''AJFDELEGADELEGA'', 0, ''CODDELEGA''
			exec dbo.CalculateInternalCode ''AJFLSTUSRLSTUSR'', 0, ''CODLSTUSR''
			exec dbo.CalculateInternalCode ''AJFLSTCOLLSTCOL'', 0, ''CODLSTCOL''
			exec dbo.CalculateInternalCode ''AJFLSTRENLSTREN'', 0, ''CODLSTREN''
			exec dbo.CalculateInternalCode ''AJFUSRWIDUSRWID'', 0, ''CODUSRWID''
			exec dbo.CalculateInternalCode ''UserAuthorization'', 0 , ''codua''

			exec dbo.CalculateInternalCode ''AJFWORKFLOWPROCESS'', 0 , ''CODPRCESS''
			exec dbo.CalculateInternalCode ''AJFWORKFLOWTASK'', 0 , ''CODTASK''

 
		commit transaction
	END TRY
	BEGIN CATCH
		rollback transaction
		declare @erro as nvarchar (4000)
		set @erro = ERROR_MESSAGE()
		RAISERROR (@erro, 16, -1)
	END CATCH
end')


GO
