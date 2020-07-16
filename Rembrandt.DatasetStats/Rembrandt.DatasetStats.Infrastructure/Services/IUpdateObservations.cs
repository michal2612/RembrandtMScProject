using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.DatasetStats.Core.Models;

namespace Rembrandt.DatasetStats.Infrastructure.Services
{
    public interface IUpdateObservations
    {
        Task UpdateObservationsAsync(IEnumerable<ObservationDto> observationDtos);
    }
}