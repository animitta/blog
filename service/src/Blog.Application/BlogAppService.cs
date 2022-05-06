using Blog.Localization;
using Volo.Abp.Application.Services;

namespace Blog
{
    public abstract class BlogAppService : ApplicationService
    {
        protected BlogAppService()
        {
            LocalizationResource = typeof(BlogResource);
        }
    }
}
