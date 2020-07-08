using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Rembrandt.Contracts.IoC;

namespace Rembrandt.Dataset.Infrastructure.Services
{
    public interface IAddDataService
    {
        Task AddObservationDtoAsync(IObservationDto observation);
        Task AddObservationsDtoAsync(IEnumerable<IObservationDto> observations);
        Task AddMultipleDefaultListAsync(JsonElement defaultMultipleList);
    }
}