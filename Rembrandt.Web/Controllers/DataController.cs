using System;
using System.Net.Http;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.Contracts.Classes.Stats;
using Rembrandt.Web.Services;
using Rembrandt.Web.ViewModels;

namespace Rembrandt.Web.Controllers
{
    [Route("[action]")]
    public class DataController : Controller
    {
        readonly HttpClient _httpClient;
        
        readonly IPublishEndpoint _publishEndpoint;


        public DataController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://51.104.49.19:5000")
            };
        }

        public async Task<IActionResult> Data()
        {
            return await Task.FromResult(View());
        }

        [Route("{siteId}")]
        public async Task<IActionResult> Location(int siteId)
        {

            var result = await _httpClient.GetAsync($"/stats-gateway/{siteId}");
            var resultObservations = await _httpClient.GetAsync($"/sites-gateway/{siteId}");

            if(!result.IsSuccessStatusCode)
                return Content("Something went wrong!");

            var locationViewModel = new LocationViewModel()
            {
                ObservationStatDto = JsonConvert.DeserializeObject<ObservationStatDto>(await result.Content.ReadAsStringAsync()),
                ObservationsDto = JsonConvert.DeserializeObject<ObservationDto[]>(await resultObservations.Content.ReadAsStringAsync())
            };
            return View(locationViewModel);
        }

        public async Task<IActionResult> Add()
        {
            return await Task.FromResult(View(new ObservationDto() {Activities = new ActivitiesDto(), Attributes = new AttributesDto()}));
        }

        [HttpPost]
        public async Task<IActionResult> Submit(ObservationDto observationDto)
        {
            //byte[] userName;
            //var cookie = Request.Cookies["jwtToken"];
            //var user = HttpContext.Session.TryGetValue(cookie, out userName);

            observationDto.Source = "http://rembrandt-project.ukwest.cloudapp.azure.com/" + "dupa";

            await _publishEndpoint.Publish<ObservationDto>(observationDto);

            return Ok();
        }
    }
}