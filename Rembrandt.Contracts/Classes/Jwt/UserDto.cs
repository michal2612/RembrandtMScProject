using System;

namespace Rembrandt.Contracts.Classes.Jwt
{
    public class UserDto
    {
        public string Key { get; set; }

        public string Email { get; set; }

        public DateTime RegisteredAt { get; set; }
        
        public string Role { get; set; }
    }
}