using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel;

namespace Blog.Extensions
{
    /// <summary>
    /// 枚举扩展
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// 获取枚举对用户友好的名称
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <returns>描述文本</returns>
        public static string GetUserFriendlyName(this Enum value)
        {
            var type = value.GetType();
            var member = type.GetMember(value.ToString()).FirstOrDefault();
            var descriptionAttribute = member.GetCustomAttribute<DescriptionAttribute>(false);
            if (descriptionAttribute != null)
            {
                return descriptionAttribute.Description;
            }

            var displayName = member.GetCustomAttribute<DisplayNameAttribute>(false);
            if (displayName != null)
            {
                return displayName.DisplayName;
            }

            var display = member.GetCustomAttribute<DisplayNameAttribute>(false);

            return display != null ? display.DisplayName : member?.Name;
        }
    }
}
