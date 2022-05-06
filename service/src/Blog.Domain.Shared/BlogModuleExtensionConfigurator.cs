using Volo.Abp.Threading;

namespace Blog
{
    public static class BlogModuleExtensionConfigurator
    {
        private static readonly OneTimeRunner OneTimeRunner = new();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                ConfigureExistingProperties();
                ConfigureExtraProperties();
            });
        }

        private static void ConfigureExistingProperties()
        {
            // 配置已存在属性
        }

        private static void ConfigureExtraProperties()
        {
            // 配置扩展属性
        }
    }
}
