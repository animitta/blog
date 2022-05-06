using Blog.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public abstract class BlogController : AbpControllerBase
    {
        protected BlogController()
        {
            LocalizationResource = typeof(BlogResource);
        }
    }
}
