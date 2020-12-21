using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Rembrandt.Contracts.Classes.User;
using Rembrandt.Users.Infrastructure.Extensions;

namespace Rembrandt.Users.Infrastructure.Services.Users
{
    public class RegisterService : IRegisterService
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _memoryCache;

        public RegisterService(IUserService userSerivce, IJwtHandler jwtHandler, IMemoryCache memoryCache)
        {
            _userService = userSerivce;
            _jwtHandler = jwtHandler;
            _memoryCache = memoryCache;
        }
        public async Task Register(Register register)
        {
            if(register.Password != register.RepeatPassword)
            {
                throw new Exception("Passwords should be the same!");
            }
                
            await _userService.RegisterAsync(register.Email, register.Password);
            var user = await _userService.GetUserAsync(register.Email);
            var jwt = _jwtHandler.CreateToken(register.Email, user.Role);

            _memoryCache.SetJwt(register.Guid, jwt);
        }
    }
}