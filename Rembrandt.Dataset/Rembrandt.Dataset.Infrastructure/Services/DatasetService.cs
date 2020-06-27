using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using Rembrandt.Dataset.Core.Models;
using Rembrandt.Dataset.Core.Repositories;
using Rembrandt.Dataset.Infrastructure.DTO;

namespace Rembrandt.Dataset.Infrastructure.Services
{
    public class DatasetService : IDatasetService
    {
        private readonly IObservationRepository _observationRepository;
        private readonly IMapper _mapper;

        public DatasetService(IObservationRepository observationRepository, IMapper mapper)
        {
            _observationRepository = observationRepository;
            _mapper = mapper;
        }

        public async Task AddObservationAsync(ObservationDto observeration)
        {
            var observationCore = _mapper.Map<ObservationDto, Observation>(observeration);
            await _observationRepository.AddObservationAsync(observationCore);
        }

        public async Task<IEnumerable<ObservationDto>> GetAllObservationsAsync()
        {
            var observationsCore = await _observationRepository.GetAllObservationsAsync();
            var observationsDto = new List<ObservationDto>();

            foreach(var observation in observationsCore)
                observationsDto.Add(_mapper.Map<Observation, ObservationDto>(observation));

            return observationsDto;
        }

        public async Task<ObservationDto> GetObservationAsync(string id)
        {
            var observationCore = await _observationRepository.GetObservationAsync(id);

            return _mapper.Map<Observation,ObservationDto>(observationCore);
        }
    }
}