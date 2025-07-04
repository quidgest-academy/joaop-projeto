USE [W_GnBD]
if (2501 > isnull((select versao from [AJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'USERLOGIN') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [USERLOGIN] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2501 > isnull((select versao from [AJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'ASYNCPROCESS') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [ASYNCPROCESS] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2501 > isnull((select versao from [AJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'ASYNCPROCESSARGUMENT') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [ASYNCPROCESSARGUMENT] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2501 > isnull((select versao from [AJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'NOTIFICATIONEMAILSIGNATURE') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [NOTIFICATIONEMAILSIGNATURE] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2501 > isnull((select versao from [AJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'NOTIFICATIONMESSAGE') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [NOTIFICATIONMESSAGE] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2501 > isnull((select versao from [AJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'ASYNCPROCESSATTACHMENTS') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [ASYNCPROCESSATTACHMENTS] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2501 > isnull((select versao from [AJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'USERAUTHORIZATION') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [USERAUTHORIZATION] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2502 > isnull((select versao from [AJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFCOUNTRY') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [AJFCOUNTRY] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2505 > isnull((select versao from [AJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFCLUB') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [AJFCLUB] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2506 > isnull((select versao from [AJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFCONTRACT') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [AJFCONTRACT] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2506 > isnull((select versao from [AJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFPLAYER') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [AJFPLAYER] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if (2507 > isnull((select versao from [AJFcfg]),0) or 'W_GnZeroTrue'='1')
begin
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFAGENTE') = 0)
BEGIN
BEGIN TRAN
	ALTER TABLE [AJFAGENTE] REBUILD

	if (@@error <> 0)
		ROLLBACK TRAN
	else
		COMMIT TRAN
	end
END
GO
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFMEM') = 0)
	ALTER TABLE [AJFMEM] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFCFG') = 0)
	ALTER TABLE [AJFCFG] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFUSRSET') = 0)
	ALTER TABLE [AJFUSRSET] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFUSRCFG') = 0)
	ALTER TABLE [AJFUSRCFG] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFWKFACT') = 0)
	ALTER TABLE [AJFWKFACT] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFWKFCON') = 0)
	ALTER TABLE [AJFWKFCON] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFWKFLIG') = 0)
	ALTER TABLE [AJFWKFLIG] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFWKFLOW') = 0)
	ALTER TABLE [AJFWKFLOW] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFNOTIFI') = 0)
	ALTER TABLE [AJFNOTIFI] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFSCRCRD') = 0)
	ALTER TABLE [AJFSCRCRD] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFPOSTIT') = 0)
	ALTER TABLE [AJFPOSTIT] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFPRMFRM') = 0)
	ALTER TABLE [AJFPRMFRM] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFALERTA') = 0)
	ALTER TABLE [AJFALERTA] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFALTENT') = 0)
	ALTER TABLE [AJFALTENT] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFTALERT') = 0)
	ALTER TABLE [AJFTALERT] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFDELEGA') = 0)
	ALTER TABLE [AJFDELEGA] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFLSTUSR') = 0)
	ALTER TABLE [AJFLSTUSR] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFLSTCOL') = 0)
	ALTER TABLE [AJFLSTCOL] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFLSTREN') = 0)
	ALTER TABLE [AJFLSTREN] REBUILD
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'AJFUSRWID') = 0)
	ALTER TABLE [AJFUSRWID] REBUILD
GO
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'DOCUMS') = 0)
	ALTER TABLE [DOCUMS] REBUILD
GO
if ((select count(1) tablename from sys.fulltext_index_columns fic where UPPER(object_name(fic.[object_id])) = 'hashcd') = 0)
	ALTER TABLE [hashcd] REBUILD
GO