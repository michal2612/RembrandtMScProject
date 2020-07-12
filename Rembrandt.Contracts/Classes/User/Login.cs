using System;

namespace Rembrandt.Contracts.Classes.User
{
    public class Login
    {
        public Guid Guid = Guid.NewGuid();
        public string Email { get; set; }   
        public string Password { get; set; }
    }
}