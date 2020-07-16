using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.Contracts.Classes.Stats;
using Rembrandt.DatasetStats.Core.Models;

namespace Rembrandt.DatasetStats.Core.Repository
{
    public interface IStatsRepository
    {
        Task UpdateDatabaseAsync(IEnumerable<ObservationStat> observations);
        Task<ObservationStat> GetObservationStatByIdAsync(int siteId);
        Task<IEnumerable<ObservationStat>> GetAllObservationsStatAsync();
    }
}