using System.Threading;
using System.Threading.Tasks;
using Blog.Data;using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Volo.Abp;

namespace Blog.DbMigrator
{
    public class DbMigratorHostedService : IHostedService
    {
        private readonly IConfiguration _configuration;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        public DbMigratorHostedService(IConfiguration configuration, IHostApplicationLifetime hostApplicationLifetime)
        {
            _configuration = configuration;
            _hostApplicationLifetime = hostApplicationLifetime;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var application = AbpApplicationFactory.Create<BlogDbMigratorModule>(options =>
            {
                options.Services.ReplaceConfiguration(_configuration);
                options.UseAutofac();
                options.Services.AddLogging(c => c.AddSerilog());
            });

            application.Initialize();
            await application
                .ServiceProvider
                .GetRequiredService<BlogDbMigrationService>()
                .MigrateAsync();

            application.Shutdown();
            _hostApplicationLifetime.StopApplication();
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
