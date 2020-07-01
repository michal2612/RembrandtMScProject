using Microsoft.EntityFrameworkCore;
using Rembrandt.Dataset.Core.Models;

namespace Rembrandt.Dataset.Core.Context
{
    public class ObservationContext : DbContext
    {
        public DbSet<Observation> Observations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=..\Rembrandt.Dataset.Api\observations.db");
    }
}