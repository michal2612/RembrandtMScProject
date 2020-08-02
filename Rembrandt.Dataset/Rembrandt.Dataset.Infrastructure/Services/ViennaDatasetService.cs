using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.Contracts.Classes.Dataset.ViennaObservations;

namespace Rembrandt.Dataset.Infrastructure.Services
{
    public class ViennaDatasetService : IViennaDatasetService
    {
        public async Task<IEnumerable<ViennaObservationDto>> GetAllObservationsAsync()
        {
            return new List<ViennaObservationDto>();
        }

        public async Task<IEnumerable<ViennaObservationDto>> GetObservationsByIdAsync(string userId)
        {
            return new List<ViennaObservationDto>();
        }
    }
}