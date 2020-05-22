using JWT.Algorithms;
using JWT.Builder;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterProject.Models
{
    public static class SecurityKey
    {
        private static readonly string securityKeyPath = @"C:\Users\Michal\source\repos\MasterProject\securityKey.txt";

        public static string ReturnSecurityKey()
        {
            return System.IO.File.ReadAllLines(securityKeyPath).First();
        }

        public static SymmetricSecurityKey ReturnSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ReturnSecurityKey()));
        }

        //JWT BUILDER
        //---------------------------------
        public static string GenerateAccessToken()
        {
            return new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(Encoding.UTF8.GetBytes(ReturnSecurityKey()))
                .AddClaim("exp", DateTime.Now.AddHours(1))
                .AddClaim("username", "dupsko")
                //.addClaim("role", user.Role)
                .Encode(); //generates and return token
        }

        public static IDictionary<string, object> VerifyToken(string token)
        {
            return new JwtBuilder()
                .WithSecret(Encoding.UTF8.GetBytes(ReturnSecurityKey()))
                .MustVerifySignature()
                .Decode<Dictionary<string, object>>(token);
        }
        //---------------------------------
    }
}
