using System;

namespace Rembrandt.Contracts.Classes.User
{
    public class Register
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public Guid Guid = Guid.NewGuid();
    }
}