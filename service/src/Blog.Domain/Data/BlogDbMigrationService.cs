using System;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using static Blog.Helpers.PathHelper;

namespace Blog.Data
{
    public class BlogDbMigrationService : ITransientDependency
    {

        private readonly IDataSeeder _dataSeeder;
        private readonly IEnumerable<IBlogDbSchemaMigrator> _dbSchemaMigrators;

        public BlogDbMigrationService(IDataSeeder dataSeeder, IEnumerable<IBlogDbSchemaMigrator> dbSchemaMigrators)
        {
            _dataSeeder = dataSeeder;
            _dbSchemaMigrators = dbSchemaMigrators;
            Logger = NullLogger<BlogDbMigrationService>.Instance;
        }

        public ILogger<BlogDbMigrationService> Logger { get; set; }

        public async Task MigrateAsync()
        {
            var initialMigrationAdded = AddInitialMigrationIfNotExist();
            if (initialMigrationAdded)
            {
                return;
            }

            Logger.LogInformation("Started database migrations...");
            await MigrateDatabaseSchemaAsync();
            Logger.LogInformation($"Successfully completed database migrations.");

            Logger.LogInformation($"Started seed data...");
            await SeedDataAsync();
            Logger.LogInformation($"Successfully completed seed data.");

            Logger.LogInformation("You can safely end this process...");
        }

        private async Task MigrateDatabaseSchemaAsync()
        {
            Logger.LogInformation("Migrating schema for host database");

            foreach (var migrator in _dbSchemaMigrators)
            {
                await migrator.MigrateAsync();
            }
        }

        private async Task SeedDataAsync()
        {
            Logger.LogInformation($"Executing host database seed...");

            await _dataSeeder.SeedAsync(new DataSeedContext());

            // 可以调用WithProperty为Context添加上下文参数
        }

        private bool AddInitialMigrationIfNotExist()
        {
            try
            {
                // 迁移项目不存在
                if (!DbMigrationsProjectExists())
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            try
            {
                // 迁移文件夹不存在
                if (!MigrationsFolderExists())
                {
                    AddInitialMigration();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Logger.LogWarning("Couldn't determinate if any migrations exist : {@message}", e.Message);
                return false;
            }
        }

        private static bool DbMigrationsProjectExists()
        {
            var dbMigrationsProjectFolder = GetEntityFrameworkCoreProjectFolderPath();
            return dbMigrationsProjectFolder != null;
        }

        private static bool MigrationsFolderExists()
        {
            var dbMigrationsProjectFolder = GetEntityFrameworkCoreProjectFolderPath();
            return Directory.Exists(Path.Combine(dbMigrationsProjectFolder, "Migrations"));
        }

        private void AddInitialMigration()
        {
            Logger.LogInformation("Creating initial migration...");

            string fileName;
            string argumentPrefix;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                argumentPrefix = "-c";
                fileName = "/bin/bash";
            }
            else
            {
                argumentPrefix = "/C";
                fileName = "cmd.exe";
            }

            var procStartInfo = new ProcessStartInfo(fileName, $"{argumentPrefix} \"abp create-migration-and-run-migrator \"{GetEntityFrameworkCoreProjectFolderPath()}\"\"");

            try
            {
                Process.Start(procStartInfo);
            }
            catch (Exception)
            {
                throw new Exception("Couldn't run ABP CLI...");
            }
        }
    }
}
