using Volo.Abp.Settings;

namespace Blog.Settings
{
    public class BlogSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(new SettingDefinition(BlogSettings.IsEnableComments, BlogSettingsDefaults.IsEnableComments.ToString()));
        }
    }
}
