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

        public ViennaDatasetViewModel()
        {
            AttributesNames = AddAttributesNames(new ViennaAttributesDto());
            SubAttributesNames = AddAttributesNames(new ViennaSubAttributesDto());
        }

        Dictionary<string, string> AddAttributesNames(object obj)
        {
            MemberInfo[] properties = obj.GetType().GetProperties();
            var dictionary = new Dictionary<string, string>();

            foreach(var property in properties)
            {
                var propertyName = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                if(propertyName != null)
                    dictionary.Add(property.Name, propertyName.GetName());
                else
                    dictionary.Add(property.Name, property.Name);
            }
            return dictionary;
        }
    }
}