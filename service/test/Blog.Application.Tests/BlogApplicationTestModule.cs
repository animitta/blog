using Volo.Abp.Modularity;

namespace Blog
{
    [DependsOn(typeof(BlogApplicationModule))]
    public class BlogApplicationTestModule : AbpModule
    {
    }
}