using System;
using System.ComponentModel.DataAnnotations;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.Users.Core.Helpers;

namespace Rembrandt.Users.Core.Models
{
    public class User
    {
        [Key]
        public int PrimaryKey { get; protected set; }

        public string Key { get; protected set; }

        public string Password { get; protected set; }

        public string Email { get; protected set; }

        public DateTime RegisteredAt { get; protected set; }

        public string Role { get; protected set; }
        
        public Details Details { get; protected set; }

        protected User()
        {
            
        }

        public User(string email, string password, string salt)
        {
            Key = GenerateKey();
            Email = SetEmail(email);
            Password = SetPassword(password);
            RegisteredAt = DateTime.UtcNow;
            Role = SetRole();
            Details = new Details() {
                Salt = salt
            };
        }

        string SetEmail(string email)
        {
            if(String.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException("Email should not be null!");

            return email.ToLower();
        }

        string SetPassword(string password)
        {
            if(String.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("Password should not be null!");

            return password;
        }

        string GenerateKey()
            => Guid.NewGuid().ToString();

        string SetRole()
            => Roles.user.ToString();
    }
}