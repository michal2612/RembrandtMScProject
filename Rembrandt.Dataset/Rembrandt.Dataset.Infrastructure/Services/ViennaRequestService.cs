using System.Collections.Generic;
using System.Linq;
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
        readonly IViennaObservationRepository _repository;

        readonly IMapper _mapper;

        public ViennaRequestService(IViennaObservationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ViennaObservationDto>> GetMatchingObservationsDtoAsync(ViennaRequest request)
        {
            var observations = new List<ViennaObservation>();

            foreach(var observation in await _repository.GetAllObservationsAsync())
            {
            }

            return _mapper.Map<IEnumerable<ViennaObservation>, IEnumerable<ViennaObservationDto>>(observations);
        }
    }
}