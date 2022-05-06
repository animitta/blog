using Blog.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Blog
{
    [DependsOn(typeof(BlogEntityFrameworkCoreTestModule))]
    public class BlogDomainTestModule : AbpModule
    {
    }
}