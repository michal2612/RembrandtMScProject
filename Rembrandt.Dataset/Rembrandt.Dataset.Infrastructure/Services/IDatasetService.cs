using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.Dataset.Core.Models;
using Rembrandt.Dataset.Infrastructure.DTO;

namespace Rembrandt.Dataset.Infrastructure.Services
{
    public interface IDatasetService
    {
        Task AddObservationAsync(ObservationDto observeration);
        Task<ObservationDto> GetObservationAsync(string id);
        Task<IEnumerable<ObservationDto>> GetAllObservationsAsync();
    }
}