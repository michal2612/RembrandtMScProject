using System;
using Rembrandt.Users.Core.Helpers;

namespace Rembrandt.Users.Core.Models
{
    public class User
    {
        public int PrimaryKey { get; protected set; }
        public string Key { get; protected set; }
        public string  Username { get; protected set; }
        public string Password { get; protected set; }
        public string Email { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime RegisteredAt { get; protected set; }
        public string Role { get; protected set; }

        protected User()
        {
            
        }

        public User(string email, string username, string password, string salt)
        {
            Key = GenerateKey();
            Email = SetEmail(email);
            Username = SetUsername(username);
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

        private string SetUsername(string username)
        {
            if(String.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException("Username should not be null!");

            return username.ToLower();
        }

        private string SetPassword(string password)
        {
            if(String.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("Username should not be null!");

            return password.ToLower();
        }

        private string GenerateKey()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChar = new char[32];
            var random = new Random();

            for(int i = 0; i < stringChar.Length; i++)
                stringChar[i] = chars[random.Next(chars.Length)];

            return new String(stringChar);
        }

        private string SetRole()
            => Roles.user.ToString();
    }
}