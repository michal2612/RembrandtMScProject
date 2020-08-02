using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.Contracts.Classes.Dataset.ViennaObservations;

namespace Rembrandt.Dataset.Infrastructure.Services
{
    public interface IViennaDatasetService
    {
        Task<IEnumerable<ViennaObservationDto>> GetObservationsByIdAsync(string userId);

        Task<IEnumerable<ViennaObservationDto>> GetAllObservationsAsync();
    }
}