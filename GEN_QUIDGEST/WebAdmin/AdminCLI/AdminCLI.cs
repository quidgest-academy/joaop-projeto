using CommandLine;
using CSGenio.persistence;
using CSGenio.config;
using DbAdmin;
using GenioServer.security;
using System;

namespace AdminCLI
{
    static partial class AdminCLI
    {
        private static DBMaintenance dBMaintenance;
        private static SysConfiguration sysConfiguration;

        private static IConfigurationManager _configManager;

        static int Main(string[] args)
        {
            //Starting procedure for SP
            Init();
            
            //Parse console arguments
            try
            {
                var parsedArgs = CommandLine.Parser.Default.ParseArguments<ReindexOptions, ListReindexScriptsOptions, WriteConfigurationOptions, 
                    ReadConfigurationOptions, BackupOptions, RestoreOptions, RemoveBackupOptions, CreateRedirectOptions, ConfigOptions>(args);

                return parsedArgs.MapResult(
                    (ReindexOptions opts) => Reindex(opts),
                    (ListReindexScriptsOptions opts) => ListReindexScripts(opts),
                    (WriteConfigurationOptions opts) => WriteConfiguration(opts),
                    (ReadConfigurationOptions opts) => ReadConfiguration(opts),
                    (BackupOptions opts) => Backup(opts),
                    (RestoreOptions opts) => Restore(opts),
                    (RemoveBackupOptions opts) => RemoveBackup(opts),
                    (CreateRedirectOptions opts) => CreateNewRedirect(opts),
                    (ConfigOptions opts) => HandleConfig(opts),
                    errs => 1);
            }
            catch (Exception e) {
                Console.WriteLine("The following error has ocurred: " + e.Message);
                return 1;
            }
        }

        private static void Init()
        {
            //GenioServer services
            CSGenio.GenioDIDefault.Use();

            //Initialize library classes
            dBMaintenance = new DBMaintenance(AppDomain.CurrentDomain.BaseDirectory);
            _configManager = new FileConfigurationManager(CSGenio.framework.Configuration.GetConfigPath());
            sysConfiguration = new SysConfiguration(_configManager);
        }
    }
}
