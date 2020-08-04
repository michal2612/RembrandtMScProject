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

        public List<string> AttributesNames { get; set; } = new List<string>();

        public ViennaDatasetViewModel()
        {
            AddAttributesNames();
        }

        void AddAttributesNames()
        {
            MemberInfo[] properties = new ViennaAttributesDto().GetType().GetProperties();

            foreach(var property in properties)
            {
                try
                {
                    var propertyName = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                    if(propertyName != null)
                        AttributesNames.Add(propertyName.GetName());
                    else
                        AttributesNames.Add(property.Name);
                }
                catch(Exception)
                {
                }
            }

        }
    }
}