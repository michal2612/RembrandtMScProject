using System.Collections.Generic;
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
        readonly IViennaObservationRepository _repository;

        readonly IMapper _mapper;

        public AddViennaService(IViennaObservationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddObservationAsync(ViennaObservationDto observation)
            => await  _repository.AddObservationAsync(_mapper.Map<ViennaObservationDto, ViennaObservation>(observation));

        public async Task AddObservationsAsync(IEnumerable<ViennaObservationDto> observations)
        {
            foreach(var observation in observations)
                await AddObservationAsync(observation);
        }

        public async Task<IEnumerable<ViennaObservationDto>> AddObservationsJsonAsync(JsonElement defaultMultipleList)
        {
            var jObject = (JArray)JObject.Parse(defaultMultipleList.ToString())["features"];
            var jObjects = new List<JToken>();

            foreach(var objectJ in jObject)
                jObjects.Add(objectJ["properties"]);

            var myObjects = new List<ViennaObservationDto>();
            foreach(var objectJ in jObjects)
                //await AddObservationAsync(objectJ.ToObject<DefaultViennaObservation>().ViennaObservationDto());
                myObjects.Add(objectJ.ToObject<DefaultViennaObservation>().ViennaObservationDto());
                
            return myObjects;
        }
    }
}