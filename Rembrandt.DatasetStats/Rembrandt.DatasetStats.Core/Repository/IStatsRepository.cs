using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.DatasetStats.Core.Models;

namespace Rembrandt.DatasetStats.Core.Repository
{
    public interface IStatsRepository
    {
        Task UpdateDatabaseAsync(IEnumerable<ObservationStat> observations);

        Task<ObservationStat> GetObservationStatByIdAsync(int siteId);

        Task<IEnumerable<ObservationStat>> GetAllObservationsStatAsync();

        Task UpdateObservationAsync(int siteId, ObservationStat observationStat);
    }
}