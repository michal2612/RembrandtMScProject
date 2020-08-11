using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Rembrandt.Contracts.Classes.Dataset.ViennaObservations;
using Rembrandt.Contracts.Classes.Dataset.ViennaRequests;
using Rembrandt.Dataset.Core.Models.ViennaDataset;
using Rembrandt.Dataset.Core.Repositories;

namespace Rembrandt.Dataset.Infrastructure.Services
{
    public class ViennaRequestService : IViennaRequestService
    {
        private readonly IViennaObservationRepository _repository;

        private readonly IMapper _mapper;

        public ViennaRequestService(IViennaObservationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ViennaObservationDto>> GetMatchingObservationsDtoAsync(ViennaRequest request)
        {
            var observations = new List<ViennaObservationDto>();

            foreach(var observation in await _repository.GetAllObservationsAsync())
                foreach(var subAttribute in request.RequestedActivities)
                    if((bool?)observation.SubAttributes.GetType().GetProperty(subAttribute).GetValue(observation.SubAttributes) == true)
                    {
                        observations.Add(_mapper.Map<ViennaObservation, ViennaObservationDto>(observation));
                        break;
                    }
            return observations;
        }
    }
}