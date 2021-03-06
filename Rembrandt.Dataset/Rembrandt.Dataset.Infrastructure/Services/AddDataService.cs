using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json.Linq;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.Contracts.IoC;
using Rembrandt.Dataset.Core.Models;
using Rembrandt.Dataset.Core.Repositories;

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

        public async Task AddObservationDtoAsync(IObservationDto observation)
        {
            if (observation == null)
            {
                throw new ArgumentNullException("Json object can not be null!");
            }
            await _observationRepository.AddObservationAsync
                (_mapper.Map<ObservationDto, Observation>(observation.ObservationDto()));
        }

        public async Task AddObservationsDtoAsync(IEnumerable<IObservationDto> observations)
        {
            if (observations == null)
            {
                throw new ArgumentNullException("Json object can not be null!");
            }

            foreach(var observation in observations)
            {
                await _observationRepository.AddObservationAsync
                    (_mapper.Map<ObservationDto, Observation>(observation.ObservationDto()));
            }
        }

        public async Task AddMultipleDefaultListAsync(JsonElement defaultMultipleList)
        {
            if(String.IsNullOrWhiteSpace(defaultMultipleList.GetRawText()))
            {
                throw new ArgumentNullException("Json object can not be null!");
            }

            var jObjectFeatures = (JArray)JObject.Parse(defaultMultipleList.ToString())["features"];

            foreach(var observation in jObjectFeatures)
            {
                await _observationRepository.AddObservationAsync
                    (_mapper.Map<ObservationDto, Observation>
                        (observation["properties"].ToObject<DefaultObservation>().ObservationDto()));
            }
        }
    }
}