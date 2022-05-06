using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.Emailing;
using Volo.Abp.Modularity;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.SettingManagement;

namespace Blog
{
    [DependsOn(typeof(BlogDomainSharedModule))]
    [DependsOn(typeof(AbpEmailingModule))]
    [DependsOn(typeof(AbpBackgroundJobsDomainModule))]
    [DependsOn(typeof(AbpSettingManagementDomainModule))]
    public class BlogDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
#if DEBUG
            context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
        }
    }
}
