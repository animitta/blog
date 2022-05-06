using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace Blog
{
    public static class BlogDtoExtensions
    {
        private static readonly OneTimeRunner OneTimeRunner = new();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
            });
        }
    }
}
