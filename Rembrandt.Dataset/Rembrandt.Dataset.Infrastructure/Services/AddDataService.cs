using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Rembrandt.Dataset.Core.Models;
using Rembrandt.Dataset.Core.Repositories;
using Rembrandt.Dataset.Infrastructure.DTO;

namespace Rembrandt.Dataset.Infrastructure.Services
{
    public class AddDataService : IAddDataService
    {
        private readonly IObservationRepository _observationRepository;
        private readonly IMapper _mapper;

        public AddDataService(IObservationRepository observationRepository, IMapper mapper)
        {
            _observationRepository = observationRepository;
            _mapper = mapper;
        }

        public async Task AddObservationDtoAsync(ObservationDto observationDto)
        {
            if (observationDto == null)
                throw new ArgumentNullException("Json object can not be null!");

            await _observationRepository.AddObservationAsync(_mapper.Map<ObservationDto, Observation>(observationDto));
        }

        public async Task AddObservationsDtoAsync(IEnumerable<ObservationDto> observationsDto)
        {
            if (observationsDto == null)
                throw new ArgumentNullException("Json object can not be null!");

            foreach(var observation in observationsDto)
                await _observationRepository.AddObservationAsync(_mapper.Map<ObservationDto, Observation>(observation));
        }
    }
}