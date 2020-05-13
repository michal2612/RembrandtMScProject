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
    public class RegisterController : ControllerBase
    {
        //FIELDS
        private readonly UserContext _context;

        //CONSTRUCTORS
        public RegisterController(UserContext db)
        {
            _context = db;
        }

        //METHODS
        [HttpGet]
        public List<User> ListOfUsers()
        {
            return _context.Users.ToList();
        }

        [HttpPost]
        public User AddUserToDb(User user)
        {
            return user;
        }

        public bool CheckUser(User user)
        {
            if (String.IsNullOrWhiteSpace(user.Username) || String.IsNullOrWhiteSpace(user.EmailAddress))
                return false;
            if (_context.Users.Where(u => u.Username == user.Username).Count() == 0 && _context.Users.Where(u => u.EmailAddress == user.EmailAddress).Count() == 0)
                return false;
            return true;
        }
    }
}