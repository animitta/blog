using Volo.Abp.Threading;

namespace Blog.EntityFrameworkCore
{
    public static class BlogEfCoreEntityExtensionMappings
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            // 配置普通属性+配置额外属性
            BlogModuleExtensionConfigurator.Configure();

            // 配置扩展属性
            OneTimeRunner.Run(() =>
            {
                //ObjectExtensionManager.Instance
                //    .MapEfCoreProperty<ModuleEntity, Type>(
                //        "PropertyName",
                //        (entityBuilder, propertyBuilder) =>
                //        {
                //            propertyBuilder.HasMaxLength(128);
                //        }
                //    );
            });
        }
    }
}
