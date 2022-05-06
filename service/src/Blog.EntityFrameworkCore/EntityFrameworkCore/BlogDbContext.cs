using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Blog.Users;
using static Blog.EntityFrameworkCore.BlogDbConsts;

namespace Blog.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class BlogDbContext : AbpDbContext<BlogDbContext>
    {
        #region Entities

        public DbSet<User> Users { get; set; }

        #endregion

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();

            #region Users

            builder.Entity<User>(b =>
            {
                b.ToTable(UserTableName, DbSchema);
                b.ConfigureByConvention();

                b.Property(t => t.Name).IsRequired().HasMaxLength(UserConsts.MaxNameLength);
                b.Property(t => t.Email).IsRequired().HasMaxLength(UserConsts.MaxEmailLength);
                b.Property(t => t.Mobile).HasMaxLength(UserConsts.MobileLength);
                b.Property(t => t.HashedPassword).IsRequired().HasMaxLength(UserConsts.MaxHashedPasswordLength);

                b.HasIndex(t => t.Name).IsUnique();
                b.HasIndex(t => t.Email).IsUnique();
                b.HasIndex(t => t.Mobile).IsUnique();
            });

            #endregion

            #region Articles

            //builder.Entity<Category>(b =>
            //{
            //    b.ToTable(CategoryTableName, DbSchema);
            //    b.ConfigureByConvention();

            //    b.Property(t => t.Name).IsRequired().HasMaxLength(CategoryConsts.MaxNameLength);
            //    b.Property(t => t.Description).HasMaxLength(CategoryConsts.MaxDescriptionLength);
            //    b.Property(t => t.ImageUrl).IsRequired().HasMaxLength(CategoryConsts.MaxImageUrlLength);
            //});

            //builder.Entity<Tag>(b =>
            //{
            //    b.ToTable(TagTableName, DbSchema);
            //    b.ConfigureByConvention();

            //    b.Property(t => t.Name).IsRequired().HasMaxLength(TagConsts.MaxNameLength);
            //    b.HasOne<Category>().WithMany().HasForeignKey(t => t.CategoryId).OnDelete(DeleteBehavior.Cascade);
            //});

            //builder.Entity<Article>(b =>
            //{
            //    b.ToTable(ArticleTableName, DbSchema);
            //    b.ConfigureByConvention();

            //    b.Property(t => t.Title).IsRequired().HasMaxLength(ArticleConsts.MaxTitleLength);
            //    b.Property(t => t.Remark).HasMaxLength(ArticleConsts.MaxRemarkLength);
            //    b.HasOne<Category>().WithMany().HasForeignKey(a => a.CreatorId).OnDelete(DeleteBehavior.Cascade);
            //});

            //builder.Entity<ArticleTag>(b =>
            //{
            //    b.ToTable(ArticleTagTableName, DbSchema);
            //    b.ConfigureByConvention();

            //    b.HasKey(t => new { t.ArticleId, t.TagId });
            //});

            //builder.Entity<Comment>(b =>
            //{
            //    b.ToTable(CommentTableName, DbSchema);
            //    b.ConfigureByConvention();

            //    b.Property(t => t.CommenterIp).IsRequired().HasMaxLength(CommentConsts.MaxCommenterIpLength);
            //    b.HasOne<Article>().WithMany().HasForeignKey(c => c.ArticleId).OnDelete(DeleteBehavior.Cascade);
            //    b.HasOne<Comment>().WithMany().HasForeignKey(c => c.ParentCommentId).OnDelete(DeleteBehavior.Cascade);
            //});

            #endregion
        }
    }
}
