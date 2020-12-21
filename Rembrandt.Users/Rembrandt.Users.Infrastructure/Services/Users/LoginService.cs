using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Rembrandt.Contracts.Classes.User;
using Rembrandt.Users.Infrastructure.Extensions;
using Rembrandt.Users.Infrastructure.Services;
using Rembrandt.Users.Infrastructure.Services.Users;

namespace Rembrandt.Users.Infrastructure.Commands
{
    public class LoginService : ILoginService
    {
        private readonly IUserService _userService;

        private readonly IJwtHandler _jwtHandler;
        
        private readonly IMemoryCache _memoryCache;

        public LoginService(IUserService userService, IJwtHandler jwtHandler, IMemoryCache memoryCache)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
            _memoryCache = memoryCache;
        }

        public async Task Login(Login login)
        {
            await _userService.LoginAsync(login.Email, login.Password);
            var user = await _userService.GetUserAsync(login.Email);
            var jwt= _jwtHandler.CreateToken(login.Email, user.Role);

            _memoryCache.SetJwt(login.Guid, jwt);
        }
    }
}