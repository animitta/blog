using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace Blog.Users
{
    /// <inheritdoc />
    public class UserAppService : BlogAppService, IUserAppService
    {
        private readonly UserManager _manager;
        private readonly IRepository<User, Guid> _repository;

        public UserAppService(UserManager manager, IRepository<User, Guid> repository)
        {
            _manager = manager;
            _repository = repository;
        }

        /// <inheritdoc />
        [RemoteService(IsEnabled = false)]
        public async Task<UserDto> LoginAsync(string email, string password)
        {
            var user = await _repository.FindAsync(u => u.Email == email);
            if (user == null)
            {
                throw new BusinessException(BlogDomainErrorCodes.UserEntityNotFound);
            }

            _manager.EmailPasswordLogin(user, password);
            await _repository.UpdateAsync(user);
            return ObjectMapper.Map<User, UserDto>(user);
        }

        /// <inheritdoc />
        public async Task<UserDto> CreateAsync(UserCreatingDto input)
        {
            var user = await _manager.CreateAsync(input.Name, input.Sex, input.Email, input.Password, input.Mobile);

            await _repository.InsertAsync(user);
            return ObjectMapper.Map<User, UserDto>(user);
        }
    }
}
