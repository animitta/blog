using System;
using System.Linq;
using System.Threading.Tasks;using Microsoft.EntityFrameworkCore;using Xunit;using Shouldly;
using Volo.Abp.Domain.Repositories;
using Blog.Users;namespace Blog.EntityFrameworkCore.Samples
{
    public class UserRepositoryTests : BlogEntityFrameworkCoreTestBase
    {
        private readonly IRepository<User, Guid> _repository;

        public UserRepositoryTests()
        {
            _repository = GetRequiredService<IRepository<User, Guid>>();
        }

        [Fact]
        public async Task Should_Query_AppUser()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                //Act
                var adminUser = await (await _repository.GetQueryableAsync())
                    .Where(u => u.Name == "admin")
                    .FirstOrDefaultAsync();

                //Assert
                adminUser.ShouldNotBeNull();
            });
        }
    }
}
