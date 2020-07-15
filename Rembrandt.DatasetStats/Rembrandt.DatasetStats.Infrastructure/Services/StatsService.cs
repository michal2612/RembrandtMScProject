using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.Contracts.Classes.Stats;
using Rembrandt.DatasetStats.Core.Models;

namespace Rembrandt.DatasetStats.Infrastructure.Services
{
    public class StatsService : IStatsService
    {
        public Task GetObservations(IEnumerable<ObservationDto> observations)
        {
            throw new System.NotImplementedException();
        }

        public Task<ObservationStatDto> GetObservationStat(int siteId)
        {
            throw new System.NotImplementedException();
        }
    }
}