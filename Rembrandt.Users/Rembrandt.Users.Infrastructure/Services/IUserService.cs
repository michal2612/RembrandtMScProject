using System.Threading.Tasks;
using Rembrandt.Users.Infrastructure.DTO;

namespace Rembrandt.Users.Infrastructure.Services
{
    public interface IUserService
    {
        Task RegisterAsync(string email, string username, string password);
        Task<UserDto> GetUserAsync(string email);
        Task LoginAsync(string email, string password);
    }
}