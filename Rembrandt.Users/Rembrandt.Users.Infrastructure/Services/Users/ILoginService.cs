using System.Threading.Tasks;
using Rembrandt.Users.Infrastructure.Commands.Classes;

namespace Rembrandt.Users.Infrastructure.Services.Users
{
    public interface ILoginService
    {
        Task Login(Login login);
    }
}