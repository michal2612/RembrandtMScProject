using System;
using Rembrandt.Contracts.Classes.Jwt;

namespace Rembrandt.Users.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(string email, string role);
    }
}