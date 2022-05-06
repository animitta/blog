using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Blog.Articles
{
    /// <summary>
    /// 文章实体
    /// </summary>
    public class Article : AggregateRoot<Guid>, ICreationAuditedObject, IHasModificationTime
    {
        private Article()
        {
        }

        public Article(string title, string content)
        {

        }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public int ClickTimes { get; private set; }

        public int PraiseTimes { get; private set; }

        public int TreadTimes { get; private set; }

        public bool IsTop { get; set; }

        public bool IsEnableComments { get; private set; }

        public Guid CategoryId { get; private set; }

        public Guid? CreatorId { get; private set; }

        public DateTime CreationTime { get; private set; }

        public DateTime? LastModificationTime { get; set; }
    }
}
