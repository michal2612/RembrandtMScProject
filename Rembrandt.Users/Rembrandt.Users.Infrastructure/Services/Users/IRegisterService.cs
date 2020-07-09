using System.Threading.Tasks;
using Rembrandt.Contracts.Classes.User;

namespace Rembrandt.Users.Infrastructure.Services.Users
{
    public interface IRegisterService
    {
        Task Register(Register register);
    }
}