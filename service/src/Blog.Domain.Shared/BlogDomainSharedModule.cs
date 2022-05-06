using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.SettingManagement;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Validation.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Blog.Localization;

namespace Blog
{
    [DependsOn(typeof(AbpBackgroundJobsDomainSharedModule))]
    [DependsOn(typeof(AbpSettingManagementDomainSharedModule))]
    public class BlogDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            BlogModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<BlogDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<BlogResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/Blog");

                options.DefaultResourceType = typeof(BlogResource);
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Blog", typeof(BlogResource));
            });
        }
    }
}
