using System;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using static Blog.Articles.TagConsts;

namespace Blog.Tags
{
    public class Tag : AggregateRoot<Guid>, ICreationAuditedObject
    {
        private Tag()
        {
        }

        public Tag(string name, Guid? categoryId)
        {
            CategoryId = categoryId;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), MaxNameLength, MinNameLength);
        }

        #region Properties

        public string Name { get; set; }

        public Guid? CategoryId { get; set; }

        public Guid? CreatorId { get; set; }

        public DateTime CreationTime { get; set; }
        #endregion
    }
}
