using Microsoft.EntityFrameworkCore;
using Rembrandt.Contracts.Databases;
using Rembrandt.Users.Core.Models;

namespace Rembrandt.Users.Core.Context
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var database = new DatabaseAccess("User");
            options.UseSqlServer($"Server={database.Host},{database.Port};Database={database.Database};User Id={database.User};Password={database.Password};");
        }
    }
}