using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{id}")]
        public User ReturnUserOfId(int id)
        {
            if (_context.Users.Where(c => c.Id == id).SingleOrDefault() != null)
                return _context.Users.Where(c => c.Id == id).SingleOrDefault();
            else
                return new User() { Id = id};
        }
        [HttpPost]
        public string AddUserToDb(User user)
        {
            if (CheckUser(user))
            {
                user.Role = new Roles() { Id = 1};
                _context.Users.Add(user);
                return "User has been added successfully to database";
            }
            else
                throw new Exception("User has not been added to database");
        }

        [HttpPut]
        public User UpdateUser(User user)
        {
            var userInDb = _context.Users.Where(u => u.Id == user.Id).SingleOrDefault();
            if (userInDb == null)
                throw new Exception("There is no user with that username in database");
            return userInDb;
        }
        //NO API METHODS
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