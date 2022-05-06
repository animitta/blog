using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Blog.Comments
{
    /// <summary>
    /// 评论实体
    /// </summary>
    public class Comment : AggregateRoot<Guid>, IHasCreationTime, IHasDeletionTime, ISoftDelete
    {
        private Comment()
        {
        }

        /// <summary>
        /// 原内容
        /// </summary>
        public string RawContent { get; set; }

        /// <summary>
        /// 显示内容
        /// </summary>
        public string DisplayContent { get; set; }

        /// <summary>
        /// 评论者
        /// </summary>
        public Guid? CommenterId { get; set; }

        /// <summary>
        /// 评论者IP
        /// </summary>
        public string CommenterIp { get; set; }

        /// <summary>
        /// 赞次数
        /// </summary>
        public int PraiseTimes { get; set; }

        /// <summary>
        /// 踩次数
        /// </summary>
        public int TreadCount { get; set; }

        /// <summary>
        /// 是否通过审核
        /// </summary>
        public bool IsAudited { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 是否标记为删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeletionTime { get; set; }

        /// <summary>
        /// 父评论编号
        /// </summary>
        public Guid? ParentCommentId { get; set; }

        /// <summary>
        /// 文章编号
        /// </summary>
        public Guid ArticleId { get; set; }

        /// <summary>
        /// 子评论
        /// </summary>
        public virtual ICollection<Comment> Children { get; set; }
    }
}
