using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Newtonsoft.Json;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.Contracts.Classes.Dataset.ViennaObservations;

namespace Rembrandt.Web.Services
{
    public class EventConsumer : IConsumer<ObservationDto>, IConsumer<ViennaObservationDto>
    {
        private readonly HttpClient _client;
        
        public EventConsumer()
        {
            _client = new HttpClient() {
                BaseAddress = new Uri("http://51.104.49.19:5000")
            };
        }
        public async Task Consume(ConsumeContext<ObservationDto> context)
        {
            await _client.PostAsync("/dataset-gateway/single", ReturnStringContent(context.Message));
        }


        public async Task Consume(ConsumeContext<ViennaObservationDto> context)
            => await _client.PostAsync("/vienna-dataset-gateway", ReturnStringContent(context.Message));


        StringContent ReturnStringContent(object context)
            => new StringContent(JsonConvert.SerializeObject(context), Encoding.UTF8, "application/json");

    }
}