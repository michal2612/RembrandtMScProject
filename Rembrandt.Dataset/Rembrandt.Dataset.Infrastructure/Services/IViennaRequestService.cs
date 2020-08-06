using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.Contracts.Classes.Dataset.ViennaObservations;
using Rembrandt.Contracts.Classes.Dataset.ViennaRequests;

namespace Rembrandt.Dataset.Infrastructure.Services
{
    public interface IViennaRequestService
    {
        Task<IEnumerable<ViennaObservationDto>> GetMatchingObservationsDtoAsync(ViennaRequest request);
    }
}