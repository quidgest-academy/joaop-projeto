
USE [W_GnBD]
-- comment to prevent the file from being empty
-- if the file is empty the backoffice will throw an error

EXEC BackupComputedColumns
GO
 EXEC RestoreComputedColumns
GO