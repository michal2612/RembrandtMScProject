using Microsoft.EntityFrameworkCore;
using Rembrandt.Dataset.Core.Models;

namespace Rembrandt.Dataset.Core.Database
{
    public class ObservationContext : DbContext
    {
        public DbSet<Observation> Observations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=dbservation.db");
    }
}