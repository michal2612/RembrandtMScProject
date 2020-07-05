using System;

namespace Rembrandt.Users.Infrastructure.Commands.Classes
{
    public class Login
    {
        public Guid TokenId { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }
    }
}