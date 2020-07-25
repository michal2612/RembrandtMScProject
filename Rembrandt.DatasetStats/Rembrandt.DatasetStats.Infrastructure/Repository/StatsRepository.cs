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
            => await _observationStatContext.ObservationsStat
                .Include(s => s.Activities)
                .Include(s => s.Attributes)
                .Include(s => s.PhotosAddresses)
                .Include(s => s.SkipReasons)
                .ToListAsync();

        public async Task<ObservationStat> GetObservationStatByIdAsync(int siteId)
            => await _observationStatContext.ObservationsStat
                .Include(s => s.Activities)
                .Include(s => s.Attributes)
                .Include(s => s.PhotosAddresses)
                .Include(s => s.SkipReasons)
                .Where(id => id.SiteId == siteId).SingleOrDefaultAsync();

        public async Task UpdateDatabaseAsync(IEnumerable<ObservationStat> observations)
        {
            foreach(var observation in observations)
                await _observationStatContext.ObservationsStat.AddAsync(observation);
            await _observationStatContext.SaveChangesAsync();
        }

        public async Task UpdateObservationAsync(int siteId, ObservationStat observationStat) 
        {
            var observation = await _observationStatContext.ObservationsStat.Where(c => c.SiteId == siteId).SingleOrDefaultAsync();

            if(observation == null)
                return;

            observation = observationStat;
            await _observationStatContext.SaveChangesAsync();
        }
    }
}