using Volo.Abp.Localization;
using Volo.Abp.Authorization.Permissions;
using Blog.Localization;

namespace Blog.Permissions
{
    public class BlogPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(BlogPermissions.GroupName);
            //myGroup.AddPermission(BlogPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BlogResource>(name);
        }
    }
}
