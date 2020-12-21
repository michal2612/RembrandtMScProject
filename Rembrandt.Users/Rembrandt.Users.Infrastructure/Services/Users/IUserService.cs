using System.Threading.Tasks;
using Rembrandt.Contracts.Classes.Jwt;

namespace Rembrandt.Users.Infrastructure.Services
{
    public interface IUserService
    {
        Task RegisterAsync(string email, string password);

        Task<UserDto> GetUserAsync(string email);
        
        Task LoginAsync(string email, string password);
    }
}