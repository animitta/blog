using System;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using static Blog.Articles.CategoryConsts;

namespace Blog.Articles
{
    /// <summary>
    /// 类别实体
    /// </summary>
    public class Category : AggregateRoot<Guid>, ICreationAuditedObject, IHasModificationTime
    {
        private Category()
        {
        }

        public Category(string name, string imageUrl, string description)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), MaxNameLength, MinNameLength);
            ImageUrl = Check.NotNullOrWhiteSpace(imageUrl, nameof(imageUrl), MaxImageUrlLength);
            Description = Check.NotNullOrWhiteSpace(description, nameof(description), MaxDescriptionLength);
        }

        #region Properties

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 图片URL
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public Guid? CreatorId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModificationTime { get; set; }
        #endregion
    }
}
