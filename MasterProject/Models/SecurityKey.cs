using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Text;

namespace MasterProject.Models
{
    public static class SecurityKey
    {
        public static string ReturnSecurityKey()
        {
            return System.IO.File.ReadAllLines(@"C:\Users\Michal\source\repos\MasterProject\securityKey.txt").First();
        }

        public static SymmetricSecurityKey ReturnSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ReturnSecurityKey()));
        }
    }
}
