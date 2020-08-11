using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Rembrandt.Contracts.Classes.Dataset.ViennaObservations;

namespace Rembrandt.Web.ViewModels
{
    public class ViennaDatasetViewModel
    {
        public ViennaObservationDto ViennaObservation { get; set; }

        public Dictionary<string, string> AttributesNames { get; set; }

        public Dictionary<string, string> SubAttributesNames {get; set; }

        public IEnumerable<SuitableArea> SuitableAreas { get; set; }

        public List<string> RequestedActivities { get; set; }

        public Dictionary<string, string> IntAttributesNames { get; set; }

        public Dictionary<string, string> BoolAttributesNames { get; set; }

        public ViennaDatasetViewModel()
        {
            AttributesNames = AddAttributesNames(new ViennaAttributesDto());
            SubAttributesNames = AddAttributesNames(new ViennaSubAttributesDto());
            RequestedActivities = new List<string>();
            IntAttributesNames = SelectAttributesOfType(new ViennaAttributesDto(), typeof(int?));
            BoolAttributesNames = SelectAttributesOfType(new ViennaAttributesDto(), typeof(bool?));
        }

        Dictionary<string, string> AddAttributesNames(object obj)
        {
            var dictionary = new Dictionary<string, string>();

            foreach(var property in obj.GetType().GetProperties())
            {
                var propertyName = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                if(propertyName != null)
                    dictionary.Add(property.Name, propertyName.GetName());
                else
                    dictionary.Add(property.Name, property.Name);
            }
            return dictionary;
        }

        Dictionary<string, string> SelectAttributesOfType(object obj, Type type)
        {
            var dictionary = new Dictionary<string, string>();

            foreach(var property in obj.GetType().GetProperties())
            {
                if(type == property.PropertyType)
                {
                    var propertyName = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                    if(propertyName != null)
                        dictionary.Add(property.Name, propertyName.GetName());
                    else
                        dictionary.Add(property.Name, property.Name);
                }
            }
            return dictionary;
        }
    }
}