using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rembrandt.Users.Infrastructure.Services;
using Rembrandt.Users.Infrastructure.Settings;

namespace Rembrandt.Users.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;

        public UsersController(IUserService userService, IJwtHandler jwtHandler)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
        }

        [HttpGet("{email}")]
        //[Authorize]
        public async Task<IActionResult> Get(string email)
        {
            var user =  await _userService.GetUserAsync(email);
            if(user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser(string email, string password)
        {
            await _userService.RegisterAsync(email, password);

            return Ok(_jwtHandler.CreateToken(email, "admin"));
        }

        [HttpGet("settings")]
        public IActionResult CheckSettings()
        {
            var settings = new Settings();
            return Content(settings.IssuerSigningKey);
        }
    }
}
