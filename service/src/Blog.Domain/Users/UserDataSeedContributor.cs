using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Uow;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Blog.Users
{
    public class UserDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly UserManager _userManager;
        private readonly IRepository<User> _repository;

        public UserDataSeedContributor(UserManager userManager, IRepository<User> repository)
        {
            _userManager = userManager;
            _repository = repository;
        }

        [UnitOfWork]
        public virtual async Task SeedAsync(DataSeedContext context)
        {
            // context中提供了一些参数
            await CreateUsersAsync();
        }

        private async Task CreateUsersAsync()
        {
            if (await _repository.AnyAsync())
            {
                return;
            }

            var user = await _userManager.CreateAsync("浮生若梦", Sex.Male, "thinkershare@163.com", "T8aEQvzC691w", "15818601690");
            await _repository.InsertAsync(user);
        }
    }
}
