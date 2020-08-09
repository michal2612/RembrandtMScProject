using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rembrandt.Contracts.Classes.Dataset.ViennaObservations;
using Rembrandt.Contracts.Classes.Dataset.ViennaRequests;
using Rembrandt.Dataset.Infrastructure.Services;

namespace Rembrandt.Dataset.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViennaRequestController : ControllerBase
    {
        private readonly IViennaRequestService _requestService;

        public ViennaRequestController(IViennaRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpPost]
        public async Task<IEnumerable<ViennaObservationDto>> ReturnObservations(ViennaRequest request)
        {
            return await _requestService.GetMatchingObservationsDtoAsync(request);
        }
    }
}