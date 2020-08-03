using Microsoft.EntityFrameworkCore;
using Rembrandt.Contracts.Database;
using Rembrandt.Dataset.Core.Models;
using Rembrandt.Dataset.Core.Models.ViennaDataset;

namespace Rembrandt.Dataset.Core.Context
{
    public class ObservationContext : DbContext
    {
        public DbSet<Observation> Observations { get; set; }

        public DbSet<ViennaObservation> ViennaObservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Server={DatabaseConfig.Host},{DatabaseConfig.Port};Database=Observations;User Id={DatabaseConfig.User};Password={DatabaseConfig.Password};");
            
    }
}