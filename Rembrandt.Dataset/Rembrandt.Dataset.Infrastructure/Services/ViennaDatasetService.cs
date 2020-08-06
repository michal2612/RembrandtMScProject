using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Rembrandt.Contracts.Classes.Dataset.ViennaObservations;
using Rembrandt.Dataset.Core.Models.ViennaDataset;
using Rembrandt.Dataset.Core.Repositories;

namespace Rembrandt.Dataset.Infrastructure.Services
{
    public class ViennaDatasetService : IViennaDatasetService
    {
        readonly IViennaObservationRepository _repository;

        readonly IMapper _mapper;

        public ViennaDatasetService(IMapper mapper, IViennaObservationRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ViennaObservationDto>> GetAllObservationsAsync()
        {
            return from ViennaObservation observation in await _repository.GetAllObservationsAsync()
                   select _mapper.Map<ViennaObservation, ViennaObservationDto>(observation);
        }

        public async Task<IEnumerable<ViennaObservationDto>> GetObservationsByIdAsync(string userId)
        {
            return from ViennaObservation observation in await _repository.GetObservationsAsync(userId)
                   select _mapper.Map<ViennaObservation, ViennaObservationDto>(observation);
        }
    }
}