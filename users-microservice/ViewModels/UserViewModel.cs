using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace users_microservice.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public DateTime RegisterData { get; set; }
        public string Role { get; set; }
    }
}
