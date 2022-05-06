using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Blog
{
    [DependsOn(typeof(BlogDomainModule))]
    [DependsOn(typeof(BlogApplicationContractsModule))]
    public class BlogApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<BlogApplicationModule>();
            });
        }
    }
}
