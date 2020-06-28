using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.Dataset.Core.Models;
using Rembrandt.Dataset.Infrastructure.DTO;

namespace Rembrandt.Dataset.Infrastructure.Services
{
    public interface IAddDataService
    {
        Task AddObservationDtoAsync(ObservationDto observationDto);

        Task AddObservationsDtoAsync(IEnumerable<ObservationDto> observationsDto);
    }
}