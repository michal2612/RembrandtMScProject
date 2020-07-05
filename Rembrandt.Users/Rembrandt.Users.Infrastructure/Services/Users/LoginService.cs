using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Rembrandt.Users.Infrastructure.Commands.Classes;
using Rembrandt.Users.Infrastructure.Extensions;
using Rembrandt.Users.Infrastructure.Services;
using Rembrandt.Users.Infrastructure.Services.Users;

namespace Rembrandt.Users.Infrastructure.Commands
{
    public class LoginService : ILoginService
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;

        public LoginService(IUserService userService, IJwtHandler jwtHandler, IMemoryCache memoryCache)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
            _cache = memoryCache;
        }

        public async Task Login(Login login)
        {
            await _userService.LoginAsync(login.Email, login.Password);
            var user = await _userService.GetUserAsync(login.Email);
            var jwt= _jwtHandler.CreateToken(login.Email, user.Role);

            _cache.SetJwt(login.TokenId, jwt);
        }
    }
}