using System;
using Rembrandt.Users.Core.Helpers;

namespace Rembrandt.Users.Core.Models
{
    public class User
    {
        public int PrimaryKey { get; protected set; }
        public string Key { get; protected set; }
        public string Password { get; protected set; }
        public string Email { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime RegisteredAt { get; protected set; }
        public string Role { get; protected set; }

        protected User()
        {
            
        }

        public User(string email, string password, string salt)
        {
            Key = GenerateKey();
            Email = SetEmail(email);
            Password = SetPassword(password);
            Salt = salt;
            RegisteredAt = DateTime.UtcNow;
            Role = SetRole();
        }

        private string SetEmail(string email)
        {
            if(String.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException("Email should not be null!");

            return email.ToLower();
        }

        private string SetPassword(string password)
        {
            if(String.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("Password should not be null!");

            return password.ToLower();
        }

        private string GenerateKey()
            => Guid.NewGuid().ToString();

        private string SetRole()
            => Roles.user.ToString();
    }
}