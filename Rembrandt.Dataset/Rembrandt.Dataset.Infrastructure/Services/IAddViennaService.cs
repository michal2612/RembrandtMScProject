using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Rembrandt.Contracts.Classes.Dataset.ViennaObservations;

namespace Rembrandt.Dataset.Infrastructure.Services
{
    public interface IAddViennaService
    {
        Task AddObservationAsync(ViennaObservationDto observation);

        Task AddObservationsAsync(IEnumerable<ViennaObservationDto> observations);

        Task<IEnumerable<ViennaObservationDto>> AddObservationsJsonAsync(JsonElement defaultMultipleList);
    }
}