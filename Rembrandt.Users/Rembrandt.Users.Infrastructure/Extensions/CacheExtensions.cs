using System;
using Microsoft.Extensions.Caching.Memory;
using Rembrandt.Contracts.Classes.Jwt;

namespace Rembrandt.Users.Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwt(this IMemoryCache cache, Guid tokenId, JwtDto jwt)
            => cache.Set(GetJwtKey(tokenId), jwt, TimeSpan.FromSeconds(5));

        public static JwtDto GetJwt(this IMemoryCache cache, Guid tokenId)
            => cache.Get<JwtDto>(GetJwtKey(tokenId));

        static string GetJwtKey(Guid tokenId)
            => $"jwt-{tokenId}";
    }
}