using System;

namespace Rembrandt.Contracts.Classes.User
{
    public class Login
    {
        public Guid TokenId { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }
    }
}