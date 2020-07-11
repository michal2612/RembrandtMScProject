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
        private readonly UserContext _userContext;

        public UserRepository()
            => _userContext = new UserContext();

        public async Task AddUserAsync(User user)
        {
            await _userContext.Users.AddAsync(user);
            await _userContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
            => await _userContext.Users.ToListAsync();

        public async Task<User> GetUserAsync(int id)
            => await _userContext.Users.Where(l => l.PrimaryKey == id).SingleOrDefaultAsync();

        public async Task<User> GetUserAsync(string email)
            => await _userContext.Users.Where(l => l.Email == email).SingleOrDefaultAsync();

        public async Task RemoveAsync(User user)
            => await _userContext.Users.Where(l => l.Key == user.Key).SingleOrDefaultAsync();

        public async Task UpdateAsync(User user)
        {
            var userInDb = await _userContext.Users.Where(l => l.Key == user.Key).SingleOrDefaultAsync();
            if(userInDb != null)
            {
                userInDb = user;
                await _userContext.SaveChangesAsync();
            }
        }
    }
}