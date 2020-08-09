using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.DatasetStats.Core.Models;
using Rembrandt.DatasetStats.Core.Repository;

namespace Rembrandt.DatasetStats.Infrastructure.Services
{
    public class UpdateObservations : IUpdateObservations
    {
        private readonly IStatsRepository _statsRepository;
        
        private readonly IMapper _mapper;

        public UpdateObservations(IStatsRepository statsRepository, IMapper mapper)
        {
            _statsRepository = statsRepository;
            _mapper = mapper;
        }

        public async Task UpdateObservationsAsync(IEnumerable<ObservationDto> observationDtos)
        {
            var observationsStat = new List<ObservationStat>();
            var dictionaryObservations = new Dictionary<int, List<ObservationDto>>();

            foreach(var observationDto in observationDtos)
                if(!dictionaryObservations.ContainsKey(observationDto.SiteId))
                    dictionaryObservations.Add(observationDto.SiteId, new List<ObservationDto>() {observationDto});
                else
                    dictionaryObservations[observationDto.SiteId].Add(observationDto);

            foreach(var observation in dictionaryObservations)
                observationsStat.Add(MapValue(observation.Key, observation.Value));

            await _statsRepository.UpdateDatabaseAsync(observationsStat);
        }

        public async Task UpdateSingleObservationAsync(int siteId, IEnumerable<ObservationDto> observationsDto)
        {
            var observationStat = MapValue(siteId, observationsDto);

            await _statsRepository.UpdateObservationAsync(siteId, observationStat);
        }

        ObservationStat MapValue(int sideId, IEnumerable<ObservationDto> dictionaryObservations)
        {
            var observationsStat = new ObservationStat() {SiteId = sideId};

            foreach(var observation in dictionaryObservations)
            {
                observationsStat.SkipReasons = ModifyReasons(dictionaryObservations);
                observationsStat.Attributes = ModifyAttributes(dictionaryObservations.Select(c => c.Attributes));
                observationsStat.Activities = ModifyActivities(dictionaryObservations.Select(c => c.Activities));
                observationsStat.PhotosAddresses = ModifyAdresses(dictionaryObservations.Select(c => c.PhotoAddress));
            }

            return observationsStat;
        }

        List<SkipReasons> ModifyReasons(IEnumerable<ObservationDto> observationsDto)
        {
            var resultDictionary = new List<SkipReasons>();

            foreach(var observation in observationsDto)
                if(resultDictionary.Where(c => c.Reason == observation.SkipReason).Count() == 0)
                    resultDictionary.Add(new SkipReasons()
                    {
                        Reason = observation.SkipReason,
                        ReasonCount = 1
                    });
                else
                    resultDictionary.Where(c => c.Reason == observation.SkipReason).SingleOrDefault().ReasonCount++;

            return resultDictionary;
        }

        AttributesStat ModifyAttributes(IEnumerable<AttributesDto> attributes)
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

        ActivitiesStat ModifyActivities(IEnumerable<ActivitiesDto> activities)
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

        List<PhotoAddress> ModifyAdresses(IEnumerable<string> addresses)
        {
            var addressesList = new List<PhotoAddress>();

            foreach(var address in addresses.ToList())
                addressesList.Add(new PhotoAddress() {Address = address});

            return addressesList;
        }
    }
}