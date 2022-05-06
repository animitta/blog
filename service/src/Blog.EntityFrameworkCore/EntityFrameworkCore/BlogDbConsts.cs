using Blog.Articles;
using Blog.Comments;
using Blog.Tags;
using Blog.Users;

namespace Blog.EntityFrameworkCore
{
    internal class BlogDbConsts
    {
        public const string DbSchema = null;

        public const string DbTablePrefix = "Blog.";

        public const string DbConnectionName = "Default";

        public const string UserTableName = DbTablePrefix + nameof(User);

        public const string ArticleTableName = DbTablePrefix + nameof(Article);

        public const string CategoryTableName = DbTablePrefix + nameof(Category);

        public const string ArticleTagTableName = DbTablePrefix + nameof(TagArticle);

        public const string TagTableName = DbTablePrefix + nameof(Tag);

        public const string CommentTableName = DbTablePrefix + nameof(Comment);
    }
}
