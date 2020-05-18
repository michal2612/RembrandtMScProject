using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MasterProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("token")]
        public ActionResult GetToken()
        {
            //signing credentials
            var signingCredentials = new SigningCredentials(Models.SecurityKey.ReturnSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature);
            //create token
            var token = new JwtSecurityToken(
                issuer: "smesk.in",
                audience: "readers",
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signingCredentials
                );
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}