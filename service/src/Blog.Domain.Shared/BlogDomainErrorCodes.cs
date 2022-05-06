namespace Blog
{
    /// <summary>
    /// 错误代码
    /// </summary>
    public static class BlogDomainErrorCodes
    {
        #region Users

        #region User
        public const string UserIdentityNotUnique = "blog:010101";

        public const string UserEntityNotFound = "blog:010102";

        public const string UserPasswordIncorrect = "blog:010103";
        #endregion

        #endregion
    }
}
