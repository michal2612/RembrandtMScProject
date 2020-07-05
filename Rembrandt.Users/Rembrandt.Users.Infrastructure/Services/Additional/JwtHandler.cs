using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Rembrandt.Users.Infrastructure.DTO;
using Rembrandt.Users.Infrastructure.Extensions;
using Rembrandt.Users.Infrastructure.Settings;

namespace Rembrandt.Users.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly Settings.Settings _settings;

        public JwtHandler(Settings.Settings settings)
        {
            _settings = settings;
        }

        public JwtDto CreateToken(string email, string role)
        {
            var now = DateTime.UtcNow;
            var claimsValues = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp(now).ToString(), ClaimValueTypes.Integer64)
            };

            var expiries = now.AddMinutes(_settings.ExpiryMinutes);
            var signingCredentialsValues = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.IssuerSigningKey)),SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: _settings.Issuer,
                claims: claimsValues,
                notBefore: now,
                expires: expiries,
                signingCredentials: signingCredentialsValues
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDto
            {
                Token = token,
                Expiry = expiries.ToTimestamp(expiries)
            };
        }
    }
}