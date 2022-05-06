namespace Blog.Articles
{
    /// <summary>
    /// 评论常量
    /// </summary>
    public static class CommentConsts
    {
        /// <summary>
        /// 评论者IP最小长度
        /// </summary>
        public const int MinCommenterIpLength = 7;

        /// <summary>
        /// 评论者IP最大长度
        /// </summary>
        public const int MaxCommenterIpLength = 39;


        /// <summary>
        /// 评论原始内容长度
        /// </summary>
        public const int CommentRawContentMaxLength = 1 << 10;

        /// <summary>
        /// 评论留言者IP
        /// </summary>
        public const int CommentCommenterIpMaxLength = 1 << 6;
    }
}
