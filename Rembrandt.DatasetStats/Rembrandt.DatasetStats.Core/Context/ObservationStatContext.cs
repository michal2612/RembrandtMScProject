using System;
using Microsoft.EntityFrameworkCore;
using Rembrandt.DatasetStats.Core.Models;

namespace Rembrandt.DatasetStats.Core.Context
{
    public class ObservationStatContext : DbContext
    {
        public DbSet<ObservationStat> ObservationsStat { get; set; }
        public DbSet<SkipReasons> SkipReasons { get; set; }
        public DbSet<PhotoAddress> PhotoAdresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer($"Server=51.104.49.19,1435;Database=ObservationsStats;User Id=SA;Password=<YourStrong@Passw0rd>;");
        }
    }
}