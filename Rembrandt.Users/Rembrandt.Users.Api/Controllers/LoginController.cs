using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Rembrandt.Users.Infrastructure.Services.Users;
using Rembrandt.Users.Infrastructure.Extensions;
using Rembrandt.Contracts.Classes.User;

namespace Rembrandt.Users.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        readonly IMemoryCache _memoryCache;
        readonly ILoginService _loginService;

        public LoginController(IMemoryCache memoryCache, ILoginService loginService)
        {
            _memoryCache = memoryCache;
            _loginService = loginService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(Login login)
        {
            await _loginService.Login(login);
            var jwt = _memoryCache.GetJwt(login.Guid);

            return Content(jwt.Token);
        }
    }
}   