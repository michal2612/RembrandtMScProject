using System;
using System.Collections.Generic;

namespace Rembrandt.Dataset.Core.Models
{
    public class Observation 
    {
        public int ObservationId { get; set; }

        public string SkipReason { get; protected set; }

        public DateTime TimeSubmitted { get; protected set; }

        public int SiteId { get; protected set; }

        public string PhotoAddress { get; protected set; }

        public int PhotoTowardsPointCompass { get; protected set; }

        public Attributes Attributes { get; protected set; }

        public Park Park { get; protected set; }

        public Activities Activities { get; protected set; }
        
        public Contributor Contributor { get; protected set; }
        
        protected Observation()
        {
            
        }
        public Observation(string skipReason, DateTime timeSubmitted, int siteId, string photoAddress, int photoTowardsPointCompass, Attributes attributes, Park park, Activities activities, Contributor contributor)
        {
            SkipReason = SetSkipReason(skipReason);
            TimeSubmitted = timeSubmitted;
            SiteId = siteId;
            PhotoAddress = photoAddress;
            PhotoTowardsPointCompass = photoTowardsPointCompass;
            Attributes = CheckForNullable<Attributes>(attributes);
            Park = CheckForNullable<Park>(park);
            Activities = CheckForNullable<Activities>(activities);
            Contributor = CheckForNullable<Contributor>(contributor);
        }

        private static T CheckForNullable<T>(T obj)
            => obj == null ? throw new ArgumentNullException($"Property '{typeof(T).Name}' can not be null!") : obj;

        private static string SetSkipReason(string skipReason)
            => String.IsNullOrWhiteSpace(skipReason) ? "noskip" : skipReason;
    }
}