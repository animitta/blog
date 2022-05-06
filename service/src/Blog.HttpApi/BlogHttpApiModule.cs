using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Localization.Resources.AbpUi;
using Blog.Localization;

namespace Blog
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(BlogApplicationContractsModule))]
    public class BlogHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureLocalization();
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<BlogResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
