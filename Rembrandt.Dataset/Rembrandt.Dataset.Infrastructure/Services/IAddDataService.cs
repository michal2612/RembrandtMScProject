using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.Dataset.Core.Helpers;
using Rembrandt.Dataset.Core.Models;
using Rembrandt.Dataset.Infrastructure.DTO;
using Rembrandt.Dataset.Infrastructure.IoC;

namespace Rembrandt.Dataset.Infrastructure.Services
{
    public interface IAddDataService
    {
        Task AddObservationDtoAsync(IObservationDto observation);
        Task AddObservationsDtoAsync(IEnumerable<IObservationDto> observations);
    }
}