using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            //security key
            string securityKey = System.IO.File.ReadAllLines(@"C:\Users\Michal\source\repos\MasterProject\securityKey.txt").First();
            //symetric security key
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            //signing credentials
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            //create token
            var token = new JwtSecurityToken(
                issuer: "smesdk.in",
                audience: "readers",
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signingCredentials
                );
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}