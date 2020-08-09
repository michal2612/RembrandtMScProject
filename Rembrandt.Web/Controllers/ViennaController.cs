using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rembrandt.Contracts.Classes.Dataset.ViennaObservations;
using Rembrandt.Contracts.Classes.Dataset.ViennaRequests;
using Rembrandt.Web.ViewModels;

namespace Rembrandt.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class viennaController : BaseController
    {
        public IActionResult Data()
        {
            return View(new ViennaDatasetViewModel() {
                ViennaObservation = new ViennaObservationDto() {
                    SubAttributes = new ViennaSubAttributesDto()
                }
            });
        }

        public async Task<IActionResult> Submit(ViennaRequest request)
        {
            var convertedRequest = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("/vienna-request-gateway",convertedRequest);
            
            if(responseMessage.IsSuccessStatusCode)
                return Content(responseMessage.Content.ReadAsStringAsync().Result);

            return Content(null);
        }

        public IActionResult Result(IEnumerable<ViennaObservationDto> observationsDto)
        {
            return View();
        }
    }
}