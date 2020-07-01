using Microsoft.EntityFrameworkCore;
using Rembrandt.Dataset.Core.Models;

namespace Rembrandt.Dataset.Core.ContextFiles
{
    public class ObservationContext : DbContext
    {
        public DbSet<Observation> Observations { get; set; }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<Attributes> Attributes { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Park> Parks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=observationDb.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contributor>()
                .HasKey(c => new { c.ContributorPrimaryKey});
        }
    }
}