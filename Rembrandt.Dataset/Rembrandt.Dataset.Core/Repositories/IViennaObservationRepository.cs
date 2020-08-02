using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.Dataset.Core.Models.ViennaDataset;

namespace Rembrandt.Dataset.Core.Repositories
{
    public interface IViennaObservationRepository
    {
        Task AddObservationAsync(ViennaObservation observation);

        Task<IEnumerable<ViennaObservation>> GetObservationsAsync(string userId);

        Task<IEnumerable<ViennaObservation>> GetAllObservationsAsync();
    }
}