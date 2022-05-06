using System;using System.Threading.Tasks;
using Xunit;using Volo.Abp.Domain.Repositories;
namespace Blog.Users
{
    public class UserAppServiceTests : BlogApplicationTestBase
    {
        private readonly IRepository<User, Guid> _userAppService;

        public UserAppServiceTests()
        {
            _userAppService = GetRequiredService<IRepository<User, Guid>>();
        }

        [Fact]
        public Task Initial_Data_Should_Contain_Admin_User()
        {            return Task.CompletedTask;
        }
    }
}
