using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Blog.Users
{
    public class UserDomainTests : BlogDomainTestBase
    {
        private readonly IRepository<User, Guid> _repository;
        private readonly ArticleManager _userManager;

        public UserDomainTests()
        {
            _repository = GetRequiredService<IRepository<User, Guid>>();
            _userManager = GetRequiredService<ArticleManager>();
        }

        [Fact]
        public Task Should_Set_Email_Of_A_User()
        {
            return Task.CompletedTask;
        }
    }
}
