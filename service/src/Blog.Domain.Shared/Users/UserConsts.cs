namespace Blog.Users
{
    /// <summary>
    /// 用户常量
    /// </summary>
    public static class UserConsts
    {
        /// <summary>
        /// 名称最小字符长度
        /// </summary>
        public const int MinNameLength = 2;

        /// <summary>
        /// 名称最大字符长度
        /// </summary>
        public const int MaxNameLength = 10;

        /// <summary>
        /// 邮箱最小字符长度
        /// </summary>
        public const int MinEmailLength = 5;

        /// <summary>
        /// 邮箱最大字符长度
        /// </summary>
        public const int MaxEmailLength = 50;

        /// <summary>
        /// 手机号码字符长度
        /// </summary>
        public const int MobileLength = 11;

        /// <summary>
        /// 密码最小字符长度
        /// </summary>
        public const int MinPasswordLength = 8;

        /// <summary>
        /// 密码最大字符长度
        /// </summary>
        public const int MaxPasswordLength = 32;

        /// <summary>
        /// 哈希密码最小字符长度
        /// </summary>
        public const int MinHashedPasswordLength = 32;

        /// <summary>
        /// 哈希密码最大字符长度
        /// </summary>
        public const int MaxHashedPasswordLength = 256;
    }
}
