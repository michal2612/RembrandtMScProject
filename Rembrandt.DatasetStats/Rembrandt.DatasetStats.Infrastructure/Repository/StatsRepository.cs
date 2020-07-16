using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rembrandt.DatasetStats.Core.Context;
using Rembrandt.DatasetStats.Core.Models;
using Rembrandt.DatasetStats.Core.Repository;

namespace Rembrandt.DatasetStats.Infrastructure
{
    public class StatsRepository : IStatsRepository
    {
        private readonly ObservationStatContext _observationStatContext;
        private readonly List<ObservationStat> _observations = new List<ObservationStat>();

        public StatsRepository()
        {
            _observationStatContext = new ObservationStatContext();
        }

        public async Task<IEnumerable<ObservationStat>> GetAllObservationsStatAsync()
            => await _observationStatContext.ObservationsStat.ToListAsync();

        public async Task<ObservationStat> GetObservationStatByIdAsync(int siteId)
            => await _observationStatContext.ObservationsStat.Where(id => id.SiteId == siteId).SingleOrDefaultAsync();

        public async Task UpdateDatabaseAsync(IEnumerable<ObservationStat> observations)
        {
            foreach(var observation in observations)
                await _observationStatContext.ObservationsStat.AddAsync(observation);
            await _observationStatContext.SaveChangesAsync();
        }
    }
}