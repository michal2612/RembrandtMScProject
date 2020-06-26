using System;
using System.Collections.Generic;

namespace Rembrandt.Dataset.Core.Models
{
    public class Observation 
    {
        public int Id { get; protected set; }
        public Guid ObservationGuid { get; protected set; }
        public string SkipReason { get; protected set; }
        public DateTime TimeSubmitted { get; protected set; }
        public int SiteId { get; protected set; }
        public string PhotoAddress { get; protected set; }
        public Attributes Attributes { get; protected set; }
        public Park Park { get; set; }
        public Activities Activities { get; protected set; }
        public Contributor Contributor { get; set; }

        protected Observation(string skipReason, DateTime timeSubmitted, int siteId, string photoAddress, Attributes attributes, Park park, Activities activities, Contributor contributor)
        {
            SkipReason = SetSkipReason(skipReason);
            TimeSubmitted = timeSubmitted;
            SiteId = siteId;
            PhotoAddress = photoAddress;
            Attributes = CheckForNullable<Attributes>(Attributes);
            Park = CheckForNullable<Park>(Park);
            Activities = CheckForNullable<Activities>(activities);
            Contributor = CheckForNullable<Contributor>(contributor);
        }

        private static T CheckForNullable<T>(T obj)
            => obj == null ? throw new ArgumentNullException($"Property '{typeof(T).Name}' can not be null!") : obj;

        private static string SetSkipReason(string skipReason)
            => String.IsNullOrWhiteSpace(skipReason) ? "noskip" : skipReason;
    }
}