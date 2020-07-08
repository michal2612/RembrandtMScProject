using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.Dataset.Core.Models;
using Rembrandt.Dataset.Core.Repositories;

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

        public async Task<IEnumerable<ObservationDto>> GetAllObservationsAsync()
        {
            var observationsCore = await _observationRepository.GetAllObservationsAsync();
            var observationsDto = new List<ObservationDto>();

            foreach(var observation in observationsCore)
                observationsDto.Add(_mapper.Map<Observation, ObservationDto>(observation));

            return observationsDto;
        }

        public async Task<IEnumerable<ObservationDto>> GetObservationsAsync(string id)
        {
            var observationsCore = await _observationRepository.GetObservationsAsync(id);
            var observationsDto = new List<ObservationDto>();

            foreach(var observation in observationsCore)
                observationsDto.Add(_mapper.Map<Observation, ObservationDto>(observation));

            return observationsDto;
        }
    }
}