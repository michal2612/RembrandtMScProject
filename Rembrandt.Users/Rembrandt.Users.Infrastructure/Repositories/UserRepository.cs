using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Rembrandt.Users.Core.Models;
using Rembrandt.Users.Core.Repositories;

namespace Rembrandt.Users.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>()
        {
            new User($"emailaddress1@test.com", "secretPass1word", "secretSalt")
        };

        public async Task AddUserAsync(User user)
        {
            await Task.FromResult(_users.Add(user));
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await Task.FromResult(_users.ToList());
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await Task.FromResult(_users.Where(l => l.PrimaryKey == id).SingleOrDefault());
        }

        public async Task<User> GetUserAsync(string Email)
        {
            return await Task.FromResult(_users.Where(l => l.Email == Email).SingleOrDefault());
        }

        public async Task RemoveAsync(User user)
        {
            await Task.FromResult(_users.Remove(_users.Where(l => l.Key == user.Key).SingleOrDefault()));
        }

        public Task UpdateAsync(User user)
        {
            throw new Exception();
        }
    }
}