using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.Contracts.Classes.Stats;
using Rembrandt.DatasetStats.Core.Models;
using Rembrandt.DatasetStats.Core.Repository;
using Rembrandt.DatasetStats.Infrastructure.Services;

namespace Rembrandt.DatasetStats.Infrastructure
{
    public class StatsRepository : IStatsRepository
    {
        private readonly List<ObservationStat> _observations = new List<ObservationStat>();
        private readonly IMapper _mapper;

        public StatsRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ObservationStat>> GetAllObservationsStatAsync()
            => await Task.FromResult(_observations);

        public async Task<ObservationStat> GetObservationStatByIdAsync(int siteId)
            => await Task.FromResult(_observations.Where(id => id.SiteId == siteId).SingleOrDefault());

        public async Task UpdateDatabaseAsync(IEnumerable<ObservationStat> observations)
        {
            foreach(var observation in observations)
                _observations.Add(observation);
        }
    }
}