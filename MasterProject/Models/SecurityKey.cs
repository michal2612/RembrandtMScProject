using Microsoft.IdentityModel.Tokens;
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
    }
}
