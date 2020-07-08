using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.Contracts.Classes
.Dataset;
using Rembrandt.Dataset.Core.Models;

namespace Rembrandt.Dataset.Infrastructure.Services
{
    public interface IDatasetService
    {
        Task<IEnumerable<ObservationDto>> GetObservationsAsync(string id);
        Task<IEnumerable<ObservationDto>> GetAllObservationsAsync();
    }
}