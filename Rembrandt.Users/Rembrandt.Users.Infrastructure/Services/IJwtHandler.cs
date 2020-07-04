using System;
using Rembrandt.Users.Infrastructure.DTO;

namespace Rembrandt.Users.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(string email, string role);
    }
}