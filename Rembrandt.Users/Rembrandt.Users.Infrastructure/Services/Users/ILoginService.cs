using System.Threading.Tasks;
using Rembrandt.Contracts.Classes.User;

namespace Rembrandt.Users.Infrastructure.Services.Users
{
    public interface ILoginService
    {
        Task Login(Login login);
    }
}