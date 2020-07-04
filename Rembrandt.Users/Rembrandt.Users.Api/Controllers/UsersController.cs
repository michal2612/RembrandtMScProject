using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rembrandt.Users.Infrastructure.DTO;
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
        public async Task<IActionResult> Get(string email)
        {
            var user =  await _userService.GetUserAsync(email);
            if(user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser(string email, string username, string password)
        {
            await _userService.RegisterAsync(email, username, password);

            return Ok();
        }
    }
}
