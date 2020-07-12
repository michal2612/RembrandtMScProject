using Microsoft.EntityFrameworkCore;
using Rembrandt.Contracts.Database;
using Rembrandt.Users.Core.Models;

namespace Rembrandt.Users.Core.Context
{
    public class UserContext : DbContext
    {
        // public DbSet<User> Users { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        // {
        //     options.UseSqlServer($"Server={DatabaseConfig.Host},{DatabaseConfig.Port};Database=Users;User Id={DatabaseConfig.User};Password={DatabaseConfig.Password};");
        // }
    }
}