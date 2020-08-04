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
            var observationsDb = await _repository.GetAllObservationsAsync();
            var observationsDto = new List<ViennaObservationDto>();

            foreach(var observation in observationsDb)
                observationsDto.Add(_mapper.Map<ViennaObservation, ViennaObservationDto>(observation));

            return observationsDto;
        }

        public async Task<IEnumerable<ViennaObservationDto>> GetObservationsByIdAsync(string userId)
        {
            var observations = await _repository.GetObservationsAsync(userId);
            var observationsDto = new List<ViennaObservationDto>();

            observations.ToList()
                        .ForEach(i => observationsDto.Add(_mapper.Map<ViennaObservation, ViennaObservationDto>(i)));


            return observationsDto;
        }
    }
}