using Volo.Abp.Modularity;

namespace Blog
{
    [DependsOn(typeof(BlogApplicationModule))]    [DependsOn(typeof(BlogDomainTestModule))]
    public class BlogApplicationTestModule : AbpModule
    {
    }
}