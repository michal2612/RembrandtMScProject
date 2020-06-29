using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rembrandt.Dataset.Core.Models
{
    public class Attributes
    {
        public int Lively { get; protected set; }
        public int Relaxing { get; protected set; }
        public int Tranquil { get; protected set; }
        public int Noisy { get; protected set; }
        public int Crowded { get; protected set; }
        public int Safe { get; protected set; }
        public int Beauty { get; protected set; }
        public int Biodiversity { get; protected set; }
        public int Trees { get; protected set; }
        public int Shrubs { get; protected set; }
        public int Lawns { get; protected set; }
        public int Flowers { get; protected set; }
        public int Natveg { get; protected set; }
        public int Benches { get; protected set; }
        public int Play { get; protected set; }
        public int Sports { get; protected set; }
        public int Garbage { get; protected set; }
        public int Veget { get; protected set; }
        public int Paths { get; protected set; }
        public int Facilities { get; protected set; }
        
        protected Attributes()
        {
            
        }
        public Attributes(int lively, int relaxing, int tranquil, int noisy, int crowded, int safe, int beauty, int biodiversity, int trees, int shrubs, int lawns, int flowers, int natveg, int benches, int play, int sports, int garbage, int veget, int paths, int facilities)
        {
            Lively = lively;
            Relaxing = relaxing;
            Tranquil = tranquil;
            Noisy = noisy;
            Crowded = crowded;
            Safe = safe;
            Beauty = beauty;
            Biodiversity = biodiversity;
            Trees = trees;
            Shrubs = shrubs;
            Lawns = lawns;
            Flowers = flowers;
            Natveg = natveg;
            Benches = benches;
            Play = play;
            Sports = sports;
            Garbage = garbage;
            Veget = veget;
            Paths = paths;
            Facilities = facilities;
            CheckValues(this);
        }

        private static void CheckValues(Attributes attributes)
        {
            var exceptionProperties = new List<string>()
            {
                "Beauty",
                "Biodiversity"
            };
            PropertyInfo[] props = attributes.GetType().GetProperties();
            const int minValue = 1;
            const int maxValue = 5;
            const int minValueException = 1;
            const int maxValueException = 10;

            foreach (var prop in props)
                if(!exceptionProperties.Contains(prop.Name))
                    if((int)prop.GetValue(attributes) < minValueException || (int)prop.GetValue(attributes) > maxValueException)
                        throw new ArgumentOutOfRangeException($"Value of property '{prop.Name}' should be between {minValueException} and {maxValueException}!");
                else
                    if((int)prop.GetValue(attributes) < minValue || (int)prop.GetValue(attributes) > maxValue)
                        throw new ArgumentOutOfRangeException($"Value of property '{prop.Name}' should be between {minValue} and {maxValue}!");

        }
    }
}