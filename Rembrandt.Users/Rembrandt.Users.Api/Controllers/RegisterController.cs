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
    public class RegisterController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IRegisterService _registerService;

        public RegisterController(IMemoryCache memoryCache, IRegisterService registerService)
        {
            _memoryCache = memoryCache;
            _registerService = registerService;
        }

        public async Task<IActionResult> Register(Register register)
        {
            await _registerService.Register(register);
            var jwt = _memoryCache.GetJwt(register.Guid);

            return Content(jwt.Token);
        }
    }
}