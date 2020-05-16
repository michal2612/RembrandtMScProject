using System.Linq;

namespace MasterProject.Models
{
    public static class SecurityKey
    {
        public static string ReturnSecurityKey()
        {
            return System.IO.File.ReadAllLines(@"C:\Users\Michal\source\repos\MasterProject\securityKey.txt").First();
        }
    }
}
