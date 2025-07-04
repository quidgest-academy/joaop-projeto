USE [W_GnBD]
DECLARE @triggerName nvarchar(200)
DECLARE trigger_cursor CURSOR FOR select [name] from sysobjects where xtype = 'TR'
OPEN trigger_cursor
FETCH NEXT FROM trigger_cursor 
INTO @triggerName
WHILE @@FETCH_STATUS = 0
BEGIN
	if left(@triggerName, 8) = 'tlog_AJF'
	begin
		exec ('DROP TRIGGER ' + @triggerName)
	end
	FETCH NEXT FROM trigger_cursor 
	INTO @triggerName
END 
CLOSE trigger_cursor
DEALLOCATE trigger_cursor
GO
