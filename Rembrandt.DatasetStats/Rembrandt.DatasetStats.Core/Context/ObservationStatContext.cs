using System;
using Microsoft.EntityFrameworkCore;
using Rembrandt.Contracts.Database;
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
            options.UseSqlServer($"Server={DatabaseConfig.Host},{DatabaseConfig.Port};Database=Users;User Id={DatabaseConfig.User};Password={DatabaseConfig.Password};");
        }
    }
}