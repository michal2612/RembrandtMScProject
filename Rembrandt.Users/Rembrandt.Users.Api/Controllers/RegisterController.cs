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
        readonly IMemoryCache _memoryCache;
        readonly IRegisterService _registerService;

        public RegisterController(IMemoryCache memoryCache, IRegisterService registerService)
        {
            _memoryCache = memoryCache;
            _registerService = registerService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            await _registerService.Register(register);
            var jwt = _memoryCache.GetJwt(register.Guid);

            return Content(jwt.Token);
        }
    }
}