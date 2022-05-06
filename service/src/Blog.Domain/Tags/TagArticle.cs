using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Blog.Tags
{
    /// <summary>
    /// 文章标签实体
    /// </summary>
    public class TagArticle : Entity, IHasCreationTime
    {
        private TagArticle()
        {
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="articleId">文章编号</param>
        /// <param name="tagId">标签编号</param>
        public TagArticle(Guid articleId, Guid tagId)
        {
            ArticleId = articleId;
            TagId = tagId;
        }

        #region Properties

        /// <summary>
        /// 文章编号
        /// </summary>
        public Guid ArticleId { get; private set; }

        /// <summary>
        /// 标签编号
        /// </summary>
        public Guid TagId { get; private set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
        #endregion

        /// <inheritdoc />
        public override object[] GetKeys()
        {
            return new object[] { ArticleId, TagId };
        }
    }
}
