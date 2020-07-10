using Microsoft.EntityFrameworkCore;
using Rembrandt.Contracts.Databases;
using Rembrandt.Dataset.Core.Models;

namespace Rembrandt.Dataset.Core.Context
{
    public class ObservationContext : DbContext
    {
        public DbSet<Observation> Observations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var database = new DatabaseAccess("Dataset");
            options.UseSqlServer($"Server={database.Host},{database.Port};Database={database.Database};User Id={database.User};Password={database.Password};");
        }
            
    }
}