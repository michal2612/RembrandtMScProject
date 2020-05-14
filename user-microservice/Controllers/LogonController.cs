using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using user_microservice.Models;

namespace user_microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogonController : ControllerBase
    {
        private readonly UserContext _context;

        public LogonController(UserContext db)
        {
            _context = db;
        }

        //Login
        public string Login(User user)
        {
            var userInDb = _context.Users.Where(c => c.Username == user.Username).Where(c => c.Password == user.Password).FirstOrDefault();
            if (userInDb != null)
                return "jwt_token";
            else
                throw new Exception("Login failed");
        }
        //Logoff
        public string Logoff(string jwt)
        {
            if (String.IsNullOrWhiteSpace(jwt))
                return "Log off successfull.";
            return "Failed";
        }
    }
}