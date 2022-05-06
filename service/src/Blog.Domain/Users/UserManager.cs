using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;
using Volo.Abp.Domain.Repositories;
using Ibms.Security;
using static Blog.Users.UserConsts;
using static Blog.BlogDomainErrorCodes;

namespace Blog.Users
{
    public class UserManager : DomainService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IRepository<User, Guid> _repository;

        public UserManager(IRepository<User, Guid> repository, IPasswordHasher passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        public void ChangePassword(User user, string rawPassword, string newPassword)
        {
            if (!_passwordHasher.Verify(user.HashedPassword, rawPassword))
            {
                throw new BusinessException(UserPasswordIncorrect);
            }

            Check.NotNullOrWhiteSpace(newPassword, nameof(newPassword), MaxPasswordLength, MinPasswordLength);

            user.SetHashedPassword(_passwordHasher.Hash(newPassword));
        }

        public void EmailPasswordLogin(User user, string password)
        {
            if (!_passwordHasher.Verify(user.HashedPassword, password))
            {
                throw new BusinessException(UserPasswordIncorrect);
            }

            user.Login();
        }

        public async Task<User> CreateAsync(string name, Sex sex, string email, string password, string mobile = null)
        {
            var queryable = await _repository.GetQueryableAsync();
            var query = queryable.Where(new UserIdentitySpecification(name, email, mobile));

            if (await AsyncExecuter.AnyAsync(query))
            {
                throw new BusinessException(UserIdentityNotUnique);
            }

            return new User(GuidGenerator.Create(), name, sex, email, mobile, _passwordHasher.Hash(password));
        }
    }
}
