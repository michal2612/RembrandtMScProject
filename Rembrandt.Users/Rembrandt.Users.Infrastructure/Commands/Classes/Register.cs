using System;

namespace Rembrandt.Users.Infrastructure.Commands.Classes
{
    public class Register
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid Guid = Guid.NewGuid();
    }
}