using Blog.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Blog.DbMigrator
{
    [DependsOn(typeof(AbpAutofacModule))]
    [DependsOn(typeof(BlogApplicationContractsModule))]
    [DependsOn(typeof(BlogEntityFrameworkCoreModule))]
    [DependsOn(typeof(BlogFacilitiesModule))]
    public class BlogDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
