using System.Threading.Tasks;

namespace Blog.Users
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public interface IUserAppService
    {
        public Task<UserDto> LoginAsync(string email, string password);

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>已创建用户</returns>
        public Task<UserDto> CreateAsync(UserCreatingDto input);
    }
}
