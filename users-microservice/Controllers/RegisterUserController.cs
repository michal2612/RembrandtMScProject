using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using users_microservice.ViewModels;

namespace users_microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegisterUserController : ControllerBase
    {
        static string Encrypt(string value)
        {
            if(!String.IsNullOrWhiteSpace(value))
            {
                using MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                UTF8Encoding utf = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf.GetBytes(value));
                return Convert.ToBase64String(data);
            }
            return null;
        }
        [HttpGet]
        public UserViewModel ReturnData()
        {
            var user = new UserViewModel
            {
                Id = 1,
                RegisterData = DateTime.Now,
                Password = Encrypt("passwordValue"),
                Role = Convert.ToString((Roles)1)
            };
            return user;
        }

        public bool CheckUsername(User user)
        {
            //if(String.IsNullOrWhiteSpace(user.Username) || user.Username IN DB)
            //    return false;
            return true;
        }
    }
}