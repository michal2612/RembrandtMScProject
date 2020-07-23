using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rembrandt.Contracts.Classes.User;
using Rembrandt.Users.Infrastructure.Services;

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
        [Authorize]
        public async Task<IActionResult> Get(string email)
        {
            var user =  await _userService.GetUserAsync(email);
            if(user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
