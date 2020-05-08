using System;
using System.Security.Cryptography;

namespace users_microservice
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public DateTime RegisterData { get; set; }
        public int RoleId { get; set; }
    }

    public enum Roles
    {
        User = 0,
        Moderator = 1,
        Admin = 2
    }
}
