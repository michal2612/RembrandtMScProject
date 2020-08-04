using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.DatasetStats.Core.Models;

namespace Rembrandt.DatasetStats.Core.Repository
{
    public interface IStatsRepository
    {
        Task UpdateDatabaseAsync(IEnumerable<ObservationStat> observations);

        Task UpdateObservationAsync(int siteId, ObservationStat observationStat);

        Task<ObservationStat> GetObservationStatByIdAsync(int siteId);

        Task<IEnumerable<ObservationStat>> GetAllObservationsStatAsync();
    }
}