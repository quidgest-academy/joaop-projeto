IF((SELECT COUNT(1) FROM AJFcfg) = 0)
	INSERT INTO AJFcfg (codcfg, checkdat, versao, versindx, manutdat, upgrindx, zzstate) VALUES ('     1', GETDATE(), 2507, 0, NULL, 0, 0)
ELSE
  UPDATE AJFcfg set versao = 2507;
GO
