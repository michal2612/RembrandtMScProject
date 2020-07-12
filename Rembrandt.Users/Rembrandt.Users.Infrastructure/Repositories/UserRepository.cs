using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rembrandt.Users.Core.Context;
using Rembrandt.Users.Core.Models;
using Rembrandt.Users.Core.Repositories;

namespace Rembrandt.Users.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> Users = new List<User>()
        {
            new User("test@gmail.com", "password", "salt")
        };
        private readonly UserContext _userContext;

        public UserRepository()
            => _userContext = new UserContext();

        public async Task AddUserAsync(User user)
        {
            Users.Add(user);
            //await _userContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
            => Users;

        public async Task<User> GetUserAsync(int id)
            => Users.Where(l => l.PrimaryKey == id).SingleOrDefault();

        public async Task<User> GetUserAsync(string email)
            => Users.Where(l => l.Email == email).SingleOrDefault();

        public async Task RemoveAsync(User user)
            => Users.Where(l => l.Key == user.Key).SingleOrDefault();

        public async Task UpdateAsync(User user)
        {
            var userInDb = Users.Where(l => l.Key == user.Key).SingleOrDefault();
            if(userInDb != null)
            {
                userInDb = user;
                await _userContext.SaveChangesAsync();
            }
        }
    }
}