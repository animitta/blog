using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Domain.Repositories;

namespace Blog.Articles
{
    public class ArticleManager : DomainService
    {
        private readonly IRepository<Article, Guid> _repository;

        public ArticleManager(IRepository<Article, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<Article> CreateAsync(string name)
        {
            var article = new Article(string.Empty, string.Empty);
            return await Task.FromResult(article);
        }
    }
}
