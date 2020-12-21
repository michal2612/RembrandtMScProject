using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json.Linq;
using Rembrandt.Contracts.Classes.Dataset.ViennaObservations;
using Rembrandt.Dataset.Core.Models.ViennaDataset;
using Rembrandt.Dataset.Core.Repositories;

namespace Rembrandt.Dataset.Infrastructure.Services
{
    public class AddViennaService : IAddViennaService
    {
        private readonly IViennaObservationRepository _repository;

        private readonly IMapper _mapper;

        public AddViennaService(IViennaObservationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddObservationsAsync(IEnumerable<ViennaObservationDto> observations)
            => observations.ToList().ForEach(async (observation) => await AddObservationAsync(observation));

        public async Task AddObservationAsync(ViennaObservationDto observation)
        {
            if(observation == null)
            {
                throw new ArgumentNullException("Observation can't be null!");
            }
            await _repository.AddObservationAsync(_mapper.Map<ViennaObservationDto, ViennaObservation>(observation));
        }

        public async Task AddObservationsJsonAsync(JsonElement defaultMultipleList)
        {
            var jObjects = (JArray)JObject.Parse(defaultMultipleList.ToString())["features"];

            foreach(var objectJ in jObjects)
            {
                await AddObservationAsync(objectJ["properties"].ToObject<DefaultViennaObservation>().ViennaObservationDto());
            }
        }
    }
}