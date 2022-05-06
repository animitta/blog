using System;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Volo.Abp.Security.Claims;
using Blog.Users;
using Blog.Models.Users;

namespace Blog.Controllers
{
    /// <summary>
    /// 认证控制器
    /// </summary>
    [ApiController]
    [Route("api/app/[controller]")]
    public class TokenController : BlogController
    {
        private readonly JwtOptions _options;
        private readonly IUserAppService _userAppService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options"></param>
        /// <param name="userAppService"></param>
        public TokenController(IOptions<JwtOptions> options, IUserAppService userAppService)
        {
            _options = options.Value;
            _userAppService = userAppService;
        }

        /// <summary>
        /// 创建Token
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> CreateAsync(EmailPasswordLoginDto input)
        {
            var user = await _userAppService.LoginAsync(input.Email, input.Password);
            var claims = new Claim[]
            {
                new Claim(AbpClaimTypes.Name, user.Name),
                new Claim(AbpClaimTypes.UserName, user.Account),
                new Claim(AbpClaimTypes.UserId, user.Id.ToString()),
            };

            return CreateToken(claims);
        }

        private string CreateToken(IEnumerable<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecurityKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_options.Issuer, _options.Audience, claims, signingCredentials: credentials, expires: DateTime.Now.AddMinutes(30));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
