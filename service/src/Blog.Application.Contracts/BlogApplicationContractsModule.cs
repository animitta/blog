using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace Blog
{
    [DependsOn(typeof(BlogDomainSharedModule))]
    [DependsOn(typeof(AbpObjectExtendingModule))]
    public class BlogApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            BlogDtoExtensions.Configure();
        }
    }
}
