using System;

namespace Rembrandt.Users.Core.Models
{
    public class User
    {
        public int PrimaryKey { get; set; }
        public string Key { get; set; }
        public string  Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
        public DateTime RegisteredAt { get; set; }
        public int Role { get; set; }
    }
}