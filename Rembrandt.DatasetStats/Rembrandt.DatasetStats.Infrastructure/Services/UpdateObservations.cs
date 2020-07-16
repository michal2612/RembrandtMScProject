using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.DatasetStats.Core.Models;
using Rembrandt.DatasetStats.Core.Repository;

namespace Rembrandt.DatasetStats.Infrastructure.Services
{
    public class UpdateObservations : IUpdateObservations
    {
        private readonly IStatsRepository _statsRepository;

        public UpdateObservations(IStatsRepository statsRepository)
        {
            _statsRepository = statsRepository;
        }

        public async Task UpdateObservationsAsync(IEnumerable<ObservationDto> observationDtos)
        {
            var observationsStat = new List<ObservationStat>();
            var dictionaryObservations = new Dictionary<int, List<ObservationDto>>();

            foreach(var observationDto in observationDtos)
            {
                if(!dictionaryObservations.ContainsKey(observationDto.SiteId))
                    dictionaryObservations.Add(observationDto.SiteId, new List<ObservationDto>() {observationDto});
                else
                    dictionaryObservations[observationDto.SiteId].Add(observationDto);
            }

            foreach(var observation in dictionaryObservations)
                observationsStat.Add(MapValue(observation.Key, observation.Value));

            await _statsRepository.UpdateDatabaseAsync(observationsStat);
        }

        private ObservationStat MapValue(int sideId, List<ObservationDto> dictionaryObservations)
        {
            var observationsStat = new ObservationStat() {SiteId = sideId};

            foreach(var observation in dictionaryObservations)
            {
                observationsStat.TimesSubmitted.Add(observation.TimeSubmitted);
                observationsStat.PhotosAddresses.Add(observation.PhotoAddress);
                observationsStat.SkipReasons = ModifyObservations(dictionaryObservations, "SkipReason");
                observationsStat.Attributes = ModifyAttributes(dictionaryObservations.Select(c => c.Attributes));
                observationsStat.Activities = ModifyActivities(dictionaryObservations.Select(c => c.Activities));
            }

            return observationsStat;
        }

        private Dictionary<string, int> ModifyObservations(IEnumerable<object> observationsDto, string propertyName)
        {
            var resultDictionary = new Dictionary<string, int>();

            foreach(var observation in observationsDto)
            {
                var keyValue = (string)observation.GetType().GetProperty(propertyName).GetValue(observation);
                if(resultDictionary.ContainsKey(keyValue))
                    resultDictionary[keyValue]++;
                else
                    resultDictionary.Add(keyValue, 1);
            }
            return resultDictionary;
        }

        private AttributesStat ModifyAttributes(IEnumerable<AttributesDto> attributes)
        {
            var propertyNames = attributes.First().GetType().GetProperties();
            var resultAttributesStat = new AttributesStat();

            foreach(var property in propertyNames)
            {
                var values = new List<int>();
                foreach(var attribute in attributes)
                {
                    var attributeValue = attribute.GetType().GetProperty(property.Name).GetValue(attribute);
                    if(attributeValue != null)
                        values.Add((int)attributeValue);
                }
                resultAttributesStat.GetType().GetProperty(property.Name).SetValue(resultAttributesStat,(float)values.Sum()/(float)values.Count());
            }   
            return resultAttributesStat;
        }

        private ActivitiesStat ModifyActivities(IEnumerable<ActivitiesDto> activities)
        {
            var propertyNames = activities.First().GetType().GetProperties();
            var resultAttributesStat = new ActivitiesStat();

            foreach(var property in propertyNames)
            {
                bool propertyValue;
                var activiteValues = activities.Select(c => c.GetType().GetProperty(property.Name).GetValue(c)).ToList();

                if(activiteValues.Where(c => (bool?)c == true).Count() >= (activiteValues.Count()/2))
                    propertyValue = true;
                else
                    propertyValue = false;
                resultAttributesStat.GetType().GetProperty(property.Name).SetValue(resultAttributesStat, propertyValue);
            }
            return resultAttributesStat;
        }
    }
}