using Microsoft.EntityFrameworkCore;
using Rembrandt.Users.Core.Models;

namespace Rembrandt.Users.Core.Context
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer($"Server=51.104.49.19,1434;Database=Users;User Id=SA;Password=<YourStrong@Passw0rd>;");
        }
    }
}