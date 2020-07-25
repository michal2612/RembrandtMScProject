using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.Contracts.Classes
.Dataset;

namespace Rembrandt.Dataset.Infrastructure.Services
{
    public interface IDatasetService
    {
        Task<IEnumerable<ObservationDto>> GetObservationsAsync(string id);

        Task<IEnumerable<ObservationDto>> GetAllObservationsAsync();
        
        Task<IEnumerable<ObservationDto>> GetMultipleObservationsDtobySiteIdAsync(int siteId);
    }
}