using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.Users.Core.Models;

namespace Rembrandt.Users.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int id);

        Task<User> GetUserAsync(string email);

        Task<IEnumerable<User>> GetAllUsersAsync();

        Task AddUserAsync(User user);

        Task RemoveAsync(User user);
        
        Task UpdateAsync(User user);
    }
}